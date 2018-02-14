namespace Rentalbase.Migrations
{
    using Rentalbase.DAL;
    using Rentalbase.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Rentalbase.DAL.RBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Rentalbase.DAL.RBaseContext context)
        {
            var landlords = new List<Landlord>
            {
                new Landlord {Name="Joshua Lansang", Street="332 Lake Forest Drive", City="Seattle", State="WA", Zip=11111, Phone="1111111111", Email="jlansang@rbase.com"},
                new Landlord {Name="Michael Quandt", Street="74 Lookout Ave.", City="Silverlake", State="WA", Zip=22222, Phone="2222222222", Email="mquandt@rbase.com"},
                new Landlord {Name="Alex Reid", Street="834 Ashley St.", City="Malone", State="WA", Zip=33333, Phone="3333333333", Email="areid@rbase.com"},
            };
            landlords.ForEach(s => context.Landlords.AddOrUpdate(p => p.Email, s));
            context.SaveChanges();

            var propTypes = new List<PropertyType>
            {
                new PropertyType{Type="Apartment"},
                new PropertyType{Type="SFH"},
                new PropertyType{Type="Industrial"},
            };
            propTypes.ForEach(s => context.PropertyTypes.AddOrUpdate(p => p.Type, s));
            context.SaveChanges();

            var properties = new List<Property>
            {
                new Property { LandlordID=1, Street="38 Galvin Road", City="Seattle", State="WA", Zip=98181, Value=5000, Description="Need something here", PropertyType = propTypes.SingleOrDefault(t => t.Type == "Apartment")},
                new Property { LandlordID=2, Street="856 South Pl", City="Seattle", State="WA", Zip=98183, Value=20000, Description="Need something here", PropertyType = propTypes.SingleOrDefault(t => t.Type == "Industrial")},
                new Property { LandlordID=3, Street="4738 West Dr.", City="Seattle", State="WA", Zip=98184, Value=40000, Description="Need something here", PropertyType = propTypes.SingleOrDefault(t => t.Type == "SFH")},

                new Property { Street="40 Sample Dr.", City="Tacoma", State="WA", Zip=98321, Value=99000, Description="Need something here"},
                new Property { Street="50 Sample Dr.", City="Tacoma", State="WA", Zip=98322, Value=100000, Description="Need something here"},
                new Property { Street="60 Sample Dr.", City="Tacoma", State="WA", Zip=98323, Value=101000, Description="Need something here"},
                new Property { Street="70 Sample Dr.", City="Tacoma", State="WA", Zip=98324, Value=102000, Description="Need something here"},

                new Property { Street="10 Sample Dr.", City="Olympia", State="WA", Zip=98410, Value=300000, Description="Need something here"},
                new Property { Street="20 Sample Dr.", City="Olympia", State="WA", Zip=98411, Value=310000, Description="Need something here"},
                new Property { Street="30 Sample Dr.", City="Olympia", State="WA", Zip=98412, Value=320000, Description="Need something here"},
                new Property { Street="35 Sample Dr.", City="Olympia", State="WA", Zip=98413, Value=330000, Description="Need something here"},
            };

            properties.ForEach(s => context.Properties.AddOrUpdate(p => p.Street, s));
            context.SaveChanges();

            var tenants = new List<Tenant>
            {
                new Tenant { PropertyID=1, Name="Thomas M Anders", Phone="2063651375", Email="tanders@gmail.com", RegistrationDate=DateTime.Parse("2010-01-01")},
                new Tenant { PropertyID=1, Name="Jen Anders", Phone="2063651375", Email="janders@gmail.com", RegistrationDate=DateTime.Parse("2010-01-01")},

                new Tenant { Name="Jake Jakson", Phone="2830937463", Email="jj@gmail.com", RegistrationDate=DateTime.Parse("2012-02-01")},
                new Tenant { Name="Franky Fish", Phone="2063653789", Email="ff@gmail.com", RegistrationDate=DateTime.Parse("2012-10-01")},
            };
            tenants.ForEach(s => context.Tenants.AddOrUpdate(t => t.Email, s));
            context.SaveChanges();


            var leases = new List<Lease>
            {
                new Lease { ID=1, StartDate=DateTime.Parse("2010-01-01"), EndDate=DateTime.Parse("2011-01-01"), RateMonthly=2000,
                    PropertyID = properties.Single(p => p.Street == "38 Galvin Road").ID,
                    Tenants = new List<Tenant>()},
                new Lease { ID=2, StartDate=DateTime.Parse("2012-02-01"), EndDate=DateTime.Parse("2012-01-01"), RateMonthly=2000,
                    PropertyID = properties.Single(p => p.Street == "38 Galvin Road").ID,
                    Tenants = new List<Tenant>()},
                new Lease { ID=3, StartDate=DateTime.Parse("2010-10-01"), EndDate=DateTime.Parse("2010-06-01"), RateMonthly=2000,
                    PropertyID = properties.Single(p => p.Street == "38 Galvin Road").ID,
                    Tenants = new List<Tenant>()},
            };

            leases.ForEach(s => context.Leases.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();

            var invTypes = new List<InvoiceType>
            {
                new InvoiceType {Type="MAINTENANCE"},
                new InvoiceType {Type="RENT"},
                new InvoiceType {Type="DAMAGE"},
                new InvoiceType {Type="DEPOSIT"},
            };
            invTypes.ForEach(s => context.InvoiceTypes.AddOrUpdate(p => p.Type, s));
            context.SaveChanges();

            var invoices = new List<Invoice>
            {
                new Invoice { ID=1, PropertyID = properties.Single(p => p.Street == "38 Galvin Road").ID, DateIssued=DateTime.Parse("2010-01-23"), DatePaid=DateTime.Parse("2010-02-02"), Description="Rent Payment", Cost=2000.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },
                new Invoice { ID=2, PropertyID = properties.Single(p => p.Street == "38 Galvin Road").ID, DateIssued=DateTime.Parse("2010-02-23"), DatePaid=DateTime.Parse("2010-03-02"), Description="Rent Payment", Cost=2000.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },
                new Invoice { ID=3, PropertyID = properties.Single(p => p.Street == "38 Galvin Road").ID, DateIssued=DateTime.Parse("2010-03-23"), DatePaid=DateTime.Parse("2010-04-02"), Description="Rent Payment", Cost=2000.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },
                new Invoice { ID=4, PropertyID = properties.Single(p => p.Street == "38 Galvin Road").ID, DateIssued=DateTime.Parse("2010-04-23"), DatePaid=DateTime.Parse("2010-05-02"), Description="Rent Payment", Cost=2000.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },

                new Invoice { ID=5, PropertyID = properties.Single(p => p.Street == "856 South Pl").ID, DateIssued=DateTime.Parse("2012-02-23"), DatePaid=DateTime.Parse("2012-03-02"), Description="Rent Payment", Cost=2000.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },
                new Invoice { ID=6, PropertyID = properties.Single(p => p.Street == "856 South Pl").ID, DateIssued=DateTime.Parse("2012-03-23"), DatePaid=DateTime.Parse("2012-04-02"), Description="Rent Payment", Cost=2000.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },
                new Invoice { ID=7, PropertyID = properties.Single(p => p.Street == "856 South Pl").ID, DateIssued=DateTime.Parse("2012-04-23"), DatePaid=DateTime.Parse("2012-05-02"), Description="Rent Payment", Cost=2000.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },
                new Invoice { ID=8, PropertyID = properties.Single(p => p.Street == "856 South Pl").ID, DateIssued=DateTime.Parse("2012-05-23"), DatePaid=DateTime.Parse("2012-06-02"), Description="Rent Payment", Cost=2000.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "RENT") },

                new Invoice { ID=9, PropertyID = properties.Single(p => p.Street == "4738 West Dr.").ID, DateIssued=DateTime.Parse("2017-05-23"), DatePaid=DateTime.Parse("2018-01-02"), Description="Rent Payment", Cost=2000.00M, InvoiceType = invTypes.SingleOrDefault(t => t.Type == "DAMAGE") },
            };
            invoices.ForEach(s => context.Invoices.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();

            AddOrUpdateTenant(context, 1, "tanders@gmail.com");
            AddOrUpdateTenant(context, 1, "janders@gmail.com");
            AddOrUpdateTenant(context, 2, "jj@gmail.com");
            AddOrUpdateTenant(context, 3, "ff@gmail.com");
            
        }

        void AddOrUpdateTenant(RBaseContext context, int leaseID, string tenantEmail)
        {
            var ls = context.Leases.SingleOrDefault(l => l.ID == leaseID);
            var ten = context.Tenants.SingleOrDefault(t => t.Email == tenantEmail);
            if (ten == null)
                ls.Tenants.Add(context.Tenants.Single(t => t.Email == tenantEmail));
        }
    }
}
