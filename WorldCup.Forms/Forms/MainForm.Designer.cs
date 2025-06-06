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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            lbTitleWorldCup = new Label();
            btnConfirmFavoriteTeam = new Button();
            label1 = new Label();
            cbTeams = new ComboBox();
            tabPage2 = new TabPage();
            lbFavoritePlayers = new Label();
            lbPlayers = new Label();
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
            gbLanguage = new GroupBox();
            rbHr = new RadioButton();
            rbEn = new RadioButton();
            gbDataSource = new GroupBox();
            rbApi = new RadioButton();
            rbJson = new RadioButton();
            gbGender = new GroupBox();
            rbMen = new RadioButton();
            rbWomen = new RadioButton();
            btnConfirmSettings = new Button();
            lbTitleSettings = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage4.SuspendLayout();
            gbLanguage.SuspendLayout();
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
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lbTitleWorldCup);
            tabPage1.Controls.Add(btnConfirmFavoriteTeam);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(cbTeams);
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Name = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Enter += tabPage1_Enter;
            tabPage1.Leave += tabPage1_LeaveAsync;
            // 
            // lbTitleWorldCup
            // 
            resources.ApplyResources(lbTitleWorldCup, "lbTitleWorldCup");
            lbTitleWorldCup.Name = "lbTitleWorldCup";
            // 
            // btnConfirmFavoriteTeam
            // 
            btnConfirmFavoriteTeam.BackColor = Color.LightCoral;
            resources.ApplyResources(btnConfirmFavoriteTeam, "btnConfirmFavoriteTeam");
            btnConfirmFavoriteTeam.Name = "btnConfirmFavoriteTeam";
            btnConfirmFavoriteTeam.UseVisualStyleBackColor = false;
            btnConfirmFavoriteTeam.Click += btnConfirmFavoriteTeam_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // cbTeams
            // 
            cbTeams.FormattingEnabled = true;
            resources.ApplyResources(cbTeams, "cbTeams");
            cbTeams.Name = "cbTeams";
            cbTeams.SelectionChangeCommitted += cbTeams_SelectionChangeCommitted;
            cbTeams.SelectedValueChanged += cbTeams_SelectedValueChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(lbFavoritePlayers);
            tabPage2.Controls.Add(lbPlayers);
            tabPage2.Controls.Add(flpFavorites);
            tabPage2.Controls.Add(flpOthers);
            tabPage2.Controls.Add(lbTitleFavoritePlayers);
            resources.ApplyResources(tabPage2, "tabPage2");
            tabPage2.Name = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Enter += tabPage2_Enter;
            tabPage2.Leave += tabPage2_Leave;
            // 
            // lbFavoritePlayers
            // 
            resources.ApplyResources(lbFavoritePlayers, "lbFavoritePlayers");
            lbFavoritePlayers.Name = "lbFavoritePlayers";
            // 
            // lbPlayers
            // 
            resources.ApplyResources(lbPlayers, "lbPlayers");
            lbPlayers.Name = "lbPlayers";
            // 
            // flpFavorites
            // 
            flpFavorites.AllowDrop = true;
            resources.ApplyResources(flpFavorites, "flpFavorites");
            flpFavorites.BorderStyle = BorderStyle.FixedSingle;
            flpFavorites.Name = "flpFavorites";
            flpFavorites.DragDrop += flpFavorites_DragDrop;
            flpFavorites.DragEnter += flpFavorites_DragEnter;
            // 
            // flpOthers
            // 
            flpOthers.AllowDrop = true;
            resources.ApplyResources(flpOthers, "flpOthers");
            flpOthers.BorderStyle = BorderStyle.FixedSingle;
            flpOthers.Name = "flpOthers";
            flpOthers.DragDrop += flpOthers_DragDrop;
            flpOthers.DragEnter += flpOthers_DragEnter;
            // 
            // lbTitleFavoritePlayers
            // 
            resources.ApplyResources(lbTitleFavoritePlayers, "lbTitleFavoritePlayers");
            lbTitleFavoritePlayers.Name = "lbTitleFavoritePlayers";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dataGridView1);
            tabPage3.Controls.Add(btnPrintPdf);
            tabPage3.Controls.Add(lbCbTitleFilter);
            tabPage3.Controls.Add(lbTitleRangList);
            tabPage3.Controls.Add(cbFilter);
            resources.ApplyResources(tabPage3, "tabPage3");
            tabPage3.Name = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.Enter += tabPage3_EnterAsync;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 100;
            // 
            // btnPrintPdf
            // 
            resources.ApplyResources(btnPrintPdf, "btnPrintPdf");
            btnPrintPdf.Name = "btnPrintPdf";
            btnPrintPdf.UseVisualStyleBackColor = true;
            btnPrintPdf.Click += btnPrintPdf_Click;
            // 
            // lbCbTitleFilter
            // 
            resources.ApplyResources(lbCbTitleFilter, "lbCbTitleFilter");
            lbCbTitleFilter.Name = "lbCbTitleFilter";
            // 
            // lbTitleRangList
            // 
            resources.ApplyResources(lbTitleRangList, "lbTitleRangList");
            lbTitleRangList.Name = "lbTitleRangList";
            // 
            // cbFilter
            // 
            cbFilter.FormattingEnabled = true;
            resources.ApplyResources(cbFilter, "cbFilter");
            cbFilter.Name = "cbFilter";
            cbFilter.SelectedValueChanged += cbFilter_SelectedValueChanged;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(gbLanguage);
            tabPage4.Controls.Add(gbDataSource);
            tabPage4.Controls.Add(gbGender);
            tabPage4.Controls.Add(btnConfirmSettings);
            tabPage4.Controls.Add(lbTitleSettings);
            resources.ApplyResources(tabPage4, "tabPage4");
            tabPage4.Name = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            tabPage4.Enter += tabPage4_Enter;
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
            // 
            // rbEn
            // 
            resources.ApplyResources(rbEn, "rbEn");
            rbEn.Name = "rbEn";
            rbEn.TabStop = true;
            rbEn.Tag = "en";
            rbEn.UseVisualStyleBackColor = true;
            // 
            // gbDataSource
            // 
            gbDataSource.Controls.Add(rbApi);
            gbDataSource.Controls.Add(rbJson);
            resources.ApplyResources(gbDataSource, "gbDataSource");
            gbDataSource.Name = "gbDataSource";
            gbDataSource.TabStop = false;
            // 
            // rbApi
            // 
            resources.ApplyResources(rbApi, "rbApi");
            rbApi.Checked = true;
            rbApi.Name = "rbApi";
            rbApi.TabStop = true;
            rbApi.Tag = "api";
            rbApi.UseVisualStyleBackColor = true;
            // 
            // rbJson
            // 
            resources.ApplyResources(rbJson, "rbJson");
            rbJson.Name = "rbJson";
            rbJson.Tag = "json";
            rbJson.UseVisualStyleBackColor = true;
            // 
            // gbGender
            // 
            gbGender.Controls.Add(rbMen);
            gbGender.Controls.Add(rbWomen);
            resources.ApplyResources(gbGender, "gbGender");
            gbGender.Name = "gbGender";
            gbGender.TabStop = false;
            // 
            // rbMen
            // 
            resources.ApplyResources(rbMen, "rbMen");
            rbMen.Name = "rbMen";
            rbMen.Tag = "women";
            rbMen.UseVisualStyleBackColor = true;
            // 
            // rbWomen
            // 
            resources.ApplyResources(rbWomen, "rbWomen");
            rbWomen.Checked = true;
            rbWomen.Name = "rbWomen";
            rbWomen.TabStop = true;
            rbWomen.Tag = "men";
            rbWomen.UseVisualStyleBackColor = true;
            // 
            // btnConfirmSettings
            // 
            btnConfirmSettings.DialogResult = DialogResult.OK;
            btnConfirmSettings.ForeColor = Color.Black;
            resources.ApplyResources(btnConfirmSettings, "btnConfirmSettings");
            btnConfirmSettings.Name = "btnConfirmSettings";
            btnConfirmSettings.UseVisualStyleBackColor = true;
            btnConfirmSettings.Click += btnConfirmSettings_ClickAsync;
            // 
            // lbTitleSettings
            // 
            resources.ApplyResources(lbTitleSettings, "lbTitleSettings");
            lbTitleSettings.Name = "lbTitleSettings";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Name = "MainForm";
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
            gbLanguage.ResumeLayout(false);
            gbLanguage.PerformLayout();
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
        private GroupBox gbLanguage;
        private RadioButton rbHr;
        private RadioButton rbEn;
        private GroupBox gbDataSource;
        private RadioButton rbApi;
        private RadioButton rbJson;
        private GroupBox gbGender;
        private RadioButton rbMen;
        private RadioButton rbWomen;
        private Button btnConfirmSettings;
        private Label lbFavoritePlayers;
        private Label lbPlayers;
        private DataGridView dataGridView1;
    }
}