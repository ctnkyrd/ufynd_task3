using System;
using Microsoft.AspNetCore.Mvc;
using task3.webapi.Services;

namespace task3.webapi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/{id:int}")]
    public class HotelRatesController : ControllerBase
    {
        private IHotelRatesService _service;
        public HotelRatesController(IHotelRatesService service)
        {
            _service = service;
        }

        public IActionResult GetHotelRates(int id, [FromQuery] DateTime arrivalDate)
        {
            try
            {
                //get filtered hotel rates
                var result = _service.GetHotelRates(id, arrivalDate);
                if (result.hotelRates.Count == 0)
                {
                    return NotFound($"There is no available rate at {arrivalDate.ToShortDateString()}");
                }
                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.ParamName);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something wrong happened!");
            }

        }
    }
}