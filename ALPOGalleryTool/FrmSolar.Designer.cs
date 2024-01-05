
namespace ALPOGalleryTool
{
    partial class FrmSolar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgObservation = new Cyotek.Windows.Forms.ImageBox();
            this.lstAttachments = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lstMsgs = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblOversized = new System.Windows.Forms.Label();
            this.TenthsMin = new System.Windows.Forms.NumericUpDown();
            this.dtObsrvTime = new System.Windows.Forms.DateTimePicker();
            this.ObsrvDate = new System.Windows.Forms.DateTimePicker();
            this.cmbTelescopes = new System.Windows.Forms.ComboBox();
            this.cmbObserver = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.lstFilters = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTrnsp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSeeing = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lstOtherFltr = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblObsrvName = new System.Windows.Forms.Label();
            this.ckOverride = new System.Windows.Forms.CheckBox();
            this.btnGenSectRpt = new System.Windows.Forms.Button();
            this.btnGenName = new System.Windows.Forms.Button();
            this.btnTrimFileName = new System.Windows.Forms.Button();
            this.btnParseFileForDate = new System.Windows.Forms.Button();
            this.btnTrash = new System.Windows.Forms.Button();
            this.btnAddTags = new System.Windows.Forms.Button();
            this.btnDeleteImg = new System.Windows.Forms.Button();
            this.txtImportFldr = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkImport = new System.Windows.Forms.CheckBox();
            this.btnPriorTag = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnApndTags = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lstCardinal = new System.Windows.Forms.ListBox();
            this.ckExtractOnly = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TenthsMin)).BeginInit();
            this.SuspendLayout();
            // 
            // imgObservation
            // 
            this.imgObservation.Location = new System.Drawing.Point(631, 32);
            this.imgObservation.Name = "imgObservation";
            this.imgObservation.Size = new System.Drawing.Size(717, 586);
            this.imgObservation.TabIndex = 7;
            this.imgObservation.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lstAttachments
            // 
            this.lstAttachments.FormattingEnabled = true;
            this.lstAttachments.ItemHeight = 15;
            this.lstAttachments.Location = new System.Drawing.Point(36, 141);
            this.lstAttachments.Name = "lstAttachments";
            this.lstAttachments.Size = new System.Drawing.Size(546, 49);
            this.lstAttachments.TabIndex = 37;
            this.lstAttachments.SelectedIndexChanged += new System.EventHandler(this.lstAttachments_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(36, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 15);
            this.label8.TabIndex = 36;
            this.label8.Text = "Attachments";
            // 
            // lstMsgs
            // 
            this.lstMsgs.FormattingEnabled = true;
            this.lstMsgs.ItemHeight = 15;
            this.lstMsgs.Location = new System.Drawing.Point(34, 21);
            this.lstMsgs.Name = "lstMsgs";
            this.lstMsgs.Size = new System.Drawing.Size(548, 94);
            this.lstMsgs.TabIndex = 35;
            this.lstMsgs.SelectedIndexChanged += new System.EventHandler(this.lstMsgs_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(34, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 15);
            this.label7.TabIndex = 34;
            this.label7.Text = "Submissions";
            // 
            // lblOversized
            // 
            this.lblOversized.AutoSize = true;
            this.lblOversized.BackColor = System.Drawing.Color.Yellow;
            this.lblOversized.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOversized.ForeColor = System.Drawing.Color.Red;
            this.lblOversized.Location = new System.Drawing.Point(637, 9);
            this.lblOversized.Name = "lblOversized";
            this.lblOversized.Size = new System.Drawing.Size(88, 20);
            this.lblOversized.TabIndex = 43;
            this.lblOversized.Text = "Oversized";
            this.lblOversized.Visible = false;
            this.lblOversized.Click += new System.EventHandler(this.lblOversized_Click);
            // 
            // TenthsMin
            // 
            this.TenthsMin.Location = new System.Drawing.Point(357, 211);
            this.TenthsMin.Name = "TenthsMin";
            this.TenthsMin.Size = new System.Drawing.Size(51, 21);
            this.TenthsMin.TabIndex = 41;
            // 
            // dtObsrvTime
            // 
            this.dtObsrvTime.CustomFormat = "HHmm";
            this.dtObsrvTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtObsrvTime.Location = new System.Drawing.Point(218, 211);
            this.dtObsrvTime.Name = "dtObsrvTime";
            this.dtObsrvTime.ShowUpDown = true;
            this.dtObsrvTime.Size = new System.Drawing.Size(105, 21);
            this.dtObsrvTime.TabIndex = 40;
            // 
            // ObsrvDate
            // 
            this.ObsrvDate.CustomFormat = "yyyy-MM-dd";
            this.ObsrvDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ObsrvDate.Location = new System.Drawing.Point(36, 211);
            this.ObsrvDate.Name = "ObsrvDate";
            this.ObsrvDate.ShowUpDown = true;
            this.ObsrvDate.Size = new System.Drawing.Size(168, 21);
            this.ObsrvDate.TabIndex = 39;
            // 
            // cmbTelescopes
            // 
            this.cmbTelescopes.FormattingEnabled = true;
            this.cmbTelescopes.Location = new System.Drawing.Point(292, 265);
            this.cmbTelescopes.Name = "cmbTelescopes";
            this.cmbTelescopes.Size = new System.Drawing.Size(269, 23);
            this.cmbTelescopes.TabIndex = 46;
            // 
            // cmbObserver
            // 
            this.cmbObserver.FormattingEnabled = true;
            this.cmbObserver.Location = new System.Drawing.Point(55, 263);
            this.cmbObserver.Name = "cmbObserver";
            this.cmbObserver.Size = new System.Drawing.Size(119, 23);
            this.cmbObserver.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(55, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 47;
            this.label1.Text = "Observer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(288, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 48;
            this.label2.Text = "Telescope";
            // 
            // lstTags
            // 
            this.lstTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTags.FormattingEnabled = true;
            this.lstTags.ItemHeight = 15;
            this.lstTags.Location = new System.Drawing.Point(395, 404);
            this.lstTags.Name = "lstTags";
            this.lstTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTags.Size = new System.Drawing.Size(230, 259);
            this.lstTags.TabIndex = 63;
            this.lstTags.DoubleClick += new System.EventHandler(this.lstTags_DoubleClick);
            // 
            // btnProcess
            // 
            this.btnProcess.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.create_map_icon;
            this.btnProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProcess.Location = new System.Drawing.Point(631, 625);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(24, 24);
            this.btnProcess.TabIndex = 59;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtTags
            // 
            this.txtTags.Location = new System.Drawing.Point(218, 364);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(399, 21);
            this.txtTags.TabIndex = 52;
            this.txtTags.DoubleClick += new System.EventHandler(this.txtTags_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(34, 494);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 58;
            this.label5.Text = "Notes";
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(34, 512);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(349, 152);
            this.rtbNotes.TabIndex = 57;
            this.rtbNotes.Text = "";
            // 
            // lstFilters
            // 
            this.lstFilters.FormattingEnabled = true;
            this.lstFilters.ItemHeight = 15;
            this.lstFilters.Location = new System.Drawing.Point(34, 388);
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstFilters.Size = new System.Drawing.Size(78, 94);
            this.lstFilters.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(38, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 55;
            this.label4.Text = "Filter";
            // 
            // txtTrnsp
            // 
            this.txtTrnsp.Location = new System.Drawing.Point(549, 332);
            this.txtTrnsp.Name = "txtTrnsp";
            this.txtTrnsp.Size = new System.Drawing.Size(45, 21);
            this.txtTrnsp.TabIndex = 50;
            this.txtTrnsp.Text = "0";
            this.txtTrnsp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(549, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 54;
            this.label3.Text = "Transp";
            // 
            // txtSeeing
            // 
            this.txtSeeing.Location = new System.Drawing.Point(489, 332);
            this.txtSeeing.Name = "txtSeeing";
            this.txtSeeing.Size = new System.Drawing.Size(42, 21);
            this.txtSeeing.TabIndex = 49;
            this.txtSeeing.Text = "0";
            this.txtSeeing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(486, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 53;
            this.label6.Text = "Seeing";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFileName.Location = new System.Drawing.Point(693, 630);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(69, 16);
            this.lblFileName.TabIndex = 51;
            this.lblFileName.Text = "File Name";
            this.lblFileName.TextChanged += new System.EventHandler(this.lblFileName_TextChanged);
            // 
            // lstOtherFltr
            // 
            this.lstOtherFltr.FormattingEnabled = true;
            this.lstOtherFltr.ItemHeight = 15;
            this.lstOtherFltr.Location = new System.Drawing.Point(121, 388);
            this.lstOtherFltr.Name = "lstOtherFltr";
            this.lstOtherFltr.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstOtherFltr.Size = new System.Drawing.Size(83, 94);
            this.lstOtherFltr.TabIndex = 64;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(118, 370);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 15);
            this.label9.TabIndex = 65;
            this.label9.Text = "2nd Filter";
            // 
            // lblObsrvName
            // 
            this.lblObsrvName.AutoSize = true;
            this.lblObsrvName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblObsrvName.Location = new System.Drawing.Point(53, 289);
            this.lblObsrvName.Name = "lblObsrvName";
            this.lblObsrvName.Size = new System.Drawing.Size(41, 15);
            this.lblObsrvName.TabIndex = 66;
            this.lblObsrvName.Text = "Name";
            // 
            // ckOverride
            // 
            this.ckOverride.AutoSize = true;
            this.ckOverride.ForeColor = System.Drawing.Color.White;
            this.ckOverride.Location = new System.Drawing.Point(189, 267);
            this.ckOverride.Name = "ckOverride";
            this.ckOverride.Size = new System.Drawing.Size(72, 19);
            this.ckOverride.TabIndex = 67;
            this.ckOverride.Text = "Override";
            this.ckOverride.UseVisualStyleBackColor = true;
            this.ckOverride.CheckedChanged += new System.EventHandler(this.ckOverride_CheckedChanged);
            // 
            // btnGenSectRpt
            // 
            this.btnGenSectRpt.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.x_office_spreadsheet_icon;
            this.btnGenSectRpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenSectRpt.Location = new System.Drawing.Point(545, 206);
            this.btnGenSectRpt.Name = "btnGenSectRpt";
            this.btnGenSectRpt.Size = new System.Drawing.Size(37, 37);
            this.btnGenSectRpt.TabIndex = 61;
            this.btnGenSectRpt.UseVisualStyleBackColor = true;
            this.btnGenSectRpt.Click += new System.EventHandler(this.btnGenSectRpt_Click);
            // 
            // btnGenName
            // 
            this.btnGenName.BackgroundImage = global::ALPOGalleryTool.Properties.Resources._20_gear_2_icon;
            this.btnGenName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenName.Location = new System.Drawing.Point(663, 625);
            this.btnGenName.Name = "btnGenName";
            this.btnGenName.Size = new System.Drawing.Size(24, 24);
            this.btnGenName.TabIndex = 60;
            this.btnGenName.UseVisualStyleBackColor = true;
            this.btnGenName.Click += new System.EventHandler(this.btnGenName_Click);
            // 
            // btnTrimFileName
            // 
            this.btnTrimFileName.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.minus_icon;
            this.btnTrimFileName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTrimFileName.Location = new System.Drawing.Point(487, 206);
            this.btnTrimFileName.Name = "btnTrimFileName";
            this.btnTrimFileName.Size = new System.Drawing.Size(37, 37);
            this.btnTrimFileName.TabIndex = 44;
            this.btnTrimFileName.UseVisualStyleBackColor = true;
            this.btnTrimFileName.Click += new System.EventHandler(this.btnTrimFileName_Click);
            // 
            // btnParseFileForDate
            // 
            this.btnParseFileForDate.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.document_split_icon;
            this.btnParseFileForDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnParseFileForDate.Location = new System.Drawing.Point(430, 206);
            this.btnParseFileForDate.Name = "btnParseFileForDate";
            this.btnParseFileForDate.Size = new System.Drawing.Size(37, 37);
            this.btnParseFileForDate.TabIndex = 42;
            this.btnParseFileForDate.UseVisualStyleBackColor = true;
            this.btnParseFileForDate.Click += new System.EventHandler(this.btnParseFileForDate_Click);
            // 
            // btnTrash
            // 
            this.btnTrash.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Actions_trash_empty_icon;
            this.btnTrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTrash.Location = new System.Drawing.Point(588, 21);
            this.btnTrash.Name = "btnTrash";
            this.btnTrash.Size = new System.Drawing.Size(37, 37);
            this.btnTrash.TabIndex = 38;
            this.btnTrash.UseVisualStyleBackColor = true;
            this.btnTrash.Click += new System.EventHandler(this.btnTrash_Click);
            // 
            // btnAddTags
            // 
            this.btnAddTags.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.UpArrow;
            this.btnAddTags.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddTags.Location = new System.Drawing.Point(357, 388);
            this.btnAddTags.Name = "btnAddTags";
            this.btnAddTags.Size = new System.Drawing.Size(32, 32);
            this.btnAddTags.TabIndex = 68;
            this.btnAddTags.UseVisualStyleBackColor = true;
            this.btnAddTags.Click += new System.EventHandler(this.btnAddTags_Click);
            // 
            // btnDeleteImg
            // 
            this.btnDeleteImg.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Actions_trash_empty_icon;
            this.btnDeleteImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteImg.Location = new System.Drawing.Point(588, 141);
            this.btnDeleteImg.Name = "btnDeleteImg";
            this.btnDeleteImg.Size = new System.Drawing.Size(37, 37);
            this.btnDeleteImg.TabIndex = 69;
            this.btnDeleteImg.UseVisualStyleBackColor = true;
            this.btnDeleteImg.Click += new System.EventHandler(this.btnDeleteImg_Click);
            // 
            // txtImportFldr
            // 
            this.txtImportFldr.Location = new System.Drawing.Point(39, 332);
            this.txtImportFldr.Name = "txtImportFldr";
            this.txtImportFldr.Size = new System.Drawing.Size(421, 21);
            this.txtImportFldr.TabIndex = 70;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(36, 314);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 15);
            this.label10.TabIndex = 71;
            this.label10.Text = "Import Path";
            // 
            // chkImport
            // 
            this.chkImport.AutoSize = true;
            this.chkImport.ForeColor = System.Drawing.Color.White;
            this.chkImport.Location = new System.Drawing.Point(126, 313);
            this.chkImport.Name = "chkImport";
            this.chkImport.Size = new System.Drawing.Size(61, 19);
            this.chkImport.TabIndex = 72;
            this.chkImport.Text = "Import";
            this.chkImport.UseVisualStyleBackColor = true;
            this.chkImport.CheckedChanged += new System.EventHandler(this.chkImport_CheckedChanged);
            // 
            // btnPriorTag
            // 
            this.btnPriorTag.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.arrow_refresh_icon;
            this.btnPriorTag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPriorTag.Location = new System.Drawing.Point(357, 464);
            this.btnPriorTag.Name = "btnPriorTag";
            this.btnPriorTag.Size = new System.Drawing.Size(32, 32);
            this.btnPriorTag.TabIndex = 73;
            this.btnPriorTag.UseVisualStyleBackColor = true;
            this.btnPriorTag.Click += new System.EventHandler(this.btnPriorTag_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.customer;
            this.btnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.Location = new System.Drawing.Point(12, 258);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(32, 32);
            this.btnProfile.TabIndex = 74;
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnApndTags
            // 
            this.btnApndTags.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Upload_icon;
            this.btnApndTags.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnApndTags.Location = new System.Drawing.Point(357, 426);
            this.btnApndTags.Name = "btnApndTags";
            this.btnApndTags.Size = new System.Drawing.Size(32, 32);
            this.btnApndTags.TabIndex = 75;
            this.btnApndTags.UseVisualStyleBackColor = true;
            this.btnApndTags.Click += new System.EventHandler(this.btnApndTags_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(215, 388);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 15);
            this.label11.TabIndex = 77;
            this.label11.Text = "Cardinal";
            // 
            // lstCardinal
            // 
            this.lstCardinal.FormattingEnabled = true;
            this.lstCardinal.ItemHeight = 15;
            this.lstCardinal.Items.AddRange(new object[] {
            "N",
            "NE",
            "E",
            "SE",
            "S",
            "SW",
            "W",
            "NW"});
            this.lstCardinal.Location = new System.Drawing.Point(218, 404);
            this.lstCardinal.Name = "lstCardinal";
            this.lstCardinal.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCardinal.Size = new System.Drawing.Size(50, 79);
            this.lstCardinal.TabIndex = 76;
            this.lstCardinal.DoubleClick += new System.EventHandler(this.lstCardinal_DoubleClick);
            // 
            // ckExtractOnly
            // 
            this.ckExtractOnly.AutoSize = true;
            this.ckExtractOnly.ForeColor = System.Drawing.Color.White;
            this.ckExtractOnly.Location = new System.Drawing.Point(631, 649);
            this.ckExtractOnly.Name = "ckExtractOnly";
            this.ckExtractOnly.Size = new System.Drawing.Size(128, 19);
            this.ckExtractOnly.TabIndex = 78;
            this.ckExtractOnly.Text = "Extract Image Only";
            this.ckExtractOnly.UseVisualStyleBackColor = true;
            // 
            // FrmSolar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1364, 672);
            this.Controls.Add(this.ckExtractOnly);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lstCardinal);
            this.Controls.Add(this.btnApndTags);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnPriorTag);
            this.Controls.Add(this.chkImport);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtImportFldr);
            this.Controls.Add(this.btnDeleteImg);
            this.Controls.Add(this.btnAddTags);
            this.Controls.Add(this.ckOverride);
            this.Controls.Add(this.lblObsrvName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lstOtherFltr);
            this.Controls.Add(this.lstTags);
            this.Controls.Add(this.btnGenSectRpt);
            this.Controls.Add(this.btnGenName);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtTags);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.lstFilters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTrnsp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSeeing);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTelescopes);
            this.Controls.Add(this.cmbObserver);
            this.Controls.Add(this.btnTrimFileName);
            this.Controls.Add(this.lblOversized);
            this.Controls.Add(this.btnParseFileForDate);
            this.Controls.Add(this.TenthsMin);
            this.Controls.Add(this.dtObsrvTime);
            this.Controls.Add(this.ObsrvDate);
            this.Controls.Add(this.btnTrash);
            this.Controls.Add(this.lstAttachments);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lstMsgs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.imgObservation);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmSolar";
            this.Text = "Solar Observations";
            this.Shown += new System.EventHandler(this.FrmSolar_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.TenthsMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cyotek.Windows.Forms.ImageBox imgObservation;
        private System.Windows.Forms.Button btnTrash;
        private System.Windows.Forms.ListBox lstAttachments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstMsgs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTrimFileName;
        private System.Windows.Forms.Label lblOversized;
        private System.Windows.Forms.Button btnParseFileForDate;
        private System.Windows.Forms.NumericUpDown TenthsMin;
        private System.Windows.Forms.DateTimePicker dtObsrvTime;
        private System.Windows.Forms.DateTimePicker ObsrvDate;
        private System.Windows.Forms.ComboBox cmbTelescopes;
        private System.Windows.Forms.ComboBox cmbObserver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.Button btnGenSectRpt;
        private System.Windows.Forms.Button btnGenName;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.ListBox lstFilters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTrnsp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSeeing;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.ListBox lstOtherFltr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblObsrvName;
        private System.Windows.Forms.CheckBox ckOverride;
        private System.Windows.Forms.Button btnAddTags;
        private System.Windows.Forms.Button btnDeleteImg;
        private System.Windows.Forms.TextBox txtImportFldr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkImport;
        private System.Windows.Forms.Button btnPriorTag;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnApndTags;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox lstCardinal;
        private System.Windows.Forms.CheckBox ckExtractOnly;
    }
}