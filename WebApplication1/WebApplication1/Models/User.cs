namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Journal? OwnedJournal { get; set; }
        public int? OwnedJournalId { get; set; }
        public ICollection<Journal> OwnedJournals { get; set; }
        public ICollection<UserJournal>? EditingJournals { get; set; }

        public User()
        {
            OwnedJournals = new HashSet<Journal>();
            EditingJournals = new HashSet<UserJournal>();
        }
    }
}
