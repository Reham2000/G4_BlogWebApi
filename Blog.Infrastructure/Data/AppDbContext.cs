using Blog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options) { }
    
        // Set Database Tables

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // fluent API
            // PK
            //modelBuilder.Entity<Category>().HasKey(e => e.CatId);
            modelBuilder.Entity<Category>().HasIndex(e => e.Name).IsUnique();
            //modelBuilder.Entity<Category>(entity =>
            //{
            //    //entity.HasKey(e => e.CatId);
            //    entity.HasIndex(e => e.Name).IsUnique();
            //});
            modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(e => e.UserName).IsUnique();

            // 1 category M Post
            //modelBuilder.Entity<Post>()
            //    .HasOne(p => p.Category)
            //    .WithMany(c => c.Posts)
            //    .HasForeignKey(p => p.CategoryId);


        }

    }
}
