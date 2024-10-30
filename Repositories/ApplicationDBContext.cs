using GameShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShop.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }  
        public DbSet<Genre> Genres { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
          //  Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
