using Application.Services.EmployeeService;
using Domain;
using Domain.Dtos;

namespace UnitTests.RepositoriesTests
{
    public class EmployeeTests
    {
        private readonly IEmployeeService EmployeeService;

        public EmployeeTests(IEmployeeService _employeeService)
        {
            this.EmployeeService = _employeeService;
        }

        [Fact]
        public async Task CreateEmployee()
        {
            var employee = new EmployeeDTO()
            {
                Position = new PositionDTO()
                {
                    Name = "Python Developer"
                },
                Address = new AddressDTO()
                {
                    City = "Paris",
                    Country = "France",
                    Address = "Rue la liberté, 45 N°22",
                    PostCode = "2000-55"
                },
                Age = 25,
                IsActive = true,
                Name = "Test name",
                SigningDate = DateTime.Now
            };

            var createdEmployee = await EmployeeService.CreateNewEmployee(employee);

            Assert.NotNull(createdEmployee);

        }

        [Fact]
        public async Task CreateEmployeeWithEmptyAddress()
        {
            var employee = new EmployeeDTO()
            {
                Position = new PositionDTO()
                {
                    Name = "Cobol Developer"
                },
                Age = 25,
                IsActive = true,
                Name = "Test name empty address",
                SigningDate = DateTime.Now
            };

            var createdEmployee = await EmployeeService.CreateNewEmployee(employee);

            Assert.NotNull(createdEmployee);

        }
    }
}