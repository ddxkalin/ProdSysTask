using Application.Services.EmployeeService;
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
                    Address = "Rue la libert�, 45 N�22",
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

        [Fact]
        public async Task UpdateEmployee()
        {
            var employee = new EmployeeDTO()
            {
                Position = new PositionDTO()
                {
                    Name = "Full Stack Developer (.NET/Angular)"
                },
                Address = new AddressDTO()
                {
                    City = "Lisbon",
                    Country = "Portugal",
                    Address = "Rua vila alferes chamusca, 7, 1�DTO",
                    PostCode = "1800-433"
                },
                Age = 24,
                IsActive = true,
                Name = "Kalin STOEV",
                SigningDate = DateTime.Now
            };

            await EmployeeService.UpdateEmployeeAsync(2, employee);

            Assert.True(true);
        }

        [Fact]
        public async Task DeleteEmployee()
        {
            await EmployeeService.DeleteEmployee(1);
            Assert.True(true);
        }
    }
}