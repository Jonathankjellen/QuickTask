using Microsoft.AspNetCore.Mvc;
using QuickTask_Backend.Models;
using QuickTask_Backend.Services;

namespace QuickTask_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? status) =>
            Ok(await _service.GetAllAsync(status));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _service.GetByIdAsync(id);
            return task is null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskItem task)
        {
            var created = await _service.CreateAsync(task);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskItem task)
        {
            var success = await _service.UpdateAsync(id, task);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }

    }
}
