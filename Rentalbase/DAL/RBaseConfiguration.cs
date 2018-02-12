using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Rentalbase.DAL
{
    public class RBaseConfiguration : DbConfiguration
    {
        public RBaseConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            //uncomment to simulate transient errors here
            //DbInterception.Add(new RBaseInterceptorTransientErrors());
            //DbInterception.Add(new RBaseInterceptorLogging());
        }
    }
}