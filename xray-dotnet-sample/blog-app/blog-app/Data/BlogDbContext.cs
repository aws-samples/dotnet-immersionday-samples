using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog_app.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }
        public DbSet<BlogCategory> Categories { get; set; }
        public DbSet<BlogPost> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogCategory>().ToTable("BlogCategory");
            modelBuilder.Entity<BlogPost>().ToTable("BlogPost");
        }
    }
}
