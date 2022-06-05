using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.Trucks.Businesss;
using Volvo.Trucks.Domain.Contracts.Repositories;
using Volvo.Trucks.Domain.Contracts.Services;
using Volvo.Trucks.Infraestructure;

namespace Volvo.Trucks.Tests
{
    [TestFixture]
    public class TruckServiceTest
    {

        ITruckService _truckService;
        

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<TruckDBContext>()
                 .UseInMemoryDatabase(databaseName: "TruckTestDB")
                 .Options;

            TruckDBContext dbContext = new TruckDBContext(options);
            ITruckRepository _repository = new TruckRepository(dbContext);
            _truckService = new TruckService(_repository);
        }

        [Test]
        public void EnsureTruckOnlyAcceptCorrectModelYear()
        {
            Assert.Throws<ArgumentException>(delegate { _truckService.CreateTruck(Domain.Enums.ModelType.FH, DateTime.Now.Year - 1); });
            
        }

        [Test]
        public void EnsureTruckAcceptCurretYearOnModelYear()
        {
            var truck = _truckService.CreateTruck(Domain.Enums.ModelType.FH, DateTime.Now.Year);

            Assert.IsTrue(truck.Id > 0);
        }

        [Test]
        public void EnsureTruckCreatedWithCurrentManufactureYear()
        {
            var truck = _truckService.CreateTruck(Domain.Enums.ModelType.FH, DateTime.Now.Year);

            Assert.IsTrue(truck.ManufactuirngYear == DateTime.Now.Year);
        }

        
    }
}
