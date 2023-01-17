using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Address
{
    public interface IAddressRepository
    {
        Task<int> CreateAddress(AddressDTO address);
    }
}
