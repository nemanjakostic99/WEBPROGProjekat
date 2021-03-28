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
            // modelBuilder.Entity<Bolnica>().HasMany<Sprat>().WithOne(p => p.bolnica).OnDelete(DeleteBehavior.Cascade);
            // modelBuilder.Entity<Sprat>().HasMany<Soba>().WithOne(p => p.sprat).OnDelete(DeleteBehavior.Cascade);
            // modelBuilder.Entity<Soba>().HasMany<Krevet>().WithOne(p => p.soba).OnDelete(DeleteBehavior.Cascade);
            // modelBuilder.Entity<Krevet>().HasOne<Pacijent>().WithOne(p => p.krevet).OnDelete(DeleteBehavior.Cascade);
            

            // modelBuilder.Entity<Krevet>().HasOne(e => e.pacijent)
            //     .WithOne(e => e.krevet)
            //     .HasForeignKey<Krevet>(p => p.pacijentID);
                
        }


    }

}