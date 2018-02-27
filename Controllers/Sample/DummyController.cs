using Microsoft.AspNetCore.Mvc;
using XYC.Domain.Context.Sample;

namespace XYC.Controllers.Sample
{
    public class DummyController: Controller
    {
        private SampleContext _ctx;

        public DummyController(SampleContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}