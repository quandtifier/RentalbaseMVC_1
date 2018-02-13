using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Rentalbase.Models;

namespace Rentalbase.DAL
{
    public class RBaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RBaseContext>
    {
        protected override void Seed(RBaseContext context)
        {

            var propTypes = new List<PropertyType>
            {
                new PropertyType{Type="Apartment"},
                new PropertyType{Type="SFH"},
                new PropertyType{Type="Industrial"},
            };
            propTypes.ForEach(s => context.PropertyTypes.Add(s));
            context.SaveChanges();

            var properties = new List<Property>
            {
                new Property { Street="38 Galvin Road", City="Seattle", State="WA", Zip=98181, Value=5000, Description="Need something here", Type = propTypes.SingleOrDefault(t => t.Type == "Apartment")},
                new Property { Street="61 North Mulbary", City="Seattle", State="WA", Zip=98182, Value=10000, Description="Need something here", Type = propTypes.SingleOrDefault(t => t.Type == "Apartment")},
                new Property { Street="856 South Pl", City="Seattle", State="WA", Zip=98183, Value=20000, Description="Need something here", Type = propTypes.SingleOrDefault(t => t.Type == "Industrial")},
                new Property { Street="4738 West Dr.", City="Seattle", State="WA", Zip=98184, Value=40000, Description="Need something here", Type = propTypes.SingleOrDefault(t => t.Type == "SFH")},

                new Property { Street="40 Sample Dr.", City="Tacoma", State="WA", Zip=98321, Value=99000, Description="Need something here"},
                new Property { Street="50 Sample Dr.", City="Tacoma", State="WA", Zip=98322, Value=100000, Description="Need something here"},
                new Property { Street="60 Sample Dr.", City="Tacoma", State="WA", Zip=98323, Value=101000, Description="Need something here"},
                new Property { Street="70 Sample Dr.", City="Tacoma", State="WA", Zip=98324, Value=102000, Description="Need something here"},

                new Property { Street="10 Sample Dr.", City="Olympia", State="WA", Zip=98410, Value=300000, Description="Need something here"},
                new Property { Street="20 Sample Dr.", City="Olympia", State="WA", Zip=98411, Value=310000, Description="Need something here"},
                new Property { Street="30 Sample Dr.", City="Olympia", State="WA", Zip=98412, Value=320000, Description="Need something here"},
                new Property { Street="35 Sample Dr.", City="Olympia", State="WA", Zip=98413, Value=330000, Description="Need something here"},
            };

            properties.ForEach(s => context.Properties.Add(s));
            context.SaveChanges();

            var tenants = new List<Tenant>
            {
                new Tenant { ID=1, PropertyID=1, Name="Thomas M Anders", Phone="2063651375", Email="tanders@gmail.com", RegistrationDate=DateTime.Parse("2010-01-01")},
                new Tenant { ID=2, PropertyID=1, Name="Jen Anders", Phone="2063651375", Email="janders@gmail.com", RegistrationDate=DateTime.Parse("2010-01-01")},

                new Tenant { ID=3, Name="Jake Jakson", Phone="2830937463", Email="jj@gmail.com", RegistrationDate=DateTime.Parse("2012-02-01")},
                new Tenant { ID=4, Name="Franky Fish", Phone="2063653789", Email="ff@gmail.com", RegistrationDate=DateTime.Parse("2012-10-01")},
            };
            tenants.ForEach(s => context.Tenants.Add(s));
            context.SaveChanges();

            var leases = new List<Lease>
            {
                new Lease { ID=1, PropertyID=1, StartDate=DateTime.Parse("2010-01-01"), EndDate=DateTime.Parse("2011-01-01"), RateMonthly=2000},
                new Lease { ID=2, PropertyID=1, StartDate=DateTime.Parse("2012-02-01"), EndDate=DateTime.Parse("2012-01-01"), RateMonthly=2000},
                new Lease { ID=3, PropertyID=1, StartDate=DateTime.Parse("2010-10-01"), EndDate=DateTime.Parse("2010-06-01"), RateMonthly=2000},
            };

            leases.ForEach(s => context.Leases.Add(s));
            context.SaveChanges();

            //AddOrUpdateTenant(context, 1, "Thomas M Anders");
            //AddOrUpdateTenant(context, 1, "Jen Anders");
            //AddOrUpdateTenant(context, 2, "Jake Jakson");
            //AddOrUpdateTenant(context, 3, "Franky Fish");

        }


        //void AddOrUpdateTenant(RBaseContext context, int leaseID, string tenantName)
        //{
        //    var ls = context.Leases.SingleOrDefault(l => l.ID == leaseID);
        //    var ten = ls.Tenants.SingleOrDefault(t => t.Name == tenantName);
        //    if (ten == null)
        //        ls.Tenants.Add(context.Tenants.Single(t => t.Name == tenantName));
        //}



    }
}