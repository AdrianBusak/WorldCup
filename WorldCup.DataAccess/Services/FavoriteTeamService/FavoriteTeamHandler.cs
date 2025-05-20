using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.DataAccess.Services.FavoriteTeamService
{
    internal class FavoriteTeamHandler : IFavoriteTeamHandler
    {
        private const string PATH = @"assets\favoriteTeam.txt";
        public string LoadFavoriteTeam()
        {
            if (!File.Exists(PATH))
            {
                throw new FileNotFoundException();
            }

            var team = File.ReadAllText(PATH);

            if (string.IsNullOrEmpty(team))
            {
                throw new NullReferenceException();
            }

            return team;
        }

        public void SaveFavoriteTeam(string team)
        {
            if (!File.Exists(PATH))
            {
                try
                {
                    File.WriteAllText(PATH, team);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
