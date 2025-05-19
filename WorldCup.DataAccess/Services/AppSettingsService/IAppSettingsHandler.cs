using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.DataAccess.Services.AppSettingsService
{
    public interface IAppSettingsHandler
    {
        public void SaveSettings(Models.AppSettings settings);
        public Models.AppSettings LoadSettings();
    }
}
