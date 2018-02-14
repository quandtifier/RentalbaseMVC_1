using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rentalbase.Models
{
    public class Property
    {
        public int ID { get; set; }
        public int LandlordID { get; set; } = 1;
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }
        [Required]
        public int Zip { get; set; }
        [Display(Name = "Assessment")]
        public int Value { get; set; }
        public string Description { get; set; }
        
        public virtual Landlord Landlord { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
        public virtual ICollection<Lease> Leases { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}