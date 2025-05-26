namespace WorldCup.Forms.Forms
{
    partial class MainForm
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            lbTitleWorldCup = new Label();
            btnConfirmFavoriteTeam = new Button();
            label1 = new Label();
            cbTeams = new ComboBox();
            tabPage2 = new TabPage();
            flpFavorites = new FlowLayoutPanel();
            flpOthers = new FlowLayoutPanel();
            lbTitleFavoritePlayers = new Label();
            tabPage3 = new TabPage();
            dataGridView1 = new DataGridView();
            btnPrintPdf = new Button();
            lbCbTitleFilter = new Label();
            lbTitleRangList = new Label();
            cbFilter = new ComboBox();
            tabPage4 = new TabPage();
            groupBox1 = new GroupBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            groupBox2 = new GroupBox();
            rbHr = new RadioButton();
            rbEn = new RadioButton();
            gbGender = new GroupBox();
            rbMen = new RadioButton();
            rbWomen = new RadioButton();
            btnConfirmSettings = new Button();
            btnCancel = new Button();
            lbTitleSettings = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage4.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            gbGender.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lbTitleWorldCup);
            tabPage1.Controls.Add(btnConfirmFavoriteTeam);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(cbTeams);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 417);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbTitleWorldCup
            // 
            lbTitleWorldCup.AutoSize = true;
            lbTitleWorldCup.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitleWorldCup.Location = new Point(201, 32);
            lbTitleWorldCup.Name = "lbTitleWorldCup";
            lbTitleWorldCup.Size = new Size(391, 54);
            lbTitleWorldCup.TabIndex = 3;
            lbTitleWorldCup.Text = "Svijetsko prvenstvo";
            // 
            // btnConfirmFavoriteTeam
            // 
            btnConfirmFavoriteTeam.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirmFavoriteTeam.Location = new Point(279, 239);
            btnConfirmFavoriteTeam.Name = "btnConfirmFavoriteTeam";
            btnConfirmFavoriteTeam.Size = new Size(219, 43);
            btnConfirmFavoriteTeam.TabIndex = 2;
            btnConfirmFavoriteTeam.Text = "Spremi odabir";
            btnConfirmFavoriteTeam.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(279, 150);
            label1.Name = "label1";
            label1.Size = new Size(142, 28);
            label1.TabIndex = 1;
            label1.Text = "Omiljena ekipa";
            // 
            // cbTeams
            // 
            cbTeams.FormattingEnabled = true;
            cbTeams.Location = new Point(279, 181);
            cbTeams.Name = "cbTeams";
            cbTeams.Size = new Size(219, 28);
            cbTeams.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(flpFavorites);
            tabPage2.Controls.Add(flpOthers);
            tabPage2.Controls.Add(lbTitleFavoritePlayers);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 417);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // flpFavorites
            // 
            flpFavorites.Location = new Point(418, 116);
            flpFavorites.Name = "flpFavorites";
            flpFavorites.Size = new Size(354, 283);
            flpFavorites.TabIndex = 6;
            // 
            // flpOthers
            // 
            flpOthers.Location = new Point(25, 116);
            flpOthers.Name = "flpOthers";
            flpOthers.Size = new Size(354, 283);
            flpOthers.TabIndex = 5;
            // 
            // lbTitleFavoritePlayers
            // 
            lbTitleFavoritePlayers.AutoSize = true;
            lbTitleFavoritePlayers.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitleFavoritePlayers.Location = new Point(246, 29);
            lbTitleFavoritePlayers.Name = "lbTitleFavoritePlayers";
            lbTitleFavoritePlayers.Size = new Size(295, 54);
            lbTitleFavoritePlayers.TabIndex = 4;
            lbTitleFavoritePlayers.Text = "Omiljeni igrači";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dataGridView1);
            tabPage3.Controls.Add(btnPrintPdf);
            tabPage3.Controls.Add(lbCbTitleFilter);
            tabPage3.Controls.Add(lbTitleRangList);
            tabPage3.Controls.Add(cbFilter);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(792, 417);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(194, 107);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(581, 285);
            dataGridView1.TabIndex = 8;
            // 
            // btnPrintPdf
            // 
            btnPrintPdf.Location = new Point(622, 19);
            btnPrintPdf.Name = "btnPrintPdf";
            btnPrintPdf.Size = new Size(153, 54);
            btnPrintPdf.TabIndex = 7;
            btnPrintPdf.Text = "Ispiši";
            btnPrintPdf.UseVisualStyleBackColor = true;
            // 
            // lbCbTitleFilter
            // 
            lbCbTitleFilter.AutoSize = true;
            lbCbTitleFilter.Location = new Point(22, 84);
            lbCbTitleFilter.Name = "lbCbTitleFilter";
            lbCbTitleFilter.Size = new Size(42, 20);
            lbCbTitleFilter.TabIndex = 6;
            lbCbTitleFilter.Text = "Filter";
            // 
            // lbTitleRangList
            // 
            lbTitleRangList.AutoSize = true;
            lbTitleRangList.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitleRangList.Location = new Point(285, 19);
            lbTitleRangList.Name = "lbTitleRangList";
            lbTitleRangList.Size = new Size(209, 54);
            lbTitleRangList.TabIndex = 5;
            lbTitleRangList.Text = "Rang liste";
            // 
            // cbFilter
            // 
            cbFilter.FormattingEnabled = true;
            cbFilter.Location = new Point(22, 107);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(151, 28);
            cbFilter.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(groupBox1);
            tabPage4.Controls.Add(groupBox2);
            tabPage4.Controls.Add(gbGender);
            tabPage4.Controls.Add(btnConfirmSettings);
            tabPage4.Controls.Add(btnCancel);
            tabPage4.Controls.Add(lbTitleSettings);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(792, 417);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Location = new Point(292, 136);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(208, 125);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Jezik";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(48, 40);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(117, 24);
            radioButton1.TabIndex = 2;
            radioButton1.TabStop = true;
            radioButton1.Text = "Hrvatski jezik";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(48, 81);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(118, 24);
            radioButton2.TabIndex = 3;
            radioButton2.TabStop = true;
            radioButton2.Text = "Engleski jezik";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbHr);
            groupBox2.Controls.Add(rbEn);
            groupBox2.Location = new Point(533, 136);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(208, 125);
            groupBox2.TabIndex = 11;
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
            // gbGender
            // 
            gbGender.Controls.Add(rbMen);
            gbGender.Controls.Add(rbWomen);
            gbGender.Location = new Point(51, 136);
            gbGender.Name = "gbGender";
            gbGender.Size = new Size(208, 125);
            gbGender.TabIndex = 10;
            gbGender.TabStop = false;
            gbGender.Text = "Spol";
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
            // btnConfirmSettings
            // 
            btnConfirmSettings.DialogResult = DialogResult.OK;
            btnConfirmSettings.ForeColor = Color.Black;
            btnConfirmSettings.Location = new Point(522, 330);
            btnConfirmSettings.Name = "btnConfirmSettings";
            btnConfirmSettings.Size = new Size(246, 66);
            btnConfirmSettings.TabIndex = 9;
            btnConfirmSettings.Text = "Potvrdi";
            btnConfirmSettings.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(24, 330);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(246, 66);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Odustani";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbTitleSettings
            // 
            lbTitleSettings.AutoSize = true;
            lbTitleSettings.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitleSettings.Location = new Point(300, 24);
            lbTitleSettings.Name = "lbTitleSettings";
            lbTitleSettings.Size = new Size(192, 54);
            lbTitleSettings.TabIndex = 6;
            lbTitleSettings.Text = "Postavke";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            gbGender.ResumeLayout(false);
            gbGender.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label lbTitleWorldCup;
        private Button btnConfirmFavoriteTeam;
        private Label label1;
        private ComboBox cbTeams;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private FlowLayoutPanel flpFavorites;
        private FlowLayoutPanel flpOthers;
        private Label lbTitleFavoritePlayers;
        private Label lbTitleRangList;
        private ComboBox cbFilter;
        private Button btnPrintPdf;
        private Label lbCbTitleFilter;
        private Label lbTitleSettings;
        private GroupBox groupBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private GroupBox groupBox2;
        private RadioButton rbHr;
        private RadioButton rbEn;
        private GroupBox gbGender;
        private RadioButton rbMen;
        private RadioButton rbWomen;
        private Button btnConfirmSettings;
        private Button btnCancel;
        private DataGridView dataGridView1;
    }
}