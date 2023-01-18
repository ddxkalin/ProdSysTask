using Domain.Dtos;

namespace Persistence.Repository.Address
{
    public interface IAddressRepository
    {
        Task<int> CreateAddress(AddressDTO address);
        Task UpdateAddress(int addressId, AddressDTO address);
    }
}
