using Microsoft.EntityFrameworkCore;
using MyWordBlog.DAL.Entidades;
using System.Diagnostics.Metrics;

namespace MyWordBlog.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<Commentary> Commentaries { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().HasIndex(c => c.Title).IsUnique();

            modelBuilder.Entity<Commentary>().HasIndex(c => c.Id).IsUnique();
            

        }
    }
}
