namespace WorldCup.Forms.Forms
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            btnCancel = new Button();
            btnConfirm = new Button();
            rbWomen = new RadioButton();
            rbMen = new RadioButton();
            gbGender = new GroupBox();
            gbLanguage = new GroupBox();
            rbHr = new RadioButton();
            rbEn = new RadioButton();
            gbGender.SuspendLayout();
            gbLanguage.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.Name = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.DialogResult = DialogResult.OK;
            btnConfirm.ForeColor = Color.Black;
            resources.ApplyResources(btnConfirm, "btnConfirm");
            btnConfirm.Name = "btnConfirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // rbWomen
            // 
            resources.ApplyResources(rbWomen, "rbWomen");
            rbWomen.Name = "rbWomen";
            rbWomen.Tag = "men";
            rbWomen.UseVisualStyleBackColor = true;
            // 
            // rbMen
            // 
            resources.ApplyResources(rbMen, "rbMen");
            rbMen.Checked = true;
            rbMen.Name = "rbMen";
            rbMen.TabStop = true;
            rbMen.Tag = "women";
            rbMen.UseVisualStyleBackColor = true;
            // 
            // gbGender
            // 
            gbGender.Controls.Add(rbWomen);
            gbGender.Controls.Add(rbMen);
            resources.ApplyResources(gbGender, "gbGender");
            gbGender.Name = "gbGender";
            gbGender.TabStop = false;
            // 
            // gbLanguage
            // 
            gbLanguage.Controls.Add(rbHr);
            gbLanguage.Controls.Add(rbEn);
            resources.ApplyResources(gbLanguage, "gbLanguage");
            gbLanguage.Name = "gbLanguage";
            gbLanguage.TabStop = false;
            // 
            // rbHr
            // 
            resources.ApplyResources(rbHr, "rbHr");
            rbHr.Checked = true;
            rbHr.Name = "rbHr";
            rbHr.TabStop = true;
            rbHr.Tag = "hr";
            rbHr.UseVisualStyleBackColor = true;
            rbHr.CheckedChanged += rbHr_CheckedChanged;
            // 
            // rbEn
            // 
            resources.ApplyResources(rbEn, "rbEn");
            rbEn.Name = "rbEn";
            rbEn.Tag = "en";
            rbEn.UseVisualStyleBackColor = true;
            rbEn.CheckedChanged += rbEn_CheckedChanged;
            // 
            // Settings
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gbLanguage);
            Controls.Add(gbGender);
            Controls.Add(btnConfirm);
            Controls.Add(btnCancel);
            Name = "Settings";
            Load += Settings_Load;
            gbGender.ResumeLayout(false);
            gbGender.PerformLayout();
            gbLanguage.ResumeLayout(false);
            gbLanguage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCancel;
        private Button btnConfirm;
        private RadioButton rbWomen;
        private RadioButton rbMen;
        private GroupBox gbGender;
        private GroupBox gbLanguage;
        private RadioButton rbHr;
        private RadioButton rbEn;
    }
}