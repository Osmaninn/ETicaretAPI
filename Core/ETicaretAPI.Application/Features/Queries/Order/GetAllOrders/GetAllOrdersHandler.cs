using ETicaretAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Order.GetAllOrders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersRequest, List<GetAllOrdersResponse>>
    {
        private IOrderService _orderService;

        public GetAllOrdersHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<List<GetAllOrdersResponse>> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetAllOrdersAsync();

            return result.Select(o => new GetAllOrdersResponse
            {
                CreatedDate = o.CreatedDate,
                OrderCode = o.OrderCode,
                TotalPrice = o.TotalPrice,
                Username = o.Username
            }).ToList();
        }

    }
}
