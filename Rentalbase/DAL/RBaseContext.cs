﻿using Rentalbase.Models;
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
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Lease> Leases { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Lease>()
            //    .HasMany(l => l.Tenants).WithMany(t => t.Leases)
            //    .Map(v => v.MapLeftKey("LeaseID")
            //    .MapRightKey("TenantID")
            //    .ToTable("LeaseTenant"));
        }
    }
}