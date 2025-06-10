using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Enums;

namespace WorldCup.DataAccess.Models
{
    public class Player
    {
        public string Name { get; set; }
        public bool Captain { get; set; }
        public int ShirtNumber { get; set; }
        public Position Position { get; set; }
    }
}
