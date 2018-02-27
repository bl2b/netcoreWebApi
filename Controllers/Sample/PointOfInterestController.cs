using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using XYC.Services.Fakes.Sample;
using XYC.Common.Models.Sample;
using XYC.Domain.Abstract.Sample;
using Microsoft.Extensions.Logging;
using System;

namespace XYC.Sample.API.Controllers
{
    [Route("api/sample/cities")]
    public class PointOfInterestController: Controller
    {

        private ILogger<PointOfInterestController> _logger;
         private IMailService _mailService;
        // private ICityInfoRepository _cityInfoRepository;


        public PointOfInterestController(ILogger<PointOfInterestController> logger, IMailService mailService)
        {
            _logger = logger;
             _mailService = mailService;
            // _cityInfoRepository = cityInfoRepository;
        }

        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointOfInterest(int cityId)
        {
            try
            {
                throw new Exception("test");
                var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
                if(city == null){
                    _logger.LogInformation($"City with id {cityId} wasn't found when accessing points of interest.");
                    return NotFound();
                }

                return Ok(city.PointOfInterest);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting points of interest for city with id {cityId}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if(city == null)
                return NotFound();
            
            var pointofinterest = city.PointOfInterest.FirstOrDefault(c => c.Id == id);
            if(pointofinterest == null)
                return NotFound();
            
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
                return NotFound();
            
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

        [HttpPut("{cityId}/pointsofinterest/{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id, [FromBody] PointOfInterestForUpdateDto pot)
        {
            if(pot == null)
                return BadRequest();

            if(pot.Description == pot.Name)
                ModelState.AddModelError("Description","The provided description should be different form the name");

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if(city == null)
                return NotFound();

            var potFromStore = city.PointOfInterest.FirstOrDefault(p => p.Id == id);
            if(potFromStore == null)
                return NotFound();

            potFromStore.Name = pot.Name;
            potFromStore.Description = pot.Description;

            return NoContent();
        }

        [HttpPatch("{cityId}/pointsofinterest/{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id, [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {
            if(patchDoc == null)
                return BadRequest();

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if(city == null)
                return NotFound();

            var potFromStore = city.PointOfInterest.FirstOrDefault(p => p.Id == id);
            if(potFromStore == null)
                return NotFound();

            var potPatch = new PointOfInterestForUpdateDto()
            {
                Name = potFromStore.Name,
                Description = potFromStore.Description
            };

            patchDoc.ApplyTo(potPatch, ModelState);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(potPatch.Description == potPatch.Name)
                ModelState.AddModelError("Description","The provided description should be different form the name");

            TryValidateModel(potPatch); //check for object dataanotation

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            potFromStore.Name = potPatch.Name;
            potFromStore.Description = potPatch.Description;

            return NoContent();
        }

        [HttpDelete("{cityId}/pointsofinterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if(city == null)
                return NotFound();

            var potFromStore = city.PointOfInterest.FirstOrDefault(p => p.Id == id);
            if(potFromStore == null)
                return NotFound();

            city.PointOfInterest.Remove(potFromStore);

            _mailService.Send("Point of interest deleted.",
                    $"Point of interest {potFromStore.Name} with id {potFromStore.Id} was deleted.");

            return NoContent();
        }
    }
}