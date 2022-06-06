using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.Trucks.Domain.Contracts.Repositories;
using Volvo.Trucks.Domain.Contracts.Services;
using Volvo.Trucks.Domain.Enums;
using Volvo.Trucks.Domain.Model;

namespace Volvo.Trucks.Businesss
{
    public class TruckService : ITruckService
    {
        readonly ITruckRepository _truckRepository;
        public TruckService(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public void ChangeTruck(int truckId, ModelType model, int modelYear, int manufacturingYear)
        {
            int cYear = DateTime.Now.Year;
            ValidateTruck(modelYear, cYear,manufacturingYear);


            Truck truck = _truckRepository.GetTruckById(truckId);
            truck.Model = model;
            truck.ManufactuirngYear = cYear;
            truck.ModelYear = modelYear;

            _truckRepository.Update(truck);
        }

        public Truck CreateTruck(ModelType model, int modelYear, int manufacturingYear)
        {
            int cYear = DateTime.Now.Year;
            ValidateTruck(modelYear, cYear,manufacturingYear);

            Truck truck = new Truck();
            truck.Model = model;
            truck.ManufactuirngYear = cYear;
            truck.ModelYear = modelYear;
            return _truckRepository.Create(truck);
        }

        private static void ValidateTruck(int modelYear, int cYear,int manufacturingYear)
        {
            if (modelYear != cYear && modelYear != cYear + 1)
            {
                throw new ArgumentException("modelYear only accepts current year or subsequent");
            }

            if (manufacturingYear != DateTime.Now.Year)
            {
                throw new ArgumentException("manufacturing year only accpets current year");
            }
        }

        public void DeleteTruck(Truck truck)
        {
            if (truck == null)
                throw new ArgumentException("truck is null");

            _truckRepository.Delete(truck.Id);
        }

        public IList<Truck> GetAll()
        {
            return _truckRepository.GetAll();
        }

        public Truck GetById(int id)
        {
            return _truckRepository.GetTruckById(id);
        }
    }
}
