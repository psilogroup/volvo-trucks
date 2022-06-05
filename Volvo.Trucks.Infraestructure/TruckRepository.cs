using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.Trucks.Domain.Contracts.Repositories;
using Volvo.Trucks.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Volvo.Trucks.Infraestructure
{
    public class TruckRepository : ITruckRepository
    {
        readonly TruckDBContext _dbContext;
        public TruckRepository(TruckDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public Truck Create(Truck truck)
        {
            if (truck == null)
                throw new ArgumentNullException(nameof(truck));

            truck.Created = DateTime.Now;
            truck.LastModified = null;

            var result = _dbContext.Trucks.Add(truck);
            _dbContext.SaveChanges();
            return result.Entity;

        }

        public void Delete(int id)
        {
            var truck = _dbContext.Trucks.Find(id);

            if (truck == null)
                throw new Exception($"Truck {id} not found");

            _dbContext.Trucks.Remove(truck);
            _dbContext.SaveChanges();
        }

        public IList<Truck> GetAll()
        {
            var trucks = _dbContext.Trucks.ToList();
            return trucks;
        }

        public Truck GetTruckById(int id)
        {
            var truck = _dbContext.Trucks.Find(id);

            if (truck == null)
                throw new ArgumentException($"Truck {id} not found");

            return truck;
        }

        public void Update(Truck truck)
        {

            if (truck == null)
                throw new ArgumentNullException(nameof(truck));

            var _truckEntity = _dbContext.Trucks.Find(truck.Id);

            if (_truckEntity == null)
                throw new ArgumentException($"Truck {truck.Id} not found");

            _truckEntity.Model = truck.Model;
            _truckEntity.ManufactuirngYear = truck.ManufactuirngYear;
            _truckEntity.ModelYear = truck.ModelYear;
            _truckEntity.LastModified = DateTime.Now;

            _dbContext.SaveChanges();
        }
    }
}
