namespace API.Controllers
{
    using Application.Services.EmployeeService;
    using Domain.Dtos;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService EmployeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var employees = await this.EmployeeService.GetAllEmployees();

            return Ok(employees);
        }

        [HttpGet("{id}", Name = "employeeById")]
        public async Task<IActionResult> GetEmployeeAsync(int id)
        {
            var employee = await EmployeeService.GetEmployeeByIdAsync(id);

            if(employee == null)
                return NotFound();
            
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDTO employee)
        {
            try
            {
                var createdEmployee = await this.EmployeeService.CreateNewEmployee(employee);
                return Ok(createdEmployee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDTO employeeDto)
        {
            try
            {
                var dbEmployee = await EmployeeService.GetEmployeeByIdAsync(id);
                if (dbEmployee == null)
                    return NotFound();

                await EmployeeService.UpdateEmployeeAsync(id, employeeDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var dbEmployee = await this.EmployeeService.GetEmployeeByIdAsync(id);

                if (dbEmployee == null)
                    return NotFound();

                await EmployeeService.DeleteEmployee(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}