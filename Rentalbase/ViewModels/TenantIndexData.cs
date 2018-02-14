using System.Collections.Generic;
using Rentalbase.Models;

namespace Rentalbase.ViewModels
{
    public class TenantIndexData
    {
        public IEnumerable<Tenant> Tenants { get; set; }
        public IEnumerable<Lease> Leases { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }
    }
}