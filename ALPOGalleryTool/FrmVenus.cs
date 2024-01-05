using ALPOGalleryTool.DataAccess;
using ALPOGalleryTool.DataAccess.MongoDto;
using ALPOGalleryTool.DataAccess.VenusDataSetTableAdapters;
using ALPOGalleryTool.Interfaces;
using ALPOGalleryTool.Properties;
using iwantedue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALPOGalleryTool
{
    public partial class FrmVenus : Form
    {
        private readonly IDataSrvc _dataSrvc;
        private readonly string _wrkFldr;
        private List<IObserver> _observers = new List<IObserver>();
        private List<string> _tags = new List<string>();
        private List<ITelescope> _telescopes = new List<ITelescope>();
        private Dictionary<string, string> _imgFiles = new Dictionary<string, string>();
        private Dictionary<string, AttachmentPoco> _attachments = new Dictionary<string, AttachmentPoco>();
        private bool _initDone = false;
        private int cnt = 0;
        private string _rptAuthorEmail;
        private string _tmpFileName;
        private VenusDataSet.Venus_Phase_ElngDataTable _phaseElngData = new VenusDataSet.Venus_Phase_ElngDataTable();
        private VenusDataSet.Venus_CMDataTable _cmData = new VenusDataSet.Venus_CMDataTable();
        private const double CmI_Period = 564; //543.185;
        private const double CmII_Period = 16.57955; //15.808333;

        public FrmVenus(IDataSrvc dataSrvc)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _dataSrvc = dataSrvc;
            LoadUsers();
            LoadFilters();
            LoadTelescopes();
            _wrkFldr = Settings.Default.VenusStaged;
            LoadReports();
            LoadTags();
            LoadPhaseAndElng();
            LoadCmData();
        }

        private void LoadTags()
        {
            lstTags.Items.Clear();
            _tags = _dataSrvc.GetRecentTags("Venus")
                .Where(t => t.StartsWith("Elng") == false && t.StartsWith("Phase") == false).ToList();
            List<string> _persistentTags = _dataSrvc.GetPersistentTags("Venus").ToList();
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

        private void LoadFilters()
        {
            lstOtherFltr.Items.Clear();
            lstFilters.Items.Clear();
            lstFilters.Items.Add("CH4");
            lstFilters.Items.Add("IR");
            lstFilters.Items.Add("WL");
            lstFilters.Items.Add("RGB");
            lstFilters.Items.Add("R");
            lstFilters.Items.Add("UV");
            lstOtherFltr.Items.Add("IR-Block");
            lstOtherFltr.Items.Add("UV-Block");
            lstOtherFltr.Items.Add("UV-IR-Block");
            lstOtherFltr.Items.Add("Wr15");
            lstOtherFltr.Items.Add("Wr21");
            lstOtherFltr.Items.Add("Wr47");

        }

        private void LoadTelescopes()
        {
            _telescopes.Clear();
            _telescopes = _dataSrvc.GetAllTelescopes().ToList();
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
                //btnProfile.Visible = HasProfile(obsrvr.Initials);
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

        private string GenerateFileName(string attachmentFileName)
        {
            string name = Path.GetFileNameWithoutExtension(attachmentFileName);
            string ext = Path.GetExtension(attachmentFileName);
            cnt++;
            return name + "_id" + cnt.ToString("00") + ext;
        }

        private void FrmVenus_Shown(object sender, EventArgs e)
        {
            _initDone = true;
            this.WindowState = FormWindowState.Maximized;
        }

        protected void lstAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_initDone)
            {
                try
                {
                    MemoryStream ms = new MemoryStream(_attachments[lstAttachments.Text].Data);
                    imgObservation.Image = Image.FromStream(ms);
                    imgObservation.Text = lstAttachments.Text;
                    TenthsMin.Value = 0;
                    //lstCardinal.SelectedIndex = -1;
                    SetTagList();
                    lblOversized.Visible = _attachments[lstAttachments.Text].Data.LongLength > 300000;
                    lblOversized.Text = "Oversized: " + _attachments[lstAttachments.Text].Data.LongLength.ToString("N0");
                    _tmpFileName = lstAttachments.Text;
                    TrySetFilter();
                    TrySetObsrvTimestamp();
                    lblFileName.Text = String.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Loading Attachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TrySetObsrvTimestamp()
        {
            lblDateError.Visible = false;
            if (string.IsNullOrEmpty(_tmpFileName))
            {
                lblDateError.Visible = true;
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

                //Pattern: ddMMyyyy hhmm **********************************************
                if (cmbObserver.Text == @"ClyFstr")
                {
                    string tmp = _tmpFileName.ToUpper().Replace("SATURN ", "");
                    string fileDT = tmp.Substring(4, 4) + "-" +
                                    tmp.Substring(2, 2) + "-" +
                                    tmp.Substring(0, 2) + " " +
                                          tmp.Substring(9, 2) + ":" +
                                          tmp.Substring(11, 2);
                    if (DateTime.TryParse(fileDT, out DateTime dtm))
                    {
                        ObsrvDate.Value = dtm;
                        dtObsrvTime.Value = dtm;
                    }
                    return;
                }

                string tmpFileNameForDate = _tmpFileName.Replace("[", "_").Replace("]", "");
                string fileDateTime = tmpFileNameForDate.Substring(0, 10) + " " +
                                      tmpFileNameForDate.Substring(11, 2) + ":" +
                                      tmpFileNameForDate.Substring(13, 2);
                if (fileDateTime.Substring(0, 10).Contains("_"))
                {
                    fileDateTime = fileDateTime.Substring(0, 10).Replace("_", "-") + fileDateTime.Substring(10);
                }
                if (DateTime.TryParse(fileDateTime, out DateTime dt))
                {
                    ObsrvDate.Value = dt;
                    dtObsrvTime.Value = dt;
                }
                else
                {
                    lblDateError.Visible = true;
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

        private void TrySetFilter()
        {
            if (lstAttachments.Text.ToUpper().Contains("-WL-") ||
                lstAttachments.Text.ToUpper().Contains("-WL_") ||
                lstAttachments.Text.ToUpper().Contains("_WL_") ||
                                lstAttachments.Text.ToUpper().Contains("-L_") ||
                lstAttachments.Text.ToUpper().Contains("_L_") ||
                lstAttachments.Text.ToUpper().Contains("-L-"))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("WL"), true);
            }
            if (lstAttachments.Text.ToUpper().Contains("-IR-") ||
                lstAttachments.Text.ToUpper().Contains("_IR"))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("IR"), true);
            }
            if (lstAttachments.Text.ToUpper().Contains("-UV-") ||
                lstAttachments.Text.ToUpper().Contains("-UV_") ||
                lstAttachments.Text.ToUpper().Contains("_UV_"))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("UV"), true);
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

        private void btnGenerateCm_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                txtTags.Text = string.Empty;
                string result = string.Empty;
                DateTime dateTime = dtObsrvTime.Value.Date;
                if (dtObsrvTime.Value.Hour < 13)
                {
                    dateTime = dateTime.AddDays(-1);
                }
                foreach (VenusDataSet.Venus_Phase_ElngRow rw in _phaseElngData.Rows)
                {
                    if (rw.UT_Date == dateTime)
                    {
                        double phase = rw.Phase / 100;
                        string elng = rw.Elongation.Substring(2) + " (" + rw.Elongation.Substring(0, 1) + ")";
                        result = $"Phase {phase.ToString("N2")}, Elng {elng}";
                        break;
                    }
                }

                string cm_I = string.Empty;
                string cm_II = string.Empty;
                DateTime mostRecentPrimeMeridianTransit = DateTime.MinValue;
                foreach (VenusDataSet.Venus_CMRow rw in _cmData)
                {
                    if (rw.cm_transit <= dtObsrvTime.Value && rw.system == "CM I")
                    {
                        mostRecentPrimeMeridianTransit = rw.cm_transit;
                    }
                    else
                    {
                        continue;
                    }
                    if (rw.cm_transit > dtObsrvTime.Value && rw.system == "CM I")
                    {
                        break;
                    };
                }
                TimeSpan ts_cmI = dtObsrvTime.Value - mostRecentPrimeMeridianTransit;
                double cmI = (ts_cmI.TotalMinutes / CmI_Period) -1;
                cm_I = cmI.ToString("N0");
                foreach (VenusDataSet.Venus_CMRow rw in _cmData)
                {
                    if (rw.cm_transit <= dtObsrvTime.Value && rw.system == "CM II")
                    {
                        mostRecentPrimeMeridianTransit = rw.cm_transit;
                    }
                    else
                    {
                        continue;
                    }
                    if (rw.cm_transit > dtObsrvTime.Value && rw.system == "CM II")
                    {
                        break;
                    };
                }
                TimeSpan ts_cmII = dtObsrvTime.Value - mostRecentPrimeMeridianTransit;
                double cmII = (ts_cmII.TotalMinutes / CmII_Period);
                cm_II = cmII.ToString("N0");
                result = "CM I " + cm_I + ", CM II " + cm_II + ", " + result;

                if (txtTags.Text.Length == 0)
                {
                    txtTags.Text = result;
                }
                else
                {
                    txtTags.Text = txtTags.Text += "," + result;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoadPhaseAndElng()
        {
            using (Venus_Phase_ElngTableAdapter ta = new Venus_Phase_ElngTableAdapter())
            {
                ta.Fill(_phaseElngData);
            }
        }

        private void LoadCmData()
        {
            using (Venus_CMTableAdapter ta = new Venus_CMTableAdapter())
            {
                ta.Fill(_cmData);
            }
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

        private void btnGenName_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(TenthsMin.Value);
            string tenths = i > 0 ? "_" + i.ToString() : "";
            lblFileName.Text = ObsrvDate.Value.ToString("yyyy-MM-dd") + "-" +
                               dtObsrvTime.Value.ToString("HHmm") + tenths + "-" +
                               cmbObserver.Text + "-" +
                               String.Join("_", GetFilters());
        }

        private bool IsValidName()
        {
            string rgxDtTm = "^[0-9]{4}-[0-1]{1}[0-9]{1}-[0-3]{1}[0-9]{1}-[0-2]{1}[0-9]{1}[0-5]{1}[0-9]{1}";
            return Regex.IsMatch(lblFileName.Text, rgxDtTm);
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
            return Settings.Default.VenusUrl + "/" + lblFileName.Text;
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
                int recsAdded = -1;

                MongoObservation dto = new MongoObservation();
                dto.FileName = lblFileName.Text;
                dto.Filters = GetFilters();
                dto.HostGallery = "Venus";
                dto.MimeType = Path.GetExtension(lstAttachments.Text)?.ToUpper().Substring(1);
                dto.Notes = rtbNotes.Text;
                dto.ObsrvrInitials = cmbObserver.Text;
                dto.Section = "Venus";
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
                recsAdded = _dataSrvc.AddObservation(dto);
                if (recsAdded == 1)
                {
                    UpdateTagList();

                    string exportFldr = Path.GetDirectoryName(_wrkFldr);

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

        private void UpdateTagList()
        {
            string[] currentTags = txtTags.Text.Split(',');
            foreach (string tag in currentTags)
            {
                if (_tags.Contains(tag) == false &&
                    !tag.Trim().StartsWith("CM") && !tag.Trim().StartsWith("Elng") && !tag.Trim().StartsWith("Phase"))
                {
                    _tags.Add(tag);
                }
            }
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

        private void lstTags_DoubleClick(object sender, EventArgs e)
        {
            string t = txtTags.Text.Trim();
            if (t.Length == 0)
            {
                txtTags.Text = lstTags.Text;
            }
            else
            {
                txtTags.Text = t + @"," + lstTags.Text;
            }

            lstTags.SelectedIndex = -1;
        }

        private void btnTrash_Click(object sender, EventArgs e)
        {
            _initDone = false;
            string msg = Path.Combine(_wrkFldr, lstMsgs.Text);
            File.Delete(msg);
            lstMsgs.Items.Remove(lstMsgs.Text);
            _initDone = true;
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

                DirectoryInfo di = new DirectoryInfo(exportFldr);
                FileInfo[] imgs = di.GetFiles();
                foreach (FileInfo img in imgs)
                {
                    try
                    {
                        if (Path.GetExtension(img.Name) != ".csv" && Path.GetExtension(img.Name) != ".xlsx")
                        {
                            string fileNameNoExt = Path.GetFileNameWithoutExtension(img.Name);
                            string[] parts = img.Name.Split('-');
                            sb.AppendLine("Venus," + parts[4] + "," + img.Name + "," +
                                          _dataSrvc.GetObsrvUrl(fileNameNoExt));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Could not process file {img.Name} for this report. {ex.Message}");
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

        private void lblDateError_VisibleChanged(object sender, EventArgs e)
        {
            if (lblDateError.Visible)
            {
                SoundPlayer player = new SoundPlayer(ALPOGalleryTool.Properties.Resources.alert_chime);
                player.Play();
            }
        }

        private void ckOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOverride.Checked) TrySetObserver();
        }
    }

}
