namespace WorldCup.Forms.Forms
{
    partial class SettingsForm
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
            btnCancel = new Button();
            btnConfirm = new Button();
            rbMen = new RadioButton();
            rbWomen = new RadioButton();
            gbGender = new GroupBox();
            groupBox2 = new GroupBox();
            rbHr = new RadioButton();
            rbEn = new RadioButton();
            gbGender.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(22, 300);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(246, 66);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Odustani";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            btnConfirm.DialogResult = DialogResult.OK;
            btnConfirm.ForeColor = Color.Black;
            btnConfirm.Location = new Point(472, 300);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(246, 66);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Potvrdi";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // rbMen
            // 
            rbMen.AutoSize = true;
            rbMen.Location = new Point(48, 40);
            rbMen.Name = "rbMen";
            rbMen.Size = new Size(77, 24);
            rbMen.TabIndex = 2;
            rbMen.TabStop = true;
            rbMen.Text = "Žensko";
            rbMen.UseVisualStyleBackColor = true;
            // 
            // rbWomen
            // 
            rbWomen.AutoSize = true;
            rbWomen.Location = new Point(48, 81);
            rbWomen.Name = "rbWomen";
            rbWomen.Size = new Size(73, 24);
            rbWomen.TabIndex = 3;
            rbWomen.TabStop = true;
            rbWomen.Text = "Muško";
            rbWomen.UseVisualStyleBackColor = true;
            // 
            // gbGender
            // 
            gbGender.Controls.Add(rbMen);
            gbGender.Controls.Add(rbWomen);
            gbGender.Location = new Point(80, 107);
            gbGender.Name = "gbGender";
            gbGender.Size = new Size(208, 125);
            gbGender.TabIndex = 6;
            gbGender.TabStop = false;
            gbGender.Text = "Spol";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbHr);
            groupBox2.Controls.Add(rbEn);
            groupBox2.Location = new Point(454, 107);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(208, 125);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Jezik";
            // 
            // rbHr
            // 
            rbHr.AutoSize = true;
            rbHr.Location = new Point(48, 40);
            rbHr.Name = "rbHr";
            rbHr.Size = new Size(117, 24);
            rbHr.TabIndex = 2;
            rbHr.TabStop = true;
            rbHr.Text = "Hrvatski jezik";
            rbHr.UseVisualStyleBackColor = true;
            // 
            // rbEn
            // 
            rbEn.AutoSize = true;
            rbEn.Location = new Point(48, 81);
            rbEn.Name = "rbEn";
            rbEn.Size = new Size(118, 24);
            rbEn.TabIndex = 3;
            rbEn.TabStop = true;
            rbEn.Text = "Engleski jezik";
            rbEn.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(742, 389);
            Controls.Add(groupBox2);
            Controls.Add(gbGender);
            Controls.Add(btnConfirm);
            Controls.Add(btnCancel);
            Name = "SettingsForm";
            Text = "SettingsForm";
            gbGender.ResumeLayout(false);
            gbGender.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCancel;
        private Button btnConfirm;
        private RadioButton rbMen;
        private RadioButton rbWomen;
        private GroupBox gbGender;
        private GroupBox groupBox2;
        private RadioButton rbHr;
        private RadioButton rbEn;
    }
}