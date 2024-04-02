using Microsoft.EntityFrameworkCore;

namespace Service_Design_KLTN.Models
{
    public class KLTNContext : DbContext
    {
        public KLTNContext() { }
        public KLTNContext(DbContextOptions<KLTNContext> options) : base(options) { }

        public virtual DbSet<DataLandsat> DataLandsats { get; set; }
        public virtual DbSet<DataSentinel> DataSentinels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-PFCKNGI\JULES2002;Initial Catalog=SatelliteImageData;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataLandsat>(entity =>
            {
                entity.HasKey(e => e.IdData);

                entity.ToTable("DataLandsat");
            });
            modelBuilder.Entity<DataSentinel>(entity =>
            {
                entity.HasKey(e => e.IdData);

                entity.ToTable("DataSentinel");
            });
            base.OnModelCreating(modelBuilder);
        }
    } 
}
