using EmployeeManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace EmployeeProxyPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class DepartmentsController : ControllerBase
    {
        private readonly EmployeeServiceClient _employeeServiceClient;
        private readonly ILogger<DepartmentsController> _logger;

        public DepartmentsController(EmployeeServiceClient employeeServiceClient, ILogger<DepartmentsController> logger)
        {
            _employeeServiceClient = employeeServiceClient;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentDTO departmentDTO)
        {
            try
            {
                //var department = new DepartmentDTO
                //{
                //    Name = departmentDTO.Name
                //};

                _logger.LogInformation("Adding a new department");
                await _employeeServiceClient.DepartmentsAsync(departmentDTO);
                return Created();
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error occured while adding department");
                return StatusCode(500, new { error = "Could not process due to some error" });
            }
        }


        [HttpDelete("DepartmentID")]
        public async Task<IActionResult> DeleteDepartment(int DepartmentID)
        {
            try
            {
                _logger.LogInformation("Deleting a department");
                await _employeeServiceClient.DepartmentIDDELETEAsync(DepartmentID);
                return NoContent();
            }

            catch (ApiException ex)
            {
                _logger.LogInformation(ex, "Error occured while deleteing a department");
                return StatusCode(500, new { error = "Could not process due to some error " });
            }
        }


        [HttpPut("DepartmentID")]
        public async Task<IActionResult> EditDepartment(int DepartmentID, DepartmentDTO departmentDTO)
        {
            try
            {
                //var department = new DepartmentDTO
                //{
                //    DepartmentName = departmentDTO.DepartmentName
                //};

                _logger.LogInformation("Edit a department");
                await _employeeServiceClient.DepartmentIDPUTAsync(DepartmentID, departmentDTO);
                return NoContent();
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error occured while editing the deaprtment");
                return StatusCode(500, new { error = "could not process due to some error" });
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            try
            {
                _logger.LogInformation("Getting all departments");
                var data = await _employeeServiceClient.DepartmentsAllAsync();
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error occured while getting all deaprtment");
                return StatusCode(500, new { error = "Error" });
            }

        }


        [HttpGet("DepartmentID")]
        public async Task<IActionResult> GetDepartmentByID(int DepartmentID)
        {
            try
            {
                _logger.LogInformation("Gettin  department by ID");
                var data = await _employeeServiceClient.DepartmentIDGETAsync(DepartmentID);
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error occured while getting deaprtment by ID");
                return StatusCode(500, new { error = "could not process due to some error" });
            }

        }


        [HttpGet("sortasc")]
        public async Task<IActionResult> GetDepartmentInAscendingOrder()
        {
            try
            {
                _logger.LogInformation("Getting all departments in ascending order");
                var data = await _employeeServiceClient.SortascAsync();
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error occured while getting deaprtments in ascending order");
                return StatusCode(500, new { error = "could not process due to some error" });
            }
        }


        [HttpGet("sortdesc")]
        public async Task<IActionResult> GetDepartmentInDescendingOrder()
        {
            try
            {
                _logger.LogInformation("Getting all departments in descending order");
                var data = await _employeeServiceClient.SortdescAsync();
                return Ok(data);
            }

            catch (ApiException ex)
            {
                _logger.LogError(ex, "Error occured while getting deaprtments in descending order");
                return StatusCode(500, new { error = "could not process due to some error" });
            }
        }
    }
}
