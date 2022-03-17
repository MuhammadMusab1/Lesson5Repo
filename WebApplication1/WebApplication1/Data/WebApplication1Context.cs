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
            builder.Entity<User>().HasKey(user => user.Id);
            builder.Entity<Journal>().HasKey(journal => journal.Id);

            //One User has many Journals, one journal can only have one User (OneToMany)

            //builder.Entity<User>()
            //    .HasMany(user => user.Journals)
            //    .WithOne(journal => journal.Owner)
            //    .HasForeignKey(journal => journal.OwnerId);

            //Another way of doing the same OneToMany
            builder.Entity<Journal>()
                .HasOne(journal => journal.Owner)
                .WithMany(user => user.Journals)
                .HasForeignKey(journal => journal.OwnerId);

            //One editor can edit many journals and one Journal can have many editors (ManyToMany)

            builder.Entity<EditorJournal>().HasKey(editorJournal => editorJournal.Id);

            builder.Entity<EditorJournal>()
                .HasOne(ej => ej.Journal)
                .WithMany(j => j.EditorJournals)
                .HasForeignKey(ej => ej.JournalId);
            builder.Entity<EditorJournal>()
                .HasOne(ej => ej.Editor)
                .WithMany(u => u.EditorJournals)
                .HasForeignKey(ej => ej.EditorId)
                .OnDelete(DeleteBehavior.NoAction); //to resolve a foreign key constraint

        }
        public DbSet<User> User { get; set; }
        public DbSet<Journal> Journal { get; set; }
        public DbSet<EditorJournal> EditorJournal { get; set; }
    }
}

/*
Create a system that allows for Journals with Editing and Owning Users,
and configure your tables using ModelBuilder.
(A Journal can have many Editors and one Owner, which are both of the User class).
 */
