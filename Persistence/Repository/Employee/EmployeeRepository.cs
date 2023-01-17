namespace Persistence.Repository.Employee
{
    using System.Data;
    using System.Transactions;
    using Dapper;
    using Domain.Dtos;
    using Persistence;

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context) => _context = context;

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var query = "SELECT E.*, P.*, A.* FROM Employee E left join Position P on P.Id = E.PositionId left join Address A on A.Id = E.AddressId";

            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<EmployeeDTO, PositionDTO, AddressDTO, EmployeeDTO>(query, (employee, position, address) =>
                {
                    if (position != null)
                        employee.Position = position;
                    if (address != null)
                        employee.Address = address;
                    return employee;
                });

                return employees.ToList();
            }
        }
        public async Task<EmployeeDTO?> GetEmployeeByIdAsync(int id)
        {
            var query = "SELECT E.*, P.*, A.* FROM Employee E left join Position P on P.Id = E.PositionId left join Address A on A.Id = E.AddressId WHERE E.Id = @EmployeeId";

            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<EmployeeDTO, PositionDTO, AddressDTO, EmployeeDTO>(query, (employee, position, address) =>
                {
                    if (position != null)
                        employee.Position = position;
                    if (address != null)
                        employee.Address = address;
                    return employee;
                }, new { EmployeeId = id });

                return employees.FirstOrDefault();
            }
        }

        public async Task<int> CreateEmployeeAsync(EmployeeDTO employee)
        {
            var query = "INSERT INTO Employee (Name, Age, SigningDate, LeavingDate, IsActive, AddressId, PositionId) OUTPUT inserted.Id values(@Name, @Age, @SigningDate, @LeavingDate, @IsActive, @AddressId, @PositionId)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", employee.Name, DbType.String);
            parameters.Add("Age", employee.Age, DbType.Int32);
            parameters.Add("SigningDate", employee.SigningDate, DbType.Date);
            parameters.Add("LeavingDate", employee.LeavingDate, DbType.Date);
            parameters.Add("IsActive", employee.IsActive, DbType.Boolean);
            parameters.Add("AddressId", employee.AddressId, DbType.Int32);
            parameters.Add("PositionId", employee.PositionId, DbType.Int32);

            using var connection = _context.CreateConnection();

            return await connection.QuerySingleAsync<int>(query, parameters);
        }

        public async Task UpdateEmployeeAsync(int id, EmployeeDTO employee)
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