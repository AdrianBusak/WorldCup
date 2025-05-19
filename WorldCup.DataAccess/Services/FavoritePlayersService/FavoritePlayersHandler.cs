using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Models;

namespace WorldCup.DataAccess.Services.FavoritePlayersService
{
    internal class FavoritePlayersHandler : IFavoritePlayersHandler
    {
        public Task<List<Player>> LoadFavoritePlayers()
        {
            throw new NotImplementedException();
        }

        public void SaveFavoritePlayers(List<Player> players)
        {
            throw new NotImplementedException();
        }
    }
}
