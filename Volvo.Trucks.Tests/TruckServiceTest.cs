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
            int year = DateTime.Now.Year;
            Assert.Throws<ArgumentException>(delegate { _truckService.CreateTruck(Domain.Enums.ModelType.FH, year-1,year); });
            
        }

        [Test]
        public void EnsureTruckOnlyAcceptCorrectManufacturingYear()
        {
            int year = DateTime.Now.Year;
            Assert.Throws<ArgumentException>(delegate { _truckService.CreateTruck(Domain.Enums.ModelType.FH, year, year+1); });

        }

     

        [Test]
        public void CanCreateAndUpdateTruck()
        {
            int year = DateTime.Now.Year;
            var truckCreated = _truckService.CreateTruck(Domain.Enums.ModelType.FH, year,year);

            _truckService.ChangeTruck(truckCreated.Id, Domain.Enums.ModelType.FM, year,year);

            var truckUpdated = _truckService.GetById(truckCreated.Id);
            Assert.IsTrue(truckCreated.Model == Domain.Enums.ModelType.FM);
        }

        
    }
}
