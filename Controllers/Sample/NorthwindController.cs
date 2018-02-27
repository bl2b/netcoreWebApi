using XYC.Services.Abstract.Sample;
using Microsoft.AspNetCore.Mvc;

namespace XYC.Controllers.Sample
{

    [Route("api/northwind")]
    public class NorthwindController : Controller
    {
        private INorthwindRepository _nortwindRepo;

        public NorthwindController(INorthwindRepository nortwindRepo)
        {
            _nortwindRepo = nortwindRepo;
        }
        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(_nortwindRepo.GetCustomers());
        }
    }
}