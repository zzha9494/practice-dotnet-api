using System.Collections.Generic;
using System.Threading.Tasks;
using OrderApi.Models;

namespace OrderApi.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetOrders();
        Task<OrderDTO?> GetOrderById(long id);
        Task<bool> UpdateOrder(long id, OrderDTO orderDTO);
        Task<OrderDTO> CreateOrder(OrderDTO orderDTO);
        Task<bool> DeleteOrder(long id);
    }
}
