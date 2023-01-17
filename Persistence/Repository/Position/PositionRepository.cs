using Dapper;
using Domain.Dtos;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
    }
}
