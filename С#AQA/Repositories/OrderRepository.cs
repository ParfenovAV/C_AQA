using C_AQA.DTO.DapperTestsDTO;
using C_AQA.Interfaces.DapperTestsInterfaces;
using Microsoft.Data.Sqlite;
using Dapper;

namespace C_AQA.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string connection;

        public OrderRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<OrderDTO?> GetOrderByIdAndUserIdAsync(int orderId, int userId)
        {
            await using var db = new SqliteConnection(connection);
            return await db.QueryFirstOrDefaultAsync<OrderDTO>(
                "SELECT Id, UserId, OrderDate, Status, TotalPrice " +
                "FROM Orders " +
                "WHERE Id = @orderId AND UserId = @userId",
                new { orderId, userId });
        }

        public async Task<IEnumerable<OrderItemDetailsDTO>> GetOrderItemsAsync(int orderId)
        {
            await using var db = new SqliteConnection(connection);
            return await db.QueryAsync<OrderItemDetailsDTO>(
                "SELECT oi.OrderId, p.Name AS ProductName, oi.Quantity, oi.UnitPrice " +
                "FROM OrderItems oi " +
                "JOIN Products p ON p.Id = oi.ProductId " +
                "WHERE oi.OrderId = @orderId",
                new { orderId });
        }

        public async Task<IEnumerable<CategoryBuyerDTO>> GetBuyersByCategoryNameAsync(string categoryName)
        {
            await using var db = new SqliteConnection(connection);
            return await db.QueryAsync<CategoryBuyerDTO>(
                "SELECT DISTINCT u.Id AS userId, a.City AS city, u.FirstName AS firstName, " +
                "u.LastName AS lastName, p.Name AS productName " +
                "FROM OrderItems oi " +
                "JOIN Products p ON p.Id = oi.ProductId " +
                "JOIN Categories c ON c.Id = p.CategoryId " +
                "JOIN Orders o ON o.Id = oi.OrderId " +
                "JOIN Users u ON u.Id = o.UserId " +
                "JOIN Addresses a ON a.UserId = u.Id " +
                "WHERE c.Name = @categoryName",
                new { categoryName });
        }
    }
}
