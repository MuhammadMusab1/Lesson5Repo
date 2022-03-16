﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(WebApplication1Context))]
    [Migration("20220316184319_AddRelationshipsAndTouchUps")]
    partial class AddRelationshipsAndTouchUps
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication1.Models.Journal", b =>
                {
                    b.Property<int>("JournalNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JournalNumber"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("JournalNumber");

                    b.HasIndex("OwnerId");

                    b.ToTable("Journal");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnedJournalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnedJournalId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebApplication1.Models.UserJournal", b =>
                {
                    b.Property<int>("EditingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EditingId"), 1L, 1);

                    b.Property<int>("JournalNumber")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EditingId");

                    b.HasIndex("JournalNumber");

                    b.HasIndex("UserId");

                    b.ToTable("UserJournal");
                });

            modelBuilder.Entity("WebApplication1.Models.Journal", b =>
                {
                    b.HasOne("WebApplication1.Models.User", "Owner")
                        .WithMany("OwnedJournals")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.HasOne("WebApplication1.Models.Journal", "OwnedJournal")
                        .WithMany()
                        .HasForeignKey("OwnedJournalId");

                    b.Navigation("OwnedJournal");
                });

            modelBuilder.Entity("WebApplication1.Models.UserJournal", b =>
                {
                    b.HasOne("WebApplication1.Models.Journal", "Journal")
                        .WithMany("JournalEditors")
                        .HasForeignKey("JournalNumber")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany("EditingJournals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Journal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication1.Models.Journal", b =>
                {
                    b.Navigation("JournalEditors");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Navigation("EditingJournals");

                    b.Navigation("OwnedJournals");
                });
#pragma warning restore 612, 618
        }
    }
}
