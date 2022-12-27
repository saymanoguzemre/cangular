using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _contect;
        public BuggyController(StoreContext contect)
        {
            _contect = contect;

        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var request = _contect.Products.Find(52);

            if(request == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var request = _contect.Products.Find(52);

            var returnRequest = request.ToString();

            return Ok(new ApiResponse(500));
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