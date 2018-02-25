using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using XYC.Domain.Fakes;

namespace XYC.Sample.API.Controllers
{
    [Route("api/sample/cities")]
    public class CitiesController: Controller
    {
        [HttpGet()]
        public JsonResult GetCities()
        {
            return new JsonResult(CitiesDataStore.Current.Cities);
            // return new JsonResult(new List<object>()
            // {
            //     new {id = 1, Name = "Philippines"},
            //     new {id = 2, Name = "USA"}
            // });
        }
    }
}