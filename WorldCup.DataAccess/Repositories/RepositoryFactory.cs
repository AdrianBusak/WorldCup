using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Models;
using WorldCup.DataAccess.Repositories.ApiData;
using WorldCup.DataAccess.Repositories.FileData;
using WorldCup.DataAccess.Repositories.Interfaces;
using WorldCup.DataAccess.Services.AppSettingsService;
using WorldCup.DataAccess.Services.FavoritePlayersService;
using WorldCup.DataAccess.Services.FavoriteTeamService;
using WorldCup.DataAccess.Services.PlayerImagePathService;

namespace WorldCup.DataAccess.Repositories
{
    internal static class RepositoryFactory
    {
        private static IAppSettingsHandler appSettingsHandler = new AppSettingsHandler();
        private static readonly AppSettings source = appSettingsHandler.LoadSettings();

        internal static Interfaces.IDataReader CreateReader()
        {
            return source.DataSource.ToLower().Equals("api")
                ? new ApiRepository()
                : new FileRepository();
        }

        internal static IAppSettingsHandler CreateAppSettingsHandler()
            => new AppSettingsHandler();

        internal static IPlayerImagePathHandler CreatePlayerImagePathHandler()
        => new PlayerImagePathHandler();

        internal static IFavoriteTeamHandler CreateFavoriteTeamHandler()
        => new FavoriteTeamHandler();

        internal static IFavoritePlayersHandler CreateFavoritePlayersHandler()
        => new FavoritePlayersHandler();
    }
}
