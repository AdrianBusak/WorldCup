using System.Threading.Tasks;
using WorldCup.DataAccess.Repositorys;

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
            var test = await repository.GetCountryMatchesAsync("CRO");
            test.ForEach(test => {
                string temp = test.AwayTeam.Code != "CRO" ? test.AwayTeamCountry : test.HomeTeamCountry;
                lsTest.Items.Add($"{temp.ToString()}");
            });
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            await Status();
        }
    }
}
