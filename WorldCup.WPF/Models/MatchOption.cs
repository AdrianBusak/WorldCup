using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Models;

namespace WorldCup.WPF.Models
{
    public class MatchOption
    {
        public string Name { get; set; }
        public Match Match { get; set; }
        public override string ToString()
        => Name;
    }
}
