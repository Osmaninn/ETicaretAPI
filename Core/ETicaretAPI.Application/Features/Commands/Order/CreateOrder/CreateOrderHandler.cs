using ETicaretAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private readonly IOrderService _orderService;
        private IBasketService _basketService;

        public CreateOrderHandler(IOrderService orderService, IBasketService basketService)
        {
                _orderService= orderService;    
            _basketService= basketService;
        }
        public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            await _orderService.CreateOrderAsync(new()
            {
                Address = request.Address,
                BasketId= _basketService.GetBasketActiveUser?.Id.ToString(),
                Description = request.Description,
            });
            return new();
        }
    }
}
