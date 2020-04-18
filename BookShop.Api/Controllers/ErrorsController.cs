using BookShop.Api.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Controllers
{
    [ApiController]
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}