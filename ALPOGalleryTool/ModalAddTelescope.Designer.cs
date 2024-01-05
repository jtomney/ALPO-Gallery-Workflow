namespace ALPOGalleryTool
{
    partial class ModalAddTelescope
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
            this.grpTelescopeCntrls = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtAperture = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFocalLen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFocalRatio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInitials = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbScopeType = new System.Windows.Forms.ComboBox();
            this.grpTelescopeCntrls.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTelescopeCntrls
            // 
            this.grpTelescopeCntrls.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grpTelescopeCntrls.Controls.Add(this.cmbScopeType);
            this.grpTelescopeCntrls.Controls.Add(this.btnAdd);
            this.grpTelescopeCntrls.Controls.Add(this.txtAperture);
            this.grpTelescopeCntrls.Controls.Add(this.label6);
            this.grpTelescopeCntrls.Controls.Add(this.txtFocalLen);
            this.grpTelescopeCntrls.Controls.Add(this.label5);
            this.grpTelescopeCntrls.Controls.Add(this.txtFocalRatio);
            this.grpTelescopeCntrls.Controls.Add(this.label4);
            this.grpTelescopeCntrls.Controls.Add(this.txtInitials);
            this.grpTelescopeCntrls.Controls.Add(this.label3);
            this.grpTelescopeCntrls.Controls.Add(this.txtNotes);
            this.grpTelescopeCntrls.Controls.Add(this.label2);
            this.grpTelescopeCntrls.Controls.Add(this.label1);
            this.grpTelescopeCntrls.Location = new System.Drawing.Point(27, 23);
            this.grpTelescopeCntrls.Name = "grpTelescopeCntrls";
            this.grpTelescopeCntrls.Size = new System.Drawing.Size(490, 429);
            this.grpTelescopeCntrls.TabIndex = 3;
            this.grpTelescopeCntrls.TabStop = false;
            this.grpTelescopeCntrls.Text = "Telescope Information";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(165, 374);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 31);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add Telescope";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtAperture
            // 
            this.txtAperture.Location = new System.Drawing.Point(182, 319);
            this.txtAperture.Name = "txtAperture";
            this.txtAperture.Size = new System.Drawing.Size(54, 27);
            this.txtAperture.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Aperture";
            // 
            // txtFocalLen
            // 
            this.txtFocalLen.Location = new System.Drawing.Point(182, 272);
            this.txtFocalLen.Name = "txtFocalLen";
            this.txtFocalLen.Size = new System.Drawing.Size(82, 27);
            this.txtFocalLen.TabIndex = 9;
            this.txtFocalLen.Text = "-1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Focal Length";
            // 
            // txtFocalRatio
            // 
            this.txtFocalRatio.Location = new System.Drawing.Point(182, 225);
            this.txtFocalRatio.Name = "txtFocalRatio";
            this.txtFocalRatio.Size = new System.Drawing.Size(54, 27);
            this.txtFocalRatio.TabIndex = 7;
            this.txtFocalRatio.Text = "-1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Focal Ratio";
            // 
            // txtInitials
            // 
            this.txtInitials.Location = new System.Drawing.Point(182, 178);
            this.txtInitials.Name = "txtInitials";
            this.txtInitials.Size = new System.Drawing.Size(96, 27);
            this.txtInitials.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Initials";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(182, 131);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(217, 27);
            this.txtNotes.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Notes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scope Type";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(537, 23);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbScopeType
            // 
            this.cmbScopeType.FormattingEnabled = true;
            this.cmbScopeType.Location = new System.Drawing.Point(184, 84);
            this.cmbScopeType.Name = "cmbScopeType";
            this.cmbScopeType.Size = new System.Drawing.Size(121, 28);
            this.cmbScopeType.TabIndex = 14;
            // 
            // ModalAddTelescope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(625, 479);
            this.ControlBox = false;
            this.Controls.Add(this.grpTelescopeCntrls);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ModalAddTelescope";
            this.Text = "Add Telescope Equipment";
            this.grpTelescopeCntrls.ResumeLayout(false);
            this.grpTelescopeCntrls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTelescopeCntrls;
        private System.Windows.Forms.ComboBox cmbScopeType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtAperture;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFocalLen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFocalRatio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInitials;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
    }
}