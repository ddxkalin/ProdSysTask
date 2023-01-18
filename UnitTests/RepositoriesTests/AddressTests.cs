using Persistence.Repository.Address;
using Domain.Dtos;

namespace UnitTests.RepositoriesTests
{
    public class AddressTests
    {
        private readonly IAddressRepository AddressRepository;
        public AddressTests(IAddressRepository addressRepository)
        {
            AddressRepository = addressRepository;
        }

        [Fact]
        public async Task CreateAddress()
        {
            var address = new AddressDTO()
            {
                City = "City example",
                Country = "Country example",
                PostCode = "12345",
                Address = "Example of address"
            };

            var addressID = await AddressRepository.CreateAddress(address);

            Assert.NotEqual(0, addressID);

        }
    }
}
