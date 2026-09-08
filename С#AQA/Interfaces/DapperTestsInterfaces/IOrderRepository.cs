using System;
using System.Collections.Generic;
using System.Text;
using C_AQA.DTO.DapperTestsDTO;

namespace C_AQA.Interfaces.DapperTestsInterfaces
{
    public interface IOrderRepository
    {
        Task<OrderDTO?> GetOrderByIdAndUserIdAsync(int orderId, int userId);

        Task<IEnumerable<OrderItemDetailsDTO>> GetOrderItemsAsync(int orderId);

        Task<IEnumerable<CategoryBuyerDTO>> GetBuyersByCategoryNameAsync(string categoryName);
    }
}
