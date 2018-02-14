using Rentalbase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Rentalbase.DAL
{
    public class RBaseContext : DbContext
    {
        public RBaseContext() : base("RBaseContext")
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Lease>()
                .HasMany(l => l.Tenants)
                .WithMany(t => t.Leases)
                .Map(m =>
                {
                    m.ToTable("LeaseTenant");
                    m.MapLeftKey("LeaseID");
                    m.MapRightKey("TenantID");
                });

            modelBuilder.Entity<Lease>()
                .HasRequired(l => l.Property)
                .WithMany(p => p.Leases)
                .HasForeignKey(l => l.PropertyID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tenant>()
                .HasOptional(t => t.Property)
                .WithMany(p => p.Tenants)
                .HasForeignKey(t => t.PropertyID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Property>()
                .HasRequired(p => p.Landlord)
                .WithMany(l => l.Properties)
                .HasForeignKey(p => p.LandlordID)
                .WillCascadeOnDelete(false);

        }
    }
}