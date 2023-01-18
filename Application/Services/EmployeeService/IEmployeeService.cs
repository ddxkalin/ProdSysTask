using Domain.Dtos;

namespace Application.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployees();
        Task<EmployeeDTO> CreateNewEmployee(EmployeeDTO employee);
        Task<EmployeeDTO?> GetEmployeeByIdAsync(int id);
        Task UpdateEmployeeAsync(int id, EmployeeDTO employee);
        Task DeleteEmployee(int id);
    }
}
