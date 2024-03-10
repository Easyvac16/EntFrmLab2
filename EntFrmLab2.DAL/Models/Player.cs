namespace EntFrmLab2.DAL.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public int JerseyNumber { get; set; }
        public string Position { get; set; }
        // Foreign key
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
