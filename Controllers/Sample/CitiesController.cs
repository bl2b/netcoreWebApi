using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using XYC.Domain.Fakes;

namespace XYC.Sample.API.Controllers
{
    [Route("api/sample/cities")]
    public class CitiesController: Controller
    {
        [HttpGet()]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == id);
            if(cityToReturn == null)
            {
                return NotFound();
            }
            return Ok(cityToReturn);
        }
    }
}