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
            gbDataSource = new GroupBox();
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
            gbDataSource.SuspendLayout();
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
            tabControl1.Size = new Size(882, 493);
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
            tabPage1.Size = new Size(874, 460);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Početna";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbTitleWorldCup
            // 
            lbTitleWorldCup.AutoSize = true;
            lbTitleWorldCup.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitleWorldCup.Location = new Point(234, 76);
            lbTitleWorldCup.Name = "lbTitleWorldCup";
            lbTitleWorldCup.Size = new Size(391, 54);
            lbTitleWorldCup.TabIndex = 3;
            lbTitleWorldCup.Text = "Svijetsko prvenstvo";
            // 
            // btnConfirmFavoriteTeam
            // 
            btnConfirmFavoriteTeam.BackColor = Color.LightCoral;
            btnConfirmFavoriteTeam.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirmFavoriteTeam.Location = new Point(312, 283);
            btnConfirmFavoriteTeam.Name = "btnConfirmFavoriteTeam";
            btnConfirmFavoriteTeam.Size = new Size(219, 43);
            btnConfirmFavoriteTeam.TabIndex = 2;
            btnConfirmFavoriteTeam.Text = "Spremi odabir";
            btnConfirmFavoriteTeam.UseVisualStyleBackColor = false;
            btnConfirmFavoriteTeam.Click += btnConfirmFavoriteTeam_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(312, 194);
            label1.Name = "label1";
            label1.Size = new Size(142, 28);
            label1.TabIndex = 1;
            label1.Text = "Omiljena ekipa";
            // 
            // cbTeams
            // 
            cbTeams.FormattingEnabled = true;
            cbTeams.Location = new Point(312, 225);
            cbTeams.Name = "cbTeams";
            cbTeams.Size = new Size(219, 28);
            cbTeams.TabIndex = 0;
            cbTeams.SelectionChangeCommitted += cbTeams_SelectionChangeCommitted;
            cbTeams.SelectedValueChanged += cbTeams_SelectedValueChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(flpFavorites);
            tabPage2.Controls.Add(flpOthers);
            tabPage2.Controls.Add(lbTitleFavoritePlayers);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(874, 460);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Igrači";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Enter += tabPage2_Enter;
            // 
            // flpFavorites
            // 
            flpFavorites.AllowDrop = true;
            flpFavorites.AutoScroll = true;
            flpFavorites.BorderStyle = BorderStyle.FixedSingle;
            flpFavorites.FlowDirection = FlowDirection.TopDown;
            flpFavorites.Location = new Point(457, 94);
            flpFavorites.Name = "flpFavorites";
            flpFavorites.Size = new Size(386, 310);
            flpFavorites.TabIndex = 6;
            flpFavorites.WrapContents = false;
            flpFavorites.DragDrop += flpFavorites_DragDrop;
            flpFavorites.DragEnter += flpFavorites_DragEnter;
            // 
            // flpOthers
            // 
            flpOthers.AllowDrop = true;
            flpOthers.AutoScroll = true;
            flpOthers.BorderStyle = BorderStyle.FixedSingle;
            flpOthers.FlowDirection = FlowDirection.TopDown;
            flpOthers.Location = new Point(29, 94);
            flpOthers.Name = "flpOthers";
            flpOthers.Size = new Size(386, 310);
            flpOthers.TabIndex = 5;
            flpOthers.WrapContents = false;
            flpOthers.DragDrop += flpOthers_DragDrop;
            flpOthers.DragEnter += flpOthers_DragEnter;
            // 
            // lbTitleFavoritePlayers
            // 
            lbTitleFavoritePlayers.AutoSize = true;
            lbTitleFavoritePlayers.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitleFavoritePlayers.Location = new Point(290, 16);
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
            tabPage3.Size = new Size(874, 460);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Rang liste";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(233, 107);
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
            lbCbTitleFilter.Location = new Point(24, 84);
            lbCbTitleFilter.Name = "lbCbTitleFilter";
            lbCbTitleFilter.Size = new Size(42, 20);
            lbCbTitleFilter.TabIndex = 6;
            lbCbTitleFilter.Text = "Filter";
            // 
            // lbTitleRangList
            // 
            lbTitleRangList.AutoSize = true;
            lbTitleRangList.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitleRangList.Location = new Point(324, 19);
            lbTitleRangList.Name = "lbTitleRangList";
            lbTitleRangList.Size = new Size(209, 54);
            lbTitleRangList.TabIndex = 5;
            lbTitleRangList.Text = "Rang liste";
            // 
            // cbFilter
            // 
            cbFilter.FormattingEnabled = true;
            cbFilter.Location = new Point(24, 107);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(178, 28);
            cbFilter.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(groupBox1);
            tabPage4.Controls.Add(gbDataSource);
            tabPage4.Controls.Add(gbGender);
            tabPage4.Controls.Add(btnConfirmSettings);
            tabPage4.Controls.Add(btnCancel);
            tabPage4.Controls.Add(lbTitleSettings);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(874, 460);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Postavke";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Location = new Point(333, 156);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(208, 125);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Jezik";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
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
            // gbDataSource
            // 
            gbDataSource.Controls.Add(rbHr);
            gbDataSource.Controls.Add(rbEn);
            gbDataSource.Location = new Point(574, 156);
            gbDataSource.Name = "gbDataSource";
            gbDataSource.Size = new Size(208, 125);
            gbDataSource.TabIndex = 11;
            gbDataSource.TabStop = false;
            gbDataSource.Text = "Izvor";
            // 
            // rbHr
            // 
            rbHr.AutoSize = true;
            rbHr.Checked = true;
            rbHr.Location = new Point(48, 40);
            rbHr.Name = "rbHr";
            rbHr.Size = new Size(52, 24);
            rbHr.TabIndex = 2;
            rbHr.TabStop = true;
            rbHr.Text = "API";
            rbHr.UseVisualStyleBackColor = true;
            // 
            // rbEn
            // 
            rbEn.AutoSize = true;
            rbEn.Location = new Point(48, 81);
            rbEn.Name = "rbEn";
            rbEn.Size = new Size(65, 24);
            rbEn.TabIndex = 3;
            rbEn.Text = "JSON";
            rbEn.UseVisualStyleBackColor = true;
            // 
            // gbGender
            // 
            gbGender.Controls.Add(rbMen);
            gbGender.Controls.Add(rbWomen);
            gbGender.Location = new Point(92, 156);
            gbGender.Name = "gbGender";
            gbGender.Size = new Size(208, 125);
            gbGender.TabIndex = 10;
            gbGender.TabStop = false;
            gbGender.Text = "Spol";
            // 
            // rbMen
            // 
            rbMen.AutoSize = true;
            rbMen.Location = new Point(54, 81);
            rbMen.Name = "rbMen";
            rbMen.Size = new Size(77, 24);
            rbMen.TabIndex = 2;
            rbMen.Text = "Žensko";
            rbMen.UseVisualStyleBackColor = true;
            // 
            // rbWomen
            // 
            rbWomen.AutoSize = true;
            rbWomen.Checked = true;
            rbWomen.Location = new Point(54, 40);
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
            btnConfirmSettings.Location = new Point(563, 350);
            btnConfirmSettings.Name = "btnConfirmSettings";
            btnConfirmSettings.Size = new Size(246, 66);
            btnConfirmSettings.TabIndex = 9;
            btnConfirmSettings.Text = "Potvrdi";
            btnConfirmSettings.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(65, 350);
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
            lbTitleSettings.Location = new Point(341, 44);
            lbTitleSettings.Name = "lbTitleSettings";
            lbTitleSettings.Size = new Size(192, 54);
            lbTitleSettings.TabIndex = 6;
            lbTitleSettings.Text = "Postavke";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 493);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
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
            gbDataSource.ResumeLayout(false);
            gbDataSource.PerformLayout();
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
        private GroupBox gbDataSource;
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