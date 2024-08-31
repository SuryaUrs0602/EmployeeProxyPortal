using EmployeeManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProxyPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeServiceClient _employeeServiceClient;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(EmployeeServiceClient employeeServiceClient, ILogger<EmployeesController> logger)
        {
            _employeeServiceClient = employeeServiceClient;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                //var emp = new EmployeeDTO
                //{
                //    EmployeeName = employeeDTO.EmployeeName,
                //    EmployeeEmail = employeeDTO.EmployeeEmail,
                //    EmployeePhoneNumber = employeeDTO.EmployeePhoneNumber,
                //    DepartmentID = employeeDTO.DepartmentID,
                //    JobTitleID = employeeDTO.JobTitleID,
                //    ProjectID = employeeDTO.ProjectID,
                //};

                _logger.LogInformation("Adding a new Employee");
                await _employeeServiceClient.EmployeesAsync(employeeDTO);
                return Created();
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while adding a new employee");
                return StatusCode(500, new { error = "could not process due to some error" });
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                _logger.LogInformation("Geeting all Employees data");
                var data = await _employeeServiceClient.EmployeesAllAsync();
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting all employee");
                return StatusCode(500, new { error = "could not process due to some error" });
            }
        }


        [HttpGet("EmployeeID")]
        public async Task<IActionResult> GetEmployeeByID(int EmployeeID)
        {
            try
            {
                _logger.LogInformation("Geeting Employee data bu ID");
                var data = await _employeeServiceClient.EmployeeIDGETAsync(EmployeeID);
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting employee data by ID");
                return StatusCode(500, new { error = "could not process due to some error" });
            }
        }


        [HttpDelete("EmployeeID")]
        public async Task<IActionResult> DeleteEmployee(int EmployeeID)
        {
            try
            {
                _logger.LogInformation("Deleting employee data");
                await _employeeServiceClient.EmployeeIDDELETEAsync(EmployeeID);
                return NoContent();
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while deleting employee data");
                return StatusCode(500, new { error = "could not process due to some error" });
            }

        }


        [HttpPut("EmployeeID")]
        public async Task<IActionResult> EditEmployee(int  EmployeeID, EmployeeDTO employeeDTO)
        {
            try
            {
                //var emp = new EmployeeDTO
                //{
                //    EmployeeName = employeeDTO.EmployeeName,
                //    EmployeeEmail = employeeDTO.EmployeeEmail,
                //    EmployeePhoneNumber = employeeDTO.EmployeePhoneNumber,
                //    DepartmentID = employeeDTO.DepartmentID,
                //    JobTitleID = employeeDTO.JobTitleID,
                //    ProjectID = employeeDTO.ProjectID,
                //};

                _logger.LogInformation("UPdating the emploee data");
                await _employeeServiceClient.EmployeeIDPUTAsync(EmployeeID, employeeDTO);
                return NoContent();
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while updating employee data");
                return StatusCode(500, new { error = "could not process due to some error" });
            }

        }


        [HttpGet("EmployeeName")]
        public async Task<IActionResult> GetEmployeeByName(string EmployeeName)
        {
            try
            {
                _logger.LogInformation("Getting employee data by name");
                var data = await _employeeServiceClient.EmployeeNameAsync(EmployeeName);
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting employee data by employeename");
                return StatusCode(500, new { error = "could not process due to some error" });
            }
        }


        [HttpGet("sortasc")]
        public async Task<IActionResult> SortEmployeeInAscendingOrder()
        {
            try
            {
                _logger.LogInformation("Getting all employee data in ascending order");
                var data = await _employeeServiceClient.Sortasc2Async();
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting employee data in ascending order");
                return StatusCode(500, new { error = "could not process due to some error" });
            }

        }


        [HttpGet("sortdesc")]
        public async Task<IActionResult> SortEmployeeInDescendingOrder()
        {
            try
            {
                _logger.LogInformation("Getting all employee data in descending order");
                var data = await _employeeServiceClient.Sortdesc2Async();
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting employee data in descending order");
                return StatusCode(500, new { error = "could not process due to some error" });
            }
        }


        [HttpGet("DepartmentID")]
        public async Task<IActionResult> GetEmployeeDetailsWithDepartment(int DepartmentID)
        {
            try
            {
                _logger.LogInformation("Getting all employee data by department ID");
                var data = await _employeeServiceClient.BydepartmentIDAsync(DepartmentID);
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting employee data by deaprtment ID");
                return StatusCode(500, new { error = "could not process due to some error" });
            }
        }


        [HttpGet("ProjectID")]
        public async Task<IActionResult> GetEmployeeDetailsWithProject(int ProjectID)
        {
            try
            {
                _logger.LogInformation("Getting all employee data by projectID");
                var data = await _employeeServiceClient.ByprojectIDAsync(ProjectID);
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting employee data by projectID");
                return StatusCode(500, new { error = "could not process due to some error" });
            }

        }


        [HttpGet("JobTitleID")]
        public async Task<IActionResult> GetEmployeeDetailsWithJobTitle(int JobTitleID)
        {
            try
            {
                _logger.LogInformation("Getting all employee data by job title ID");
                var data = await _employeeServiceClient.ByjobtitleIDAsync(JobTitleID);
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error while getting employee data by jobtitle ID");
                return StatusCode(500, new { error = "could not process due to some error" });
            }

        }
    }
}
