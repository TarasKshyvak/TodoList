using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("actual")]
        public async Task<ActionResult<IEnumerable<TodoModel>>> GetActual()
        {
            return (await _todoService.GetActualAsync()).ToList();
        }

        [HttpGet("archive")]
        public async Task<ActionResult<IEnumerable<TodoModel>>> GetArchived()
        {
            return (await _todoService.GetArchivedAsync()).ToList();
        }

        [HttpPost]
        public async Task<ActionResult<TodoModel>> Add([FromBody]TodoModel model)
        {
            return Ok(await _todoService.AddAsync(model));
        }

        [HttpPut("archive/{id}")]
        public async Task<ActionResult> SetArchived(Guid id)
        {
            await _todoService.SetArchivedAsync(id);
            return Ok();
        }

        [HttpPut("done/{id}")]
        public async Task<ActionResult> SetDone(Guid id)
        {
            await _todoService.SetDoneAsync(id);
            return Ok();
        }

        [HttpPut("undone/{id}")]
        public async Task<ActionResult> SetUndone(Guid id)
        {
            await _todoService.SetUndoneAsync(id);
            return Ok();
        }
    }
}
