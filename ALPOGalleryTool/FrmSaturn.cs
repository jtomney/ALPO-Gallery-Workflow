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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALPOGalleryTool
{
    public partial class FrmSaturn : Form
    {
        private readonly IDataSrvc _dataSrvc;
        private Dictionary<string, AttachmentPoco> _attachments = new Dictionary<string, AttachmentPoco>();
        private Dictionary<string, MongoLongitude> _dictCm = new Dictionary<string, MongoLongitude>();
        private Dictionary<string, DateTime> _dictCRInfo = new Dictionary<string, DateTime>();
        private Dictionary<string, string> _imgFiles = new Dictionary<string, string>();
        private bool _initDone = true;
        private List<IObserver> _observers = new List<IObserver>();
        private string _rptAuthorEmail;
        private List<string> _tags = new List<string>();
        private List<ITelescope> _telescopes = new List<ITelescope>();
        private string _tmpFileName;
        private string _wrkFldr = string.Empty;
        private int cnt = 0;
        private bool _parsedDate = false;

        public FrmSaturn(IDataSrvc dataSrvc)
        {
            InitializeComponent();
            _dataSrvc = dataSrvc;
            InitForm();
            LoadUsers();
            LoadFilters();
            LoadTelescopes();
            LoadSecondaryFilters();
            LoadMsgs();
        }

        protected void btnParseFileForDate_Click(object sender, EventArgs e)
        {
            _parsedDate = false;
            while (int.TryParse(_tmpFileName.Substring(0, 1), out int i) == false)
            {
                _tmpFileName = _tmpFileName.Substring(1);
            }
            if (string.IsNullOrEmpty(_tmpFileName))
            {
                return;
            }
            else
            {
                TenthsMin.Value = 0;
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
                    _parsedDate = true;
                }
                return;
            }

            //Pattern yyyy-MM-dd_HH-mm
            if (cmbObserver.Text == @"NiaMNl" || cmbObserver.Text == @"MrcDlcrx" ||
                cmbObserver.Text == @"JhnWrll" || cmbObserver.Text == @"MrtLws" || cmbObserver.Text == "ChrPlr")
            {
                string fileDT = _tmpFileName.Substring(0, 10) + " " +
                                _tmpFileName.Substring(11, 2) + ":" +
                                _tmpFileName.Substring(14, 2);
                if (DateTime.TryParse(fileDT, out DateTime dtm))
                {
                    ObsrvDate.Value = dtm;
                    dtObsrvTime.Value = dtm;
                    _parsedDate = true;
                }

                if (int.TryParse(_tmpFileName.Substring(17, 2), out int secs))
                {
                    TenthsMin.Value = secs / 6;
                }
                return;
            }

            //Pattern yyyyMMdd_HHmm
            if (cmbObserver.Text == @"FboVrza")
            {
                string fileDT = _tmpFileName.Substring(0, 4) + "-" +
                                _tmpFileName.Substring(4, 2) + "-" +
                                _tmpFileName.Substring(6, 2) + " " +
                                _tmpFileName.Substring(9, 2) + ":" +
                                _tmpFileName.Substring(11, 2);
                if (DateTime.TryParse(fileDT, out DateTime dtm))
                {
                    ObsrvDate.Value = dtm;
                    dtObsrvTime.Value = dtm;
                    _parsedDate = true;
                }

                if (int.TryParse(_tmpFileName.Substring(17, 2), out int secs))
                {
                    TenthsMin.Value = secs / 6;
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
                    _parsedDate = true;
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
                    _parsedDate = true;
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
                _parsedDate = true;
            }

            if (tmpFileNameForDate.IndexOf("_", StringComparison.Ordinal) == 15)
            {
                if (int.TryParse(tmpFileNameForDate.Substring(16, 1), out int i))
                {
                    TenthsMin.Value = i;
                }
            }
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
                MongoObservation dto = new MongoObservation();
                dto.FileName = lblFileName.Text;
                dto.Filters = GetFilters();
                dto.HostGallery = "Saturn";
                dto.MimeType = Path.GetExtension(lstAttachments.Text)?.ToUpper().Substring(1);
                dto.Notes = rtbNotes.Text;
                dto.ObsrvrInitials = cmbObserver.Text;
                dto.Section = "Saturn";
                dto.Seeing = double.Parse(txtSeeing.Text);
                dto.Tags = GetTags();
                dto.Telescope = cmbTelescopes.Text;
                dto.Transparency = double.Parse(txtTrnsp.Text);
                dto.UtObsrvDt = DateTime.Parse(ObsrvDate.Value.ToString("yyyy-MM-dd") + " " +
                                               dtObsrvTime.Value.ToString("HH:mm"));
                dto.Url = GetUrl(dto.UtObsrvDt);
                int offset = DateTime.Now.IsDaylightSavingTime() ? -4 : -5;
                dto.UtObsrvDt = dto.UtObsrvDt.AddHours(offset);
                if (dto.IsValid() == false)
                {
                    MessageBox.Show(dto.ErrMsg, "Invalid Observation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                int recsAdded = _dataSrvc.AddObservation(dto);
                if (recsAdded == 1)
                {
                    UpdateTagList();
                    string exportFldr = Path.GetDirectoryName(_wrkFldr);
                    if (Directory.Exists(exportFldr) == false)
                    {
                        Directory.CreateDirectory(exportFldr);
                    }

                    string trgFile = Path.Combine(exportFldr,
                        lblFileName.Text + Path.GetExtension(lstAttachments.Text));
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

        protected void btnTrash_Click(object sender, EventArgs e)
        {
            _initDone = false;
            string msg = Path.Combine(_wrkFldr, lstMsgs.Text);
            File.Delete(msg);
            lstMsgs.Items.Remove(lstMsgs.Text);
            _initDone = true;
        }

        protected void btnTrimFileName_Click(object sender, EventArgs e)
        {
            if (_tmpFileName != string.Empty)
            {
                _tmpFileName = _tmpFileName.Substring(1);
            }
        }

        private void btnGenerateCm_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CalculateCm();
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

        private void btnGenName_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(TenthsMin.Value);
            string tenths = i > 0 ? "_" + i.ToString() : "";
            lblFileName.Text = ObsrvDate.Value.ToString("yyyy-MM-dd") + "-" +
                               dtObsrvTime.Value.ToString("HHmm") + tenths + "-" +
                               cmbObserver.Text + "-" +
                               String.Join("_", GetFilters());
        }

        private void CalculateCm()
        {
            StringBuilder sb = new StringBuilder();
            string dt = ObsrvDate.Value.ToString("d") + " " + dtObsrvTime.Value.ToString("t");
            DateTime obsDt = DateTime.Parse(dt);
            SaturnCentralMeridian cmCalc = new SaturnCentralMeridian(_dataSrvc);
            sb.Append("CM I ");
            sb.Append(cmCalc.GetSaturnCMbyObsrvDt(obsDt, "CMI"));
            sb.Append(", CM II ");
            sb.Append(cmCalc.GetSaturnCMbyObsrvDt(obsDt, "CMII"));
            sb.Append(", CM III ");
            sb.Append(cmCalc.GetSaturnCMbyObsrvDt(obsDt, "CMIII"));
            txtTags.Text = sb.ToString();
        }

        private string GenerateFileName(string attachmentFileName)
        {
            string name = Path.GetFileNameWithoutExtension(attachmentFileName);
            string ext = Path.GetExtension(attachmentFileName);
            cnt++;
            return name + "_" + cnt.ToString("00") + ext;
        }

        private void TrySetFilter()
        {
            if (lstAttachments.Text.ToUpper().Contains("-IR-") ||
                lstAttachments.Text.ToUpper().Contains("-IR_") ||
                lstAttachments.Text.ToUpper().Contains(" IR ") ||
                lstAttachments.Text.ToUpper().Contains("_IR_"))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("IR"), true);
            }
            if (lstAttachments.Text.ToUpper().Contains("-RGB-") ||
                lstAttachments.Text.ToUpper().Contains("_RGB_") ||
                lstAttachments.Text.ToUpper().Contains(" RGB ") ||
                lstAttachments.Text.ToUpper().Contains("_RGB-"))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("RGB"), true);
            }
            if (lstAttachments.Text.ToUpper().Contains("-WL-") ||
                lstAttachments.Text.ToUpper().Contains("-WL_") ||
                lstAttachments.Text.ToUpper().Contains(" WL ") ||
                lstAttachments.Text.ToUpper().Contains("_WL_") ||
                    lstAttachments.Text.ToUpper().Contains("-L-"))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("WL"), true);
            }
            if (lstAttachments.Text.ToUpper().Contains("-R-") ||
                lstAttachments.Text.ToUpper().Contains("-R_") ||
                lstAttachments.Text.ToUpper().Contains("_R_") ||
                lstAttachments.Text.ToUpper().Contains(" R "))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("R"), true);
            }
            if (lstAttachments.Text.ToUpper().Contains("-CH-"))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("CH4"), true);
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

        private string GetUrl(DateTime obsrvDt)
        {
            string result = Settings.Default.SaturnUrl + lblFileName.Text;
            result = result.Replace("YYYY", "2023-2024");
            return result;
        }

        private bool IsValidName()
        {
            string rgxDtTm = "^[0-9]{4}-[0-1]{1}[0-9]{1}-[0-3]{1}[0-9]{1}-[0-2]{1}[0-9]{1}[0-5]{1}[0-9]{1}";
            return Regex.IsMatch(lblFileName.Text, rgxDtTm);
        }

        private void LoadFilters()
        {
            lstFilters.Items.Add("B");
            lstFilters.Items.Add("CH4");
            lstFilters.Items.Add("G");
            lstFilters.Items.Add("IR");
            lstFilters.Items.Add("R");
            lstFilters.Items.Add("RGB");
            lstFilters.Items.Add("WL");
            lstFilters.Items.Add("UV");
            lstFilters.Items.Add("V");
            lstFilters.Items.Add("NA");
        }

        private void InitForm()
        {
            if (_initDone)
            {
                _wrkFldr = Settings.Default.SaturnStaged;
                LoadReports();
                LoadTags();
            }
        }

        private void LoadTags()
        {
            lstTags.Items.Clear();
            _tags = _dataSrvc.GetRecentTags("Saturn").ToList();
            List<string> _persistentTags = _dataSrvc.GetPersistentTags("Saturn").ToList();
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

        private void LoadMsgs()
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

        private void LoadSecondaryFilters()
        {
            lstOtherFltr.Items.Add("IR Block");
            lstOtherFltr.Items.Add("UV Block");
            lstOtherFltr.Items.Add("UV-IR Block");
            lstOtherFltr.Items.Add("Wr8");
            lstOtherFltr.Items.Add("Wr15");
            lstOtherFltr.Items.Add("Wr23A");
            lstOtherFltr.Items.Add("Wr58");
            lstOtherFltr.Items.Add("Wr80A");
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

        private List<string> PrepTelescopeList(List<string> lst)
        {
            lst = lst.Distinct(
                StringComparer.CurrentCultureIgnoreCase).ToList();
            lst.Sort();
            return lst;
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

            //if (obsrvr != null)
            //{
            //    cmbObserver.Text = obsrvr.Initials;
            //    var scopes = _telescopes.Where(s => s.Initials == obsrvr.Initials);
            //    if (scopes.Any())
            //    {
            //        List<string> lst = new List<string>();
            //        foreach (ITelescope scope in scopes)
            //        {
            //            string focalRatio = @"f/" + scope.FocalRatio;
            //            string focalLength = @"FL " + scope.FocalLength;
            //            string suffix = "";
            //            if (scope.FocalLength > -1 || scope.FocalRatio > -1)
            //            {
            //                suffix = scope.FocalLength > -1 ? focalLength : focalRatio;
            //                lst.Add((scope.ScopeType + @" " + scope.Aperture + @"mm " + suffix).Trim());
            //            }
            //            else
            //            {
            //                lst.Add((scope.ScopeType + @" " + scope.Aperture + @"mm " + suffix).Trim());
            //            }
            //        }

            //        lst = PrepTelescopeList(lst);
            //        cmbTelescopes.Items.Clear();
            //        cmbTelescopes.Items.AddRange(lst.ToArray());
            //        cmbTelescopes.SelectedIndex = -1;
            //    }
            //    else
            //    {
            //        cmbTelescopes.Items.Clear();
            //    }
            //}
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
                LoadMsgs();
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
                    SetTagList();
                    lblOversized.Visible = _attachments[lstAttachments.Text].Data.LongLength > 300000;
                    _tmpFileName = lstAttachments.Text;
                    btnParseFileForDate_Click(this, null);
                    if (!_parsedDate)
                    {
                        ObsrvDate.CalendarForeColor = Color.Red;
                        dtObsrvTime.CalendarForeColor = Color.Red;
                    }
                    else
                    {
                        ObsrvDate.CalendarForeColor = Color.Black;
                        dtObsrvTime.CalendarForeColor = Color.Black;
                    }
                    TrySetFilter();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Loading Attachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected void txtTags_DoubleClick(object sender, EventArgs e)
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

        private void FrmSaturn_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            lblObsrvName.Text = string.Empty;
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
                if (_wrkFldr.Contains(@"Solar"))
                {
                    DirectoryInfo di = new DirectoryInfo(exportFldr);
                    DirectoryInfo[] subfolders = di.GetDirectories("CR*");
                    foreach (DirectoryInfo fldr in subfolders)
                    {
                        FileInfo[] imgs = fldr.GetFiles();
                        foreach (FileInfo img in imgs)
                        {
                            if (img.Extension.ToLower().Contains("lnk")) continue;
                            string fileNameNoExt = Path.GetFileNameWithoutExtension(img.Name);
                            string[] parts = img.Name.Split('-');
                            sb.AppendLine("Sun," + parts[4] + "," + img.Name + "," +
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
                            sb.AppendLine("Saturn" + "," + parts[4] + "," + img.Name + "," +
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

        private void ckOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOverride.Checked)
            {
                TrySetObserver();
            }
        }

    }
}
