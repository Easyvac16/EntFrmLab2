namespace EntFrmLab2.DAL.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int Team1Id { get;set; }
        public Team Team1 { get; set; }
        public int Team2Id { get; set; }
        public Team Team2 { get; set; } 
        public int GoalsTeam1 { get; set; }
        public int GoalsTeam2 { get; set; } 
        public DateTime MatchDate { get; set; }
        public List<GoalScorer> GoalScorers { get; set; }
    }
}
