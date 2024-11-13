namespace ALPOGalleryTool
{
    partial class FrmEclipse
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
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnDeleteImg = new System.Windows.Forms.Button();
            this.ckOverride = new System.Windows.Forms.CheckBox();
            this.btnGenSectRpt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTelescopes = new System.Windows.Forms.ComboBox();
            this.cmbObserver = new System.Windows.Forms.ComboBox();
            this.lblOversized = new System.Windows.Forms.Label();
            this.btnParseFileForDate = new System.Windows.Forms.Button();
            this.dtObsrvTime = new System.Windows.Forms.DateTimePicker();
            this.ObsrvDate = new System.Windows.Forms.DateTimePicker();
            this.btnTrash = new System.Windows.Forms.Button();
            this.lstAttachments = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lstMsgs = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.imgObservation = new Cyotek.Windows.Forms.ImageBox();
            this.btnApndTags = new System.Windows.Forms.Button();
            this.btnAddTags = new System.Windows.Forms.Button();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.btnGenName = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.lstFilters = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtTrnsp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSeeing = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lstOtherFltr = new System.Windows.Forms.ListBox();
            this.lblObsrvName = new System.Windows.Forms.Label();
            this.grpObsrvtnTimestamp = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbEclipse = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.grpLocation = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLong = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCamera = new System.Windows.Forms.TextBox();
            this.txtIso = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtExposure = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbStage = new System.Windows.Forms.ComboBox();
            this.txtFocalLen = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtObscured = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtMagnitude = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDanjon = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lblTimestampErr = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRpts = new System.Windows.Forms.CheckBox();
            this.chkAlbumMisc = new System.Windows.Forms.CheckBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.dlgOpnFile = new System.Windows.Forms.OpenFileDialog();
            this.grpObsrvtnTimestamp.SuspendLayout();
            this.grpLocation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProfile
            // 
            this.btnProfile.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.customer;
            this.btnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.Location = new System.Drawing.Point(6, 250);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(32, 32);
            this.btnProfile.TabIndex = 93;
            this.btnProfile.UseVisualStyleBackColor = true;
            // 
            // btnDeleteImg
            // 
            this.btnDeleteImg.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Actions_trash_empty_icon;
            this.btnDeleteImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteImg.Location = new System.Drawing.Point(561, 112);
            this.btnDeleteImg.Name = "btnDeleteImg";
            this.btnDeleteImg.Size = new System.Drawing.Size(37, 37);
            this.btnDeleteImg.TabIndex = 92;
            this.btnDeleteImg.UseVisualStyleBackColor = true;
            this.btnDeleteImg.Click += new System.EventHandler(this.btnDeleteImg_Click);
            // 
            // ckOverride
            // 
            this.ckOverride.AutoSize = true;
            this.ckOverride.ForeColor = System.Drawing.Color.White;
            this.ckOverride.Location = new System.Drawing.Point(111, 237);
            this.ckOverride.Name = "ckOverride";
            this.ckOverride.Size = new System.Drawing.Size(72, 19);
            this.ckOverride.TabIndex = 91;
            this.ckOverride.Text = "Override";
            this.ckOverride.UseVisualStyleBackColor = true;
            this.ckOverride.CheckedChanged += new System.EventHandler(this.ckOverride_CheckedChanged);
            // 
            // btnGenSectRpt
            // 
            this.btnGenSectRpt.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.x_office_spreadsheet_icon;
            this.btnGenSectRpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenSectRpt.Location = new System.Drawing.Point(675, 581);
            this.btnGenSectRpt.Name = "btnGenSectRpt";
            this.btnGenSectRpt.Size = new System.Drawing.Size(37, 37);
            this.btnGenSectRpt.TabIndex = 90;
            this.btnGenSectRpt.UseVisualStyleBackColor = true;
            this.btnGenSectRpt.Click += new System.EventHandler(this.btnGenSectRpt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(238, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 89;
            this.label2.Text = "Telescope";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(49, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 88;
            this.label1.Text = "Observer";
            // 
            // cmbTelescopes
            // 
            this.cmbTelescopes.FormattingEnabled = true;
            this.cmbTelescopes.Location = new System.Drawing.Point(241, 255);
            this.cmbTelescopes.Name = "cmbTelescopes";
            this.cmbTelescopes.Size = new System.Drawing.Size(123, 23);
            this.cmbTelescopes.TabIndex = 87;
            // 
            // cmbObserver
            // 
            this.cmbObserver.FormattingEnabled = true;
            this.cmbObserver.Location = new System.Drawing.Point(49, 255);
            this.cmbObserver.Name = "cmbObserver";
            this.cmbObserver.Size = new System.Drawing.Size(134, 23);
            this.cmbObserver.TabIndex = 86;
            // 
            // lblOversized
            // 
            this.lblOversized.AutoSize = true;
            this.lblOversized.BackColor = System.Drawing.Color.Yellow;
            this.lblOversized.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOversized.ForeColor = System.Drawing.Color.Red;
            this.lblOversized.Location = new System.Drawing.Point(624, 0);
            this.lblOversized.Name = "lblOversized";
            this.lblOversized.Size = new System.Drawing.Size(88, 20);
            this.lblOversized.TabIndex = 85;
            this.lblOversized.Text = "Oversized";
            this.lblOversized.Visible = false;
            // 
            // btnParseFileForDate
            // 
            this.btnParseFileForDate.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.document_split_icon;
            this.btnParseFileForDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnParseFileForDate.Location = new System.Drawing.Point(6, 174);
            this.btnParseFileForDate.Name = "btnParseFileForDate";
            this.btnParseFileForDate.Size = new System.Drawing.Size(37, 37);
            this.btnParseFileForDate.TabIndex = 84;
            this.btnParseFileForDate.UseVisualStyleBackColor = true;
            this.btnParseFileForDate.Click += new System.EventHandler(this.btnParseFileForDate_Click);
            // 
            // dtObsrvTime
            // 
            this.dtObsrvTime.CalendarForeColor = System.Drawing.Color.Black;
            this.dtObsrvTime.CustomFormat = "HH:mm:ss";
            this.dtObsrvTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtObsrvTime.Location = new System.Drawing.Point(136, 19);
            this.dtObsrvTime.Name = "dtObsrvTime";
            this.dtObsrvTime.ShowUpDown = true;
            this.dtObsrvTime.Size = new System.Drawing.Size(73, 21);
            this.dtObsrvTime.TabIndex = 82;
            // 
            // ObsrvDate
            // 
            this.ObsrvDate.CustomFormat = "yyyy-MM-dd";
            this.ObsrvDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ObsrvDate.Location = new System.Drawing.Point(15, 19);
            this.ObsrvDate.Name = "ObsrvDate";
            this.ObsrvDate.ShowUpDown = true;
            this.ObsrvDate.Size = new System.Drawing.Size(97, 21);
            this.ObsrvDate.TabIndex = 81;
            // 
            // btnTrash
            // 
            this.btnTrash.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Actions_trash_empty_icon;
            this.btnTrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTrash.Location = new System.Drawing.Point(563, 23);
            this.btnTrash.Name = "btnTrash";
            this.btnTrash.Size = new System.Drawing.Size(37, 37);
            this.btnTrash.TabIndex = 80;
            this.btnTrash.UseVisualStyleBackColor = true;
            this.btnTrash.Click += new System.EventHandler(this.btnTrash_Click);
            // 
            // lstAttachments
            // 
            this.lstAttachments.FormattingEnabled = true;
            this.lstAttachments.ItemHeight = 15;
            this.lstAttachments.Location = new System.Drawing.Point(9, 101);
            this.lstAttachments.Name = "lstAttachments";
            this.lstAttachments.Size = new System.Drawing.Size(546, 49);
            this.lstAttachments.TabIndex = 79;
            this.lstAttachments.SelectedIndexChanged += new System.EventHandler(this.lstAttachments_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(10, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 15);
            this.label8.TabIndex = 78;
            this.label8.Text = "Attachments";
            // 
            // lstMsgs
            // 
            this.lstMsgs.FormattingEnabled = true;
            this.lstMsgs.ItemHeight = 15;
            this.lstMsgs.Location = new System.Drawing.Point(9, 23);
            this.lstMsgs.Name = "lstMsgs";
            this.lstMsgs.Size = new System.Drawing.Size(548, 49);
            this.lstMsgs.TabIndex = 77;
            this.lstMsgs.SelectedIndexChanged += new System.EventHandler(this.lstMsgs_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(9, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 15);
            this.label7.TabIndex = 76;
            this.label7.Text = "Submissions";
            // 
            // imgObservation
            // 
            this.imgObservation.Location = new System.Drawing.Point(671, 23);
            this.imgObservation.Name = "imgObservation";
            this.imgObservation.Size = new System.Drawing.Size(681, 549);
            this.imgObservation.TabIndex = 75;
            this.imgObservation.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // btnApndTags
            // 
            this.btnApndTags.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Upload_icon;
            this.btnApndTags.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnApndTags.Location = new System.Drawing.Point(362, 478);
            this.btnApndTags.Name = "btnApndTags";
            this.btnApndTags.Size = new System.Drawing.Size(32, 32);
            this.btnApndTags.TabIndex = 104;
            this.btnApndTags.UseVisualStyleBackColor = true;
            this.btnApndTags.Click += new System.EventHandler(this.btnApndTags_Click);
            // 
            // btnAddTags
            // 
            this.btnAddTags.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.UpArrow;
            this.btnAddTags.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddTags.Location = new System.Drawing.Point(362, 440);
            this.btnAddTags.Name = "btnAddTags";
            this.btnAddTags.Size = new System.Drawing.Size(32, 32);
            this.btnAddTags.TabIndex = 103;
            this.btnAddTags.UseVisualStyleBackColor = true;
            this.btnAddTags.Click += new System.EventHandler(this.btnAddTags_Click);
            // 
            // lstTags
            // 
            this.lstTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTags.FormattingEnabled = true;
            this.lstTags.ItemHeight = 15;
            this.lstTags.Location = new System.Drawing.Point(400, 440);
            this.lstTags.Name = "lstTags";
            this.lstTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTags.Size = new System.Drawing.Size(230, 154);
            this.lstTags.TabIndex = 102;
            // 
            // btnGenName
            // 
            this.btnGenName.BackgroundImage = global::ALPOGalleryTool.Properties.Resources._20_gear_2_icon;
            this.btnGenName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenName.Location = new System.Drawing.Point(750, 587);
            this.btnGenName.Name = "btnGenName";
            this.btnGenName.Size = new System.Drawing.Size(24, 24);
            this.btnGenName.TabIndex = 101;
            this.btnGenName.UseVisualStyleBackColor = true;
            this.btnGenName.Click += new System.EventHandler(this.btnGenName_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.create_map_icon;
            this.btnProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProcess.Location = new System.Drawing.Point(718, 587);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(24, 24);
            this.btnProcess.TabIndex = 100;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtTags
            // 
            this.txtTags.Location = new System.Drawing.Point(235, 606);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(399, 21);
            this.txtTags.TabIndex = 95;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(12, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 99;
            this.label5.Text = "Notes";
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(12, 440);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(338, 102);
            this.rtbNotes.TabIndex = 98;
            this.rtbNotes.Text = "";
            // 
            // lstFilters
            // 
            this.lstFilters.FormattingEnabled = true;
            this.lstFilters.ItemHeight = 15;
            this.lstFilters.Location = new System.Drawing.Point(11, 578);
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstFilters.Size = new System.Drawing.Size(78, 79);
            this.lstFilters.TabIndex = 97;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(15, 560);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 96;
            this.label4.Text = "Filter";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFileName.Location = new System.Drawing.Point(780, 592);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(69, 16);
            this.lblFileName.TabIndex = 94;
            this.lblFileName.Text = "File Name";
            // 
            // txtTrnsp
            // 
            this.txtTrnsp.Location = new System.Drawing.Point(589, 257);
            this.txtTrnsp.Name = "txtTrnsp";
            this.txtTrnsp.Size = new System.Drawing.Size(45, 21);
            this.txtTrnsp.TabIndex = 106;
            this.txtTrnsp.Text = "0";
            this.txtTrnsp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(589, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 108;
            this.label3.Text = "Transp";
            // 
            // txtSeeing
            // 
            this.txtSeeing.Location = new System.Drawing.Point(529, 257);
            this.txtSeeing.Name = "txtSeeing";
            this.txtSeeing.Size = new System.Drawing.Size(42, 21);
            this.txtSeeing.TabIndex = 105;
            this.txtSeeing.Text = "0";
            this.txtSeeing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(526, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 107;
            this.label6.Text = "Seeing";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(97, 560);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 15);
            this.label9.TabIndex = 110;
            this.label9.Text = "2nd Filter";
            // 
            // lstOtherFltr
            // 
            this.lstOtherFltr.FormattingEnabled = true;
            this.lstOtherFltr.ItemHeight = 15;
            this.lstOtherFltr.Location = new System.Drawing.Point(100, 578);
            this.lstOtherFltr.Name = "lstOtherFltr";
            this.lstOtherFltr.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstOtherFltr.Size = new System.Drawing.Size(83, 79);
            this.lstOtherFltr.TabIndex = 109;
            // 
            // lblObsrvName
            // 
            this.lblObsrvName.AutoSize = true;
            this.lblObsrvName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblObsrvName.Location = new System.Drawing.Point(49, 281);
            this.lblObsrvName.Name = "lblObsrvName";
            this.lblObsrvName.Size = new System.Drawing.Size(41, 15);
            this.lblObsrvName.TabIndex = 111;
            this.lblObsrvName.Text = "Name";
            // 
            // grpObsrvtnTimestamp
            // 
            this.grpObsrvtnTimestamp.Controls.Add(this.ObsrvDate);
            this.grpObsrvtnTimestamp.Controls.Add(this.dtObsrvTime);
            this.grpObsrvtnTimestamp.ForeColor = System.Drawing.Color.White;
            this.grpObsrvtnTimestamp.Location = new System.Drawing.Point(49, 165);
            this.grpObsrvtnTimestamp.Name = "grpObsrvtnTimestamp";
            this.grpObsrvtnTimestamp.Size = new System.Drawing.Size(227, 46);
            this.grpObsrvtnTimestamp.TabIndex = 112;
            this.grpObsrvtnTimestamp.TabStop = false;
            this.grpObsrvtnTimestamp.Text = "Observation Timestamp";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(232, 588);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 15);
            this.label10.TabIndex = 113;
            this.label10.Text = "Tags";
            // 
            // cmbEclipse
            // 
            this.cmbEclipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEclipse.FormattingEnabled = true;
            this.cmbEclipse.Location = new System.Drawing.Point(49, 329);
            this.cmbEclipse.Name = "cmbEclipse";
            this.cmbEclipse.Size = new System.Drawing.Size(110, 21);
            this.cmbEclipse.TabIndex = 114;
            this.cmbEclipse.SelectedIndexChanged += new System.EventHandler(this.cmbEclipse_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(51, 311);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 115;
            this.label11.Text = "Eclipse Event";
            // 
            // grpLocation
            // 
            this.grpLocation.Controls.Add(this.label13);
            this.grpLocation.Controls.Add(this.txtLong);
            this.grpLocation.Controls.Add(this.label12);
            this.grpLocation.Controls.Add(this.txtLat);
            this.grpLocation.Controls.Add(this.txtLocation);
            this.grpLocation.ForeColor = System.Drawing.Color.White;
            this.grpLocation.Location = new System.Drawing.Point(294, 165);
            this.grpLocation.Name = "grpLocation";
            this.grpLocation.Size = new System.Drawing.Size(326, 46);
            this.grpLocation.TabIndex = 116;
            this.grpLocation.TabStop = false;
            this.grpLocation.Text = "Location";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(213, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 15);
            this.label13.TabIndex = 4;
            this.label13.Text = "Long:";
            // 
            // txtLong
            // 
            this.txtLong.Location = new System.Drawing.Point(257, 17);
            this.txtLong.Name = "txtLong";
            this.txtLong.Size = new System.Drawing.Size(52, 21);
            this.txtLong.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(118, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Lat:";
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(151, 17);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(52, 21);
            this.txtLat.TabIndex = 1;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(11, 17);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(100, 21);
            this.txtLocation.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(374, 239);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 15);
            this.label14.TabIndex = 117;
            this.label14.Text = "Camera";
            // 
            // txtCamera
            // 
            this.txtCamera.Location = new System.Drawing.Point(377, 257);
            this.txtCamera.Name = "txtCamera";
            this.txtCamera.Size = new System.Drawing.Size(114, 21);
            this.txtCamera.TabIndex = 118;
            // 
            // txtIso
            // 
            this.txtIso.Location = new System.Drawing.Point(377, 306);
            this.txtIso.Name = "txtIso";
            this.txtIso.Size = new System.Drawing.Size(48, 21);
            this.txtIso.TabIndex = 120;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label15.Location = new System.Drawing.Point(374, 288);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 15);
            this.label15.TabIndex = 119;
            this.label15.Text = "ISO";
            // 
            // txtExposure
            // 
            this.txtExposure.Location = new System.Drawing.Point(377, 361);
            this.txtExposure.Name = "txtExposure";
            this.txtExposure.Size = new System.Drawing.Size(69, 21);
            this.txtExposure.TabIndex = 122;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label16.Location = new System.Drawing.Point(374, 343);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 15);
            this.label16.TabIndex = 121;
            this.label16.Text = "Exposure";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label17.Location = new System.Drawing.Point(51, 366);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 13);
            this.label17.TabIndex = 124;
            this.label17.Text = "Eclipse Stage";
            // 
            // cmbStage
            // 
            this.cmbStage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStage.FormattingEnabled = true;
            this.cmbStage.Items.AddRange(new object[] {
            "Penumbral",
            "Partial",
            "Totality",
            "Annularity",
            "C1",
            "C2",
            "C3",
            "C4",
            "All",
            "Undefined"});
            this.cmbStage.Location = new System.Drawing.Point(49, 384);
            this.cmbStage.Name = "cmbStage";
            this.cmbStage.Size = new System.Drawing.Size(110, 21);
            this.cmbStage.TabIndex = 123;
            // 
            // txtFocalLen
            // 
            this.txtFocalLen.Location = new System.Drawing.Point(241, 311);
            this.txtFocalLen.Name = "txtFocalLen";
            this.txtFocalLen.Size = new System.Drawing.Size(69, 21);
            this.txtFocalLen.TabIndex = 126;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label18.Location = new System.Drawing.Point(238, 293);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 15);
            this.label18.TabIndex = 125;
            this.label18.Text = "Focal Length";
            // 
            // txtObscured
            // 
            this.txtObscured.Location = new System.Drawing.Point(563, 358);
            this.txtObscured.Name = "txtObscured";
            this.txtObscured.Size = new System.Drawing.Size(45, 21);
            this.txtObscured.TabIndex = 128;
            this.txtObscured.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label19.Location = new System.Drawing.Point(551, 340);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 15);
            this.label19.TabIndex = 130;
            this.label19.Text = "Obscuration";
            // 
            // txtMagnitude
            // 
            this.txtMagnitude.Location = new System.Drawing.Point(563, 311);
            this.txtMagnitude.Name = "txtMagnitude";
            this.txtMagnitude.Size = new System.Drawing.Size(42, 21);
            this.txtMagnitude.TabIndex = 127;
            this.txtMagnitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label20.Location = new System.Drawing.Point(551, 291);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 15);
            this.label20.TabIndex = 129;
            this.label20.Text = "Magnitude";
            // 
            // txtDanjon
            // 
            this.txtDanjon.Location = new System.Drawing.Point(563, 404);
            this.txtDanjon.Name = "txtDanjon";
            this.txtDanjon.Size = new System.Drawing.Size(45, 21);
            this.txtDanjon.TabIndex = 131;
            this.txtDanjon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label21.Location = new System.Drawing.Point(561, 386);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 15);
            this.label21.TabIndex = 132;
            this.label21.Text = "Danjon";
            // 
            // lblTimestampErr
            // 
            this.lblTimestampErr.AutoSize = true;
            this.lblTimestampErr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblTimestampErr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTimestampErr.Location = new System.Drawing.Point(51, 214);
            this.lblTimestampErr.Name = "lblTimestampErr";
            this.lblTimestampErr.Size = new System.Drawing.Size(99, 15);
            this.lblTimestampErr.TabIndex = 133;
            this.lblTimestampErr.Text = "Timestamp Error";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRpts);
            this.groupBox1.Controls.Add(this.chkAlbumMisc);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(185, 343);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 78);
            this.groupBox1.TabIndex = 134;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Specialty Albums";
            // 
            // chkRpts
            // 
            this.chkRpts.AutoSize = true;
            this.chkRpts.Location = new System.Drawing.Point(16, 48);
            this.chkRpts.Name = "chkRpts";
            this.chkRpts.Size = new System.Drawing.Size(69, 19);
            this.chkRpts.TabIndex = 1;
            this.chkRpts.Text = "Reports";
            this.chkRpts.UseVisualStyleBackColor = true;
            // 
            // chkAlbumMisc
            // 
            this.chkAlbumMisc.AutoSize = true;
            this.chkAlbumMisc.Location = new System.Drawing.Point(16, 23);
            this.chkAlbumMisc.Name = "chkAlbumMisc";
            this.chkAlbumMisc.Size = new System.Drawing.Size(52, 19);
            this.chkAlbumMisc.TabIndex = 0;
            this.chkAlbumMisc.Text = "Misc";
            this.chkAlbumMisc.UseVisualStyleBackColor = true;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Folder_photos_icon;
            this.btnLoadFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadFile.Location = new System.Drawing.Point(628, 25);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(36, 36);
            this.btnLoadFile.TabIndex = 135;
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // FrmEclipse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1364, 667);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTimestampErr);
            this.Controls.Add(this.txtDanjon);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtObscured);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtMagnitude);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtFocalLen);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbStage);
            this.Controls.Add(this.txtExposure);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtIso);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtCamera);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.grpLocation);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbEclipse);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grpObsrvtnTimestamp);
            this.Controls.Add(this.lblObsrvName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lstOtherFltr);
            this.Controls.Add(this.txtTrnsp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSeeing);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnApndTags);
            this.Controls.Add(this.btnAddTags);
            this.Controls.Add(this.lstTags);
            this.Controls.Add(this.btnGenName);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtTags);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.lstFilters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnDeleteImg);
            this.Controls.Add(this.ckOverride);
            this.Controls.Add(this.btnGenSectRpt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTelescopes);
            this.Controls.Add(this.cmbObserver);
            this.Controls.Add(this.lblOversized);
            this.Controls.Add(this.btnParseFileForDate);
            this.Controls.Add(this.btnTrash);
            this.Controls.Add(this.lstAttachments);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lstMsgs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.imgObservation);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmEclipse";
            this.Text = "Eclipse Observation";
            this.Shown += new System.EventHandler(this.FrmEclipse_Shown);
            this.grpObsrvtnTimestamp.ResumeLayout(false);
            this.grpLocation.ResumeLayout(false);
            this.grpLocation.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnDeleteImg;
        private System.Windows.Forms.CheckBox ckOverride;
        private System.Windows.Forms.Button btnGenSectRpt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTelescopes;
        private System.Windows.Forms.ComboBox cmbObserver;
        private System.Windows.Forms.Label lblOversized;
        private System.Windows.Forms.Button btnParseFileForDate;
        private System.Windows.Forms.DateTimePicker dtObsrvTime;
        private System.Windows.Forms.DateTimePicker ObsrvDate;
        private System.Windows.Forms.Button btnTrash;
        private System.Windows.Forms.ListBox lstAttachments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstMsgs;
        private System.Windows.Forms.Label label7;
        private Cyotek.Windows.Forms.ImageBox imgObservation;
        private System.Windows.Forms.Button btnApndTags;
        private System.Windows.Forms.Button btnAddTags;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.Button btnGenName;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.ListBox lstFilters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtTrnsp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSeeing;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lstOtherFltr;
        private System.Windows.Forms.Label lblObsrvName;
        private System.Windows.Forms.GroupBox grpObsrvtnTimestamp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbEclipse;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grpLocation;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLong;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCamera;
        private System.Windows.Forms.TextBox txtIso;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtExposure;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbStage;
        private System.Windows.Forms.TextBox txtFocalLen;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtObscured;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtMagnitude;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDanjon;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblTimestampErr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAlbumMisc;
        private System.Windows.Forms.CheckBox chkRpts;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.OpenFileDialog dlgOpnFile;
    }
}