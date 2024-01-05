using ALPOGalleryTool.DataAccess.MongoDto;
using ALPOGalleryTool.Interfaces;
using ALPOGalleryTool.Properties;
using iwantedue;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ALPOGalleryTool
{
    public partial class FrmMain : Form
    {
        private const double JupCm1Offset = 0.6096528d;
        private const double JupCm2Offset = 0.604027d;
        private readonly IDataSrvc _dataSrvc;
        private Dictionary<string, AttachmentPoco> _attachments = new Dictionary<string, AttachmentPoco>();
        private string _carrRtn = string.Empty;
        private Dictionary<string, MongoLongitude> _dictCm = new Dictionary<string, MongoLongitude>();
        private Dictionary<string, DateTime> _dictCRInfo = new Dictionary<string, DateTime>();
        private Dictionary<string, string> _imgFiles = new Dictionary<string, string>();
        private bool _initDone = false;
        private List<IObserver> _observers = new List<IObserver>();
        private string _rptAuthorEmail;
        private List<string> _tags = new List<string>();
        private List<ITelescope> _telescopes = new List<ITelescope>();
        private string _tmpFileName;
        private string _wrkFldr;
        private int cnt = 0;

        public FrmMain(IDataSrvc dataSrvc)
        {
            InitializeComponent();
            _dataSrvc = dataSrvc;
            LoadUsers();
            LoadFilters();
            LoadSections();
            LoadTelescopes();
            LoadCarringtonRotations();
            this.WindowState = FormWindowState.Maximized;
        }

        protected void btnAddObsrvr_Click(object sender, EventArgs e)
        {
            ModalAddObserver modal = new ModalAddObserver();
            if (modal.ShowDialog() == DialogResult.OK)
            {
                IObserver dto = new MongoObserver();
                dto.Email = modal.Email;
                dto.Initials = modal.Initials;
                dto.City = modal.City;
                dto.Country = modal.Country;
                dto.FirstName = modal.FirstName;
                dto.LastName = modal.LastName;
                dto.Region = modal.PrvncState;
                dto.EmailName = modal.EmailName;
                int recsInserted = _dataSrvc.AddObserver(dto);
                if (recsInserted == 1)
                {
                    LoadUsers();
                }

                MessageBox.Show("Inserted Records:" + recsInserted.ToString());
            }
            modal.Dispose();
            modal = null;
        }

        protected void btnGenName_Click(object sender, EventArgs e)
        {
            if (cmbSections.Text == @"Solar")
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
            }
            int i = Convert.ToInt32(TenthsMin.Value);
            string tenths = i > 0 ? "_" + i.ToString() : "";
            string[] filters = GetFilters().Where(f => f.Contains("Block") == false).ToArray();
            lblFileName.Text = ObsrvDate.Value.ToString("yyyy-MM-dd") + "-" +
                               dtObsrvTime.Value.ToString("HHmm") + tenths + "-" +
                               cmbObserver.Text + "-" +
                               String.Join("_", filters);
        }

        protected void btnGenSectionRpt_Click(object sender, EventArgs e)
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
                }
                else
                {
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
                                sb.AppendLine(cmbSections.Text + "," + parts[4] + "," + img.Name + "," +
                                              _dataSrvc.GetObsrvUrl(fileNameNoExt));
                            }
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
                MessageBox.Show((ex.Message));
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        protected void btnImgFldrSelect_Click(object sender, EventArgs e)
        {
            DialogResult result = fldrDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                lstImgsToProcess.Items.Clear();
                lblImgFolder.Text = fldrDlg.SelectedPath;
                DirectoryInfo di = new DirectoryInfo(fldrDlg.SelectedPath);
                FileInfo[] imgFiles = di.GetFiles();
                foreach (FileInfo imgFile in imgFiles)
                {
                    lstImgsToProcess.Items.Add(imgFile.Name);
                }
            }

        }

        protected void btnImgSelFolder_Click(object sender, EventArgs e)
        {
            if (cmbSections.SelectedIndex == -1)
            {
                MessageBox.Show(@"You need to select a Section first",
                    @"Section Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
            }
            else
            {
                fldrDlg.SelectedPath = _wrkFldr;
                DialogResult result = fldrDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    lstAttachments.Items.Clear();
                    _attachments.Clear();
                    DirectoryInfo di = new DirectoryInfo(fldrDlg.SelectedPath);
                    FileInfo[] imgFiles = di.GetFiles();
                    foreach (FileInfo imgFile in imgFiles)
                    {
                        byte[] data = File.ReadAllBytes(imgFile.FullName);
                        lstAttachments.Items.Add(imgFile.Name);
                        AttachmentPoco tmp = new AttachmentPoco
                        {
                            Data = data,
                            FileName = imgFile.Name
                        };
                        _attachments.Add(tmp.FileName, tmp);
                    }
                }
            }
        }

        protected void btnParseFileForDate_Click(object sender, EventArgs e)
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

            if (cmbObserver.Text == @"ClyFstr" && cmbSections.Text != "Mars")
            {
                string fileDT = _tmpFileName.Substring(0, 10) + " " +
                                      _tmpFileName.Substring(11, 2) + ":" +
                                      _tmpFileName.Substring(14, 2);
                if (DateTime.TryParse(fileDT, out DateTime dtm))
                {
                    ObsrvDate.Value = dtm;
                    dtObsrvTime.Value = dtm;
                }
                return;
            }
            if (cmbObserver.Text == @"ClyFstr" && cmbSections.Text == "Mars")
            {
                string x = _tmpFileName.Substring(5);
                string dy = x.Substring(0, 2);
                string mnth = x.Substring(2, 2);
                string yr = x.Substring(4, 4);
                string hr = x.Substring(9, 2);
                string mn = x.Substring(11, 2);
                string fileDT = yr + "-" + mnth + "-" + dy + " " + hr + ":" + mn;
                if (DateTime.TryParse(fileDT, out DateTime dtm))
                {
                    ObsrvDate.Value = dtm;
                    dtObsrvTime.Value = dtm;
                }
                return;
            }
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
                }
                return;
            }
            if (cmbObserver.Text == @"NiaMNl" || cmbObserver.Text == @"MrcDlcrx" ||
                cmbObserver.Text == @"JhnWrll")
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

            if (cmbObserver.Text == @"MrtLws")
            {
                string fileDT = _tmpFileName.Substring(0, 10) + " " +
                                _tmpFileName.Substring(11, 2) + ":" +
                                _tmpFileName.Substring(13, 2);
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

            if (cmbObserver.Text == @"MkHd")
            {
                string fileDT = _tmpFileName.Substring(0, 10) + " " +
                                _tmpFileName.Substring(11, 2) + ":" +
                                _tmpFileName.Substring(14, 2);
                if (DateTime.TryParse(fileDT, out DateTime dtm))
                {
                    ObsrvDate.Value = dtm;
                    dtObsrvTime.Value = dtm;
                }

                if (int.TryParse(_tmpFileName.Substring(17, 1), out int secs))
                {
                    TenthsMin.Value = secs;
                }
                return;
            }

            if (cmbObserver.Text == @"GryWlk")
            {
                string tmp = _tmpFileName.Replace("[", "_").Replace("]", "");
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

            if (cmbObserver.Text == @"ChrPlr")
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

            if (cmbObserver.Text == @"JmWlhm")
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
                }
                if (int.TryParse(_tmpFileName.Substring(14, 1), out int secs))
                {
                    TenthsMin.Value = secs;
                }
                return;
            }

            //Format yyyy-MM-dd-hh_mm
            if (cmbObserver.Text == @"RobBlln")
            {
                string fileDT = _tmpFileName.Substring(0, 4) + "-" +
                                _tmpFileName.Substring(5, 2) + "-" +
                                _tmpFileName.Substring(8, 2) + " " +
                                _tmpFileName.Substring(11, 2) + ":" +
                                _tmpFileName.Substring(14, 2);
                if (DateTime.TryParse(fileDT, out DateTime dtm))
                {
                    ObsrvDate.Value = dtm;
                    dtObsrvTime.Value = dtm;
                }
                if (int.TryParse(_tmpFileName.Substring(16, 1), out int secs))
                {
                    TenthsMin.Value = secs;
                }
                return;
            }

            if (cmbObserver.Text == @"VdSlvJ" && cmbSections.Text == @"Solar")
            {
                string rgxPattern = @"([2]\d{1}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))";
                if (Regex.IsMatch(_tmpFileName, rgxPattern))
                {
                    Match m = Regex.Match(_tmpFileName, rgxPattern);
                    string tmpDate = "20" + m.Value + " ";
                    int ptr = m.Index + m.Value.Length + 1;
                    string tmpTime = _tmpFileName.Substring(ptr, 8).Replace("-", ":");
                    if (DateTime.TryParse(tmpDate + tmpTime, out DateTime tmpDateTime))
                    {
                        tmpDateTime = tmpDateTime.AddHours(3);
                        ObsrvDate.Value = tmpDateTime;
                        dtObsrvTime.Value = tmpDateTime;
                        if (tmpTime.Length > 5 && int.TryParse(tmpTime.Substring(6, 2), out int secs))
                        {
                            TenthsMin.Value = secs / 6;
                        }
                    }
                }
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
            else
            {
                ObsrvDate.CalendarForeColor = Color.Red;
            }

            if (tmpFileNameForDate.IndexOf("_", StringComparison.Ordinal) == 15)
            {
                if (int.TryParse(tmpFileNameForDate.Substring(16, 1), out int i))
                {
                    TenthsMin.Value = i;
                }
            }
        }

        private DateTime ParseKeyedDateTime()
        {
            string datePart = ObsrvDate.Value.ToString("yyyy-MM-dd");
            string timePart = dtObsrvTime.Value.ToString("HH:mm");
            return DateTime.Parse(datePart + " " + timePart);
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
                dto.HostGallery = cmbSections.Text;
                dto.MimeType = Path.GetExtension(lstAttachments.Text)?.ToUpper().Substring(1);
                dto.Notes = rtbNotes.Text;
                dto.ObsrvrInitials = cmbObserver.Text;
                dto.Section = cmbSections.Text;
                dto.Seeing = double.Parse(txtSeeing.Text);
                dto.Tags = GetTags();
                dto.Telescope = cmbTelescopes.Text;
                dto.Transparency = double.Parse(txtTrnsp.Text);
                dto.UtObsrvDt = DateTime.Parse(ObsrvDate.Value.ToString("yyyy-MM-dd") + " " +
                                               dtObsrvTime.Value.ToString("HH:mm"));
                int offset = DateTime.Now.IsDaylightSavingTime() ? -4 : -5;
                dto.UtObsrvDt = dto.UtObsrvDt.AddHours(offset);
                dto.Url = GetUrl();
                dto.CarringtonRotation = SetCarrRtn();
                if (dto.IsValid() == false)
                {
                    MessageBox.Show(dto.ErrMsg, "Invalid Observation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                int recsAdded = _dataSrvc.AddObservation(dto);
                if (recsAdded == 1)
                {
                    UpdateTagList();
                    string exportFldr = Path.GetDirectoryName(_wrkFldr);
                    if (cmbSections.Text == @"Solar")
                    {
                        exportFldr = Path.Combine(exportFldr, _carrRtn);
                    }
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

        private int SetCarrRtn()
        {
            int result = 0;
            if (cmbSections.Text == "Solar")
            {
                return Convert.ToInt32(_carrRtn.Replace("CR", ""));
            }
            return result;
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

        protected void cmbObserver_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrySetObserver();
        }

        protected void cmbSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_initDone)
            {
                switch (cmbSections.Text)
                {
                    case "Jupiter":
                        {
                            _wrkFldr = Settings.Default.JupiterStaged;
                            LoadCmData(cmbSections.Text);
                            txtOffset1.Visible = true;
                            txtOffset2.Visible = true;
                            txtOffset3.Visible = true;
                            break;
                        }
                    case "Mars":
                        {
                            _wrkFldr = Settings.Default.MarsStaged;
                            break;
                        }
                    case "Mercury":
                        {
                            _wrkFldr = Settings.Default.MercuryStaged;
                            break;
                        }
                    case "Saturn":
                        {
                            _wrkFldr = Settings.Default.SaturnStaged;
                            break;
                        }
                    case "Solar":
                        {
                            _wrkFldr = Settings.Default.SolarStaged;
                            break;
                        }
                    case "Venus":
                        {
                            _wrkFldr = Settings.Default.VenusStaged;
                            break;
                        }
                    case "Remote":
                        {
                            _wrkFldr = Settings.Default.RemoteStaged;
                            break;
                        }
                }
                LoadReports();
                LoadTags();
            }
        }

        protected void FrmMain_Shown(object sender, EventArgs e)
        {
            _initDone = true;
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
                    if (!HasValidImgExtension())
                    {
                        MessageBox.Show("Invalid file extension");
                        return;
                    }
                    TrySetFilter();
                    btnParseFileForDate_Click(this, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Loading Attachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool HasValidImgExtension()
        {
            bool result = false;
            string ext = Path.GetExtension(_tmpFileName).ToUpper();
            switch (ext)
            {
                case ".JPG":
                case ".PNG":
                case ".GIF":
                    {
                        result = true;
                        break;
                    }
            }
            return result;
        }

        private void TrySetFilter()
        {
            if (lstAttachments.Text.ToUpper().Contains("-IR-") ||
                lstAttachments.Text.ToUpper().Contains("-IR_") ||
                lstAttachments.Text.ToUpper().Contains("_IR_") ||
                lstAttachments.Text.ToUpper().Contains(" IR "))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("IR"), true);
            }
            if (lstAttachments.Text.ToUpper().Contains("-RGB-") ||
                lstAttachments.Text.ToUpper().Contains("_RGB_") ||
                lstAttachments.Text.ToUpper().Contains("-RGB.") ||
                lstAttachments.Text.ToUpper().Contains("-RGB_") ||
                lstAttachments.Text.ToUpper().Contains(" RGB "))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("RGB"), true);
            }
            if (lstAttachments.Text.ToUpper().Contains("-WL-") ||
                lstAttachments.Text.ToUpper().Contains("_WL_") ||
                lstAttachments.Text.ToUpper().Contains("-WL_") ||
                lstAttachments.Text.ToUpper().Contains("-L-") ||
                lstAttachments.Text.ToUpper().Contains(" WL "))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("WL"), true);
            }
            if (lstAttachments.Text.ToUpper().Contains("-CH4-") ||
                lstAttachments.Text.ToUpper().Contains("-CH4_") ||
                lstAttachments.Text.ToUpper().Contains("_CH4_") ||
                lstAttachments.Text.ToUpper().Contains(" CH4 "))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("CH4"), true);
            }
            if (lstAttachments.Text.ToUpper().Contains("-UV-") ||
                lstAttachments.Text.ToUpper().Contains("-UV_") ||
                lstAttachments.Text.ToUpper().Contains("_UV_") ||
                lstAttachments.Text.ToUpper().Contains(" UV "))
            {
                lstFilters.ClearSelected();
                lstFilters.SetSelected(lstFilters.FindString("UV"), true);
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
                LoadMsg();
            }
        }

        protected void lstTags_DoubleClick(object sender, EventArgs e)
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

        private void AddTag(string tag)
        {
            AddTagSeparator();
            txtTags.Text += tag;
        }

        private void AddTagSeparator()
        {
            if (txtTags.Text.Length > 0 && !txtTags.Text.EndsWith(","))
            {
                txtTags.Text = txtTags.Text + @", ";
            }
        }

        private void btnAddScope_Click(object sender, EventArgs e)
        {
            ModalAddTelescope modal = new ModalAddTelescope(_dataSrvc, cmbObserver.Text);
            if (modal.ShowDialog() == DialogResult.OK)
            {
                LoadTelescopes();
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

        private void btnLoadRptByObj_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> tblData = new Dictionary<string, int>();
            var observations = _dataSrvc.GetObsrvtnsByDateRange(dtStart.Value, dtEnd.Value);
            List<string> sections = observations.Select(o => o.Section).Distinct().ToList();
            foreach (string section in sections)
            {
                tblData.Add(section, observations.Count(o => o.Section == section));
            }

            List<string> scopetypes = observations.Select(o => o.Telescope).Distinct().ToList();
            foreach (string scopetype in scopetypes)
            {
                try
                {
                    string key = scopetype.Substring(0, 3);
                    if (tblData.ContainsKey(key))
                    {
                        int x = tblData[key] + 1;
                        tblData[key] = x;
                    }
                    else
                    {
                        tblData.Add(key, 1);
                    }
                }
                catch { }
            }

            List<string> initials = observations.Select(o => o.ObsrvrInitials).Distinct().ToList();

            var countries = _observers.Where(o => initials.Contains(o.Initials)).Distinct();
            foreach (IObserver observer in countries)
            {
                if (string.IsNullOrEmpty(observer.Country))
                {
                    continue;
                }

                string key = observer.Country.Trim();
                if (!string.IsNullOrEmpty(key))
                {
                    if (tblData.ContainsKey(key))
                    {
                        tblData[key] = tblData[key] + 1;
                    }
                    else
                    {
                        tblData.Add(key, 1);
                    }
                }
            }

            foreach (MongoObservation observation in observations)
            {
                string key = observation.ObsrvrInitials;
                if (tblData.ContainsKey(key))
                {
                    tblData[key] = tblData[key] + 1;
                }
                else
                {
                    tblData.Add(key, 1);
                }
            }

            var rows = from row in tblData select new { Item = row.Key, Price = row.Value };
            dgvwByObject.DataSource = rows.ToArray();
        }

        private void btnShrink_Click(object sender, EventArgs e)
        {
            float dpi = 96f;
            string tmp = Path.GetTempFileName();
            string tmpFileName = Path.Combine(Path.GetTempPath(),
                lstAttachments.Text);
            File.WriteAllBytes(tmp, _attachments[lstAttachments.Text].Data);
            Bitmap originalBitmap = new Bitmap(tmp);
            using (Graphics gr = Graphics.FromImage(originalBitmap))
            {
                MessageBox.Show(gr.DpiX + " x " + gr.DpiY, "DPI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (gr.DpiX < dpi)
                {
                    dpi = gr.DpiX;
                }
            }
            int origWidth = originalBitmap.Width;
            int origHeight = originalBitmap.Height;

            int newWidth = Convert.ToInt32(origWidth * 0.95f);
            int newHeight = Convert.ToInt32(origHeight * 0.95f);

            using (Bitmap bm = new Bitmap(newWidth, newHeight))
            {
                Point[] points =
                {
                    new Point(0, 0),
                    new Point(newWidth, 0),
                    new Point(0, newHeight),
                };
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    gr.DrawImage(originalBitmap, points);
                }
                float dpix = dpi;
                float dpiy = dpi;
                bm.SetResolution(dpix, dpiy);
                SaveImage(bm, tmpFileName);
                SystemSounds.Beep.Play();
            }
        }

        private void CalculateCm()
        {
            switch (cmbSections.Text)
            {
                case "Mars":
                    {
                        string dt = ObsrvDate.Value.ToString("d") + " " + dtObsrvTime.Value.ToString("t");
                        DateTime obsDt = DateTime.Parse(dt);
                        MarsCentralMeridian cmCalc = new MarsCentralMeridian(_dataSrvc);
                        string sCM = cmCalc.GetMarsCMbyObsrvDt(obsDt);
                        int cm;
                        if (Int32.TryParse(sCM, out cm))
                        {
                            if (cm < 0 && cm > -10)
                            {
                                cm = 360 + cm;
                            }
                            txtTags.Text = @"CM " + cm.ToString();
                        }
                        break;
                    }
                case "Jupiter":
                    {
                        StringBuilder sb = new StringBuilder();
                        string dt = ObsrvDate.Value.ToString("d") + " " + dtObsrvTime.Value.ToString("t");
                        DateTime obsDt = DateTime.Parse(dt);
                        JupiterCentralMeridian cmCalc = new JupiterCentralMeridian(_dataSrvc, obsDt);
                        sb.Append("CM I ");
                        int cm = Int32.Parse(cmCalc.GetJupiterCMbyObsrvDt(obsDt, "CMI"));
                        int offset = Int32.Parse(txtOffset1.Text);
                        cm = cm + offset;
                        sb.Append(cm.ToString());
                        sb.Append(", CM II ");
                        cm = Int32.Parse(cmCalc.GetJupiterCMbyObsrvDt(obsDt, "CMII"));
                        offset = Int32.Parse(txtOffset2.Text);
                        cm = cm + offset;
                        sb.Append(cm.ToString());
                        sb.Append(", CM III ");
                        cm = Int32.Parse(cmCalc.GetJupiterCMbyObsrvDt(obsDt, "CMIII"));
                        offset = Int32.Parse(txtOffset3.Text);
                        cm = cm + offset;
                        sb.Append(cm.ToString());
                        txtTags.Text = sb.ToString();
                        break;
                    }
                case "Saturn":
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
                        break;
                    }
            }
        }

        private string GenerateFileName(string attachmentFileName)
        {
            string name = Path.GetFileNameWithoutExtension(attachmentFileName);
            string ext = Path.GetExtension(attachmentFileName);
            cnt++;
            return name + "_" + cnt.ToString("00") + ext;
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

            return result.ToArray();
        }

        private string GetUrl()
        {
            string result = "";
            switch (cmbSections.Text)
            {
                case "Jupiter":
                    {
                        result = Settings.Default.JupiterUrl + lblFileName.Text;
                        break;
                    }
                case "Mars":
                    {
                        result = Settings.Default.MarsUrl + lblFileName.Text;
                        break;
                    }
                case "Mercury":
                    {
                        result = Settings.Default.MercuryUrl + lblFileName.Text;
                        break;
                    }
                case "Saturn":
                    {
                        result = Settings.Default.SaturnUrl + lblFileName.Text;
                        break;
                    }
                case "Solar":
                    {
                        result = Settings.Default.SolarUrl + GetAlbumByCarrRtn(_carrRtn) + "/" + _carrRtn + "/" + lblFileName.Text;
                        break;
                    }
                case "Venus":
                    {
                        result = Settings.Default.VenusUrl + lblFileName.Text;
                        break;
                    }
                case "Remote":
                    {
                        result = Settings.Default.RemoteUrl + lblFileName.Text;
                        break;
                    }
            }

            return result;
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

        private void LoadCmData(string planet)
        {
            // _dictCm.Clear();
            //var data = _dataSrvc.GetLongDataByPlanet(planet);
            //_dictCm = data.ToDictionary(d => d.DateStamp, d => d);
        }

        private void LoadFilters()
        {
            lstFilters.Items.Add("B");
            lstFilters.Items.Add("CaK");
            lstFilters.Items.Add("CH4");
            lstFilters.Items.Add("G");
            lstFilters.Items.Add("Ha");
            lstFilters.Items.Add("IR");
            lstFilters.Items.Add("Mono");
            lstFilters.Items.Add("Na-D");
            lstFilters.Items.Add("R");
            lstFilters.Items.Add("RGB");
            lstFilters.Items.Add("WL");
            lstFilters.Items.Add("Wr8");
            lstFilters.Items.Add("Wr11");
            lstFilters.Items.Add("Wr15");
            lstFilters.Items.Add("Wr21");
            lstFilters.Items.Add("Wr23A");
            lstFilters.Items.Add("Wr25");
            lstFilters.Items.Add("Wr30");
            lstFilters.Items.Add("Wr47");
            lstFilters.Items.Add("Wr56");
            lstFilters.Items.Add("Wr58");
            lstFilters.Items.Add("Wr80A");
            lstFilters.Items.Add("Wr82");
            lstFilters.Items.Add("UV");
            lstFilters.Items.Add("UV-IR-Block");
            lstFilters.Items.Add("IR-Block");
            lstFilters.Items.Add("NA");
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

        private void LoadSections()
        {
            List<string> Sections = new List<string>()
            {
                "--Select--",
                "Solar",
                "Mercury",
                "Venus",
                "Mars",
                "Jupiter",
                "Saturn",
                "Remote"
            };
            cmbSections.DataSource = Sections;
        }

        private void LoadTags()
        {
            lstTags.Items.Clear();
            if (cmbSections.Text == "Solar")
            {
                _tags = _dataSrvc.GetRecentTags(cmbSections.Text).ToList();
            }
            else
            {
                _tags = _dataSrvc.GetRecentTags(cmbSections.Text, 60).ToList();
            }
            List<string> _persistentTags = _dataSrvc.GetPersistentTags(cmbSections.Text).ToList();
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

        private List<string> PrepTelescopeList(List<string> lst)
        {
            lst = lst.Distinct(
                StringComparer.CurrentCultureIgnoreCase).ToList();
            lst.Sort();
            return lst;
        }

        // Save the file with the appropriate format.
        private void SaveImage(Image image, string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension.ToLower())
            {
                case ".bmp":
                    image.Save(filename, ImageFormat.Bmp);
                    break;
                case ".exif":
                    image.Save(filename, ImageFormat.Exif);
                    break;
                case ".gif":
                    image.Save(filename, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    image.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    image.Save(filename, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    image.Save(filename, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unknown file extension " + extension);
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

        private void TrySetObserver()
        {
            if (lstMsgs.SelectedItems.Count == 1)
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
                    obsrvr = _observers.FirstOrDefault(o => o.EmailName.ToLower() == _rptAuthorEmail.ToLower()
                                                        || o.Email == _rptAuthorEmail.ToLower());
                }

                //var obsrvr = (cmbObserver.Text == string.Empty)
                //    ? _observers.FirstOrDefault(o => o.EmailName == _rptAuthorEmail)
                //    : _observers.FirstOrDefault(o => o.Initials == cmbObserver.Text);
                if (obsrvr != null)
                {
                    cmbObserver.Text = obsrvr.Initials;
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
            }
        }

        private void txtTags_MouseDoubleClick(object sender, MouseEventArgs e)
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
    }
}
