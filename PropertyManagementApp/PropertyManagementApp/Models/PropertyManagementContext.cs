using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PropertyManagementApp.Models
{
    public partial class PropertyManagementContext : DbContext
    {
        public PropertyManagementContext()
        {
        }

        public PropertyManagementContext(DbContextOptions<PropertyManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaintenanceRequest> MaintenanceRequest { get; set; }
        public virtual DbSet<PaymentHistory> PaymentHistory { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<PropertyLeaser> PropertyLeaser { get; set; }
        public virtual DbSet<PropertyOwner> PropertyOwner { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaintenanceRequest>(entity =>
            {
                entity.HasKey(e => e.MaintenanceId);

                entity.ToTable("Maintenance_Request");

                entity.Property(e => e.MaintenanceId).HasColumnName("MaintenanceID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Documents).HasMaxLength(50);

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.MaintenanceRequest)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maintenance_Request_Property");
            });

            modelBuilder.Entity<PaymentHistory>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.ToTable("Payment_History");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.TotalLate).HasColumnName("Total_late");

                entity.Property(e => e.TotalMonths).HasColumnName("Total_months");

                entity.Property(e => e.TotalPaid).HasColumnName("Total_paid");

                entity.Property(e => e.TotalPayments).HasColumnName("Total_payments");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.ContractTime)
                    .HasColumnName("Contract_time")
                    .HasMaxLength(50);

                entity.Property(e => e.LeaserId).HasColumnName("LeaserID");

                entity.Property(e => e.MonthlyRate).HasColumnName("Monthly_rate");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Picture).HasColumnType("image");

                entity.Property(e => e.SquareFeet).HasColumnName("Square_feet");

                entity.Property(e => e.Utilities).HasMaxLength(50);

                entity.HasOne(d => d.Leaser)
                    .WithMany(p => p.Property)
                    .HasForeignKey(d => d.LeaserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_Property_Leaser");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Property)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_Property_Owner");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Property)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_Payment_History");
            });

            modelBuilder.Entity<PropertyLeaser>(entity =>
            {
                entity.HasKey(e => e.LeaserId);

                entity.ToTable("Property_Leaser");

                entity.Property(e => e.LeaserId).HasColumnName("LeaserID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Comments).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("Phone_number")
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ZipCode).HasColumnName("Zip_code");
            });

            modelBuilder.Entity<PropertyOwner>(entity =>
            {
                entity.HasKey(e => e.OwnerId);

                entity.ToTable("Property_Owner");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Comments).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ZipCode).HasColumnName("Zip_code");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
