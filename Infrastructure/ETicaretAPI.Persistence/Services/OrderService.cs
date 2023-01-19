using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Dtos.Order;
using ETicaretAPI.Application.Features.Queries.Order.GetAllOrders;
using ETicaretAPI.Application.Features.Queries.Product.GetAllProducts;
using ETicaretAPI.Application.Repositories.OrderRepository;
using ETicaretAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Services
{
    public class OrderService : IOrderService
    {
        private IOrderWriteRepository _orderWriteRepository;
        private IOrderReadRepository _orderReadRepository;

        public OrderService(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        public async Task CreateOrderAsync(CreateOrder order)
        {
            await _orderWriteRepository.AddAsync(new()
            {
                Address= order.Address,
                BasketId= Guid.Parse(order.BasketId),
                Description= order.Description,
                OrderCode = Guid.NewGuid().ToString(),  
            });            
        }

        public async Task<List<GetAllOrders>> GetAllOrdersAsync()
        {
              return await _orderReadRepository.GetAll().Include(o => o.Basket)
                        .ThenInclude(b => b.User)
                        .Include(o => o.Basket)
                        .ThenInclude(b => b.BasketItems)
                        .ThenInclude(bi => bi.Product)
                        .Select(o => new GetAllOrders
                        {
                            OrderCode = o.OrderCode,
                            CreatedDate = o.CreateDate,
                            Username = o.Basket.User.UserName,
                            TotalPrice = o.Basket.BasketItems.Sum(bi => bi.Product.Price * bi.Quantity)
                        })
                        .ToListAsync();
        }

        public async Task<GetOrder> GetOrderById(string id)
        {
            var data = await _orderReadRepository.GetAll().Include(o => o.Basket)
                                    .ThenInclude(b => b.BasketItems)
                                    .ThenInclude(bi => bi.Product)
                                    .FirstOrDefaultAsync(o => o.Id == Guid.Parse(id));

            return new()
            {
                Id = data.Id.ToString(),
                OrderCode = data.OrderCode,
                CreatedDate = data.CreateDate,
                Address = data.Address,
                Description= data.Description,
                BasketItems = data.Basket.BasketItems.Select(bi => new
                {
                    bi.Product.Name,
                    bi.Product.Price,
                    bi.Quantity      
                }),
            };
        }
    }
}
