using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using XYC.Domain.Fakes;
using XYC.Models.Sample;

namespace XYC.Sample.API.Controllers
{
    [Route("api/sample/cities")]
    public class PointOfInterestController: Controller
    {

        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }
            return Ok(city.PointOfInterest);
        }

        [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }
            
            var pointofinterest = city.PointOfInterest.FirstOrDefault(c => c.Id == id);
            if(pointofinterest == null)
            {
                return NotFound();
            }
            return Ok(pointofinterest);
        }

        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if(pointOfInterest == null)
                return BadRequest();

            if(pointOfInterest.Description == pointOfInterest.Name)
                ModelState.AddModelError("Description","The provided description should be different form the name");

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }
            
            //demo purposes - to be improved
            var maxPotId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointOfInterest).Max(p => p.Id);
            
            var finalePot = new PointOfInterestDto()
            {
                Id = ++maxPotId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointOfInterest.Add(finalePot);

            return CreatedAtRoute("GetPointOfInterest", new {cityId = cityId, id = finalePot.Id}, finalePot);
        }
    }
}