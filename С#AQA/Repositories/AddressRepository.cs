using C_AQA.Interfaces.DapperTestsInterfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using C_AQA.DTO.DapperTestsDTO;
using C_AQA.Interfaces.DapperTestsInterfaces;
using Dapper;

namespace C_AQA.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly string connection;
        public AddressRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<AddressDTO> GetAddressByUserId(int userId)
        {
            using var db = new SqliteConnection(connection);
            var address = await db.QueryFirstOrDefaultAsync<AddressDTO>("SELECT * from Addresses " +
                "WHERE UserId = @userId", new { userId });
            return address;
        }
    }
}
