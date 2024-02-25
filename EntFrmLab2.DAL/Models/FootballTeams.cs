using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntFrmLab2.DAL.Models
{
    public class FootballTeams
    {
        public int id { get; set; }
        public string TeamName { get; set; }
        public string TeamCity { get; set; }
        public int GameLoss { get; set; }
        public int GameWin { get; set; }
        public int GameTie { get; set; }
        public int ScoredGoals { get; set; }
        public int MissedHeads { get; set; }
    }
}
