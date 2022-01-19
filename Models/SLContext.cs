using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class SLContext: DbContext
    {
        public DbSet<Igrac> Igraci {get; set; }
        public DbSet<Tim> Timovi {get; set; }
        public DbSet<Utakmica> Utakmice {get; set; }
        public DbSet<Liga> Lige {get; set; }

        public SLContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tim>()
            .HasMany<Utakmica>()
            .WithOne(u => u.Tim1);

        }
    }
}