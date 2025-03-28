﻿
using ErmakovAppDiplom.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ErmakovAppDiplom
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Models.Attribute> Attributes { get; set; }
        public DbSet<BoardNote> BoardNotes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffAttribute> StaffAttributes { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Связь "Один ко многим" для Owner
            builder.Entity<BoardNote>()
                .HasOne(b => b.Owner)
                .WithMany(u => u.BoardNotesAsOwner)
                .HasForeignKey(b => b.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);  // Чтобы при удалении пользователя не удалялись BoardNote

            // Связь "Один ко многим" для Receiver
            builder.Entity<BoardNote>()
                .HasOne(b => b.Receiver)
                .WithMany(u => u.BoardNotesAsReceiver)
                .HasForeignKey(b => b.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
