﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rentalbase.Models
{
    public class Property
    {
        public int ID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }

        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<Lease> Leases { get; set; }
    }
}