using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntFrmLab2.DAL.Models
{
    public class Match
    {
        public int Id { get; set; }
        public Team Team1Id { get; set; } 
        public Team Team2Id { get; set; } 
        public int GoalsTeam1 { get; set; }
        public int GoalsTeam2 { get; set; } 
        public DateTime MatchDate { get; set; }
        public List<GoalScorer> GoalScorers { get; set; }
    }
}
