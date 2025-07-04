﻿
using ErmakovAppDiplom.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ErmakovAppDiplom
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Models.Attribute> Attributes { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<BoardNote> BoardNotes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<EquipmentItem> EquipmentItems { get; set; }
        public DbSet<EquipmentItemAttribute> ItemAttributes { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<SubLocation> Sublocations { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
