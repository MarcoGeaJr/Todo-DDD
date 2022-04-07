using Microsoft.AspNetCore.Mvc;
using Todo.Shared.Commands;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpPost("")]
        public ActionResult<GenericCommandResult> Create()
        {
            return null;
        }
    }
}
