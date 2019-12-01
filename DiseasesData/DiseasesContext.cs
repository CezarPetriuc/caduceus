using Microsoft.EntityFrameworkCore;
using System;

namespace DiseasesData
{
    public class DiseasesContext : DbContext
    {
        public DbSet<Disease> Diseases { get; set; }

        public DbSet<Name> Names { get; set; }

        public DbSet<Cause> Causes { get; set; }

        public DiseasesContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=DiseasesDb;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cause>()
                .HasOne(typeof(Disease), "Disease")
                .WithMany()
                .HasForeignKey("DiseaseId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cause>()
                .HasOne(typeof(Disease), "CausedBy")
                .WithMany()
                .HasForeignKey("CausedById")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cause>()
                .HasIndex(p => new { p.DiseaseId, p.CausedById })
                .IsUnique();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
