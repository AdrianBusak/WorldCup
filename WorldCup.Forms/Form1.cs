using System.Threading.Tasks;
using WorldCup.DataAccess.Models;
using WorldCup.DataAccess.Repositories;

namespace WorldCup.Forms
{
    public partial class Form1 : Form
    {
        private DataRepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new DataRepository();
        }

        public async Task Status()
        {
            try
            {
                repository.SaveSettings(new AppSettings() { Competition = "women", DataSource = "api", Language = "hr" });
                var test = await repository.GetTeamsAsync();

                test.ForEach(test =>
                {

                    lsTest.Items.Add($"{test.Country} - {test.Wins}");
                });

                AppSettings appSettings = repository.LoadSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            await Status();
        }
    }
}
