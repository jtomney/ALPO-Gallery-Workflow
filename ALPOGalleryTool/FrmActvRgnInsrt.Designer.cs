namespace ALPOGalleryTool
{
    partial class FrmActvRgnInsrt
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtActvRgn = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lstCurAR = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewAR = new System.Windows.Forms.TextBox();
            this.btnPost = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // dtActvRgn
            // 
            this.dtActvRgn.CustomFormat = "MM/dd/yyyy";
            this.dtActvRgn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtActvRgn.Location = new System.Drawing.Point(113, 21);
            this.dtActvRgn.Name = "dtActvRgn";
            this.dtActvRgn.Size = new System.Drawing.Size(105, 24);
            this.dtActvRgn.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Existing:";
            // 
            // lstCurAR
            // 
            this.lstCurAR.FormattingEnabled = true;
            this.lstCurAR.ItemHeight = 18;
            this.lstCurAR.Location = new System.Drawing.Point(113, 70);
            this.lstCurAR.Name = "lstCurAR";
            this.lstCurAR.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstCurAR.Size = new System.Drawing.Size(105, 238);
            this.lstCurAR.TabIndex = 3;
            this.lstCurAR.DoubleClick += new System.EventHandler(this.lstCurAR_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "New:";
            // 
            // txtNewAR
            // 
            this.txtNewAR.Location = new System.Drawing.Point(305, 70);
            this.txtNewAR.Name = "txtNewAR";
            this.txtNewAR.Size = new System.Drawing.Size(447, 24);
            this.txtNewAR.TabIndex = 5;
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(461, 138);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 29);
            this.btnPost.TabIndex = 6;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // FrmActvRgnInsrt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 681);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.txtNewAR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstCurAR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtActvRgn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmActvRgnInsrt";
            this.Text = "Insert Active Regions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtActvRgn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstCurAR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewAR;
        private System.Windows.Forms.Button btnPost;
    }
}