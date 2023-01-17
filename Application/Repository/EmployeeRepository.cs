namespace Application.Repository
{
    using System.Data;
    using Dapper;
    using Domain;
    using Domain.Dtos;
    using Persistence;

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context) => _context = context;

        public async Task<IEnumerable<Employees>> GetAllEmployeesAsync()
        {
            var query = "Select * FROM Employee";

            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employees>(query);

                return employees.ToList();
            }
        }
        public async Task<Employees> GetEmployeeByIdAsync(int id)
        {
            var query = "Select * FROM Employee WHERE Id = @EmployeeId";

            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QuerySingleOrDefaultAsync<Employees>(query, new { id });

                return employees;
            }
        }

        public async Task<Employees> CreateEmployeeAsync(EmployeeDto employee)
        {
            var query = "INSERT INTO Employee (EmployeeId, Name, Age, DateOfSigning) VALUES (@EmployeeId, @Name, @Age, @DateOfSigning)";
                // "INSERT INTO Address (City, Country, FullAddress, PostCode) VALUES (@City, @Country, @FullAddress, @PostCode)";

            var parameters = new DynamicParameters();
            parameters.Add("EmployeeId", employee.EmployeeId, DbType.Int32);
            parameters.Add("Name", employee.Name, DbType.String);
            parameters.Add("Age", employee.Age, DbType.String);
            parameters.Add("DateOfSigning", employee.DateOfSigning, DbType.Date);
            // parameters.Add("City", employee.City, DbType.String);
            // parameters.Add("Country", employee.County, DbType.String);
            // parameters.Add("FullAddress", employee.FullAddress, DbType.String);
            // parameters.Add("PostCode", employee.PostCode, DbType.Int32);

            using var connection = this._context.CreateConnection();

            var id = await connection.QueryFirstOrDefaultAsync<int>(query, parameters);

            var createdEmployee = new Employees
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Age = employee.Age,
                DateOfSigning = employee.DateOfSigning
            };

            return createdEmployee;
        }

        public async Task UpdateEmployeeAsync(int id, EmployeeDto employee)
        {
            var query = "UPDATE Employee SET Name = @Name, Age = @Age WHERE Id = @EmployeeId";

            var parameters = new DynamicParameters();
            parameters.Add("EmployeeId", id, DbType.Int32);
            parameters.Add("Name", employee.Name, DbType.String);
            parameters.Add("Age", employee.Age, DbType.String);

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteEmployee(int id)
        {
            var query = "DELETE FROM Employee WHERE Id = @EmployeeId";

            using var connection = _context.CreateConnection();
            
            await connection.ExecuteAsync(query, new { id });
        }
    }
}