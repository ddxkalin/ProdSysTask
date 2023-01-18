using Dapper;
using Domain.Dtos;

namespace Persistence.Repository.Position
{
    public class PositionRepository : IPositionRepository
    {
        private readonly DataContext _context;

        public PositionRepository(DataContext context) => _context = context; 

        public async Task<int> CreatePosition(PositionDTO position)
        {
            var query = "INSERT INTO Position (Name) output inserted.Id values (@Name)";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<int>(query, new
                {
                    Name = position.Name
                });
            }
        }

        public async Task UpdatePosition(int PositionId, PositionDTO position)
        {
            var query = "Update Position set Name = @Name where Id = @PositionID";

            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync<int>(query, new
                {
                    PositionID = PositionId,
                    Name = position.Name
                });
            }
        }
    }
}
