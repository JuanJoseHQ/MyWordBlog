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

        public DbSet<Comentary> Comentaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().HasIndex(c => c.Title).IsUnique();
            
        }
    }
}
