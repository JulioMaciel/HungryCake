namespace HungryCake.API.Models
{
    public class Filter
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public int Percentage { get; set; }
        public bool CaseSensitive { get; set; }
    }
}