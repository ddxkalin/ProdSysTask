namespace Persistence.Repository.Employee
{
    using Domain.Dtos;

    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
        Task<EmployeeDTO?> GetEmployeeByIdAsync(int id);
        Task<int> CreateEmployeeAsync(EmployeeDTO employee);
        Task UpdateEmployeeAsync(int id, EmployeeDTO employee);
        Task DeleteEmployee(int id);
    }
}