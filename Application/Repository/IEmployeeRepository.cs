namespace Application.Repository
{
    using Domain;
    using Domain.Dtos;

    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employees>> GetAllEmployeesAsync();
        public Task<Employees> GetEmployeeByIdAsync(int id);
        public Task<Employees> CreateEmployeeAsync(EmployeeDto employee);
        Task UpdateEmployeeAsync(int id, EmployeeDto employee);
        Task DeleteEmployee(int id);
    }
}