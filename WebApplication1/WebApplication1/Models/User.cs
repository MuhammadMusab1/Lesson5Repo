namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Journal> Journals { get; set; }
        public ICollection<EditorJournal> EditorJournals { get; set; }
        public User()
        {
            Journals = new HashSet<Journal>();
            EditorJournals = new HashSet<EditorJournal>();
        }
    }
}
