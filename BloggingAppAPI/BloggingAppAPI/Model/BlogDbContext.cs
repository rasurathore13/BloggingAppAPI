using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingAppAPI.Model
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            :base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity => 
            {
                entity.HasKey("BlogId");
                entity.Property("BlogMainImageUrl")
                      .HasMaxLength(1000);
                entity.Property("BlogHeading")
                      .HasMaxLength(150);
                entity.Property("BlogBrief")
                      .HasMaxLength(250);
                entity.Property("BlogAuthor")
                      .HasMaxLength(50);
                entity.Property("BlogDateTimeStamp");
            });
        }
    }
}
