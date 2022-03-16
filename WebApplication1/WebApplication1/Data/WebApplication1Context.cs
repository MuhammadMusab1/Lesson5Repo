#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context (DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //One to many
            builder.Entity<User>().HasKey(user => user.Id);
            builder.Entity<User>().HasMany(user => user.Journals)
                .WithOne(journal => journal.Owner)
                .HasForeignKey(journal => journal.OwnerId);

            //(A Journal can have many Editors and one Owner, which are both of the User class).
            //one journal can have many editorsUser
            //one editorUser can have many journals

            builder.Entity<EditorJournal>()
                .HasKey(editorJournal => new { editorJournal.EditorId, editorJournal.JournalId });

            //builder.Entity<EditorJournal>()
            //    .HasOne(editorJournal => editorJournal.JournalId)
            //    .WithMany()

            /*
             //Many To Many
             modelBuilder.Entity<BookCategory>()
        .HasKey(bc => new { bc.BookId, bc.CategoryId });
            
               modelBuilder.Entity<BookCategory>()
        .HasOne(bc => bc.Book)
        .WithMany(b => b.BookCategories)
        .HasForeignKey(bc => bc.BookId); 
            
               modelBuilder.Entity<BookCategory>()
        .HasOne(bc => bc.Category)
        .WithMany(c => c.BookCategories)
        .HasForeignKey(bc => bc.CategoryId);
             */
        }

        public DbSet<User> User { get; set; }
        public DbSet<Journal> Journal { get; set; }
    }
}
