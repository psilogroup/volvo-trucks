using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Volvo.Trucks.API.DTO;
using Volvo.Trucks.Domain.Contracts.Services;
using Volvo.Trucks.Domain.Model;

namespace Volvo.Trucks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        IMapper _mapper;
        ITruckService _truckService;
        public TruckController(IMapper mapper, ITruckService truckService)
        {
            _mapper = mapper;
            _truckService = truckService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                List<Truck> result = (List<Truck>)_truckService.GetAll();

                var resultDTO = _mapper.Map<List<TruckDTO>>(result);
                return Ok(resultDTO);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var truck = _truckService.GetById(id);
                var truckDto = _mapper.Map<TruckDTO>(truck);
                return Ok(truckDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Create(TruckDTO truckdto)
        {
            try
            {
                var _mappedTruck = _mapper.Map<Truck>(truckdto);
                var result = _truckService.CreateTruck(_mappedTruck.Model,_mappedTruck.ModelYear,_mappedTruck.ManufactuirngYear);
                var resultDTO = _mapper.Map<TruckDTO>(result);
                return Ok(resultDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]TruckDTO truckDTO)
        {
            try
            {
                var _mappedTruck = _mapper.Map<Truck>(truckDTO);
                _truckService.ChangeTruck(id, _mappedTruck.Model, truckDTO.ModelYear,truckDTO.ManufacturingYear);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _truckService.DeleteTruck(new Truck() { Id = id });
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
