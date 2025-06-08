using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Enums;

namespace WorldCup.DataAccess.Models
{
    public class AppSettings
    {
        public string Language { get; set; }
        public string Competition { get; set; }
        public string DataSource { get; set; }
        public WindowMode WindowMode { get; set; }
    }
}
