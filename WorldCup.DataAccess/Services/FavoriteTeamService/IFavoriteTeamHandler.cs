using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.DataAccess.Services.FavoriteTeamService
{
    public interface IFavoriteTeamHandler
    {
        void SaveFavoriteTeam(string team);
        string LoadFavoriteTeam();
    }
}
