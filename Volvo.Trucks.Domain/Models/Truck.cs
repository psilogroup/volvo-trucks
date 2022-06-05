using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volvo.Trucks.Domain.Model
{
    public class Truck
    {
        public int Id { get; set; }
        public Enums.ModelType Model { get; set; }
        public int ManufactuirngYear { get; set; }
        public int ModelYear { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

    }
}
