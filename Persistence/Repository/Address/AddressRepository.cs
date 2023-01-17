﻿using Dapper;
using Domain.Dtos;
using Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
