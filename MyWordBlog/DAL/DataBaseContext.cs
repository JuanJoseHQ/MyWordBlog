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
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserAdmin> UsersAdmin { get; set; }
        public DbSet<UserCommon> UsersCommon { get; set; }
        public DbSet<UserLogin> UsersLogin { get; set; }
        public DbSet<UserRegistred> UsersRegistred { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().HasIndex(c => c.Title).IsUnique();
            
        }
    }
}
