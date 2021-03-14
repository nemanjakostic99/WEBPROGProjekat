using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    public class BolnicaContext : DbContext 
    {
        public DbSet<Bolnica> Bolnice { get; set; }

        public DbSet<Krevet> Kreveti { get; set; }

        public DbSet<Soba> Sobe { get; set; }

        public DbSet<Pacijent> Pacijenti { get; set; }

        public BolnicaContext(DbContextOptions options) : base(options){

        }

    }

}