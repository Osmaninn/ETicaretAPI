using ETicaretAPI.Application.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrder order);

        Task<List<GetAllOrders>> GetAllOrdersAsync();

        Task<GetOrder> GetOrderById(string id);

    }
}
