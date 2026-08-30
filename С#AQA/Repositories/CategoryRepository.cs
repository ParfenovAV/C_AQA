using C_AQA.Interfaces.DapperTestsInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using C_AQA.DTO.DapperTestsDTO;
using Microsoft.Data.Sqlite;
using Dapper;

namespace C_AQA.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string connection;
        public CategoryRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            await using var db = new SqliteConnection(connection);
            return await db.QueryAsync<CategoryDTO>("SELECT * FROM Categories");
        }
    }
}
