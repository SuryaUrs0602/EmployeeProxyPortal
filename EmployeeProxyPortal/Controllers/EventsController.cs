using EmployeeManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProxyPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EventsController : ControllerBase
    {
        private readonly EmployeeServiceClient _employeeServiceClient;
        private readonly ILogger<EventsController> _logger;

        public EventsController(EmployeeServiceClient employeeServiceClient, ILogger<EventsController> logger)
        {
            _employeeServiceClient = employeeServiceClient;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> AddTask(EventDTO eventDTO)
        {
            try
            {
                //var eve = new EventDTO
                //{
                //    TaskName = eventDTO.TaskName,
                //    TaskStatus = eventDTO.TaskStatus,
                //    ProjectID = eventDTO.ProjectID
                //};

                _logger.LogInformation("Adding a new TAsk");
                await _employeeServiceClient.EventsAsync(eventDTO);
                return Created();
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while adding a new task");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }


        [HttpDelete("TaskID")]
        public async Task<IActionResult> DeleteTask(int TaskID)
        {
            try
            {
                _logger.LogInformation("deleting TAsk");
                await _employeeServiceClient.TaskIDDELETEAsync(TaskID);
                return NoContent();
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while deleting task");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }

        }


        [HttpPut("TaskID")]
        public async Task<IActionResult> EditTask(int TaskID, EventDTO eventDTO)
        {
            try
            {
                //var eve = new EventDTO
                //{
                //    TaskName = eventDTO.TaskName,
                //    TaskStatus = eventDTO.TaskStatus,
                //    ProjectID = eventDTO.ProjectID
                //};

                _logger.LogInformation("Updating the task");
                await _employeeServiceClient.TaskIDPUTAsync(TaskID, eventDTO);
                return NoContent();
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while updating the task");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetAllTask()
        {
            try
            {
                _logger.LogInformation("Getting all tasks");
                var data = await _employeeServiceClient.EventsAllAsync();
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting all task");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }


        [HttpGet("TaskID")]
        public async Task<IActionResult> GetTaskByID(int TaskID)
        {
            try
            {
                _logger.LogInformation("Getting task by ID");
                var data = await _employeeServiceClient.TaskIDGETAsync(TaskID);
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting task by ID");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }


        [HttpGet("sortasc")]
        public async Task<IActionResult> SortTaskInAscendingOrder()
        {
            try
            {
                _logger.LogInformation("Getting all tasks in ascending order");
                var data = await _employeeServiceClient.Sortasc3Async();
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while sorting all task in ascending order");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }


        [HttpGet("sortdesc")]
        public async Task<IActionResult> SortTaskInDescendingOrder()
        {
            try
            {
                _logger.LogInformation("Getting all tasks in descending order");
                var data = await _employeeServiceClient.Sortdesc3Async();
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while sorting all task in descending order");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }


        [HttpGet("status")]
        public async Task<IActionResult> GetTaskByStatus(string status)
        {
            try
            {
                _logger.LogInformation("Getting all tasks by status");
                var data = await _employeeServiceClient.StatusAsync(status);
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting task by status");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }

        }


        [HttpGet("ProjectID")]
        public async Task<IActionResult> GetTaskOkProject(int ProjectID)
        {
            try
            {
                _logger.LogInformation("Getting all tasks by project ID");
                var data = await _employeeServiceClient.ByprojectID2Async(ProjectID);
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting task by project ID");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }
    }
}
