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
            this.TenthsMin = new System.Windows.Forms.NumericUpDown();
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
            ((System.ComponentModel.ISupportInitialize)(this.TenthsMin)).BeginInit();
            this.grpObsrvtnTimestamp.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProfile
            // 
            this.btnProfile.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.customer;
            this.btnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.Location = new System.Drawing.Point(9, 272);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(32, 32);
            this.btnProfile.TabIndex = 93;
            this.btnProfile.UseVisualStyleBackColor = true;
            // 
            // btnDeleteImg
            // 
            this.btnDeleteImg.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Actions_trash_empty_icon;
            this.btnDeleteImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteImg.Location = new System.Drawing.Point(585, 155);
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
            this.ckOverride.Location = new System.Drawing.Point(186, 281);
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
            this.btnGenSectRpt.Location = new System.Drawing.Point(542, 220);
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
            this.label2.Location = new System.Drawing.Point(285, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 89;
            this.label2.Text = "Telescope";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(52, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 88;
            this.label1.Text = "Observer";
            // 
            // cmbTelescopes
            // 
            this.cmbTelescopes.FormattingEnabled = true;
            this.cmbTelescopes.Location = new System.Drawing.Point(289, 279);
            this.cmbTelescopes.Name = "cmbTelescopes";
            this.cmbTelescopes.Size = new System.Drawing.Size(269, 23);
            this.cmbTelescopes.TabIndex = 87;
            // 
            // cmbObserver
            // 
            this.cmbObserver.FormattingEnabled = true;
            this.cmbObserver.Location = new System.Drawing.Point(52, 277);
            this.cmbObserver.Name = "cmbObserver";
            this.cmbObserver.Size = new System.Drawing.Size(119, 23);
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
            this.btnParseFileForDate.Location = new System.Drawing.Point(427, 220);
            this.btnParseFileForDate.Name = "btnParseFileForDate";
            this.btnParseFileForDate.Size = new System.Drawing.Size(37, 37);
            this.btnParseFileForDate.TabIndex = 84;
            this.btnParseFileForDate.UseVisualStyleBackColor = true;
            this.btnParseFileForDate.Click += new System.EventHandler(this.btnParseFileForDate_Click);
            // 
            // TenthsMin
            // 
            this.TenthsMin.Location = new System.Drawing.Point(319, 19);
            this.TenthsMin.Name = "TenthsMin";
            this.TenthsMin.Size = new System.Drawing.Size(51, 21);
            this.TenthsMin.TabIndex = 83;
            // 
            // dtObsrvTime
            // 
            this.dtObsrvTime.CustomFormat = "HHmm";
            this.dtObsrvTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtObsrvTime.Location = new System.Drawing.Point(199, 19);
            this.dtObsrvTime.Name = "dtObsrvTime";
            this.dtObsrvTime.ShowUpDown = true;
            this.dtObsrvTime.Size = new System.Drawing.Size(105, 21);
            this.dtObsrvTime.TabIndex = 82;
            // 
            // ObsrvDate
            // 
            this.ObsrvDate.CustomFormat = "yyyy-MM-dd";
            this.ObsrvDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ObsrvDate.Location = new System.Drawing.Point(15, 19);
            this.ObsrvDate.Name = "ObsrvDate";
            this.ObsrvDate.ShowUpDown = true;
            this.ObsrvDate.Size = new System.Drawing.Size(168, 21);
            this.ObsrvDate.TabIndex = 81;
            // 
            // btnTrash
            // 
            this.btnTrash.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Actions_trash_empty_icon;
            this.btnTrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTrash.Location = new System.Drawing.Point(585, 35);
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
            this.lstAttachments.Location = new System.Drawing.Point(33, 155);
            this.lstAttachments.Name = "lstAttachments";
            this.lstAttachments.Size = new System.Drawing.Size(546, 49);
            this.lstAttachments.TabIndex = 79;
            this.lstAttachments.SelectedIndexChanged += new System.EventHandler(this.lstAttachments_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(33, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 15);
            this.label8.TabIndex = 78;
            this.label8.Text = "Attachments";
            // 
            // lstMsgs
            // 
            this.lstMsgs.FormattingEnabled = true;
            this.lstMsgs.ItemHeight = 15;
            this.lstMsgs.Location = new System.Drawing.Point(31, 35);
            this.lstMsgs.Name = "lstMsgs";
            this.lstMsgs.Size = new System.Drawing.Size(548, 94);
            this.lstMsgs.TabIndex = 77;
            this.lstMsgs.SelectedIndexChanged += new System.EventHandler(this.lstMsgs_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(31, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 15);
            this.label7.TabIndex = 76;
            this.label7.Text = "Submissions";
            // 
            // imgObservation
            // 
            this.imgObservation.Location = new System.Drawing.Point(625, 23);
            this.imgObservation.Name = "imgObservation";
            this.imgObservation.Size = new System.Drawing.Size(727, 604);
            this.imgObservation.TabIndex = 75;
            this.imgObservation.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // btnApndTags
            // 
            this.btnApndTags.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Upload_icon;
            this.btnApndTags.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnApndTags.Location = new System.Drawing.Point(332, 418);
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
            this.btnAddTags.Location = new System.Drawing.Point(332, 380);
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
            this.lstTags.Location = new System.Drawing.Point(370, 396);
            this.lstTags.Name = "lstTags";
            this.lstTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTags.Size = new System.Drawing.Size(230, 259);
            this.lstTags.TabIndex = 102;
            // 
            // btnGenName
            // 
            this.btnGenName.BackgroundImage = global::ALPOGalleryTool.Properties.Resources._20_gear_2_icon;
            this.btnGenName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenName.Location = new System.Drawing.Point(638, 632);
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
            this.btnProcess.Location = new System.Drawing.Point(606, 632);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(24, 24);
            this.btnProcess.TabIndex = 100;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtTags
            // 
            this.txtTags.Location = new System.Drawing.Point(193, 356);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(399, 21);
            this.txtTags.TabIndex = 95;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(9, 486);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 99;
            this.label5.Text = "Notes";
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(9, 504);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(349, 152);
            this.rtbNotes.TabIndex = 98;
            this.rtbNotes.Text = "";
            // 
            // lstFilters
            // 
            this.lstFilters.FormattingEnabled = true;
            this.lstFilters.ItemHeight = 15;
            this.lstFilters.Location = new System.Drawing.Point(9, 380);
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstFilters.Size = new System.Drawing.Size(78, 94);
            this.lstFilters.TabIndex = 97;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(13, 362);
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
            this.lblFileName.Location = new System.Drawing.Point(668, 637);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(69, 16);
            this.lblFileName.TabIndex = 94;
            this.lblFileName.Text = "File Name";
            // 
            // txtTrnsp
            // 
            this.txtTrnsp.Location = new System.Drawing.Point(514, 329);
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
            this.label3.Location = new System.Drawing.Point(514, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 108;
            this.label3.Text = "Transp";
            // 
            // txtSeeing
            // 
            this.txtSeeing.Location = new System.Drawing.Point(454, 329);
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
            this.label6.Location = new System.Drawing.Point(451, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 107;
            this.label6.Text = "Seeing";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(90, 362);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 15);
            this.label9.TabIndex = 110;
            this.label9.Text = "2nd Filter";
            // 
            // lstOtherFltr
            // 
            this.lstOtherFltr.FormattingEnabled = true;
            this.lstOtherFltr.ItemHeight = 15;
            this.lstOtherFltr.Location = new System.Drawing.Point(93, 380);
            this.lstOtherFltr.Name = "lstOtherFltr";
            this.lstOtherFltr.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstOtherFltr.Size = new System.Drawing.Size(83, 94);
            this.lstOtherFltr.TabIndex = 109;
            // 
            // lblObsrvName
            // 
            this.lblObsrvName.AutoSize = true;
            this.lblObsrvName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblObsrvName.Location = new System.Drawing.Point(52, 303);
            this.lblObsrvName.Name = "lblObsrvName";
            this.lblObsrvName.Size = new System.Drawing.Size(41, 15);
            this.lblObsrvName.TabIndex = 111;
            this.lblObsrvName.Text = "Name";
            // 
            // grpObsrvtnTimestamp
            // 
            this.grpObsrvtnTimestamp.Controls.Add(this.ObsrvDate);
            this.grpObsrvtnTimestamp.Controls.Add(this.dtObsrvTime);
            this.grpObsrvtnTimestamp.Controls.Add(this.TenthsMin);
            this.grpObsrvtnTimestamp.ForeColor = System.Drawing.Color.White;
            this.grpObsrvtnTimestamp.Location = new System.Drawing.Point(28, 209);
            this.grpObsrvtnTimestamp.Name = "grpObsrvtnTimestamp";
            this.grpObsrvtnTimestamp.Size = new System.Drawing.Size(393, 46);
            this.grpObsrvtnTimestamp.TabIndex = 112;
            this.grpObsrvtnTimestamp.TabStop = false;
            this.grpObsrvtnTimestamp.Text = "Observation Timestamp";
            // 
            // FrmEclipse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1364, 667);
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
            ((System.ComponentModel.ISupportInitialize)(this.TenthsMin)).EndInit();
            this.grpObsrvtnTimestamp.ResumeLayout(false);
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
        private System.Windows.Forms.NumericUpDown TenthsMin;
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
    }
}