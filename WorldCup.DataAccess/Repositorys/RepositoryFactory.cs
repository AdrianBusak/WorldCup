using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Models;
using WorldCup.DataAccess.Repositorys.ApiData;
using WorldCup.DataAccess.Repositorys.FileData;
using WorldCup.DataAccess.Repositorys.Interfaces;
using WorldCup.DataAccess.Services.AppSettingsService;
using WorldCup.DataAccess.Services.FavoritePlayersService;
using WorldCup.DataAccess.Services.FavoriteTeamService;
using WorldCup.DataAccess.Services.PlayerImagePathService;

namespace WorldCup.DataAccess.Repositorys
{
    internal static class RepositoryFactory
    {
        private static IAppSettingsHandler appSettingsHandler = new AppSettingsHandler();
        private static readonly AppSettings source = appSettingsHandler.LoadSettings();

        internal static Interfaces.IDataReader CreateReader()
        {
            return source.DataSource.ToUpper() == "API"
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
