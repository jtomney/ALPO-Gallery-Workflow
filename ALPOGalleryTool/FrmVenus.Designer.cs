namespace ALPOGalleryTool
{
    partial class FrmVenus
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
            this.lstAttachments = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lstMsgs = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblOversized = new System.Windows.Forms.Label();
            this.imgObservation = new Cyotek.Windows.Forms.ImageBox();
            this.TenthsMin = new System.Windows.Forms.NumericUpDown();
            this.dtObsrvTime = new System.Windows.Forms.DateTimePicker();
            this.ObsrvDate = new System.Windows.Forms.DateTimePicker();
            this.txtTrnsp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSeeing = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ckOverride = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lstOtherFltr = new System.Windows.Forms.ListBox();
            this.lstFilters = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTelescopes = new System.Windows.Forms.ComboBox();
            this.cmbObserver = new System.Windows.Forms.ComboBox();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.btnGenerateCm = new System.Windows.Forms.Button();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.btnGenName = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblObsrvName = new System.Windows.Forms.Label();
            this.btnApndTags = new System.Windows.Forms.Button();
            this.btnAddTags = new System.Windows.Forms.Button();
            this.btnTrash = new System.Windows.Forms.Button();
            this.btnGenSectRpt = new System.Windows.Forms.Button();
            this.lblDateError = new System.Windows.Forms.Label();
            this.btnRecalcDate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TenthsMin)).BeginInit();
            this.SuspendLayout();
            // 
            // lstAttachments
            // 
            this.lstAttachments.FormattingEnabled = true;
            this.lstAttachments.ItemHeight = 15;
            this.lstAttachments.Location = new System.Drawing.Point(3, 136);
            this.lstAttachments.Name = "lstAttachments";
            this.lstAttachments.Size = new System.Drawing.Size(449, 49);
            this.lstAttachments.TabIndex = 76;
            this.lstAttachments.SelectedIndexChanged += new System.EventHandler(this.lstAttachments_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(3, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 15);
            this.label8.TabIndex = 75;
            this.label8.Text = "Attachments";
            // 
            // lstMsgs
            // 
            this.lstMsgs.FormattingEnabled = true;
            this.lstMsgs.ItemHeight = 15;
            this.lstMsgs.Location = new System.Drawing.Point(3, 27);
            this.lstMsgs.Name = "lstMsgs";
            this.lstMsgs.Size = new System.Drawing.Size(449, 79);
            this.lstMsgs.TabIndex = 74;
            this.lstMsgs.SelectedIndexChanged += new System.EventHandler(this.lstMsgs_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 15);
            this.label7.TabIndex = 73;
            this.label7.Text = "Submissions";
            // 
            // lblOversized
            // 
            this.lblOversized.AutoSize = true;
            this.lblOversized.BackColor = System.Drawing.Color.Yellow;
            this.lblOversized.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOversized.ForeColor = System.Drawing.Color.Red;
            this.lblOversized.Location = new System.Drawing.Point(636, 4);
            this.lblOversized.Name = "lblOversized";
            this.lblOversized.Size = new System.Drawing.Size(77, 16);
            this.lblOversized.TabIndex = 80;
            this.lblOversized.Text = "Oversized";
            this.lblOversized.Visible = false;
            // 
            // imgObservation
            // 
            this.imgObservation.Location = new System.Drawing.Point(631, 23);
            this.imgObservation.Name = "imgObservation";
            this.imgObservation.Size = new System.Drawing.Size(727, 604);
            this.imgObservation.TabIndex = 79;
            this.imgObservation.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // TenthsMin
            // 
            this.TenthsMin.Location = new System.Drawing.Point(324, 202);
            this.TenthsMin.Name = "TenthsMin";
            this.TenthsMin.Size = new System.Drawing.Size(51, 21);
            this.TenthsMin.TabIndex = 83;
            // 
            // dtObsrvTime
            // 
            this.dtObsrvTime.CustomFormat = "HHmm";
            this.dtObsrvTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtObsrvTime.Location = new System.Drawing.Point(185, 202);
            this.dtObsrvTime.Name = "dtObsrvTime";
            this.dtObsrvTime.ShowUpDown = true;
            this.dtObsrvTime.Size = new System.Drawing.Size(105, 21);
            this.dtObsrvTime.TabIndex = 82;
            // 
            // ObsrvDate
            // 
            this.ObsrvDate.CustomFormat = "yyyy-MM-dd";
            this.ObsrvDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ObsrvDate.Location = new System.Drawing.Point(3, 202);
            this.ObsrvDate.Name = "ObsrvDate";
            this.ObsrvDate.ShowUpDown = true;
            this.ObsrvDate.Size = new System.Drawing.Size(168, 21);
            this.ObsrvDate.TabIndex = 81;
            // 
            // txtTrnsp
            // 
            this.txtTrnsp.Location = new System.Drawing.Point(247, 374);
            this.txtTrnsp.Name = "txtTrnsp";
            this.txtTrnsp.Size = new System.Drawing.Size(45, 21);
            this.txtTrnsp.TabIndex = 108;
            this.txtTrnsp.Text = "0";
            this.txtTrnsp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(244, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 110;
            this.label3.Text = "Transp";
            // 
            // txtSeeing
            // 
            this.txtSeeing.Location = new System.Drawing.Point(247, 320);
            this.txtSeeing.Name = "txtSeeing";
            this.txtSeeing.Size = new System.Drawing.Size(42, 21);
            this.txtSeeing.TabIndex = 107;
            this.txtSeeing.Text = "0";
            this.txtSeeing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(244, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 109;
            this.label6.Text = "Seeing";
            // 
            // ckOverride
            // 
            this.ckOverride.AutoSize = true;
            this.ckOverride.ForeColor = System.Drawing.Color.White;
            this.ckOverride.Location = new System.Drawing.Point(131, 245);
            this.ckOverride.Name = "ckOverride";
            this.ckOverride.Size = new System.Drawing.Size(72, 19);
            this.ckOverride.TabIndex = 106;
            this.ckOverride.Text = "Override";
            this.ckOverride.UseVisualStyleBackColor = true;
            this.ckOverride.CheckedChanged += new System.EventHandler(this.ckOverride_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(111, 292);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 15);
            this.label9.TabIndex = 105;
            this.label9.Text = "2nd Filter";
            // 
            // lstOtherFltr
            // 
            this.lstOtherFltr.FormattingEnabled = true;
            this.lstOtherFltr.ItemHeight = 15;
            this.lstOtherFltr.Location = new System.Drawing.Point(114, 310);
            this.lstOtherFltr.Name = "lstOtherFltr";
            this.lstOtherFltr.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstOtherFltr.Size = new System.Drawing.Size(110, 94);
            this.lstOtherFltr.TabIndex = 104;
            // 
            // lstFilters
            // 
            this.lstFilters.FormattingEnabled = true;
            this.lstFilters.ItemHeight = 15;
            this.lstFilters.Location = new System.Drawing.Point(6, 310);
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstFilters.Size = new System.Drawing.Size(89, 94);
            this.lstFilters.TabIndex = 103;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(10, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 102;
            this.label4.Text = "Filter";
            // 
            // cmbTelescopes
            // 
            this.cmbTelescopes.FormattingEnabled = true;
            this.cmbTelescopes.Location = new System.Drawing.Point(222, 243);
            this.cmbTelescopes.Name = "cmbTelescopes";
            this.cmbTelescopes.Size = new System.Drawing.Size(216, 23);
            this.cmbTelescopes.TabIndex = 101;
            // 
            // cmbObserver
            // 
            this.cmbObserver.FormattingEnabled = true;
            this.cmbObserver.Location = new System.Drawing.Point(3, 241);
            this.cmbObserver.Name = "cmbObserver";
            this.cmbObserver.Size = new System.Drawing.Size(119, 23);
            this.cmbObserver.TabIndex = 100;
            // 
            // lstTags
            // 
            this.lstTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTags.FormattingEnabled = true;
            this.lstTags.ItemHeight = 16;
            this.lstTags.Location = new System.Drawing.Point(404, 374);
            this.lstTags.Name = "lstTags";
            this.lstTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTags.Size = new System.Drawing.Size(221, 292);
            this.lstTags.TabIndex = 114;
            this.lstTags.DoubleClick += new System.EventHandler(this.lstTags_DoubleClick);
            // 
            // btnGenerateCm
            // 
            this.btnGenerateCm.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Maps_Globe_Filled_icon;
            this.btnGenerateCm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerateCm.Location = new System.Drawing.Point(330, 301);
            this.btnGenerateCm.Name = "btnGenerateCm";
            this.btnGenerateCm.Size = new System.Drawing.Size(30, 29);
            this.btnGenerateCm.TabIndex = 113;
            this.btnGenerateCm.UseVisualStyleBackColor = true;
            this.btnGenerateCm.Click += new System.EventHandler(this.btnGenerateCm_Click);
            // 
            // txtTags
            // 
            this.txtTags.Location = new System.Drawing.Point(366, 301);
            this.txtTags.Multiline = true;
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(259, 68);
            this.txtTags.TabIndex = 111;
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(3, 410);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(349, 200);
            this.rtbNotes.TabIndex = 112;
            this.rtbNotes.Text = "";
            // 
            // btnGenName
            // 
            this.btnGenName.BackgroundImage = global::ALPOGalleryTool.Properties.Resources._20_gear_2_icon;
            this.btnGenName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenName.Location = new System.Drawing.Point(656, 637);
            this.btnGenName.Name = "btnGenName";
            this.btnGenName.Size = new System.Drawing.Size(24, 24);
            this.btnGenName.TabIndex = 117;
            this.btnGenName.UseVisualStyleBackColor = true;
            this.btnGenName.Click += new System.EventHandler(this.btnGenName_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.create_map_icon;
            this.btnProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProcess.Location = new System.Drawing.Point(626, 637);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(24, 24);
            this.btnProcess.TabIndex = 116;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFileName.Location = new System.Drawing.Point(686, 642);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(69, 16);
            this.lblFileName.TabIndex = 115;
            this.lblFileName.Text = "File Name";
            // 
            // lblObsrvName
            // 
            this.lblObsrvName.AutoSize = true;
            this.lblObsrvName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblObsrvName.Location = new System.Drawing.Point(3, 267);
            this.lblObsrvName.Name = "lblObsrvName";
            this.lblObsrvName.Size = new System.Drawing.Size(41, 15);
            this.lblObsrvName.TabIndex = 118;
            this.lblObsrvName.Text = "Name";
            // 
            // btnApndTags
            // 
            this.btnApndTags.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Upload_icon;
            this.btnApndTags.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnApndTags.Location = new System.Drawing.Point(366, 441);
            this.btnApndTags.Name = "btnApndTags";
            this.btnApndTags.Size = new System.Drawing.Size(32, 32);
            this.btnApndTags.TabIndex = 120;
            this.btnApndTags.UseVisualStyleBackColor = true;
            this.btnApndTags.Click += new System.EventHandler(this.btnApndTags_Click);
            // 
            // btnAddTags
            // 
            this.btnAddTags.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.UpArrow;
            this.btnAddTags.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddTags.Location = new System.Drawing.Point(366, 403);
            this.btnAddTags.Name = "btnAddTags";
            this.btnAddTags.Size = new System.Drawing.Size(32, 32);
            this.btnAddTags.TabIndex = 119;
            this.btnAddTags.UseVisualStyleBackColor = true;
            this.btnAddTags.Click += new System.EventHandler(this.btnAddTags_Click);
            // 
            // btnTrash
            // 
            this.btnTrash.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.Actions_trash_empty_icon;
            this.btnTrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTrash.Location = new System.Drawing.Point(458, 27);
            this.btnTrash.Name = "btnTrash";
            this.btnTrash.Size = new System.Drawing.Size(37, 37);
            this.btnTrash.TabIndex = 121;
            this.btnTrash.UseVisualStyleBackColor = true;
            this.btnTrash.Click += new System.EventHandler(this.btnTrash_Click);
            // 
            // btnGenSectRpt
            // 
            this.btnGenSectRpt.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.x_office_spreadsheet_icon;
            this.btnGenSectRpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenSectRpt.Location = new System.Drawing.Point(458, 70);
            this.btnGenSectRpt.Name = "btnGenSectRpt";
            this.btnGenSectRpt.Size = new System.Drawing.Size(37, 37);
            this.btnGenSectRpt.TabIndex = 122;
            this.btnGenSectRpt.UseVisualStyleBackColor = true;
            this.btnGenSectRpt.Click += new System.EventHandler(this.btnGenSectRpt_Click);
            // 
            // lblDateError
            // 
            this.lblDateError.AutoSize = true;
            this.lblDateError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblDateError.ForeColor = System.Drawing.Color.Red;
            this.lblDateError.Location = new System.Drawing.Point(3, 223);
            this.lblDateError.Name = "lblDateError";
            this.lblDateError.Size = new System.Drawing.Size(63, 15);
            this.lblDateError.TabIndex = 123;
            this.lblDateError.Text = "Date Error";
            this.lblDateError.Visible = false;
            this.lblDateError.VisibleChanged += new System.EventHandler(this.lblDateError_VisibleChanged);
            // 
            // btnRecalcDate
            // 
            this.btnRecalcDate.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.arrow_refresh_icon;
            this.btnRecalcDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecalcDate.Location = new System.Drawing.Point(394, 199);
            this.btnRecalcDate.Name = "btnRecalcDate";
            this.btnRecalcDate.Size = new System.Drawing.Size(24, 24);
            this.btnRecalcDate.TabIndex = 124;
            this.btnRecalcDate.UseVisualStyleBackColor = true;
            this.btnRecalcDate.Click += new System.EventHandler(this.btnRecalcDate_Click);
            // 
            // FrmVenus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1370, 681);
            this.Controls.Add(this.btnRecalcDate);
            this.Controls.Add(this.lblDateError);
            this.Controls.Add(this.btnGenSectRpt);
            this.Controls.Add(this.btnTrash);
            this.Controls.Add(this.btnApndTags);
            this.Controls.Add(this.btnAddTags);
            this.Controls.Add(this.lblObsrvName);
            this.Controls.Add(this.btnGenName);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.lstTags);
            this.Controls.Add(this.btnGenerateCm);
            this.Controls.Add(this.txtTags);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.txtTrnsp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSeeing);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ckOverride);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lstOtherFltr);
            this.Controls.Add(this.lstFilters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTelescopes);
            this.Controls.Add(this.cmbObserver);
            this.Controls.Add(this.TenthsMin);
            this.Controls.Add(this.dtObsrvTime);
            this.Controls.Add(this.ObsrvDate);
            this.Controls.Add(this.lblOversized);
            this.Controls.Add(this.imgObservation);
            this.Controls.Add(this.lstAttachments);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lstMsgs);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmVenus";
            this.Text = "Venus";
            this.Shown += new System.EventHandler(this.FrmVenus_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.TenthsMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstAttachments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstMsgs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblOversized;
        private Cyotek.Windows.Forms.ImageBox imgObservation;
        private System.Windows.Forms.NumericUpDown TenthsMin;
        private System.Windows.Forms.DateTimePicker dtObsrvTime;
        private System.Windows.Forms.DateTimePicker ObsrvDate;
        private System.Windows.Forms.TextBox txtTrnsp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSeeing;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ckOverride;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lstOtherFltr;
        private System.Windows.Forms.ListBox lstFilters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTelescopes;
        private System.Windows.Forms.ComboBox cmbObserver;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.Button btnGenerateCm;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Button btnGenName;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblObsrvName;
        private System.Windows.Forms.Button btnApndTags;
        private System.Windows.Forms.Button btnAddTags;
        private System.Windows.Forms.Button btnTrash;
        private System.Windows.Forms.Button btnGenSectRpt;
        private System.Windows.Forms.Label lblDateError;
        private System.Windows.Forms.Button btnRecalcDate;
    }
}