using ALPOGalleryTool.DataAccess;
using ALPOGalleryTool.DataAccess.MongoDto;
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
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ALPOGalleryTool
{
    public partial class FrmSolar : Form
    {
        private readonly IDataSrvc _dataSrvc;
        private Dictionary<string, AttachmentPoco> _attachments = new Dictionary<string, AttachmentPoco>();
        private string _carrRtn = string.Empty;
        private Dictionary<string, MongoLongitude> _dictCm = new Dictionary<string, MongoLongitude>();
        private Dictionary<string, DateTime> _dictCRInfo = new Dictionary<string, DateTime>();
        private Dictionary<string, string> _dictImportFiles = new Dictionary<string, string>();
        private Dictionary<string, string> _imgFiles = new Dictionary<string, string>();
        private bool _initDone = false;
        private List<IObserver> _observers = new List<IObserver>();
        private Stack<string> _poppedTags = new Stack<string>();
        private Stack<string> _priorTags = new Stack<string>();
        private List<MongoObsrvProfile> _profiles;
        private List<MongoObservation> _recentObservations;
        private List<string> _recentFileNames = new List<string>();
        private string _rptAuthorEmail;
        private List<string> _tags = new List<string>();
        private List<ITelescope> _telescopes = new List<ITelescope>();
        private string _tmpFileName;
        private string _wrkFldr = string.Empty;
        private int cnt = 0;
        public FrmSolar(IDataSrvc dataSrvc)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _dataSrvc = dataSrvc;
            LoadUsers();
            LoadFilters();
            LoadTelescopes();
            LoadCarringtonRotations();
            _wrkFldr = Settings.Default.SolarStaged;
            LoadReports();
            LoadTags();
            GetRecentFileNames();
            GetProfiles();
        }

        protected void btnProcess_Click(object sender, EventArgs e)
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
                if (!ckExtractOnly.Checked && _recentFileNames.Contains(lblFileName.Text))
                {
                    MessageBox.Show("This file name already exists", "Duplication");
                    return;
                }
                if (!ckExtractOnly.Checked) _recentFileNames.Add(lblFileName.Text);
                int recsAdded = -1;
                if (ckExtractOnly.Checked == false)
                {
                    MongoObservation dto = new MongoObservation();
                    dto.FileName = lblFileName.Text;
                    dto.Filters = GetFilters();
                    dto.HostGallery = "Solar";
                    dto.MimeType = Path.GetExtension(lstAttachments.Text)?.ToUpper().Substring(1);
                    dto.Notes = rtbNotes.Text;
                    dto.ObsrvrInitials = cmbObserver.Text;
                    dto.Section = "Solar";
                    dto.Seeing = double.Parse(txtSeeing.Text);
                    dto.Tags = GetTags();
                    dto.Telescope = cmbTelescopes.Text;
                    dto.Transparency = double.Parse(txtTrnsp.Text);
                    dto.UtObsrvDt = DateTime.Parse(ObsrvDate.Value.ToString("yyyy-MM-dd") + " " +
                                                   dtObsrvTime.Value.ToString("HH:mm"));
                    int offset = DateTime.Now.IsDaylightSavingTime() ? -4 : -5;
                    dto.UtObsrvDt = dto.UtObsrvDt.AddHours(offset);
                    dto.Url = GetUrl();
                    dto.CarringtonRotation = Convert.ToInt32(_carrRtn.Substring(2));
                    if (dto.IsValid() == false)
                    {
                        MessageBox.Show(dto.ErrMsg, "Invalid Observation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    recsAdded = _dataSrvc.AddObservation(dto);
                }
                else
                {
                    recsAdded = 1;
                }
                if (recsAdded == 1)
                {
                    UpdateTagList();
                    while (_poppedTags.Count > 0)
                    {
                        _priorTags.Push(_poppedTags.Pop());
                    }
                    _priorTags.Push(txtTags.Text);
                    string exportFldr = Path.GetDirectoryName(_wrkFldr);

                    exportFldr = Path.Combine(exportFldr, _carrRtn);

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
                    ckExtractOnly.Checked = false;
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
                    lstCardinal.SelectedIndex = -1;
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

        protected void lstMsgs_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnGenName_Click(object sender, EventArgs e)
        {

            _carrRtn = "0000";
            List<string> lstCarrRtns = _dictCRInfo.Keys.ToList();
            lstCarrRtns.Sort();

            var futureCR = _dictCRInfo.Where(d => d.Value > ParseKeyedDateTime()).OrderBy(d => d.Value);
            _carrRtn = (Convert.ToInt32(futureCR.ToList()[0].Key) - 1).ToString();

            if (_carrRtn == "0000")
            {
                MessageBox.Show("Carrington Rotation cannot be 0000", "Carrington Rotation Lookup Failed");
                return;
            }
            _carrRtn = @"CR" + _carrRtn;

            int i = Convert.ToInt32(TenthsMin.Value);
            string tenths = i > 0 ? "_" + i.ToString() : "";
            lblFileName.Text = ObsrvDate.Value.ToString("yyyy-MM-dd") + "-" +
                               dtObsrvTime.Value.ToString("HHmm") + tenths + "-" +
                               cmbObserver.Text + "-" +
                               String.Join("_", GetFilters());
            if(cmbObserver.Text.Trim() == "")
            {
                MessageBox.Show("The observer must be selected from the drop down list.", "Error");
                return;
            }
            //{
            //    lblFileName.Text = ObsrvDate.Value.ToString("yyMMdd") + "-" +
            //                   dtObsrvTime.Value.ToString("HHmm") + tenths + "-" +
            //                   cmbObserver.Text + "-" +
            //                   String.Join("_", GetFilters());
            //}                           
            if (!ckExtractOnly.Checked && _recentFileNames.Contains(lblFileName.Text))
            {
                MessageBox.Show("This file name already exists", "Duplication");
                return;
            }
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
                DirectoryInfo[] subfolders = di.GetDirectories("CR*");
                foreach (DirectoryInfo fldr in subfolders)
                {
                    FileInfo[] imgs = fldr.GetFiles();
                    foreach (FileInfo img in imgs)
                    {
                        try
                        {
                            if (img.Extension.ToLower().Contains("lnk")) continue;
                            string fileNameNoExt = Path.GetFileNameWithoutExtension(img.Name);
                            string[] parts = img.Name.Split('-');
                            sb.AppendLine("Sun," + parts[4] + "," + img.Name + "," +
                                          _dataSrvc.GetObsrvUrl(fileNameNoExt));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Could not process file {img.Name} for this report. {ex.Message}");
                        }
                    }
                }
                File.WriteAllText(trg, sb.ToString());
                MessageBox.Show(@"Report completed");
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
            }
            try
            {
                if (cmbObserver.Text == @"PatPtvn")
                {
                    string tmPattern = @"[0-2][0-9]-[0-5][0-9]-[0-5][0-9]";
                    var match = Regex.Matches(_tmpFileName, tmPattern);
                    if (match.Count == 2)
                    {
                        string datePart = "20" + match[0].Value;
                        string timePart = match[1].Value.Replace("-", ":");
                        DateTime output = DateTime.Parse(datePart + " " + timePart);
                        ObsrvDate.Value = output;
                        dtObsrvTime.Value = output;
                        TenthsMin.Value = output.Second / 6;
                    }
                    return;
                }

                if (cmbObserver.Text == @"MntLvnt")
                {
                    string dtPattern = @"([1-3]{2})([0-9]{2})([0-9]{2})";
                    var match = Regex.Matches(_tmpFileName, dtPattern);
                    if (match.Count == 1)
                    {
                        string datePart = "20" + match[0].Value;
                        datePart = datePart.Substring(0, 4) + "-" + datePart.Substring(4, 2) + "-" + datePart.Substring(6, 2);
                        ObsrvDate.Value = DateTime.Parse(datePart).AddDays(-1);
                    }
                    return;
                }

                if (cmbObserver.Text == @"GlhGrsm")
                {
                    int ptr = _tmpFileName.IndexOf("_id") - 10;
                    string datePart = _tmpFileName.Substring(ptr, 10);
                    ObsrvDate.Value = DateTime.Parse(datePart);
                    return;
                }

                if (cmbObserver.Text == @"NiaMNl" || cmbObserver.Text == @"MrcDlcrx" ||
                    cmbObserver.Text == @"JhnWrll" || cmbObserver.Text == @"MrtLws")
                {
                    string fileDT = _tmpFileName.Substring(0, 10) + " " +
                                    _tmpFileName.Substring(11, 2) + ":" +
                                    _tmpFileName.Substring(14, 2);
                    if (DateTime.TryParse(fileDT, out DateTime dtm))
                    {
                        ObsrvDate.Value = dtm;
                        dtObsrvTime.Value = dtm;
                    }

                    if (int.TryParse(_tmpFileName.Substring(17, 2), out int secs))
                    {
                        TenthsMin.Value = secs / 6;
                    }
                    return;
                }

                //Pattern: yyyy-MM-dd hhmmss
                if (cmbObserver.Text == "JmKvTy")
                {
                    string fileDT = _tmpFileName.Substring(0, 10) + " " +
                                    _tmpFileName.Substring(11, 2) + ":" +
                                    _tmpFileName.Substring(13, 2);
                    if (DateTime.TryParse(fileDT, out DateTime dtm))
                    {
                        ObsrvDate.Value = dtm;
                        dtObsrvTime.Value = dtm;
                    }

                    if (int.TryParse(_tmpFileName.Substring(15, 2), out int secs))
                    {
                        TenthsMin.Value = secs / 6;
                    }
                    return;
                }
                if (cmbObserver.Text == @"JmKvTy")
                {
                    string tmp = _tmpFileName.Replace("[", "_").Replace("]", "");
                    string fileDT = "20" + tmp.Substring(0, 2) + "-" + tmp.Substring(2, 2) + "-" + tmp.Substring(4, 2) + " " +
                                    tmp.Substring(7, 2) + ":" +
                                    tmp.Substring(9, 2);
                    if (DateTime.TryParse(fileDT, out DateTime dtm))
                    {
                        ObsrvDate.Value = dtm;
                        dtObsrvTime.Value = dtm;
                        if (int.TryParse(_tmpFileName.Substring(11, 2), out int secs))
                        {
                            TenthsMin.Value = secs / 6;
                        }
                    }
                    return;
                }
                if (cmbObserver.Text == @"GryWlk")
                {
                    string tmp = _tmpFileName.Replace("[", "_").Replace("]", "");
                    string fileDT = tmp.Substring(0, 10) + " " +
                                    tmp.Substring(11, 2) + ":" +
                                    tmp.Substring(14, 2);
                    if (DateTime.TryParse(fileDT, out DateTime dtm))
                    {
                        ObsrvDate.Value = dtm;
                        dtObsrvTime.Value = dtm;
                    }
                    return;
                }

                if (cmbObserver.Text == @"FrnMllo")
                {
                    string tmp = _tmpFileName.Replace("_", "-");
                    string fileDT = tmp.Substring(0, 10) + " " +
                                    tmp.Substring(11, 2) + ":" +
                                    tmp.Substring(13, 2);
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
                if (DateTime.TryParse(fileDateTime, out DateTime dt))
                {
                    ObsrvDate.Value = dt;
                    dtObsrvTime.Value = dt;
                }

                if (tmpFileNameForDate.IndexOf("_", StringComparison.Ordinal) == 15)
                {
                    if (int.TryParse(tmpFileNameForDate.Substring(16, 1), out int i))
                    {
                        TenthsMin.Value = i;
                    }
                }
            }
            catch (Exception)
            {
                ObsrvDate.CalendarForeColor = Color.Red;
            }
            finally
            {
                if(ObsrvDate.Value> DateTime.Now)
                    MessageBox.Show("The observation date is in the future.  Please correct it.","Invalid Observation Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPriorTag_Click(object sender, EventArgs e)
        {
            txtTags.Text = _priorTags.Pop();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            //https://www.flaticon.com/free-icons/consumer  Consumer icons created by O.moonstd - Flaticon
            List<MongoObsrvProfile> lstProfiles = _profiles.Where(p => p.ObsrvrInitials == cmbObserver.Text).ToList();
            ModalSelectProfile dlg = new ModalSelectProfile(lstProfiles);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MongoObsrvProfile profile = dlg.Profile;
                cmbTelescopes.Text = profile.Telescope;
                if (profile.Filters.Length > 0)
                {
                    lstOtherFltr.ClearSelected();
                    lstFilters.ClearSelected();
                    for (int i = 0; i < profile.Filters.Length; i++)
                    {
                        try
                        {
                            lstFilters.SetSelected(lstFilters.FindString(profile.Filters[i]), true);
                        }
                        catch (Exception)
                        {   //ToDo: Feedback to user?
                        }                        
                    }
                    for (int i = 0; i < profile.Filters.Length; i++)
                    {
                        try
                        {
                            lstOtherFltr.SetSelected(lstOtherFltr.FindString(profile.Filters[i]), true);
                        }
                        catch (Exception)
                        {   //ToDo: Feedback to user?
                        }
                    }
                }
                if (profile.Tags.Length > 0)
                {
                    txtTags.Text = String.Join(",", profile.Tags);
                }
            }
            dlg.Dispose();
            dlg = null;
        }

        private void btnTrash_Click(object sender, EventArgs e)
        {
            _initDone = false;
            string msg = Path.Combine(_wrkFldr, lstMsgs.Text);
            File.Delete(msg);
            lstMsgs.Items.Remove(lstMsgs.Text);
            _initDone = true;
        }

        private void btnTrimFileName_Click(object sender, EventArgs e)
        {
            if (_tmpFileName != string.Empty)
            {
                _tmpFileName = _tmpFileName.Substring(1);
            }
        }

        private void chkImport_CheckedChanged(object sender, EventArgs e)
        {
            _dictImportFiles.Clear();
            DirectoryInfo di = new DirectoryInfo(txtImportFldr.Text);
            FileInfo[] files = di.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                _dictImportFiles.Add(file.Name, file.FullName);
            }
            foreach (string item in _dictImportFiles.Keys)
            {
                lstAttachments.Items.Add(item);
                byte[] data = File.ReadAllBytes(_dictImportFiles[item]);
                AttachmentPoco atchmnt = new AttachmentPoco()
                {
                    Data = data,
                    FileName = item
                };
                _attachments.Add(item, atchmnt);
            }
        }

        private void FrmSolar_Shown(object sender, EventArgs e)
        {
            _initDone = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private string GenerateFileName(string attachmentFileName)
        {
            string name = Path.GetFileNameWithoutExtension(attachmentFileName);
            string ext = Path.GetExtension(attachmentFileName);
            cnt++;
            return name + "_id" + cnt.ToString("00") + ext;
        }

        private string GetAlbumByCarrRtn(string carrRtn)
        {
            try
            {
                return "SolarImages" + _dictCRInfo[carrRtn.Substring(2)].Year.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error determining Carrington Rotation. {ex.Message}");
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

        private void GetProfiles()
        {
            _profiles = _dataSrvc.GetAllProfiles().ToList();
        }

        private void GetRecentFileNames()
        {
            var solObsrvtns = _dataSrvc.GetObsrvtnsByDateRange(DateTime.Today.AddMonths(-1), DateTime.Today.AddDays(1)).Where(o => o.Section == "Solar");
            _recentObservations = solObsrvtns.ToList();
            _recentFileNames = solObsrvtns.Select(o => o.FileName).ToList();
        }

        private string[] GetTags()
        {
            List<string> result = new List<string>();
            foreach (string tag in txtTags.Text.Split(','))
            {
                result.Add(tag.Trim());
            }
            foreach (var item in lstCardinal.SelectedItems)
            {
                result.Add("Location:" + item.ToString());
            }
            foreach (var item in lstOtherFltr.SelectedItems)
            {
                result.Add(item.ToString());
            }

            return result.ToArray();
        }

        private string GetUrl()
        {
            return Settings.Default.SolarUrl + GetAlbumByCarrRtn(_carrRtn) + "/" + _carrRtn + "/" + lblFileName.Text; ;
        }

        private bool HasProfile(string initials)
        {
            var qry = _profiles.Where(p => p.ObsrvrInitials == initials);
            return qry.Any();
        }

        private bool IsValidName()
        {
            string rgxDtTm = "^[0-9]{4}-[0-1]{1}[0-9]{1}-[0-3]{1}[0-9]{1}-[0-2]{1}[0-9]{1}[0-5]{1}[0-9]{1}";
            return Regex.IsMatch(lblFileName.Text, rgxDtTm);
        }

        private void LoadCarringtonRotations()
        {
            _dictCm.Clear();
            var crData = _dataSrvc.GetCrRtns();
            foreach (MongoCrRtn cr in crData)
            {
                _dictCRInfo.Add(cr.CarringtonRotationNum, cr.StartDateTime);
            }
        }

        private void LoadFilters()
        {
            lstOtherFltr.Items.Clear();
            lstFilters.Items.Clear();
            lstFilters.Items.Add("CaK");
            lstFilters.Items.Add("Ha");
            lstFilters.Items.Add("O-III");
            lstFilters.Items.Add("WL");
            lstOtherFltr.Items.Add("IR-Block");
            lstOtherFltr.Items.Add("UV-Block");
            lstOtherFltr.Items.Add("UV-IR-Block");
            lstFilters.Items.Add("NA");
            lstFilters.Items.Add("Other");
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

        private void LoadTags()
        {
            lstTags.Items.Clear();
            _tags = _dataSrvc.GetRecentTags("Solar").Where(t => t.StartsWith("Location:") == false).ToList(); ;
            List<string> _persistentTags = _dataSrvc.GetPersistentTags("Solar").ToList();
            List<string> allTags = _tags.Union(_persistentTags).ToList();
            allTags.Sort();
            _tags = allTags;
            lstTags.Items.AddRange(allTags.ToArray());
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

        private void lstCardinal_DoubleClick(object sender, EventArgs e)
        {
            string tmp = txtTags.Text;
            if (tmp.Length > 0) tmp = tmp + ",";
            foreach (var item in lstCardinal.SelectedItems)
            {
                tmp += item + ",";
            }
            txtTags.Text = tmp.Substring(0, tmp.Length - 1);
            lstCardinal.SelectedItems.Clear();
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

        private DateTime ParseKeyedDateTime()
        {
            string datePart = ObsrvDate.Value.ToString("yyyy-MM-dd");
            string timePart = dtObsrvTime.Value.ToString("HH:mm");
            return DateTime.Parse(datePart + " " + timePart);
        }

        private List<string> PrepTelescopeList(List<string> lst)
        {
            lst = lst.Distinct(
                StringComparer.CurrentCultureIgnoreCase).ToList();
            lst.Sort();
            lst.Insert(0, "Undetermined");
            return lst;
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

        private void TrySetFilter()
        {
            if (lstAttachments.Text.ToUpper().Contains("-WL-") ||
                lstAttachments.Text.ToUpper().Contains("-WL_") ||
                lstAttachments.Text.ToUpper().Contains("_WL_") ||
                lstAttachments.Text.ToUpper().Contains("-540NM-") ||
                lstAttachments.Text.ToUpper().Contains("WHITE LIGHT"))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("WL"), true);
            }
            if (lstAttachments.Text.ToUpper().Contains("-WLHA-") ||
                lstAttachments.Text.ToUpper().Contains("_WLHA_") ||
                lstAttachments.Text.ToUpper().Contains("_WLHA-"))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("WL"), true);
                lstFilters.SetSelected(lstFilters.FindString("Ha"), true);
            }
            if (lstAttachments.Text.ToUpper().Contains("-HA-") ||
                lstAttachments.Text.ToUpper().Contains("-HA_") ||
                lstAttachments.Text.ToUpper().Contains("_HA_") ||
                lstAttachments.Text.ToUpper().Contains(" H ALPHA ") ||
                lstAttachments.Text.ToUpper().Contains(" HALPHA ") ||
                lstAttachments.Text.ToUpper().Contains("-HALPHA_"))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("Ha"), true);
            }
            if (lstAttachments.Text.ToUpper().Contains("-CAK-") ||
                lstAttachments.Text.ToUpper().Contains("-CAK_") ||
                lstAttachments.Text.ToUpper().Contains("_CAK_") ||
                lstAttachments.Text.ToUpper().Contains(" CAK "))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("CaK"), true);
            }
            if (lstAttachments.Text.ToUpper().Contains("-WL-KLINE"))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("WL"), true);
                lstFilters.SetSelected(lstFilters.FindString("CaK"), true);
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
                btnProfile.Visible = HasProfile(obsrvr.Initials);
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

        private void TrySetObsrvTimestamp()
        {
            btnParseFileForDate_Click(this, null);
        }

        private void txtTags_DoubleClick(object sender, EventArgs e)
        {
            txtTags.Text = string.Empty;
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

        private void lblFileName_TextChanged(object sender, EventArgs e)
        {
            if (lblFileName.Text.Length > 10 &&
                DateTime.TryParse(lblFileName.Text.Substring(0, 10), out DateTime date))
            {
                btnProcess.Visible = true;
            }
            else
            {
                btnProcess.Visible = false;
            }
        }

        private void lblOversized_Click(object sender, EventArgs e)
        {
            ModalResize modal = new ModalResize();
            modal.ImageStream = new MemoryStream(_attachments[lstAttachments.Text].Data);
            modal.ShowDialog();
        }

        private void ckOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOverride.Checked)
            {
                TrySetObserver();
            }
        }
    }
}
