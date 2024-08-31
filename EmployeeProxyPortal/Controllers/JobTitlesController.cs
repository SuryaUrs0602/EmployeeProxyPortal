using EmployeeManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProxyPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class JobTitlesController : ControllerBase
    {
        private readonly EmployeeServiceClient _employeeServiceClient;
        private readonly ILogger<JobTitlesController> _logger;

        public JobTitlesController(EmployeeServiceClient employeeServiceClient, ILogger<JobTitlesController> logger)
        {
            _employeeServiceClient = employeeServiceClient;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> AddJobTitle(JobTitleDTO jobTitleDTO)
        {
            try
            {
                //var jobTitle = new JobTitleDTO
                //{
                //    JobName = jobTitleDTO.JobName,
                //    JobSalary = jobTitleDTO.JobSalary
                //};

                _logger.LogInformation("Adding a new job title");
                await _employeeServiceClient.JobTitlesAsync(jobTitleDTO);
                return Created();
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while adding a new job title");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }


        [HttpDelete("JobTitleID")]
        public async Task<IActionResult> DeleteJobTitle(int JobTitleID)
        {
            try
            {
                _logger.LogInformation("deleting job title");
                await _employeeServiceClient.JobTitleIDDELETEAsync(JobTitleID);
                return NoContent();
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while deleting job title");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }


        [HttpPut("JobTitleDTO")]
        public async Task<IActionResult> EditJobTitle(int JobTitleID, JobTitleDTO jobTitleDTO)
        {
            try
            {
                //var jobTitle = new JobTitleDTO
                //{
                //    JobName = jobTitleDTO.JobName,
                //    JobSalary = jobTitleDTO.JobSalary
                //};

                _logger.LogInformation("Updating the job title");
                await _employeeServiceClient.JobTitleIDPUTAsync(JobTitleID, jobTitleDTO);
                return NoContent();
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while updating job title");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetAllJobTitle()
        {
            try
            {
                _logger.LogInformation("Getting all job titles");
                var data = await _employeeServiceClient.JobTitlesAllAsync();
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while Getting all job title");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }

        }


        [HttpGet("JobTitleID")]
        public async Task<IActionResult> GetJobTitleByID(int JobTitleID)
        {
            try
            {
                _logger.LogInformation("Getting job title by ID");
                var data = await _employeeServiceClient.JobTitleIDGETAsync(JobTitleID);
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while Getting job title by ID");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }


        [HttpGet("sortasc")]
        public async Task<IActionResult> SortJobTitleInAscendingOrder()
        {
            try
            {
                _logger.LogInformation("Getting all job titles in ascending order");
                var data = await _employeeServiceClient.Sortasc4Async();
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while Getting job title in ascending order");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }


        [HttpGet("sortdesc")]
        public async Task<IActionResult> SortJobTitleInDescendingOrder()
        {
            try
            {
                _logger.LogInformation("Getting all job titles in descending order");
                var data = await _employeeServiceClient.Sortdesc4Async();
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while Getting job title in descending order");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }
    }
}
