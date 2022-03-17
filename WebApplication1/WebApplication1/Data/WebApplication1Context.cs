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
            builder.Entity<Journal>().HasKey(j => j.JournalNumber);

            builder.Entity<User>().HasMany(u => u.OwnedJournals)
                .WithOne(j => j.Owner)
                .HasForeignKey(j => j.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>().HasMany(u => u.EditingJournals)
                .WithOne(ej => ej.User)
                .HasForeignKey(ej => ej.UserId);

            builder.Entity<Journal>().HasMany(j => j.JournalEditors)
                .WithOne(je => je.Journal)
                .HasForeignKey(je => je.JournalNumber);
        }

        public DbSet<User> User { get; set; }
    }
}
