namespace ALPOGalleryTool
{
    partial class FrmUploadReport
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
            this.btnGenerateRpt = new System.Windows.Forms.Button();
            this.txtDataExtract = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerateRpt
            // 
            this.btnGenerateRpt.Location = new System.Drawing.Point(49, 132);
            this.btnGenerateRpt.Name = "btnGenerateRpt";
            this.btnGenerateRpt.Size = new System.Drawing.Size(150, 36);
            this.btnGenerateRpt.TabIndex = 0;
            this.btnGenerateRpt.Text = "Generate Report";
            this.btnGenerateRpt.UseVisualStyleBackColor = true;
            this.btnGenerateRpt.Click += new System.EventHandler(this.btnGenerateRpt_Click);
            // 
            // txtDataExtract
            // 
            this.txtDataExtract.Location = new System.Drawing.Point(49, 64);
            this.txtDataExtract.Name = "txtDataExtract";
            this.txtDataExtract.Size = new System.Drawing.Size(785, 24);
            this.txtDataExtract.TabIndex = 1;
            this.txtDataExtract.Text = "C:\\Users\\Jim\\Documents\\Astronomy\\ALPO Online Content\\UploadReportData.csv";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data Extract File";
            // 
            // FrmUploadReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 623);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDataExtract);
            this.Controls.Add(this.btnGenerateRpt);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmUploadReport";
            this.Text = "Upload Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateRpt;
        private System.Windows.Forms.TextBox txtDataExtract;
        private System.Windows.Forms.Label label1;
    }
}