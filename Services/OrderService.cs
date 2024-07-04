using System.Collections.Generic;
using System.Threading.Tasks;
using OrderApi.Models;
using OrderApi.Interfaces;

namespace OrderApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            var orders = await _repository.GetOrders();
            return orders.Select(ItemToDTO).ToList();
        }

        public async Task<OrderDTO?> GetOrderById(long id)
        {
            var order = await _repository.GetOrderById(id);
            return order == null ? null : ItemToDTO(order);
        }

        public async Task<bool> UpdateOrder(long id, OrderDTO orderDTO)
        {
            var order = await _repository.GetOrderById(id);
            if (order == null)
            {
                return false;
            }

            order.Name = orderDTO.Name;
            order.IsComplete = orderDTO.IsComplete;
            await _repository.UpdateOrder(order);
            return true;
        }

        public async Task<OrderDTO> CreateOrder(OrderDTO orderDTO)
        {
            var order = new Order
            {
                Name = orderDTO.Name,
                IsComplete = orderDTO.IsComplete,
                // Secret = "23"
            };

            await _repository.CreateOrder(order);
            return ItemToDTO(order);
        }

        public async Task<bool> DeleteOrder(long id)
        {
            var order = await _repository.GetOrderById(id);
            if (order == null)
            {
                return false;
            }

            await _repository.DeleteOrder(order);
            return true;
        }

        private static OrderDTO ItemToDTO(Order order) =>
            new OrderDTO
            {
                Id = order.Id,
                Name = order.Name,
                IsComplete = order.IsComplete
            };


    }
}
