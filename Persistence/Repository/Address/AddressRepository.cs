using Dapper;
using Domain.Dtos;

namespace Persistence.Repository.Address
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;

        public AddressRepository(DataContext context) => _context = context;

        public async Task<int> CreateAddress(AddressDTO address)
        {
            var query = "INSERT INTO Address (City, Country, Address, PostCode) OUTPUT INSERTED.Id values (@City, @Country, @Address, @PostCode)";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<int>(query, new {
                    City = address.City,
                    Country = address.Country,
                    Address = address.Address,
                    PostCode = address.PostCode
                });
            }
        }

        public async Task UpdateAddress(int addressId, AddressDTO address)
        {
            var query = "Update Address set City = @City, Country = @Country, Address = @Address, PostCode = PostCode where Id = @AddressID";

            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync(query, new
                {
                    AddressID = addressId,
                    City = address.City,
                    Country = address.Country,
                    Address = address.Address,
                    PostCode = address.PostCode
                });
            }
        }
    }
}
