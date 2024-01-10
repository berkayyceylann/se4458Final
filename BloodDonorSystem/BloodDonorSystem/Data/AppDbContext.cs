using Microsoft.EntityFrameworkCore;
using BloodDonorSystem.Models;

namespace BloodDonorSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<BloodRequest> BloodRequests { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Donor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired();
                entity.Property(e => e.BloodType).IsRequired();
                entity.Property(e => e.City).IsRequired();
                entity.Property(e => e.Town).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired();
            });

            modelBuilder.Entity<BloodRequest>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RequestorHospital).IsRequired();
                entity.Property(e => e.BloodType).IsRequired();
                entity.Property(e => e.City).IsRequired();
                entity.Property(e => e.Town).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.NumberOfUnits).IsRequired();
                entity.Property(e => e.DurationOfSearch).IsRequired();
                entity.Property(e => e.Reason);
            });

            modelBuilder.Entity<BloodBank>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.BranchName).IsRequired();
                entity.Property(e => e.City).IsRequired();
                entity.Property(e => e.Town).IsRequired();
                entity.Property(e => e.UnitsAvailable).IsRequired();
                // entity.HasMany(e => e.Donors).WithOne().HasForeignKey(d => d.BloodBankId);
                
            });
        }
    }
}
