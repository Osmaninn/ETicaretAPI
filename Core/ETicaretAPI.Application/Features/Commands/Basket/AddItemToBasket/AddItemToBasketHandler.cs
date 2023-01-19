using ETicaretAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketHandler : IRequestHandler<AddItemToBasketRequest, AddItemToBasketResponse>
    {
        readonly IBasketService _basketService;

        public AddItemToBasketHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<AddItemToBasketResponse> Handle(AddItemToBasketRequest request, CancellationToken cancellationToken)
        {
           await _basketService.AddItemAsync(new()
           {
               ProductId= request.ProductId,    
               Quantity = request.Quantity,
           });
            return new AddItemToBasketResponse();
        }
    }
}
