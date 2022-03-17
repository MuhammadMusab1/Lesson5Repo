namespace WebApplication1.Models
{
    public class EditorJournal
    {
        public int Id { get; set; }
        public int EditorId { get; set; }
        public User Editor { get; set; }
        public int JournalId { get; set; }
        public Journal Journal { get; set; }
    }
}
