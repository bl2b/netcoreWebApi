using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace XYC.Sample.API.Controllers
{
    [Route("api/sample/cities")]
    public class CitiesController: Controller
    {
        [HttpGet()]
        public JsonResult GetCities()
        {
            return new JsonResult(new List<object>()
            {
                new {id = 1, Name = "Philippines"},
                new {id = 2, Name = "USA"}
            });
        }
    }
}