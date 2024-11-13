using ALPOGalleryTool.DataAccess.MongoDto;
using ALPOGalleryTool.Interfaces;
using ALPOGalleryTool.Properties;
using iwantedue;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ALPOGalleryTool
{
    public partial class FrmEclipse : Form
    {
        private string _wrkFldr = string.Empty;
        private string _outputFldr;
        private Dictionary<string, string> _imgFiles = new Dictionary<string, string>();
        private Dictionary<string, AttachmentPoco> _attachments = new Dictionary<string, AttachmentPoco>();
        private bool _initDone = false;
        private string _rptAuthorEmail;
        private int _cnt;
        private string _tmpFileName;
        private List<IObserver> _observers = new List<IObserver>();
        private List<string> _tags = new List<string>();
        private List<ITelescope> _telescopes = new List<ITelescope>();
        private readonly IEclipseDataSrvc _eclipseDataSrvc;
        private readonly IDataSrvc _dataSrvc;
        private Stack<string> _poppedTags = new Stack<string>();
        private Stack<string> _priorTags = new Stack<string>();
        private List<string> _recentFileNames = new List<string>();
        private string _eclipseTarget = @"Solar-Eclipse";
        private string _eclipseType = @"Total-Solar-Eclipse";
        private string _eclipseDtTm = @"2024-04-08";
        private Dictionary<string, string> _dictEclipseRoster = new Dictionary<string, string>();
        private bool _isPdfRpt;
        private bool _usingAdHocFile;
        private string _adHocFile;

        public FrmEclipse(IEclipseDataSrvc eclipseDataSrvc, IDataSrvc dataSrvc)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _wrkFldr = Settings.Default.EclipseStaged;
            _outputFldr = "";
            _eclipseDataSrvc = eclipseDataSrvc;
            _dataSrvc = dataSrvc;
            LoadReports();
            LoadUsers();
            LoadFilters();
            LoadTelescopes();
            LoadTags();
            LoadEclipseRoster();
            lblTimestampErr.Text = string.Empty;
        }

        private void LoadEclipseRoster()
        {
            _dictEclipseRoster.Clear();
            cmbEclipse.Items.Clear();
            _dictEclipseRoster.Add("2023-10-14 (ASE)", "Solar-Eclipse/Annular-Solar-Eclipse/2023-10-14");
            _dictEclipseRoster.Add("2023-10-28 (PLE)", "Lunar-Eclipse/Partial-Lunar-Eclipse/2023-10-28-Partial-Lunar-Eclipse");
            _dictEclipseRoster.Add("2024-03-25 (PLE)", "Lunar-Eclipse/Partial-Lunar-Eclipse/2024-03-25-Partial-Lunar-Eclipse");
            _dictEclipseRoster.Add("2024-04-08 (TSE)", "Solar-Eclipse/Total-Solar-Eclipse/2024-04-08");
            _dictEclipseRoster.Add("2024-09-18 (PLE)", "Lunar-Eclipse/Partial-Lunar-Eclipse/2024-09-18-Partial-Lunar-Eclipse");

            foreach (string item in _dictEclipseRoster.Keys)
            {
                cmbEclipse.Items.Add(item);
            }
        }

        private void LoadFilters()
        {
            lstOtherFltr.Items.Clear();
            lstFilters.Items.Clear();
            lstFilters.Items.Add("ND");
            lstFilters.Items.Add("WL");
            lstFilters.Items.Add("Mylar");
            lstFilters.Items.Add("Glass");
            lstFilters.Items.Add("CaK");
            lstFilters.Items.Add("Ha");
            lstFilters.Items.Add("NA");
            lstOtherFltr.Items.Add("Baader");
            lstOtherFltr.Items.Add("Orion");
            lstOtherFltr.Items.Add("Seymour");
            lstOtherFltr.Items.Add("Thousand Oaks");
            lstOtherFltr.Items.Add("IR-Block");
            lstOtherFltr.Items.Add("UV-Block");
            lstOtherFltr.Items.Add("UV-IR-Block");
            lstOtherFltr.Items.Add("Other");
        }

        private void LoadTags()
        {
            lstTags.Items.Clear();
            string eclipseType = DetermineEclispeType();
            _tags = _dataSrvc.GetRecentTags("Eclipse", 60).ToList();
            List<string> _persistentTags = _eclipseDataSrvc.GetPersistentTags(eclipseType).ToList();
            List<string> allTags = _tags.Union(_persistentTags).ToList();
            allTags.Sort();
            _tags = allTags;
            lstTags.Items.AddRange(allTags.ToArray());
        }

        private string DetermineEclispeType()
        {
            string result = "Solar";
            if (cmbEclipse.Text.Contains("(PLE)") || cmbEclipse.Text.Contains("(TLE)"))
            {
                result = "Lunar";
            }
            return result;
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
                ResetFields();
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
            _initDone = true;
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
                    //TenthsMin.Value = 0;
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
            DateTime result = DateTime.MinValue;
            lblTimestampErr.Text = string.Empty;
            lblTimestampErr.Visible = false;
            if (string.IsNullOrEmpty(_tmpFileName))
            {
                ObsrvDate.CalendarForeColor = Color.Red;
                return;
            }
            else
            {
                ObsrvDate.CalendarForeColor = Color.White;
                //TenthsMin.Value = 0;
                while (Int32.TryParse(_tmpFileName.Substring(0, 1), out int tmp) == false)
                {
                    _tmpFileName = _tmpFileName.Substring(1);
                }
                string tmpFileNameForDate = _tmpFileName;
                string fileDateTime = tmpFileNameForDate.Substring(0, 10) + " " +
                                      tmpFileNameForDate.Substring(11, 2) + ":" +
                                      tmpFileNameForDate.Substring(13, 2) + ":" +
                                      tmpFileNameForDate.Substring(15, 2);
                if (DateTime.TryParse(fileDateTime, out DateTime dt))
                {
                    ObsrvDate.Value = dt;
                    dtObsrvTime.Value = dt;
                    grpObsrvtnTimestamp.BackColor = Color.Transparent;
                    grpObsrvtnTimestamp.ForeColor = Color.White;
                    result = dt;
                }
                else
                {
                    fileDateTime = tmpFileNameForDate.Substring(0, 10) + " " +
                                                          tmpFileNameForDate.Substring(11, 2) + ":" +
                                                          tmpFileNameForDate.Substring(13, 2);
                    string tenths = tmpFileNameForDate.Substring(16, 1);
                    if (int.TryParse(tenths, out int secsToAdd))
                    {
                        secsToAdd *= 6;

                        if (DateTime.TryParse(fileDateTime, out DateTime dtWithTenths))
                        {
                            dtWithTenths = dtWithTenths.AddSeconds(secsToAdd);
                            ObsrvDate.Value = dtWithTenths;
                            dtObsrvTime.Value = dtWithTenths;
                            grpObsrvtnTimestamp.BackColor = Color.Transparent;
                            grpObsrvtnTimestamp.ForeColor = Color.White;
                            result = dtWithTenths;
                        }
                    }
                    else
                    {
                        if (DateTime.TryParse(fileDateTime, out DateTime dtNoTenths))
                        {
                            ObsrvDate.Value = dtNoTenths;
                            dtObsrvTime.Value = dtNoTenths;
                            grpObsrvtnTimestamp.BackColor = Color.Transparent;
                            grpObsrvtnTimestamp.ForeColor = Color.White;
                            result = dtNoTenths;
                        }
                    }
                }
            }
            if (result == DateTime.MinValue)
            {
                lblTimestampErr.Visible = true;
                lblTimestampErr.Text = "Unable to parse Time";
                ObsrvDate.Value = DateTime.Parse("2024-04-08");
            }
        }

        private void btnGenName_Click(object sender, EventArgs e)
        {
            lblFileName.Text = ObsrvDate.Value.ToString("yyyy-MM-dd") + "-" +
                               dtObsrvTime.Value.ToString("HHmmss") + "-" +
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

            if ((cmbTelescopes.Text == "" && cmbTelescopes.Items.Count > 0) && (txtCamera.Text.Trim() == ""))
            {
                MessageBox.Show(@"Telescope or camera needed", @"Missing Telescope Metadata",
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
                MongoEclipseDto dto = new MongoEclipseDto();
                dto.Camera = txtCamera.Text;
                dto.EclipseType = GetEclipseType();
                dto.Exposure = txtExposure.Text;
                dto.FileName = lblFileName.Text;
                dto.Filters = GetFilters();
                dto.FocalLength = double.Parse(txtFocalLen.Text);
                dto.HostGallery = "Eclipse";
                dto.ISO = txtIso.Text;
                if (double.TryParse(txtLat.Text, out double lat))
                {
                    dto.Latitude = lat;
                }
                dto.Location = txtLocation.Text;
                if (double.TryParse(txtLong.Text, out double lng))
                {
                    dto.Longitude = lng;
                }
                if (double.TryParse(txtMagnitude.Text, out double mag))
                {
                    dto.Magnitude = mag;
                }
                try
                {
                    dto.MimeType = Path.GetExtension(lstAttachments.Text)?.ToUpper().Substring(1);
                }
                catch (Exception)
                {
                    dto.MimeType = Path.GetExtension(_adHocFile)?.ToUpper().Substring(1);
                }                
                dto.Notes = rtbNotes.Text;
                if (double.TryParse(txtObscured.Text, out double obscured))
                {
                    dto.Obscured = obscured;
                }
                dto.ObsrvrInitials = cmbObserver.Text;
                dto.Section = "Eclipse";
                if (double.TryParse(txtSeeing.Text, out double seeing))
                {
                    if (seeing > 0)
                    {
                        dto.Seeing = seeing;
                    }
                }
                dto.Stage = cmbStage.Text;
                dto.Tags = GetTags();
                dto.Telescope = cmbTelescopes.Text;
                if (double.TryParse(txtTrnsp.Text, out double trnsp))
                {
                    if (trnsp > 0)
                    {
                        dto.Transparency = trnsp;
                    }
                }
                dto.UtObsrvDt = DateTime.Parse(ObsrvDate.Value.ToString("yyyy-MM-dd") + " " +
                                               dtObsrvTime.Value.ToString("HH:mm:ss"));
                int offset = DateTime.Now.IsDaylightSavingTime() ? -4 : -5;
                dto.UtObsrvDt = dto.UtObsrvDt.AddHours(offset);
                dto.Url = GetUrl(dto.FileName);
                if (dto.IsValid() == false)
                {
                    MessageBox.Show(dto.ErrMsg, "Invalid Observation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                int recsAdded = _eclipseDataSrvc.AddObservation(dto);
                if (recsAdded == 1)
                {
                    _recentFileNames.Add(lblFileName.Text);
                    UpdateTagList();
                    while (_poppedTags.Count > 0)
                    {
                        _priorTags.Push(_poppedTags.Pop());
                    }
                    _priorTags.Push(txtTags.Text);
                    //string exportFldr = Path.GetDirectoryName(_outputFldr);

                    //string exportFldr = Path.Combine(_outputFldr, _eclipseDtTm);

                    if (Directory.Exists(_outputFldr) == false)
                    {
                        Directory.CreateDirectory(_outputFldr);
                    }

                    string subfldr = chkAlbumMisc.Checked ? "Miscellaneous" : "";
                    subfldr = chkRpts.Checked ? "Reports" : subfldr;
                    if (subfldr.Length > 0)
                    {
                        subfldr = subfldr + @"\";
                    }

                    string trgFile = string.Empty;
                    trgFile = Path.Combine(_outputFldr, subfldr, lblFileName.Text + Path.GetExtension(lstAttachments.Text));
                    if (_usingAdHocFile)
                    {
                        if (_isPdfRpt)
                        {
                            File.Move(_adHocFile, trgFile + ".pdf");
                        }
                        else
                        {
                            imgObservation.Image = null;
                            File.Move(_adHocFile, trgFile + Path.GetExtension(_adHocFile));
                        }
                    }
                    else
                    {
                        File.WriteAllBytes(trgFile, _attachments[lstAttachments.Text].Data);
                    }

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

        /// <summary>
        /// Get the last 5 characters of the eclipse type
        /// </summary>
        /// <returns>eclispe type</returns>
        private string GetEclipseType()
        {
            string code = cmbEclipse.Text.Substring(cmbEclipse.Text.Length - 5).Replace("(", "").Replace(")", "");
            switch (code)
            {
                case "PLE":
                    return "Partial Lunar Eclipse";
                case "PSE":
                    return "Partial Solar Eclipse";
                case "TLE":
                    return "Total Lunar Eclipse";
                case "TSE":
                    return "Total Solar Eclipse";
                default:
                    return "Undefined";
            }
        }

        private void ResetFields()
        {
            txtCamera.Text = string.Empty;
            txtExposure.Text = string.Empty;
            txtFocalLen.Text = string.Empty;
            txtIso.Text = string.Empty;
            txtLat.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtLong.Text = string.Empty;
            txtMagnitude.Text = string.Empty;
            txtObscured.Text = string.Empty;
            _usingAdHocFile = false;
            _adHocFile = string.Empty;
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

        private string GetUrl(string fileName)
        {
            string subfldr = chkAlbumMisc.Checked ? "Miscellaneous" : "";
            subfldr = chkRpts.Checked ? "Reports" : subfldr;
            if (subfldr.Length > 0)
            {
                subfldr = subfldr + "/";
            }
            return Settings.Default.EclipseUrl + _dictEclipseRoster[cmbEclipse.Text] + "/" + subfldr + fileName;
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
                // string exportFldr = Path.GetDirectoryName(_wrkFldr);
                string exportFldr = @"C:\Users\Jim\OneDrive\Documents\Astronomy\ALPO Online Content\Eclipse";
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
                    DirectoryInfo[] subfolders = di.GetDirectories("2024-04-08");
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
                        DirectoryInfo[] miscfolders = fldr.GetDirectories();
                        foreach (DirectoryInfo misc in miscfolders)
                        {
                            FileInfo[] miscimgs = misc.GetFiles();
                            foreach (FileInfo img in miscimgs)
                            {
                                if (img.Extension.ToLower().Contains("lnk")) continue;
                                string fileNameNoExt = Path.GetFileNameWithoutExtension(img.Name);
                                string[] parts = img.Name.Split('-');
                                sb.AppendLine("Eclipse," + parts[4] + "," + img.Name + "," +
                                                                                 _dataSrvc.GetObsrvUrl(fileNameNoExt));
                            }
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

        private void cmbEclipse_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(_wrkFldr);
            string tmp = di.Parent.FullName;
            string eclipseDate = cmbEclipse.Text.Substring(0, 10);
            _outputFldr = Path.Combine(tmp, eclipseDate);
            ObsrvDate.Value = DateTime.Parse(eclipseDate);
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if(dlgOpnFile.ShowDialog() == DialogResult.OK)
            {
                _usingAdHocFile = true;
                string tmpAdHocFile = Path.Combine(Path.GetTempPath(), Path.GetFileName(dlgOpnFile.FileName));
                File.Copy(dlgOpnFile.FileName, tmpAdHocFile, true);
                _adHocFile = dlgOpnFile.FileName;
                if (Path.GetExtension(dlgOpnFile.FileName).ToUpper() != ".PDF")
                {
                    _isPdfRpt = false;
                    imgObservation.Image = Image.FromFile(tmpAdHocFile);
                }
                else
                {
                    _isPdfRpt = true;
                    imgObservation.Image = Properties.Resources.PDF;
                }
            }
            _tmpFileName = Path.GetFileName(dlgOpnFile.FileName);
            TrySetObsrvTimestamp();
        }
    }
}
