namespace WebApplication1.Models
{
    public class Journal
    {
        public int Id { get; set; }
        public string Entry { get; set; }
        public DateTime CreatedDate { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
    }
}
