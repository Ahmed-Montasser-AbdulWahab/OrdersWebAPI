using Entities;

namespace ServiceContracts
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllOrders();

        public Task<Order> GetOrderByOrderID(Guid orderID);

        

    }
}
