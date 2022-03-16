namespace WebApplication1.Models
{
    public class EditorJournal
    {
        public int Id { get; set; }
        public User Editor { get; set; }
        public Journal Journal { get; set; }
        public int EditorId { get; set; }//foreign key
        public int JournalId { get; set; }//foreign key
        public DateTime DateEdited { get; set; }
    }
}
