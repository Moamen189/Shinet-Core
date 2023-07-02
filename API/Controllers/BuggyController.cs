using Infastrucure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext storeContext;

        public BuggyController(StoreContext _storeContext)
        {
            storeContext = _storeContext;
        }

        [HttpGet("notfound")]

        public IActionResult GetNotFoundRequest ()
        {
            var thing = storeContext.Products.Find(30);

            if (thing == null)
            {
                return NotFound();
            }

            return Ok();
        }


        [HttpGet("servererror")]

        public IActionResult GetServerError()
        {
            var thing = storeContext.Products.Find(30);

            var ThingToReturn = thing.ToString();

            return Ok();
        }


        [HttpGet("badrequest")]

        public IActionResult GetBadRequest()
        {
               return BadRequest();
        }


        [HttpGet("badrequest/{id}")]

        public IActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}
