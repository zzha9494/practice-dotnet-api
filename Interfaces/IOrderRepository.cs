using System.Collections.Generic;
using System.Threading.Tasks;
using OrderApi.Models;

namespace OrderApi.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order?> GetOrderById(long id);
        Task CreateOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(Order order);
        bool OrderExists(long id);
    }
}
