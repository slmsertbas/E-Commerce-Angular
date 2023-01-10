using API.ErrorHandler;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            this._context = context;
        }

        [HttpGet("notfound")]

        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(42);

            if( thing == null) {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("servererror")]

        public ActionResult GetServerErrorRequest()
        {
            var thing = _context.Products.Find(42);

            var thingToString = thing.ToString();
            
            return Ok(thingToString);
        }

         [HttpGet("badrequest")]

        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]

        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}