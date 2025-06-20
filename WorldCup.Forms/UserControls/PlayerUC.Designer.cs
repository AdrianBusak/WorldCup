﻿namespace WorldCup.Forms.UserControls
{
    partial class PlayerUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbImage = new PictureBox();
            pbStarFavorite = new PictureBox();
            lbPosition = new Label();
            lbNumber = new Label();
            lbName = new Label();
            pbCaptain = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbStarFavorite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCaptain).BeginInit();
            SuspendLayout();
            // 
            // pbImage
            // 
            pbImage.Image = Properties.Resources.football_player;
            pbImage.Location = new Point(255, 3);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(96, 96);
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbImage.TabIndex = 0;
            pbImage.TabStop = false;
            pbImage.DoubleClick += pbImage_DoubleClick;
            // 
            // pbStarFavorite
            // 
            pbStarFavorite.Image = Properties.Resources.starIcon;
            pbStarFavorite.Location = new Point(219, 3);
            pbStarFavorite.Name = "pbStarFavorite";
            pbStarFavorite.Size = new Size(30, 30);
            pbStarFavorite.SizeMode = PictureBoxSizeMode.StretchImage;
            pbStarFavorite.TabIndex = 2;
            pbStarFavorite.TabStop = false;
            // 
            // lbPosition
            // 
            lbPosition.AutoSize = true;
            lbPosition.Font = new Font("Segoe UI", 10.8F);
            lbPosition.Location = new Point(9, 70);
            lbPosition.Name = "lbPosition";
            lbPosition.Size = new Size(109, 25);
            lbPosition.TabIndex = 7;
            lbPosition.Text = "Pozicija: Mid";
            // 
            // lbNumber
            // 
            lbNumber.AutoSize = true;
            lbNumber.Font = new Font("Segoe UI", 10.8F);
            lbNumber.Location = new Point(9, 41);
            lbNumber.Name = "lbNumber";
            lbNumber.Size = new Size(62, 25);
            lbNumber.TabIndex = 6;
            lbNumber.Text = "Broj: 4";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Font = new Font("Segoe UI", 10.8F);
            lbName.Location = new Point(9, 10);
            lbName.Name = "lbName";
            lbName.Size = new Size(140, 25);
            lbName.TabIndex = 5;
            lbName.Text = "Ime: Ivan Rakitić";
            // 
            // pbCaptain
            // 
            pbCaptain.Image = Properties.Resources.captainIcon;
            pbCaptain.InitialImage = Properties.Resources.captainIcon;
            pbCaptain.Location = new Point(219, 39);
            pbCaptain.Name = "pbCaptain";
            pbCaptain.Size = new Size(30, 30);
            pbCaptain.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCaptain.TabIndex = 8;
            pbCaptain.TabStop = false;
            // 
            // PlayerUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pbCaptain);
            Controls.Add(lbPosition);
            Controls.Add(lbNumber);
            Controls.Add(lbName);
            Controls.Add(pbStarFavorite);
            Controls.Add(pbImage);
            Margin = new Padding(2);
            Name = "PlayerUC";
            Size = new Size(348, 98);
            Load += PlayerUC_Load;
            MouseClick += PlayerUC_MouseClick;
            MouseDown += PlayerUC_MouseDown;
            MouseMove += PlayerUC_MouseMove;
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbStarFavorite).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCaptain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbImage;
        private PictureBox pbStarFavorite;
        private Label lbPosition;
        private Label lbNumber;
        private Label lbName;
        private PictureBox pbCaptain;
    }
}
