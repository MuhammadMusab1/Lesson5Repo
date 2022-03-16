namespace WebApplication1.Models
{
    public class Journal
    {
        public int JournalNumber { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public User Owner { get; set; }
        public int OwnerId { get; set; }

        public ICollection<UserJournal>? JournalEditors { get; set; }

        public Journal()
        {
            JournalEditors = new HashSet<UserJournal>();
        }
    }
}
