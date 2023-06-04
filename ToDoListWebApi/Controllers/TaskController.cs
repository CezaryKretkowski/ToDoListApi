using Aplication.Dtos;
using Aplication.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ToDoListWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService) {
            _taskService = taskService;
        }

        [HttpPost]
        [Route("AddTask")]
        public async Task<IActionResult> AddTask(AddTaskDto taskDto) {

            var task = await _taskService.Add(taskDto);

            if (task != null)
            {
                return new OkObjectResult(task);
            }
            return new BadRequestObjectResult("error while adding task");
        }

        [HttpGet]
        [Route("GetAllTask")]
        public async Task<IActionResult> GetAllTask() {
            var tasks = await _taskService.GetAll();

            return new OkObjectResult(tasks);

        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetByID(int id) { 
            var t = await _taskService.GetByID(id);
            if (t != null)
                return new OkObjectResult(t);
            else
                return new NotFoundResult();

        }

        [HttpPut]
        [Route("UpdateTask")]
        public async Task<IActionResult> UpdateTask(TaskDto task) {
            var retTask = await _taskService.Update(task);
            if (retTask != null)
            {
                return new OkObjectResult(retTask);
            }
            return new BadRequestObjectResult("Error while updating task");
        }

        [HttpDelete]
        [Route("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int id) { 
            var task= await _taskService.Delete(id);
            if (task != null)
            {
                return new OkObjectResult(task);
            }
            return new BadRequestObjectResult("Error while deliting task");
        }

        [HttpPatch]
        [Route("CompleteTask")]
        public async Task<IActionResult> CompleteTask(int id) { 
            var task = await _taskService.CompleteTask(id);
            if (task != null)
            {
                return new OkObjectResult(task);
            }
            return new BadRequestObjectResult("Error while updating task");

        }

        [HttpGet]
        [Route("GetAllTodayTask")]
        public async Task<IActionResult> GetAllTaskToday()
        {
            var tasks = await _taskService.GetToDayTasks();

            return new OkObjectResult(tasks);

        }
    }
}
