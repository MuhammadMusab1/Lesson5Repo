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
            builder.Entity<User>().HasKey(c => c.Id);
            builder.Entity<Journal>().HasKey(j => j.JournalNumber);
            builder.Entity<UserJournal>().HasKey(uj => uj.EditingId);


            builder.Entity<User>().HasMany(u => u.OwnedJournals)
                .WithOne(u => u.Owner)
                .HasForeignKey(u => u.JournalNumber);

            builder.Entity<Journal>().HasOne(j => j.Owner)
                .WithMany(j => j.OwnedJournals)
                .HasForeignKey(j => j.OwnerId);


            builder.Entity<UserJournal>().HasOne<User>(uj => uj.User)
                .WithMany(uj => uj.EditingJournals)
                .HasForeignKey(uj => uj.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserJournal>().HasOne<Journal>(uj => uj.Journal)
                .WithMany(uj => uj.JournalEditors)
                .HasForeignKey(uj => uj.JournalNumber)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<User>().HasMany<UserJournal>(u => u.EditingJournals)
                .WithOne(j => j.User)
                .HasForeignKey(u => u.UserId);

            builder.Entity<Journal>().HasMany<UserJournal>(j => j.JournalEditors)
                .WithOne(j => j.Journal)
                .HasForeignKey(j => j.JournalNumber);

            builder.Entity<User>().HasData(new User 
            {
                Id = 1,
                FirstName = "Zach",
                LastName = "Montreuil"
            });
        }

        public DbSet<User> User { get; set; }
        public DbSet<Journal> Journal { get; set; }
        public DbSet<UserJournal> UserJournal { get; set; }
    }
}
