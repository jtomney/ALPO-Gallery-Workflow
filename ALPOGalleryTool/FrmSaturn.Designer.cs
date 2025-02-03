
namespace ALPOGalleryTool
{
    partial class FrmSaturn
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
            this.ckOverride = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lstOtherFltr = new System.Windows.Forms.ListBox();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.btnGenerateCm = new System.Windows.Forms.Button();
            this.btnGenSectRpt = new System.Windows.Forms.Button();
            this.btnGenName = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.lstFilters = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.cmbTelescopes = new System.Windows.Forms.ComboBox();
            this.cmbObserver = new System.Windows.Forms.ComboBox();
            this.btnTrimFileName = new System.Windows.Forms.Button();
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
            this.txtTrnsp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSeeing = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblObsrvName = new System.Windows.Forms.Label();
            this.imgDateWarn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TenthsMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDateWarn)).BeginInit();
            this.SuspendLayout();
            // 
            // ckOverride
            // 
            this.ckOverride.AutoSize = true;
            this.ckOverride.ForeColor = System.Drawing.Color.White;
            this.ckOverride.Location = new System.Drawing.Point(145, 295);
            this.ckOverride.Name = "ckOverride";
            this.ckOverride.Size = new System.Drawing.Size(72, 19);
            this.ckOverride.TabIndex = 95;
            this.ckOverride.Text = "Override";
            this.ckOverride.UseVisualStyleBackColor = true;
            this.ckOverride.CheckedChanged += new System.EventHandler(this.ckOverride_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(142, 374);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 15);
            this.label9.TabIndex = 94;
            this.label9.Text = "2nd Filter";
            // 
            // lstOtherFltr
            // 
            this.lstOtherFltr.FormattingEnabled = true;
            this.lstOtherFltr.ItemHeight = 15;
            this.lstOtherFltr.Location = new System.Drawing.Point(145, 392);
            this.lstOtherFltr.Name = "lstOtherFltr";
            this.lstOtherFltr.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstOtherFltr.Size = new System.Drawing.Size(110, 94);
            this.lstOtherFltr.TabIndex = 93;
            // 
            // lstTags
            // 
            this.lstTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTags.FormattingEnabled = true;
            this.lstTags.ItemHeight = 16;
            this.lstTags.Location = new System.Drawing.Point(390, 432);
            this.lstTags.Name = "lstTags";
            this.lstTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTags.Size = new System.Drawing.Size(230, 244);
            this.lstTags.TabIndex = 92;
            this.lstTags.DoubleClick += new System.EventHandler(this.lstTags_DoubleClick);
            // 
            // btnGenerateCm
            // 
            this.btnGenerateCm.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Maps_Globe_Filled_icon;
            this.btnGenerateCm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerateCm.Location = new System.Drawing.Point(283, 392);
            this.btnGenerateCm.Name = "btnGenerateCm";
            this.btnGenerateCm.Size = new System.Drawing.Size(30, 29);
            this.btnGenerateCm.TabIndex = 91;
            this.btnGenerateCm.UseVisualStyleBackColor = true;
            this.btnGenerateCm.Click += new System.EventHandler(this.btnGenerateCm_Click);
            // 
            // btnGenSectRpt
            // 
            this.btnGenSectRpt.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.x_office_spreadsheet_icon;
            this.btnGenSectRpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenSectRpt.Location = new System.Drawing.Point(583, 283);
            this.btnGenSectRpt.Name = "btnGenSectRpt";
            this.btnGenSectRpt.Size = new System.Drawing.Size(37, 37);
            this.btnGenSectRpt.TabIndex = 90;
            this.btnGenSectRpt.UseVisualStyleBackColor = true;
            this.btnGenSectRpt.Click += new System.EventHandler(this.btnGenSectRpt_Click);
            // 
            // btnGenName
            // 
            this.btnGenName.BackgroundImage = global::ALPOGalleryTool.Properties.Resources._20_gear_2_icon;
            this.btnGenName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenName.Location = new System.Drawing.Point(662, 639);
            this.btnGenName.Name = "btnGenName";
            this.btnGenName.Size = new System.Drawing.Size(24, 24);
            this.btnGenName.TabIndex = 89;
            this.btnGenName.UseVisualStyleBackColor = true;
            this.btnGenName.Click += new System.EventHandler(this.btnGenName_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.create_map_icon;
            this.btnProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProcess.Location = new System.Drawing.Point(632, 639);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(24, 24);
            this.btnProcess.TabIndex = 88;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtTags
            // 
            this.txtTags.Location = new System.Drawing.Point(319, 396);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(301, 21);
            this.txtTags.TabIndex = 83;
            this.txtTags.DoubleClick += new System.EventHandler(this.txtTags_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(17, 493);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 87;
            this.label5.Text = "Notes";
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(17, 511);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(349, 165);
            this.rtbNotes.TabIndex = 86;
            this.rtbNotes.Text = "";
            // 
            // lstFilters
            // 
            this.lstFilters.FormattingEnabled = true;
            this.lstFilters.ItemHeight = 15;
            this.lstFilters.Location = new System.Drawing.Point(18, 362);
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstFilters.Size = new System.Drawing.Size(110, 124);
            this.lstFilters.TabIndex = 85;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(17, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 84;
            this.label4.Text = "Filter";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFileName.Location = new System.Drawing.Point(692, 639);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(69, 16);
            this.lblFileName.TabIndex = 82;
            this.lblFileName.Text = "File Name";
            // 
            // cmbTelescopes
            // 
            this.cmbTelescopes.FormattingEnabled = true;
            this.cmbTelescopes.Location = new System.Drawing.Point(275, 291);
            this.cmbTelescopes.Name = "cmbTelescopes";
            this.cmbTelescopes.Size = new System.Drawing.Size(269, 23);
            this.cmbTelescopes.TabIndex = 81;
            // 
            // cmbObserver
            // 
            this.cmbObserver.FormattingEnabled = true;
            this.cmbObserver.Location = new System.Drawing.Point(17, 291);
            this.cmbObserver.Name = "cmbObserver";
            this.cmbObserver.Size = new System.Drawing.Size(119, 23);
            this.cmbObserver.TabIndex = 80;
            // 
            // btnTrimFileName
            // 
            this.btnTrimFileName.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.minus_icon;
            this.btnTrimFileName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTrimFileName.Location = new System.Drawing.Point(468, 227);
            this.btnTrimFileName.Name = "btnTrimFileName";
            this.btnTrimFileName.Size = new System.Drawing.Size(37, 37);
            this.btnTrimFileName.TabIndex = 79;
            this.btnTrimFileName.UseVisualStyleBackColor = true;
            this.btnTrimFileName.Click += new System.EventHandler(this.btnTrimFileName_Click);
            // 
            // lblOversized
            // 
            this.lblOversized.AutoSize = true;
            this.lblOversized.BackColor = System.Drawing.Color.Yellow;
            this.lblOversized.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOversized.ForeColor = System.Drawing.Color.Red;
            this.lblOversized.Location = new System.Drawing.Point(626, 13);
            this.lblOversized.Name = "lblOversized";
            this.lblOversized.Size = new System.Drawing.Size(88, 20);
            this.lblOversized.TabIndex = 78;
            this.lblOversized.Text = "Oversized";
            this.lblOversized.Visible = false;
            // 
            // btnParseFileForDate
            // 
            this.btnParseFileForDate.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.document_split_icon;
            this.btnParseFileForDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnParseFileForDate.Location = new System.Drawing.Point(411, 227);
            this.btnParseFileForDate.Name = "btnParseFileForDate";
            this.btnParseFileForDate.Size = new System.Drawing.Size(37, 37);
            this.btnParseFileForDate.TabIndex = 77;
            this.btnParseFileForDate.UseVisualStyleBackColor = true;
            this.btnParseFileForDate.Click += new System.EventHandler(this.btnParseFileForDate_Click);
            // 
            // TenthsMin
            // 
            this.TenthsMin.Location = new System.Drawing.Point(338, 232);
            this.TenthsMin.Name = "TenthsMin";
            this.TenthsMin.Size = new System.Drawing.Size(51, 21);
            this.TenthsMin.TabIndex = 76;
            // 
            // dtObsrvTime
            // 
            this.dtObsrvTime.CustomFormat = "HHmm";
            this.dtObsrvTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtObsrvTime.Location = new System.Drawing.Point(208, 232);
            this.dtObsrvTime.Name = "dtObsrvTime";
            this.dtObsrvTime.ShowUpDown = true;
            this.dtObsrvTime.Size = new System.Drawing.Size(105, 21);
            this.dtObsrvTime.TabIndex = 75;
            // 
            // ObsrvDate
            // 
            this.ObsrvDate.CustomFormat = "yyyy-MM-dd";
            this.ObsrvDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ObsrvDate.Location = new System.Drawing.Point(17, 232);
            this.ObsrvDate.Name = "ObsrvDate";
            this.ObsrvDate.ShowUpDown = true;
            this.ObsrvDate.Size = new System.Drawing.Size(168, 21);
            this.ObsrvDate.TabIndex = 74;
            // 
            // btnTrash
            // 
            this.btnTrash.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Actions_trash_empty_icon;
            this.btnTrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTrash.Location = new System.Drawing.Point(583, 31);
            this.btnTrash.Name = "btnTrash";
            this.btnTrash.Size = new System.Drawing.Size(37, 37);
            this.btnTrash.TabIndex = 73;
            this.btnTrash.UseVisualStyleBackColor = true;
            this.btnTrash.Click += new System.EventHandler(this.btnTrash_Click);
            // 
            // lstAttachments
            // 
            this.lstAttachments.FormattingEnabled = true;
            this.lstAttachments.ItemHeight = 15;
            this.lstAttachments.Location = new System.Drawing.Point(17, 165);
            this.lstAttachments.Name = "lstAttachments";
            this.lstAttachments.Size = new System.Drawing.Size(546, 49);
            this.lstAttachments.TabIndex = 72;
            this.lstAttachments.SelectedIndexChanged += new System.EventHandler(this.lstAttachments_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(17, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 15);
            this.label8.TabIndex = 71;
            this.label8.Text = "Attachments";
            // 
            // lstMsgs
            // 
            this.lstMsgs.FormattingEnabled = true;
            this.lstMsgs.ItemHeight = 15;
            this.lstMsgs.Location = new System.Drawing.Point(17, 31);
            this.lstMsgs.Name = "lstMsgs";
            this.lstMsgs.Size = new System.Drawing.Size(548, 94);
            this.lstMsgs.TabIndex = 70;
            this.lstMsgs.SelectedIndexChanged += new System.EventHandler(this.lstMsgs_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(17, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 15);
            this.label7.TabIndex = 69;
            this.label7.Text = "Submissions";
            // 
            // imgObservation
            // 
            this.imgObservation.Location = new System.Drawing.Point(626, 31);
            this.imgObservation.Name = "imgObservation";
            this.imgObservation.Size = new System.Drawing.Size(727, 604);
            this.imgObservation.TabIndex = 68;
            this.imgObservation.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // txtTrnsp
            // 
            this.txtTrnsp.Location = new System.Drawing.Point(343, 351);
            this.txtTrnsp.Name = "txtTrnsp";
            this.txtTrnsp.Size = new System.Drawing.Size(45, 21);
            this.txtTrnsp.TabIndex = 97;
            this.txtTrnsp.Text = "0";
            this.txtTrnsp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(340, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 99;
            this.label3.Text = "Transp";
            // 
            // txtSeeing
            // 
            this.txtSeeing.Location = new System.Drawing.Point(283, 351);
            this.txtSeeing.Name = "txtSeeing";
            this.txtSeeing.Size = new System.Drawing.Size(42, 21);
            this.txtSeeing.TabIndex = 96;
            this.txtSeeing.Text = "0";
            this.txtSeeing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(280, 331);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 98;
            this.label6.Text = "Seeing";
            // 
            // lblObsrvName
            // 
            this.lblObsrvName.AutoSize = true;
            this.lblObsrvName.ForeColor = System.Drawing.Color.White;
            this.lblObsrvName.Location = new System.Drawing.Point(17, 317);
            this.lblObsrvName.Name = "lblObsrvName";
            this.lblObsrvName.Size = new System.Drawing.Size(24, 15);
            this.lblObsrvName.TabIndex = 100;
            this.lblObsrvName.Text = "tbd";
            // 
            // imgDateWarn
            // 
            this.imgDateWarn.BackColor = System.Drawing.Color.Yellow;
            this.imgDateWarn.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.warning_icon;
            this.imgDateWarn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgDateWarn.Location = new System.Drawing.Point(17, 257);
            this.imgDateWarn.Name = "imgDateWarn";
            this.imgDateWarn.Size = new System.Drawing.Size(28, 28);
            this.imgDateWarn.TabIndex = 101;
            this.imgDateWarn.TabStop = false;
            this.imgDateWarn.Visible = false;
            // 
            // FrmSaturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1370, 681);
            this.Controls.Add(this.imgDateWarn);
            this.Controls.Add(this.lblObsrvName);
            this.Controls.Add(this.txtTrnsp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSeeing);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ckOverride);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lstOtherFltr);
            this.Controls.Add(this.lstTags);
            this.Controls.Add(this.btnGenerateCm);
            this.Controls.Add(this.btnGenSectRpt);
            this.Controls.Add(this.btnGenName);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtTags);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.lstFilters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblFileName);
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
            this.Name = "FrmSaturn";
            this.Text = "Saturn Observations";
            this.Shown += new System.EventHandler(this.FrmSaturn_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.TenthsMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDateWarn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckOverride;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lstOtherFltr;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.Button btnGenerateCm;
        private System.Windows.Forms.Button btnGenSectRpt;
        private System.Windows.Forms.Button btnGenName;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.ListBox lstFilters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.ComboBox cmbTelescopes;
        private System.Windows.Forms.ComboBox cmbObserver;
        private System.Windows.Forms.Button btnTrimFileName;
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
        private System.Windows.Forms.TextBox txtTrnsp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSeeing;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblObsrvName;
        private System.Windows.Forms.PictureBox imgDateWarn;
    }
}