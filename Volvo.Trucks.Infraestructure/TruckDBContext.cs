using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volvo.Trucks.Infraestructure
{
    public class TruckDBContext : DbContext 
    {
        public DbSet<Domain.Model.Truck> Trucks { get; set; }

        public TruckDBContext(DbContextOptions<TruckDBContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
