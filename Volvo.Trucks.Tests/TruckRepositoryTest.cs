using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.Trucks.Domain.Contracts.Repositories;
using Volvo.Trucks.Domain.Model;
using Volvo.Trucks.Infraestructure;

namespace Volvo.Trucks.Tests
{
    [TestFixture]
    public class TruckRepositoryTest
    {
        private ITruckRepository _repository;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<TruckDBContext>()
                .UseInMemoryDatabase(databaseName: "TruckTestDB")
                .Options;

            TruckDBContext dbContext = new TruckDBContext(options);
            _repository = new TruckRepository(dbContext);
        }

        [Test]
        public void CanCreateTruck()
        {
            Truck truck = new Truck();
            truck.ManufactuirngYear = DateTime.Now.Year;
            truck.ModelYear = DateTime.Now.Year;
            truck.Model = Domain.Enums.ModelType.FH;

            var truckCreated = _repository.Create(truck);

            Assert.IsTrue(truckCreated.Id > 0);
        }

        [Test]
        public void CanUpdateTurck()
        {
            Truck truck = new Truck();
            truck.ManufactuirngYear = DateTime.Now.Year;
            truck.ModelYear = DateTime.Now.Year;
            truck.Model = Domain.Enums.ModelType.FH;

            var truckCreated = _repository.Create(truck);
            truckCreated.Model = Domain.Enums.ModelType.FM;
            _repository.Update(truck);
            var truckUpdated = _repository.GetTruckById(truck.Id);
            Assert.IsTrue(truckUpdated.Model.Equals(Domain.Enums.ModelType.FM));
            
        }

        [Test]
        public void  CanDeleteTruck()
        {
            Truck truck = new Truck();
            truck.ManufactuirngYear = DateTime.Now.Year;
            truck.ModelYear = DateTime.Now.Year;
            truck.Model = Domain.Enums.ModelType.FH;

            var truckCreated = _repository.Create(truck);

            
            int id = truckCreated.Id;
            _repository.Delete(id);

            Assert.Throws<ArgumentException>( delegate  {
                var x = _repository.GetTruckById(id); ;
            });
            
        }
    }
}
