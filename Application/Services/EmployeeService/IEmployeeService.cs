using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
