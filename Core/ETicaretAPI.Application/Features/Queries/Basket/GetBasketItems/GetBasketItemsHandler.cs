using ETicaretAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Basket.GetBasketItems
{
    public class GetBasketItemsHandler : IRequestHandler<GetBasketItemsRequest, List<GetBasketItemsResponse>>
    {
        private readonly IBasketService _basketService;

        public GetBasketItemsHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<List<GetBasketItemsResponse>> Handle(GetBasketItemsRequest request, CancellationToken cancellationToken)
        {
            var basketItems = await _basketService.GetBasketItemsAsync();
            return basketItems.Select(b => new GetBasketItemsResponse
            {
                BasketItemId = b.Id.ToString(),
                Price = b.Product.Price,
                Quantity = b.Quantity,
                ProductName = b.Product.Name,
            }).ToList();
        }

    }
}
