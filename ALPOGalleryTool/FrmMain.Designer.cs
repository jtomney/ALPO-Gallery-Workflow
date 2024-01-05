namespace ALPOGalleryTool
{
    partial class FrmMain
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
            this.tabPlanets = new System.Windows.Forms.TabControl();
            this.tabSolar = new System.Windows.Forms.TabPage();
            this.ckOverride = new System.Windows.Forms.CheckBox();
            this.cmbTelescopes = new System.Windows.Forms.ComboBox();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.btnGenerateCm = new System.Windows.Forms.Button();
            this.btnShrink = new System.Windows.Forms.Button();
            this.btnAddScope = new System.Windows.Forms.Button();
            this.btnImgSelFolder = new System.Windows.Forms.PictureBox();
            this.btnTrimFileName = new System.Windows.Forms.Button();
            this.btnTrash = new System.Windows.Forms.Button();
            this.lblOversized = new System.Windows.Forms.Label();
            this.btnParseFileForDate = new System.Windows.Forms.Button();
            this.btnGenSectRpt = new System.Windows.Forms.Button();
            this.TenthsMin = new System.Windows.Forms.NumericUpDown();
            this.btnGenName = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lstAttachments = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lstMsgs = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.lstFilters = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTrnsp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSeeing = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.cmbSections = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imgObservation = new Cyotek.Windows.Forms.ImageBox();
            this.btnAddObsrvr = new System.Windows.Forms.Button();
            this.cmbObserver = new System.Windows.Forms.ComboBox();
            this.dtObsrvTime = new System.Windows.Forms.DateTimePicker();
            this.ObsrvDate = new System.Windows.Forms.DateTimePicker();
            this.tabVenus = new System.Windows.Forms.TabPage();
            this.lstImgsToProcess = new System.Windows.Forms.ListBox();
            this.lblImgFolder = new System.Windows.Forms.Label();
            this.btnImgFldrSelect = new System.Windows.Forms.PictureBox();
            this.tabMars = new System.Windows.Forms.TabPage();
            this.tabJupiter = new System.Windows.Forms.TabPage();
            this.tabSaturn = new System.Windows.Forms.TabPage();
            this.btnLoadRptByObj = new System.Windows.Forms.Button();
            this.dgvwByObject = new System.Windows.Forms.DataGridView();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.fldrDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.txtOffset1 = new System.Windows.Forms.TextBox();
            this.txtOffset2 = new System.Windows.Forms.TextBox();
            this.txtOffset3 = new System.Windows.Forms.TextBox();
            this.tabPlanets.SuspendLayout();
            this.tabSolar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImgSelFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenthsMin)).BeginInit();
            this.tabVenus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImgFldrSelect)).BeginInit();
            this.tabSaturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvwByObject)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPlanets
            // 
            this.tabPlanets.Controls.Add(this.tabSolar);
            this.tabPlanets.Controls.Add(this.tabVenus);
            this.tabPlanets.Controls.Add(this.tabMars);
            this.tabPlanets.Controls.Add(this.tabJupiter);
            this.tabPlanets.Controls.Add(this.tabSaturn);
            this.tabPlanets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPlanets.Location = new System.Drawing.Point(0, 0);
            this.tabPlanets.Name = "tabPlanets";
            this.tabPlanets.SelectedIndex = 0;
            this.tabPlanets.Size = new System.Drawing.Size(1351, 749);
            this.tabPlanets.TabIndex = 0;
            // 
            // tabSolar
            // 
            this.tabSolar.BackColor = System.Drawing.Color.Black;
            this.tabSolar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabSolar.Controls.Add(this.txtOffset3);
            this.tabSolar.Controls.Add(this.txtOffset2);
            this.tabSolar.Controls.Add(this.txtOffset1);
            this.tabSolar.Controls.Add(this.ckOverride);
            this.tabSolar.Controls.Add(this.cmbTelescopes);
            this.tabSolar.Controls.Add(this.lstTags);
            this.tabSolar.Controls.Add(this.btnGenerateCm);
            this.tabSolar.Controls.Add(this.btnShrink);
            this.tabSolar.Controls.Add(this.btnAddScope);
            this.tabSolar.Controls.Add(this.btnImgSelFolder);
            this.tabSolar.Controls.Add(this.btnTrimFileName);
            this.tabSolar.Controls.Add(this.btnTrash);
            this.tabSolar.Controls.Add(this.lblOversized);
            this.tabSolar.Controls.Add(this.btnParseFileForDate);
            this.tabSolar.Controls.Add(this.btnGenSectRpt);
            this.tabSolar.Controls.Add(this.TenthsMin);
            this.tabSolar.Controls.Add(this.btnGenName);
            this.tabSolar.Controls.Add(this.label9);
            this.tabSolar.Controls.Add(this.btnProcess);
            this.tabSolar.Controls.Add(this.lstAttachments);
            this.tabSolar.Controls.Add(this.label8);
            this.tabSolar.Controls.Add(this.lstMsgs);
            this.tabSolar.Controls.Add(this.label7);
            this.tabSolar.Controls.Add(this.txtTags);
            this.tabSolar.Controls.Add(this.label6);
            this.tabSolar.Controls.Add(this.label5);
            this.tabSolar.Controls.Add(this.rtbNotes);
            this.tabSolar.Controls.Add(this.lstFilters);
            this.tabSolar.Controls.Add(this.label4);
            this.tabSolar.Controls.Add(this.txtTrnsp);
            this.tabSolar.Controls.Add(this.label3);
            this.tabSolar.Controls.Add(this.txtSeeing);
            this.tabSolar.Controls.Add(this.label2);
            this.tabSolar.Controls.Add(this.lblFileName);
            this.tabSolar.Controls.Add(this.cmbSections);
            this.tabSolar.Controls.Add(this.label1);
            this.tabSolar.Controls.Add(this.imgObservation);
            this.tabSolar.Controls.Add(this.btnAddObsrvr);
            this.tabSolar.Controls.Add(this.cmbObserver);
            this.tabSolar.Controls.Add(this.dtObsrvTime);
            this.tabSolar.Controls.Add(this.ObsrvDate);
            this.tabSolar.Location = new System.Drawing.Point(4, 26);
            this.tabSolar.Name = "tabSolar";
            this.tabSolar.Padding = new System.Windows.Forms.Padding(3);
            this.tabSolar.Size = new System.Drawing.Size(1343, 719);
            this.tabSolar.TabIndex = 0;
            this.tabSolar.Text = "Solar";
            // 
            // ckOverride
            // 
            this.ckOverride.AutoSize = true;
            this.ckOverride.ForeColor = System.Drawing.Color.White;
            this.ckOverride.Location = new System.Drawing.Point(21, 335);
            this.ckOverride.Name = "ckOverride";
            this.ckOverride.Size = new System.Drawing.Size(83, 22);
            this.ckOverride.TabIndex = 41;
            this.ckOverride.Text = "Override";
            this.ckOverride.UseVisualStyleBackColor = true;
            // 
            // cmbTelescopes
            // 
            this.cmbTelescopes.FormattingEnabled = true;
            this.cmbTelescopes.Location = new System.Drawing.Point(351, 301);
            this.cmbTelescopes.Name = "cmbTelescopes";
            this.cmbTelescopes.Size = new System.Drawing.Size(231, 25);
            this.cmbTelescopes.TabIndex = 40;
            // 
            // lstTags
            // 
            this.lstTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTags.FormattingEnabled = true;
            this.lstTags.ItemHeight = 16;
            this.lstTags.Location = new System.Drawing.Point(425, 465);
            this.lstTags.Name = "lstTags";
            this.lstTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTags.Size = new System.Drawing.Size(198, 180);
            this.lstTags.TabIndex = 39;
            this.lstTags.DoubleClick += new System.EventHandler(this.lstTags_DoubleClick);
            // 
            // btnGenerateCm
            // 
            this.btnGenerateCm.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Maps_Globe_Filled_icon;
            this.btnGenerateCm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerateCm.Location = new System.Drawing.Point(644, 403);
            this.btnGenerateCm.Name = "btnGenerateCm";
            this.btnGenerateCm.Size = new System.Drawing.Size(32, 32);
            this.btnGenerateCm.TabIndex = 38;
            this.btnGenerateCm.UseVisualStyleBackColor = true;
            this.btnGenerateCm.Click += new System.EventHandler(this.btnGenerateCm_Click);
            // 
            // btnShrink
            // 
            this.btnShrink.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Telescope_Reflecting_icon;
            this.btnShrink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShrink.Location = new System.Drawing.Point(658, 253);
            this.btnShrink.Name = "btnShrink";
            this.btnShrink.Size = new System.Drawing.Size(32, 32);
            this.btnShrink.TabIndex = 37;
            this.btnShrink.UseVisualStyleBackColor = true;
            this.btnShrink.Click += new System.EventHandler(this.btnShrink_Click);
            // 
            // btnAddScope
            // 
            this.btnAddScope.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Telescope_Reflecting_icon;
            this.btnAddScope.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddScope.Location = new System.Drawing.Point(591, 301);
            this.btnAddScope.Name = "btnAddScope";
            this.btnAddScope.Size = new System.Drawing.Size(32, 32);
            this.btnAddScope.TabIndex = 36;
            this.btnAddScope.UseVisualStyleBackColor = true;
            this.btnAddScope.Click += new System.EventHandler(this.btnAddScope_Click);
            // 
            // btnImgSelFolder
            // 
            this.btnImgSelFolder.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Folder_photos_icon;
            this.btnImgSelFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImgSelFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImgSelFolder.Location = new System.Drawing.Point(82, 164);
            this.btnImgSelFolder.Name = "btnImgSelFolder";
            this.btnImgSelFolder.Size = new System.Drawing.Size(48, 48);
            this.btnImgSelFolder.TabIndex = 35;
            this.btnImgSelFolder.TabStop = false;
            this.btnImgSelFolder.Click += new System.EventHandler(this.btnImgSelFolder_Click);
            // 
            // btnTrimFileName
            // 
            this.btnTrimFileName.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.minus_icon;
            this.btnTrimFileName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTrimFileName.Location = new System.Drawing.Point(425, 249);
            this.btnTrimFileName.Name = "btnTrimFileName";
            this.btnTrimFileName.Size = new System.Drawing.Size(32, 32);
            this.btnTrimFileName.TabIndex = 34;
            this.btnTrimFileName.UseVisualStyleBackColor = true;
            this.btnTrimFileName.Click += new System.EventHandler(this.btnTrimFileName_Click);
            // 
            // btnTrash
            // 
            this.btnTrash.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Actions_trash_empty_icon;
            this.btnTrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTrash.Location = new System.Drawing.Point(644, 21);
            this.btnTrash.Name = "btnTrash";
            this.btnTrash.Size = new System.Drawing.Size(32, 32);
            this.btnTrash.TabIndex = 33;
            this.btnTrash.UseVisualStyleBackColor = true;
            this.btnTrash.Click += new System.EventHandler(this.btnTrash_Click);
            // 
            // lblOversized
            // 
            this.lblOversized.AutoSize = true;
            this.lblOversized.BackColor = System.Drawing.Color.Yellow;
            this.lblOversized.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOversized.ForeColor = System.Drawing.Color.Red;
            this.lblOversized.Location = new System.Drawing.Point(528, 256);
            this.lblOversized.Name = "lblOversized";
            this.lblOversized.Size = new System.Drawing.Size(88, 20);
            this.lblOversized.TabIndex = 32;
            this.lblOversized.Text = "Oversized";
            this.lblOversized.Visible = false;
            // 
            // btnParseFileForDate
            // 
            this.btnParseFileForDate.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.document_split_icon;
            this.btnParseFileForDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnParseFileForDate.Location = new System.Drawing.Point(383, 249);
            this.btnParseFileForDate.Name = "btnParseFileForDate";
            this.btnParseFileForDate.Size = new System.Drawing.Size(32, 32);
            this.btnParseFileForDate.TabIndex = 31;
            this.btnParseFileForDate.UseVisualStyleBackColor = true;
            this.btnParseFileForDate.Click += new System.EventHandler(this.btnParseFileForDate_Click);
            // 
            // btnGenSectRpt
            // 
            this.btnGenSectRpt.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.x_office_spreadsheet_icon;
            this.btnGenSectRpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenSectRpt.Location = new System.Drawing.Point(629, 536);
            this.btnGenSectRpt.Name = "btnGenSectRpt";
            this.btnGenSectRpt.Size = new System.Drawing.Size(32, 32);
            this.btnGenSectRpt.TabIndex = 30;
            this.btnGenSectRpt.UseVisualStyleBackColor = true;
            this.btnGenSectRpt.Click += new System.EventHandler(this.btnGenSectionRpt_Click);
            // 
            // TenthsMin
            // 
            this.TenthsMin.Location = new System.Drawing.Point(311, 249);
            this.TenthsMin.Name = "TenthsMin";
            this.TenthsMin.Size = new System.Drawing.Size(44, 24);
            this.TenthsMin.TabIndex = 4;
            // 
            // btnGenName
            // 
            this.btnGenName.BackgroundImage = global::ALPOGalleryTool.Properties.Resources._20_gear_2_icon;
            this.btnGenName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenName.Location = new System.Drawing.Point(669, 604);
            this.btnGenName.Name = "btnGenName";
            this.btnGenName.Size = new System.Drawing.Size(36, 36);
            this.btnGenName.TabIndex = 28;
            this.btnGenName.UseVisualStyleBackColor = true;
            this.btnGenName.Click += new System.EventHandler(this.btnGenName_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(280, 301);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 18);
            this.label9.TabIndex = 26;
            this.label9.Text = "Scope";
            // 
            // btnProcess
            // 
            this.btnProcess.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.create_map_icon;
            this.btnProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProcess.Location = new System.Drawing.Point(631, 606);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(32, 32);
            this.btnProcess.TabIndex = 25;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lstAttachments
            // 
            this.lstAttachments.FormattingEnabled = true;
            this.lstAttachments.ItemHeight = 17;
            this.lstAttachments.Location = new System.Drawing.Point(169, 137);
            this.lstAttachments.Name = "lstAttachments";
            this.lstAttachments.Size = new System.Drawing.Size(469, 55);
            this.lstAttachments.TabIndex = 24;
            this.lstAttachments.SelectedIndexChanged += new System.EventHandler(this.lstAttachments_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(17, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "Attachments";
            // 
            // lstMsgs
            // 
            this.lstMsgs.FormattingEnabled = true;
            this.lstMsgs.ItemHeight = 17;
            this.lstMsgs.Location = new System.Drawing.Point(168, 21);
            this.lstMsgs.Name = "lstMsgs";
            this.lstMsgs.Size = new System.Drawing.Size(470, 89);
            this.lstMsgs.TabIndex = 22;
            this.lstMsgs.SelectedIndexChanged += new System.EventHandler(this.lstMsgs_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(17, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 18);
            this.label7.TabIndex = 21;
            this.label7.Text = "Submissions";
            // 
            // txtTags
            // 
            this.txtTags.Location = new System.Drawing.Point(350, 405);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(282, 24);
            this.txtTags.TabIndex = 10;
            this.txtTags.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtTags_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(281, 405);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "Tags";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(17, 592);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "Notes";
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(82, 589);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(300, 64);
            this.rtbNotes.TabIndex = 17;
            this.rtbNotes.Text = "";
            // 
            // lstFilters
            // 
            this.lstFilters.FormattingEnabled = true;
            this.lstFilters.ItemHeight = 17;
            this.lstFilters.Location = new System.Drawing.Point(82, 370);
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstFilters.Size = new System.Drawing.Size(147, 191);
            this.lstFilters.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(17, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "Filter";
            // 
            // txtTrnsp
            // 
            this.txtTrnsp.Location = new System.Drawing.Point(533, 349);
            this.txtTrnsp.Name = "txtTrnsp";
            this.txtTrnsp.Size = new System.Drawing.Size(49, 24);
            this.txtTrnsp.TabIndex = 7;
            this.txtTrnsp.Text = "0";
            this.txtTrnsp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(457, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Transp";
            // 
            // txtSeeing
            // 
            this.txtSeeing.Location = new System.Drawing.Point(366, 349);
            this.txtSeeing.Name = "txtSeeing";
            this.txtSeeing.Size = new System.Drawing.Size(49, 24);
            this.txtSeeing.TabIndex = 6;
            this.txtSeeing.Text = "0";
            this.txtSeeing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(281, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Seeing";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFileName.Location = new System.Drawing.Point(711, 614);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(75, 18);
            this.lblFileName.TabIndex = 9;
            this.lblFileName.Text = "File Name";
            // 
            // cmbSections
            // 
            this.cmbSections.FormattingEnabled = true;
            this.cmbSections.Location = new System.Drawing.Point(759, 536);
            this.cmbSections.Name = "cmbSections";
            this.cmbSections.Size = new System.Drawing.Size(140, 25);
            this.cmbSections.TabIndex = 8;
            this.cmbSections.SelectedIndexChanged += new System.EventHandler(this.cmbSections_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(695, 539);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Section";
            // 
            // imgObservation
            // 
            this.imgObservation.Location = new System.Drawing.Point(759, 21);
            this.imgObservation.Name = "imgObservation";
            this.imgObservation.Size = new System.Drawing.Size(565, 493);
            this.imgObservation.TabIndex = 6;
            this.imgObservation.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // btnAddObsrvr
            // 
            this.btnAddObsrvr.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.user_add_icon;
            this.btnAddObsrvr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddObsrvr.Location = new System.Drawing.Point(225, 297);
            this.btnAddObsrvr.Name = "btnAddObsrvr";
            this.btnAddObsrvr.Size = new System.Drawing.Size(32, 32);
            this.btnAddObsrvr.TabIndex = 5;
            this.btnAddObsrvr.UseVisualStyleBackColor = true;
            this.btnAddObsrvr.Click += new System.EventHandler(this.btnAddObsrvr_Click);
            // 
            // cmbObserver
            // 
            this.cmbObserver.FormattingEnabled = true;
            this.cmbObserver.Location = new System.Drawing.Point(21, 299);
            this.cmbObserver.Name = "cmbObserver";
            this.cmbObserver.Size = new System.Drawing.Size(191, 25);
            this.cmbObserver.TabIndex = 5;
            this.cmbObserver.SelectedIndexChanged += new System.EventHandler(this.cmbObserver_SelectedIndexChanged);
            // 
            // dtObsrvTime
            // 
            this.dtObsrvTime.CustomFormat = "HHmm";
            this.dtObsrvTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtObsrvTime.Location = new System.Drawing.Point(192, 249);
            this.dtObsrvTime.Name = "dtObsrvTime";
            this.dtObsrvTime.ShowUpDown = true;
            this.dtObsrvTime.Size = new System.Drawing.Size(91, 24);
            this.dtObsrvTime.TabIndex = 3;
            // 
            // ObsrvDate
            // 
            this.ObsrvDate.CustomFormat = "yyyy-MM-dd";
            this.ObsrvDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ObsrvDate.Location = new System.Drawing.Point(21, 249);
            this.ObsrvDate.Name = "ObsrvDate";
            this.ObsrvDate.ShowUpDown = true;
            this.ObsrvDate.Size = new System.Drawing.Size(145, 24);
            this.ObsrvDate.TabIndex = 2;
            // 
            // tabVenus
            // 
            this.tabVenus.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabVenus.Controls.Add(this.lstImgsToProcess);
            this.tabVenus.Controls.Add(this.lblImgFolder);
            this.tabVenus.Controls.Add(this.btnImgFldrSelect);
            this.tabVenus.Location = new System.Drawing.Point(4, 26);
            this.tabVenus.Name = "tabVenus";
            this.tabVenus.Padding = new System.Windows.Forms.Padding(3);
            this.tabVenus.Size = new System.Drawing.Size(1343, 719);
            this.tabVenus.TabIndex = 4;
            this.tabVenus.Text = "Venus";
            // 
            // lstImgsToProcess
            // 
            this.lstImgsToProcess.FormattingEnabled = true;
            this.lstImgsToProcess.ItemHeight = 17;
            this.lstImgsToProcess.Location = new System.Drawing.Point(102, 81);
            this.lstImgsToProcess.Name = "lstImgsToProcess";
            this.lstImgsToProcess.Size = new System.Drawing.Size(605, 123);
            this.lstImgsToProcess.TabIndex = 3;
            // 
            // lblImgFolder
            // 
            this.lblImgFolder.AutoSize = true;
            this.lblImgFolder.Location = new System.Drawing.Point(98, 40);
            this.lblImgFolder.Name = "lblImgFolder";
            this.lblImgFolder.Size = new System.Drawing.Size(45, 18);
            this.lblImgFolder.TabIndex = 2;
            this.lblImgFolder.Text = "folder";
            // 
            // btnImgFldrSelect
            // 
            this.btnImgFldrSelect.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Folder_photos_icon;
            this.btnImgFldrSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImgFldrSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImgFldrSelect.Location = new System.Drawing.Point(34, 40);
            this.btnImgFldrSelect.Name = "btnImgFldrSelect";
            this.btnImgFldrSelect.Size = new System.Drawing.Size(48, 48);
            this.btnImgFldrSelect.TabIndex = 1;
            this.btnImgFldrSelect.TabStop = false;
            this.btnImgFldrSelect.Click += new System.EventHandler(this.btnImgFldrSelect_Click);
            // 
            // tabMars
            // 
            this.tabMars.Location = new System.Drawing.Point(4, 26);
            this.tabMars.Name = "tabMars";
            this.tabMars.Size = new System.Drawing.Size(1343, 719);
            this.tabMars.TabIndex = 2;
            this.tabMars.Text = "Mars";
            this.tabMars.UseVisualStyleBackColor = true;
            // 
            // tabJupiter
            // 
            this.tabJupiter.Location = new System.Drawing.Point(4, 26);
            this.tabJupiter.Name = "tabJupiter";
            this.tabJupiter.Padding = new System.Windows.Forms.Padding(3);
            this.tabJupiter.Size = new System.Drawing.Size(1343, 719);
            this.tabJupiter.TabIndex = 1;
            this.tabJupiter.Text = "Jupiter";
            this.tabJupiter.UseVisualStyleBackColor = true;
            // 
            // tabSaturn
            // 
            this.tabSaturn.Controls.Add(this.btnLoadRptByObj);
            this.tabSaturn.Controls.Add(this.dgvwByObject);
            this.tabSaturn.Controls.Add(this.dtEnd);
            this.tabSaturn.Controls.Add(this.dtStart);
            this.tabSaturn.Location = new System.Drawing.Point(4, 26);
            this.tabSaturn.Name = "tabSaturn";
            this.tabSaturn.Padding = new System.Windows.Forms.Padding(3);
            this.tabSaturn.Size = new System.Drawing.Size(1343, 719);
            this.tabSaturn.TabIndex = 3;
            this.tabSaturn.Text = "Saturn";
            this.tabSaturn.UseVisualStyleBackColor = true;
            // 
            // btnLoadRptByObj
            // 
            this.btnLoadRptByObj.Location = new System.Drawing.Point(410, 124);
            this.btnLoadRptByObj.Name = "btnLoadRptByObj";
            this.btnLoadRptByObj.Size = new System.Drawing.Size(75, 37);
            this.btnLoadRptByObj.TabIndex = 3;
            this.btnLoadRptByObj.Text = "Object";
            this.btnLoadRptByObj.UseVisualStyleBackColor = true;
            this.btnLoadRptByObj.Click += new System.EventHandler(this.btnLoadRptByObj_Click);
            // 
            // dgvwByObject
            // 
            this.dgvwByObject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvwByObject.Location = new System.Drawing.Point(36, 124);
            this.dgvwByObject.Name = "dgvwByObject";
            this.dgvwByObject.RowTemplate.Height = 24;
            this.dgvwByObject.Size = new System.Drawing.Size(305, 150);
            this.dgvwByObject.TabIndex = 2;
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "yyyy-MM-dd";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(193, 41);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(142, 24);
            this.dtEnd.TabIndex = 1;
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "yyyy-MM-dd";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(36, 41);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(142, 24);
            this.dtStart.TabIndex = 0;
            // 
            // txtOffset1
            // 
            this.txtOffset1.Location = new System.Drawing.Point(354, 435);
            this.txtOffset1.Name = "txtOffset1";
            this.txtOffset1.Size = new System.Drawing.Size(28, 24);
            this.txtOffset1.TabIndex = 42;
            this.txtOffset1.Text = "0";
            this.txtOffset1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOffset1.Visible = false;
            // 
            // txtOffset2
            // 
            this.txtOffset2.Location = new System.Drawing.Point(391, 435);
            this.txtOffset2.Name = "txtOffset2";
            this.txtOffset2.Size = new System.Drawing.Size(28, 24);
            this.txtOffset2.TabIndex = 43;
            this.txtOffset2.Text = "0";
            this.txtOffset2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOffset2.Visible = false;
            // 
            // txtOffset3
            // 
            this.txtOffset3.Location = new System.Drawing.Point(429, 435);
            this.txtOffset3.Name = "txtOffset3";
            this.txtOffset3.Size = new System.Drawing.Size(28, 24);
            this.txtOffset3.TabIndex = 44;
            this.txtOffset3.Text = "0";
            this.txtOffset3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOffset3.Visible = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 749);
            this.Controls.Add(this.tabPlanets);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "ALPO Gallery Utility";
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.tabPlanets.ResumeLayout(false);
            this.tabSolar.ResumeLayout(false);
            this.tabSolar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImgSelFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenthsMin)).EndInit();
            this.tabVenus.ResumeLayout(false);
            this.tabVenus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImgFldrSelect)).EndInit();
            this.tabSaturn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvwByObject)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPlanets;
        private System.Windows.Forms.TabPage tabSolar;
        private System.Windows.Forms.TabPage tabVenus;
        private System.Windows.Forms.TabPage tabMars;
        private System.Windows.Forms.TabPage tabJupiter;
        private System.Windows.Forms.TabPage tabSaturn;
        private System.Windows.Forms.DateTimePicker dtObsrvTime;
        private System.Windows.Forms.DateTimePicker ObsrvDate;
        private System.Windows.Forms.Button btnAddObsrvr;
        private System.Windows.Forms.ComboBox cmbObserver;
        private Cyotek.Windows.Forms.ImageBox imgObservation;
        private System.Windows.Forms.ComboBox cmbSections;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTrnsp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSeeing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstFilters;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ListBox lstAttachments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstMsgs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGenName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown TenthsMin;
        private System.Windows.Forms.Button btnGenSectRpt;
        private System.Windows.Forms.Button btnParseFileForDate;
        private System.Windows.Forms.Label lblOversized;
        private System.Windows.Forms.Button btnTrash;
        private System.Windows.Forms.Button btnTrimFileName;
        private System.Windows.Forms.PictureBox btnImgFldrSelect;
        private System.Windows.Forms.FolderBrowserDialog fldrDlg;
        private System.Windows.Forms.Label lblImgFolder;
        private System.Windows.Forms.ListBox lstImgsToProcess;
        private System.Windows.Forms.PictureBox btnImgSelFolder;
        private System.Windows.Forms.Button btnAddScope;
        private System.Windows.Forms.Button btnShrink;
        private System.Windows.Forms.Button btnGenerateCm;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.ComboBox cmbTelescopes;
        private System.Windows.Forms.Button btnLoadRptByObj;
        private System.Windows.Forms.DataGridView dgvwByObject;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.CheckBox ckOverride;
        private System.Windows.Forms.TextBox txtOffset3;
        private System.Windows.Forms.TextBox txtOffset2;
        private System.Windows.Forms.TextBox txtOffset1;
    }
}

