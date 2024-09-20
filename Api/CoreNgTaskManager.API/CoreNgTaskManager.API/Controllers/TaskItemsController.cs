using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos;

namespace CoreNgTaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskItemsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TaskItemsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTaskItems()
        {
            var taskItems = await _serviceManager.TaskItemService.GetAllTaskItemsAsync(trackChanges: false);
            return Ok(taskItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllTaskItem(int id)
        {
            var taskItem = await _serviceManager.TaskItemService.GetTaskItemAsync(id, trackChanges: false);
            return Ok(taskItem);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateAntiForgeryTokenAttribute))]
        public async Task<IActionResult> PostTaskItem([FromBody] TaskItemForCreationDto taskItemForCreationDto)
        {
            var createdTaskItem = await _serviceManager.TaskItemService.CreateTaskItemAsync(taskItemForCreationDto);
            return Created("", createdTaskItem);
        }
    }
}