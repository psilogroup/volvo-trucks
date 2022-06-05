using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.Trucks.Domain.Enums;
using Volvo.Trucks.Domain.Model;

namespace Volvo.Trucks.Domain.Contracts.Services
{
    public interface ITruckService
    {

        IList<Truck> GetAll();
        Truck GetById(int id);
        Truck CreateTruck(ModelType model, int modelYear);
        void ChangeTruck(int truckId, ModelType model, int modelYear);
        void DeleteTruck(Truck truck);
    }
}
