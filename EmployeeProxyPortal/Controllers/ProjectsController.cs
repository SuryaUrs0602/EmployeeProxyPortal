using EmployeeManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProxyPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProjectsController : ControllerBase
    {
        private readonly EmployeeServiceClient _employeeServiceClient;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(EmployeeServiceClient employeeServiceClient, ILogger<ProjectsController> logger)
        {
            _employeeServiceClient = employeeServiceClient;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectDTO projectDTO)
        {
            try
            {
                //var project = new ProjectDTO
                //{
                //    ProjectName = projectDTO.ProjectName,
                //    ProjectDuration = projectDTO.ProjectDuration
                //};

                _logger.LogInformation("Adding a new project");
                await _employeeServiceClient.ProjectsAsync(projectDTO);
                return Created();
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while adding a new  project");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }


        [HttpDelete("ProjectID")]
        public async Task<IActionResult> DeleteProject(int ProjectID)
        {
            try
            {
                _logger.LogInformation("Deleting the project");
                await _employeeServiceClient.ProjectIDDELETEAsync(ProjectID);
                return NoContent();
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while deleting project");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }


        [HttpPut("ProjectID")]
        public async Task<IActionResult> EditProject(int ProjectID, ProjectDTO projectDTO)
        {
            try
            {
                //var project = new ProjectDTO
                //{
                //    ProjectName = projectDTO.ProjectName,
                //    ProjectDuration = projectDTO.ProjectDuration
                //};

                _logger.LogInformation("Updating the project");
                await _employeeServiceClient.ProjectIDPUTAsync(ProjectID, projectDTO);
                return NoContent();
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while  editing project");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                _logger.LogInformation("Getting all projects");
                var data = await _employeeServiceClient.ProjectsAllAsync();
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting all project");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }


        [HttpGet("ProjectID")]
        public async Task<IActionResult> GetProjectByID(int ProjectID)
        {
            try
            {
                _logger.LogInformation("Getting  project by ID");
                var data = await _employeeServiceClient.ProjectIDGETAsync(ProjectID);
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting project by ID");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }

        }


        [HttpGet("sortasc")]
        public async Task<IActionResult> SortProjectInAscendingOrder()
        {
            try
            {
                _logger.LogInformation("Getting all projects in ascending order");
                var data = await _employeeServiceClient.Sortasc5Async();
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting project in acendign order");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }


        [HttpGet("sortdesc")]
        public async Task<IActionResult> SortProjectInDescendingOrder()
        {
            try
            {
                _logger.LogInformation("Getting all projects in descending order");
                var data = await _employeeServiceClient.Sortdesc5Async();
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting projects in descending order");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }
    }
}
