using Persistence.Repository.Address;
using Domain;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
