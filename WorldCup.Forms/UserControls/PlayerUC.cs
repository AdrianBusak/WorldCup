using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.DataAccess.Models;
using WorldCup.Forms.Properties;

namespace WorldCup.Forms.UserControls
{
    public partial class PlayerUC : UserControl
    {
        private Point mouseDownLocation;

        public PlayerUC(Player player)
        {
            InitializeComponent();
            RegisterMouseClick(this, true);
            Player = player;
        }

        public Player Player { get; private set; }
        public bool IsSelected { get; set; }

        public string Name
        {
            get => lbName.Text;
            set
            {
                lbName.Text = value;
            }
        }
        public int ShirtNumber
        {
            get => int.TryParse(lbNumber.Text, out int number) ? number : 0;
            set
            {
                lbNumber.Text = value.ToString();
            }
        }
        public string Position
        {
            get => lbPosition.Text;
            set
            {
                lbPosition.Text = value;
            }
        }
        public bool IsCaptain
        {
            get => pbCaptain.Visible;
            set
            {
                pbCaptain.Visible = value;
            }
        }
        public bool IsFavorite
        {
            get => pbStarFavorite.Visible;
            set
            {
                pbStarFavorite.Visible = value;
            }
        }
        private string _imagePath;

        public string PlayerImage
        {
            get => _imagePath;
            set
            {
                _imagePath = value;

                if (File.Exists(value))
                {
                    pbImage.ImageLocation = value;
                }
                else
                {
                    pbImage.Image = Resources.football_player;
                    pbImage.ImageLocation = null;
                }
            }
        }


        private void ToggleSelection()
        {
            IsSelected = !IsSelected;
            this.BackColor = IsSelected ? Color.LightBlue : SystemColors.Control;
        }

        private void SelectPlayer()
        {
            IsSelected = true;
            this.BackColor = Color.LightBlue;
        }

        private void Deselect()
        {
            IsSelected = false;
            this.BackColor = SystemColors.Control;
        }

        private void DeselectAllInParent()
        {
            if (this.Parent is FlowLayoutPanel panel)
            {
                foreach (var ctrl in panel.Controls.OfType<PlayerUC>())
                {
                    ctrl.Deselect();
                }
            }
        }

        private void PlayerUC_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
        }

        private void PlayerUC_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Pokreni drag ako je miš pomaknut
                if (Math.Abs(e.X - mouseDownLocation.X) > SystemInformation.DragSize.Width ||
                    Math.Abs(e.Y - mouseDownLocation.Y) > SystemInformation.DragSize.Height)
                {
                    if (this.Parent is FlowLayoutPanel parent)
                    {
                        var selected = parent.Controls
                            .OfType<PlayerUC>()
                            .Where(x => x.IsSelected)
                            .ToList();

                        if (selected.Count == 0)
                            selected.Add(this);

                        DoDragDrop(selected, DragDropEffects.Move);
                    }
                }
            }
        }

        private void PlayerUC_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                ToggleSelection();
            }
            else
            {
                DeselectAllInParent();
                SelectPlayer();
            }
        }


        private void RegisterMouseClick(Control control, bool skipRoot = false)
        {
            if (!skipRoot)
                control.MouseClick += PlayerUC_MouseClick;

            foreach (Control child in control.Controls)
                RegisterMouseClick(child);
        }

        private void PlayerUC_Load(object sender, EventArgs e)
        {
            lbName.Text = Player.Name;
            lbNumber.Text = Player.ShirtNumber.ToString();
            lbPosition.Text = Player.Position;
            pbCaptain.Visible = Player.Captain;
        }

        private void pbImage_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Player Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pbImage.Image = Image.FromFile(openFileDialog.FileName);
                        PlayerImage = openFileDialog.FileName;
                    }
                    catch
                    {
                        MessageBox.Show("Failed to load image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
