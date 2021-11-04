using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ufynd.assessment.Contracts.Interfaces;

namespace ufynd.assessment.task3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRatesController : ControllerBase
    {
        private readonly IHotelRatesService hotelRatesService;

        public HotelRatesController(IHotelRatesService hotelRatesService)
        {
            this.hotelRatesService = hotelRatesService;
        }

        [HttpGet]
        [Route("GetHotelRates/{hotelId}/{arrivalDate}")]
        public IActionResult GetHotelRates(int hotelId, string arrivalDate)
        {
            // logging can be added.
            try
            {
                // to be added if any validation is required.
                if (hotelId <= 0 || !DateTime.TryParse(arrivalDate, out DateTime arrivalDateTime))
                {
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);
                }

                var result = this.hotelRatesService.GetHotelDetailsByHotelIdAndArrivalDate(hotelId, arrivalDateTime);
                if (result == null)
                {
                    return new StatusCodeResult(StatusCodes.Status404NotFound);
                }

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
