namespace ALPOGalleryTool
{
    partial class ModalSelectProfile
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
            this.lstAvailProfiles = new System.Windows.Forms.ListBox();
            this.btnProfileOk = new System.Windows.Forms.Button();
            this.btnProfileCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstAvailProfiles
            // 
            this.lstAvailProfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAvailProfiles.FormattingEnabled = true;
            this.lstAvailProfiles.ItemHeight = 16;
            this.lstAvailProfiles.Location = new System.Drawing.Point(39, 12);
            this.lstAvailProfiles.Name = "lstAvailProfiles";
            this.lstAvailProfiles.Size = new System.Drawing.Size(540, 100);
            this.lstAvailProfiles.TabIndex = 0;
            this.lstAvailProfiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstAvailProfiles_MouseDoubleClick);
            // 
            // btnProfileOk
            // 
            this.btnProfileOk.Location = new System.Drawing.Point(223, 131);
            this.btnProfileOk.Name = "btnProfileOk";
            this.btnProfileOk.Size = new System.Drawing.Size(63, 26);
            this.btnProfileOk.TabIndex = 1;
            this.btnProfileOk.Text = "OK";
            this.btnProfileOk.UseVisualStyleBackColor = true;
            this.btnProfileOk.Click += new System.EventHandler(this.btnProfileOk_Click);
            // 
            // btnProfileCancel
            // 
            this.btnProfileCancel.Location = new System.Drawing.Point(315, 131);
            this.btnProfileCancel.Name = "btnProfileCancel";
            this.btnProfileCancel.Size = new System.Drawing.Size(63, 26);
            this.btnProfileCancel.TabIndex = 2;
            this.btnProfileCancel.Text = "Cancel";
            this.btnProfileCancel.UseVisualStyleBackColor = true;
            this.btnProfileCancel.Click += new System.EventHandler(this.btnProfileCancel_Click);
            // 
            // ModalSelectProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 169);
            this.ControlBox = false;
            this.Controls.Add(this.btnProfileCancel);
            this.Controls.Add(this.btnProfileOk);
            this.Controls.Add(this.lstAvailProfiles);
            this.Name = "ModalSelectProfile";
            this.Text = "User Profiles";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstAvailProfiles;
        private System.Windows.Forms.Button btnProfileOk;
        private System.Windows.Forms.Button btnProfileCancel;
    }
}