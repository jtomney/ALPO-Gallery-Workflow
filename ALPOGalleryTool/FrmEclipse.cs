using ALPOGalleryTool.DataAccess.MongoDto;
using ALPOGalleryTool.Interfaces;
using ALPOGalleryTool.Properties;
using ImageProcessor.Imaging.Colors;
using iwantedue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALPOGalleryTool
{
    public partial class FrmEclipse : Form
    {
        private string _wrkFldr = string.Empty;
        private Dictionary<string, string> _imgFiles = new Dictionary<string, string>();
        private Dictionary<string, AttachmentPoco> _attachments = new Dictionary<string, AttachmentPoco>();
        private bool _initDone = false;
        private string _rptAuthorEmail;
        private int _cnt;
        private string _tmpFileName;
        private List<IObserver> _observers = new List<IObserver>();
        private List<string> _tags = new List<string>();
        private List<ITelescope> _telescopes = new List<ITelescope>();
        private readonly IDataSrvc _dataSrvc;
        private Stack<string> _poppedTags = new Stack<string>();
        private Stack<string> _priorTags = new Stack<string>();
        private List<string> _recentFileNames = new List<string>();
        private string _eclipseTarget = @"Lunar-Eclipse";
        private string _eclipseType = @"Partial-Lunar-Eclipse";
        private string _eclipseDtTm = @"2023-10-18";

        public FrmEclipse(IDataSrvc dataSrvc)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _wrkFldr = Settings.Default.EclipseStaged;
            _dataSrvc = dataSrvc;
            LoadReports();
            LoadUsers();
            LoadFilters();
            LoadTelescopes();
            LoadTags();
        }

        private void LoadFilters()
        {
            lstOtherFltr.Items.Clear();
            lstFilters.Items.Clear();
            lstFilters.Items.Add("CaK");
            lstFilters.Items.Add("Ha");
            lstFilters.Items.Add("ND");
            lstFilters.Items.Add("WL");
            lstOtherFltr.Items.Add("IR-Block");
            lstOtherFltr.Items.Add("UV-Block");
            lstOtherFltr.Items.Add("UV-IR-Block");
            lstOtherFltr.Items.Add("Thousand Oaks");
            lstFilters.Items.Add("NA");
            lstFilters.Items.Add("Other");
        }

        private void LoadTags()
        {
            lstTags.Items.Clear();
            _tags = _dataSrvc.GetRecentTags("Eclipse").ToList();
            List<string> _persistentTags = _dataSrvc.GetPersistentTags("Eclipse").ToList();
            List<string> allTags = _tags.Union(_persistentTags).ToList();
            allTags.Sort();
            _tags = allTags;
            lstTags.Items.AddRange(allTags.ToArray());
        }

        private void LoadReports()
        {
            lstMsgs.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(_wrkFldr);
            FileInfo[] imgs = di.GetFiles();
            foreach (FileInfo img in imgs)
            {
                lstMsgs.Items.Add(img.Name);
                _imgFiles.Add(img.Name, img.FullName);
            }
            _attachments.Clear();
        }

        private void lstMsgs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_initDone)
            {
                cmbObserver.SelectedIndex = -1;
                cmbTelescopes.Items.Clear();
                txtTags.Text = string.Empty;
                txtSeeing.Text = "0";
                txtTrnsp.Text = "0";
                lstFilters.SelectedIndex = -1;
                lstOtherFltr.SelectedIndex = -1;
                LoadMsg();
            }
        }

        private void LoadTelescopes()
        {
            _telescopes.Clear();
            _telescopes = _dataSrvc.GetAllTelescopes().ToList();
        }

        private void LoadUsers()
        {
            cmbObserver.Items.Clear();
            _observers = _dataSrvc.GetAllObservers().OrderBy(o => o.Initials).ToList();
            if (_observers.Any())
            {
                var initials = _observers.Select(o => o.Initials);
                foreach (string initial in initials)
                {
                    cmbObserver.Items.Add(initial);
                }
            }
        }

        private void LoadMsg()
        {
            try
            {
                lstAttachments.Items.Clear();
                string msgfile = Path.Combine(_wrkFldr, lstMsgs.Text);
                Stream messageStream = File.Open(msgfile, FileMode.Open, FileAccess.Read);
                OutlookStorage.Message message = new OutlookStorage.Message(messageStream);
                messageStream.Close();
                _rptAuthorEmail = message.From;
                foreach (var attachment in message.Attachments)
                {
                    AttachmentPoco tmp = new AttachmentPoco
                    {
                        Data = attachment.Data,
                        FileName = GenerateFileName(attachment.Filename)
                    };
                    lstAttachments.Items.Add(tmp.FileName);
                    _attachments.Add(tmp.FileName, tmp);
                }
                rtbNotes.Text = message.BodyText;
                TrySetObserver();
                message.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TrySetObserver()
        {
            cmbTelescopes.Items.Clear();
            cmbTelescopes.Text = string.Empty;

            IObserver obsrvr = null;
            if (ckOverride.Checked)
            {
                obsrvr = _observers.FirstOrDefault(o => o.Initials == cmbObserver.Text);
            }
            else
            {
                obsrvr = _observers.FirstOrDefault(o => o.EmailName.ToLower() == _rptAuthorEmail.ToLower());
            }
            if (obsrvr != null)
            {
                cmbObserver.Text = obsrvr.Initials;
                lblObsrvName.Text = (obsrvr.FirstName + " " + obsrvr.LastName).Trim();
                var scopes = _telescopes.Where(s => s.Initials == obsrvr.Initials);
                if (scopes.Any())
                {
                    List<string> lst = new List<string>();
                    foreach (ITelescope scope in scopes)
                    {
                        string focalRatio = @"f/" + scope.FocalRatio;
                        string focalLength = @"FL " + scope.FocalLength;
                        string suffix = "";
                        if (scope.FocalLength > -1 || scope.FocalRatio > -1)
                        {
                            suffix = scope.FocalLength > -1 ? focalLength : focalRatio;
                            lst.Add((scope.ScopeType + @" " + scope.Aperture + @"mm " + suffix).Trim());
                        }
                        else
                        {
                            lst.Add((scope.ScopeType + @" " + scope.Aperture + @"mm " + suffix).Trim());
                        }
                    }

                    lst = PrepTelescopeList(lst);
                    cmbTelescopes.Items.Clear();
                    cmbTelescopes.Items.AddRange(lst.ToArray());
                    cmbTelescopes.SelectedIndex = -1;
                }
                else
                {
                    cmbTelescopes.Items.Clear();
                }
            }
            if (!cmbTelescopes.Items.Contains("Undetermined")) cmbTelescopes.Items.Add("Undetermined");
        }

        private List<string> PrepTelescopeList(List<string> lst)
        {
            lst = lst.Distinct(
                StringComparer.CurrentCultureIgnoreCase).ToList();
            lst.Sort();
            lst.Insert(0, "Undetermined");
            return lst;
        }

        private void TrySetObsrvTimestamp()
        {
            btnParseFileForDate_Click(this, null);
        }

        private string GenerateFileName(string attachmentFileName)
        {
            string name = Path.GetFileNameWithoutExtension(attachmentFileName);
            string ext = Path.GetExtension(attachmentFileName);
            _cnt++;
            return name + "_id" + _cnt.ToString("00") + ext;
        }

        private void FrmEclipse_Shown(object sender, EventArgs e)
        {
            _initDone= true;
        }

        private void lstAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_initDone)
            {
                try
                {
                    MemoryStream ms = new MemoryStream(_attachments[lstAttachments.Text].Data);
                    imgObservation.Image = Image.FromStream(ms);
                    imgObservation.Text = lstAttachments.Text;
                    TenthsMin.Value = 0;
                    SetTagList();
                    lblOversized.Visible = _attachments[lstAttachments.Text].Data.LongLength > 300000;
                    lblOversized.Text = "Oversized: " + _attachments[lstAttachments.Text].Data.LongLength.ToString("N0");
                    _tmpFileName = lstAttachments.Text;
                    TrySetObsrvTimestamp();
                    lblFileName.Text = String.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Loading Attachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetTagList()
        {
            _tags.Sort();
            lstTags.Items.Clear();
            foreach (string tag in _tags)
            {
                lstTags.Items.Add(tag);
            }
        }

        private void btnParseFileForDate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_tmpFileName))
            {
                ObsrvDate.CalendarForeColor = Color.Red;
                return;
            }
            else
            {
                ObsrvDate.CalendarForeColor = Color.White;
                TenthsMin.Value = 0;
                while (Int32.TryParse(_tmpFileName.Substring(0, 1), out int tmp) == false)
                {
                    _tmpFileName = _tmpFileName.Substring(1);
                }
                string tmpFileNameForDate = _tmpFileName.Replace("[", "_").Replace("]", "");
                string fileDateTime = tmpFileNameForDate.Substring(0, 10) + " " +
                                      tmpFileNameForDate.Substring(11, 2) + ":" +
                                      tmpFileNameForDate.Substring(13, 2);
                fileDateTime = fileDateTime.Replace("_", "-");
                if (DateTime.TryParse(fileDateTime, out DateTime dt))
                {
                    ObsrvDate.Value = dt;
                    dtObsrvTime.Value = dt;
                    grpObsrvtnTimestamp.BackColor = Color.Transparent;
                    grpObsrvtnTimestamp.ForeColor = Color.White;
                }
                else
                {
                    grpObsrvtnTimestamp.BackColor = Color.Yellow;
                    grpObsrvtnTimestamp.ForeColor = Color.Black;
                }

                if (tmpFileNameForDate.IndexOf("_", StringComparison.Ordinal) == 15)
                {
                    if (int.TryParse(tmpFileNameForDate.Substring(16, 1), out int i))
                    {
                        TenthsMin.Value = i;
                    }
                }
            }
        }

        private void btnGenName_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(TenthsMin.Value);
            string tenths = i > 0 ? "_" + i.ToString() : "";
            lblFileName.Text = ObsrvDate.Value.ToString("yyyy-MM-dd") + "-" +
                               dtObsrvTime.Value.ToString("HHmm") + tenths + "-" +
                               cmbObserver.Text + "-" +
                               String.Join("_", GetFilters());
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            bool accepted = false;
            if (lblFileName.Text.EndsWith("-"))
            {
                MessageBox.Show(@"File name should not end in '-'", @"Missing Filter?",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lstTags.SelectedItems.Count > 0)
            {
                MessageBox.Show(@"No tags should be highlighted - please check", @"Tags Not Added?",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IsValidName() == false)
            {
                MessageBox.Show(@"File name does not match expected DateTime stamp", @"Invalid File Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            accepted = true;

            if (cmbTelescopes.Text == "" && cmbTelescopes.Items.Count > 0)
            {
                MessageBox.Show(@"Telescope should be selected from drop down", @"Missing Telescope Metadata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            while (File.Exists(lblFileName.Text))
            {
                DialogResult response = MessageBox.Show(
                    @"This file already exists. Proceed by making a duplicate file?",
                    @"Duplicate File Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                );
                accepted = response == DialogResult.Yes;
                if (accepted)
                {
                    lblFileName.Text = @"DUP_" + lblFileName.Text;
                }
                else
                {
                    return;
                }
            }
            Cursor = Cursors.WaitCursor;
            try
            {
                if (_recentFileNames.Contains(lblFileName.Text))
                {
                    MessageBox.Show("This file name already exists", "Duplication");
                    return;
                }
                _recentFileNames.Add(lblFileName.Text);
                MongoObservation dto = new MongoObservation();
                dto.FileName = lblFileName.Text;
                dto.Filters = GetFilters();
                dto.HostGallery = "Eclipse";
                dto.MimeType = Path.GetExtension(lstAttachments.Text)?.ToUpper().Substring(1);
                dto.Notes = rtbNotes.Text;
                dto.ObsrvrInitials = cmbObserver.Text;
                dto.Section = "Eclipse";
                dto.Seeing = double.Parse(txtSeeing.Text);
                dto.Tags = GetTags();
                dto.Telescope = cmbTelescopes.Text;
                dto.Transparency = double.Parse(txtTrnsp.Text);
                dto.UtObsrvDt = DateTime.Parse(ObsrvDate.Value.ToString("yyyy-MM-dd") + " " +
                                               dtObsrvTime.Value.ToString("HH:mm"));
                int offset = DateTime.Now.IsDaylightSavingTime() ? -4 : -5;
                dto.UtObsrvDt = dto.UtObsrvDt.AddHours(offset);
                dto.Url = GetUrl();
                if (dto.IsValid() == false)
                {
                    MessageBox.Show(dto.ErrMsg, "Invalid Observation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                int recsAdded = _dataSrvc.AddObservation(dto);
                if (recsAdded == 1)
                {
                    UpdateTagList();
                    while (_poppedTags.Count > 0)
                    {
                        _priorTags.Push(_poppedTags.Pop());
                    }
                    _priorTags.Push(txtTags.Text);
                    string exportFldr = Path.GetDirectoryName(_wrkFldr);

                    exportFldr = Path.Combine(exportFldr,_eclipseDtTm);

                    if (Directory.Exists(exportFldr) == false)
                    {
                        Directory.CreateDirectory(exportFldr);
                    }

                    string trgFile = string.Empty;
                    trgFile = Path.Combine(exportFldr, lblFileName.Text + Path.GetExtension(lstAttachments.Text));

                    File.WriteAllBytes(trgFile, _attachments[lstAttachments.Text].Data);
                    _initDone = false;
                    lstAttachments.Items.Remove(lstAttachments.SelectedItem);
                    _initDone = true;
                    lblFileName.Text = "File name";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnAddTags_Click(object sender, EventArgs e)
        {
            txtTags.Text = string.Empty;
            string tmp = string.Empty;
            foreach (var item in lstTags.SelectedItems)
            {
                tmp += item + ",";
            }
            txtTags.Text = tmp.Substring(0, tmp.Length - 1);
            lstTags.SelectedItems.Clear();
        }

        private string[] GetFilters()
        {
            List<string> result = new List<string>();
            foreach (var item in lstFilters.SelectedItems)
            {
                result.Add(item.ToString());
            }

            return result.ToArray();
        }

        private string[] GetTags()
        {
            List<string> result = new List<string>();
            foreach (string tag in txtTags.Text.Split(','))
            {
                result.Add(tag.Trim());
            }
            foreach (var item in lstOtherFltr.SelectedItems)
            {
                result.Add(item.ToString());
            }

            return result.ToArray();
        }

        private string GetUrl()
        {
            return Settings.Default.EclipseUrl + _eclipseTarget + "/" + _eclipseType + "/" + _eclipseDtTm + "/" + lblFileName.Text;
        }

        private void btnApndTags_Click(object sender, EventArgs e)
        {
            string tmp = txtTags.Text + ",";
            foreach (var item in lstTags.SelectedItems)
            {
                tmp += item + ",";
            }
            txtTags.Text = tmp.Substring(0, tmp.Length - 1);
            lstTags.SelectedItems.Clear();
        }

        private void UpdateTagList()
        {
            string[] currentTags = txtTags.Text.Split(',');
            foreach (string tag in currentTags)
            {
                if (_tags.Contains(tag) == false && !tag.Trim().StartsWith("CM"))
                {
                    _tags.Add(tag);
                }
            }
        }

        private bool IsValidName()
        {
            string rgxDtTm = "^[0-9]{4}-[0-1]{1}[0-9]{1}-[0-3]{1}[0-9]{1}-[0-2]{1}[0-9]{1}[0-5]{1}[0-9]{1}";
            return Regex.IsMatch(lblFileName.Text, rgxDtTm);
        }

        private void btnGenSectRpt_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string exportFldr = Path.GetDirectoryName(_wrkFldr);
                string trg = Path.Combine(exportFldr, "UploadReport.csv");
                if (File.Exists(trg))
                {
                    File.Delete(trg);
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(@"Object,Obsrvr Init,File Added to Gallery, Link");
                if (_wrkFldr.Contains(@"Eclipse"))
                {
                    DirectoryInfo di = new DirectoryInfo(exportFldr);
                    DirectoryInfo[] subfolders = di.GetDirectories("2023-10-28");
                    foreach (DirectoryInfo fldr in subfolders)
                    {
                        FileInfo[] imgs = fldr.GetFiles();
                        foreach (FileInfo img in imgs)
                        {
                            if (img.Extension.ToLower().Contains("lnk")) continue;
                            string fileNameNoExt = Path.GetFileNameWithoutExtension(img.Name);
                            string[] parts = img.Name.Split('-');
                            sb.AppendLine("Eclipse," + parts[4] + "," + img.Name + "," +
                                          _dataSrvc.GetObsrvUrl(fileNameNoExt));
                        }
                    }
                }
                else
                {
                    DirectoryInfo di = new DirectoryInfo(exportFldr);
                    FileInfo[] imgs = di.GetFiles();
                    foreach (FileInfo img in imgs)
                    {
                        if (Path.GetExtension(img.Name) != ".csv" && Path.GetExtension(img.Name) != ".xlsx")
                        {
                            string fileNameNoExt = Path.GetFileNameWithoutExtension(img.Name);
                            string[] parts = img.Name.Split('-');
                            sb.AppendLine("Eclipse" + "," + parts[4] + "," + img.Name + "," +
                                          _dataSrvc.GetObsrvUrl(fileNameNoExt));
                        }
                    }
                }

                File.WriteAllText(trg, sb.ToString());
                MessageBox.Show(@"Report completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.Message));
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnTrash_Click(object sender, EventArgs e)
        {
            _initDone = false;
            string msg = Path.Combine(_wrkFldr, lstMsgs.Text);
            File.Delete(msg);
            lstMsgs.Items.Remove(lstMsgs.Text);
            _initDone = true;
        }

        private void ckOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOverride.Checked)
            {
                TrySetObserver();
            }
        }

        private void btnDeleteImg_Click(object sender, EventArgs e)
        {
            string tmp = lstAttachments.Text;
            lstAttachments.SelectedIndex = lstAttachments.SelectedIndex > 0 ? lstAttachments.SelectedIndex - 1 : 0;
            for (int i = 0; i < lstAttachments.Items.Count; i++)
            {
                if (tmp == lstAttachments.Items[i].ToString())
                {
                    try
                    {
                        lstAttachments.Items.RemoveAt(i);
                        break;
                    }
                    catch (Exception)
                    { }
                }
            }
        }
    }
}
