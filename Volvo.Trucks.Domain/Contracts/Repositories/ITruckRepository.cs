using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.Trucks.Domain.Model;

namespace Volvo.Trucks.Domain.Contracts.Repositories
{
    public interface ITruckRepository
    {
        Truck GetTruckById(int id);
        IList<Truck> GetAll();
        Truck Create(Truck truck);
        void Update(Truck truck);
        void Delete(int id);

    }
}
