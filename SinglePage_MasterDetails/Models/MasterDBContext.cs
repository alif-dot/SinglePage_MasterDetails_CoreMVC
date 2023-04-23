using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SinglePage_MasterDetails.Models
{
    public partial class MasterDBContext : DbContext
    {
        public MasterDBContext()
        {
        }

        public MasterDBContext(DbContextOptions<MasterDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SaleDetail> SaleDetails { get; set; } = null!;
        public virtual DbSet<SaleMaster> SaleMasters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=MasterDB; Trusted_Connection=true; Encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.ToTable("SaleDetail");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qty).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<SaleMaster>(entity =>
            {
                entity.HasKey(e => e.SaleId)
                    .HasName("PK__SaleMast__1EE3C3FFAD2CEC3D");

                entity.ToTable("SaleMaster");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
