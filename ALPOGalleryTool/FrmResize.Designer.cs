namespace ALPOGalleryTool
{
    partial class FrmResize
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDpi = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdjustSize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(361, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(875, 875);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "DPI:";
            // 
            // txtDpi
            // 
            this.txtDpi.Location = new System.Drawing.Point(82, 61);
            this.txtDpi.Name = "txtDpi";
            this.txtDpi.Size = new System.Drawing.Size(76, 28);
            this.txtDpi.TabIndex = 2;
            this.txtDpi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(82, 111);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(76, 28);
            this.txtHeight.TabIndex = 4;
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "HT:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(82, 167);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(76, 28);
            this.txtWidth.TabIndex = 6;
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 167);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "WD:";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(82, 224);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(108, 28);
            this.txtSize.TabIndex = 8;
            this.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 224);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "SZ:";
            // 
            // btnAdjustSize
            // 
            this.btnAdjustSize.BackgroundImage = global::ALPOGalleryTool.Properties.Resources.minus_icon;
            this.btnAdjustSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdjustSize.FlatAppearance.BorderSize = 0;
            this.btnAdjustSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjustSize.Location = new System.Drawing.Point(200, 143);
            this.btnAdjustSize.Name = "btnAdjustSize";
            this.btnAdjustSize.Size = new System.Drawing.Size(32, 32);
            this.btnAdjustSize.TabIndex = 9;
            this.btnAdjustSize.UseVisualStyleBackColor = true;
            this.btnAdjustSize.Click += new System.EventHandler(this.btnAdjustSize_Click);
            // 
            // FrmResize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 903);
            this.Controls.Add(this.btnAdjustSize);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDpi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmResize";
            this.Text = "Resize Image";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDpi;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdjustSize;
    }
}