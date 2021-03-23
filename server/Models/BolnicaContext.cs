using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    public class BolnicaContext : DbContext 
    {
        public DbSet<Bolnica> Bolnice { get; set; }

        public DbSet<Sprat> Spratovi { get; set; }

        public DbSet<Krevet> Kreveti { get; set; }

        public DbSet<Soba> Sobe { get; set; }

        public DbSet<Pacijent> Pacijenti { get; set; }

        public BolnicaContext(DbContextOptions options) : base(options){
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Bolnica>().HasMany<Soba>().WithOne(p => p.bolnica).OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<Krevet>().HasOne(e => e.pacijent)
            //     .WithOne(e => e.krevet)
            //     .HasForeignKey<Krevet>(p => p.pacijentID);
                
        }


    }

}