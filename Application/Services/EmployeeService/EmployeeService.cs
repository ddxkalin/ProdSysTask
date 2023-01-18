using Persistence.Repository.Address;
using Persistence.Repository.Employee;
using Persistence.Repository.Position;
using Domain.Dtos;

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

        public async Task UpdateEmployeeAsync(int EmployeeId, EmployeeDTO employee)
        {
            EmployeeDTO dbEmployee = (await this.GetEmployeeByIdAsync(EmployeeId))!;

            employee.AddressId = dbEmployee.AddressId;
            employee.PositionId = dbEmployee.PositionId;

            //Update the address when filled
            if(employee.Address != null) 
            {
                if (!dbEmployee.AddressId.HasValue)
                    employee.AddressId = await this.AddressRepository.CreateAddress(employee.Address);
                else
                    await this.AddressRepository.UpdateAddress(dbEmployee.AddressId.Value, employee.Address);
            }

            //Update the position filled 
            if (employee.Position != null)
            {
                if (!dbEmployee.PositionId.HasValue)
                    employee.PositionId = await this.PositionRepository.CreatePosition(employee.Position);
                else
                    await this.PositionRepository.UpdatePosition(dbEmployee.PositionId.Value, employee.Position);
            }

            //update the employee
            await this.EmployeeRepository.UpdateEmployeeAsync(EmployeeId, employee);
        }

        public async Task DeleteEmployee(int id)
        {
            await EmployeeRepository.DeleteEmployee(id);
        }
    }
}
