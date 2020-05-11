using Microsoft.AspNetCore.Mvc;
using Shop.Api.Errors;
using Shop.Infrastructure.Data;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {
        private readonly ShopContext _shopContext;
        public BuggyController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundResult()
        {
            var thing = _shopContext.Products.Find(500);

            if (thing == null)
                return NotFound(new ApiResponse(404));

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerErrorResult()
        {
            var thing = _shopContext.Products.Find(500);
            var test = thing.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequestResult()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequestFormatResult(int id)
        {
            return Ok();
        }
    }
}