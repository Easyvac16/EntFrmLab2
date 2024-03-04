using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntFrmLab2.DAL.Models
{
    public class GoalScorer
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int MatchId { get; set; } 
        public int GoalsScored { get; set; } 
        public Player Player { get; set; }
        public Match Match { get; set; }
    }
}
