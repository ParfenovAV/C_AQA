using C_AQA.DTO.DapperTestsDTO;
using C_AQA.Interfaces.DapperTestsInterfaces;
using Microsoft.Data.Sqlite;
using Dapper;

namespace C_AQA.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string connection;
        public ProductRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<ProductDTO?> GetProductByIdAsync(int id)
        {
            await using var db = new SqliteConnection(connection);
            return await db.QueryFirstOrDefaultAsync<ProductDTO>(
                "SELECT Id, Name, Description, Price, Stock, CategoryId FROM Products WHERE Id = @id",
                new { id });
        }
    }
}
