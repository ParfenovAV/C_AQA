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
    }
}
