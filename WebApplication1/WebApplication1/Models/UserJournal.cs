namespace WebApplication1.Models
{
    public class UserJournal
    {
        public int EditingId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Journal Journal { get; set; }
        public int JournalNumber { get; set; }
    }
}
