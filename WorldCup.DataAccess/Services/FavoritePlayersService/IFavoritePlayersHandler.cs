using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Models;

namespace WorldCup.DataAccess.Services.FavoritePlayersService
{
    internal interface IFavoritePlayersHandler
    {
        void SaveFavoritePlayers(IEnumerable<Player> players);
        Task<IEnumerable<Player>> LoadFavoritePlayers();
    }
}
