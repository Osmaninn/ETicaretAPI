using ETicaretAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Order.GetOrderById
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, GetOrderByIdResponse>
    {
        private IOrderService _orderService;

        public GetOrderByIdHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var data = await _orderService.GetOrderById(request.OrderId);

            return new GetOrderByIdResponse()
            {
                Id = data.Id,
                Description = data.Description,
                Address = data.Address,
                BasketItems = data.BasketItems,
                CreatedDate = data.CreatedDate,
                OrderCode = data.OrderCode,
            };

        }
    }
}
