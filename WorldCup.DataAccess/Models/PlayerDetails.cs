using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.DataAccess.Enums;

namespace WorldCup.DataAccess.Models
{
    public class PlayerDetails
    {
        public string Name { get; set; }
        public bool Captain { get; set; }
        public long ShirtNumber { get; set; }
        public Position Position { get; set; }
        public int YellowCardCount { get; set; }
        public int GoalsCount { get; set; }
        public string ImagePath { get; set; }
    }
}
