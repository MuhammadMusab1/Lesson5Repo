namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Journal> Journals { get; set; }

        public User()
        {
            Journals = new HashSet<Journal>();
        }
    }
}
/*
Create a system that allows for Journals with Editing and Owning Users, 
and configure your tables using ModelBuilder. 
(A Journal can have many Editors and one Owner, which are both of the User class).
*/