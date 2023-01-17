using Persistence.Repository.Address;
using Persistence.Repository.Employee;
using Persistence.Repository.Position;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Application.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository EmployeeRepository;
        private readonly IAddressRepository AddressRepository;
        private readonly IPositionRepository PositionRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IAddressRepository addressRepository, IPositionRepository positionRepository) {
            EmployeeRepository = employeeRepository;
            AddressRepository = addressRepository;
            PositionRepository= positionRepository;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            return await EmployeeRepository.GetAllEmployeesAsync();
        }

        public async Task<EmployeeDTO> CreateNewEmployee(EmployeeDTO employee)
        {
            //Create Position if needed
            if (employee.Position != null)
                employee.PositionId = await PositionRepository.CreatePosition(employee.Position);

            //Create Address if needed
            if (employee.Address != null)
                employee.AddressId = await AddressRepository.CreateAddress(employee.Address);

            //Create now the new employee
            var createdEmployeeID = await EmployeeRepository.CreateEmployeeAsync(employee);

            var createdEmployee = await this.EmployeeRepository.GetEmployeeByIdAsync(createdEmployeeID);

            if (createdEmployee != null)
                return createdEmployee;

            throw new Exception($"An error occured while creating the new employee {employee.Name}");
        }

        public async Task<EmployeeDTO?> GetEmployeeByIdAsync(int id)
        {
            return await EmployeeRepository.GetEmployeeByIdAsync(id);
        }

        public Task UpdateEmployeeAsync(int id, EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
