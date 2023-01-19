using ETicaretAPI.Application.Features.Commands.Order.CreateOrder;
using ETicaretAPI.Application.Features.Queries.Order.GetAllOrders;
using ETicaretAPI.Application.Features.Queries.Order.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpGet("{OrderId}")]
        public async Task<IActionResult> GetOrderById([FromRoute]GetOrderByIdRequest request)
        {
            GetOrderByIdResponse response = await _mediator.Send(request);
            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllOrdersRequest request)
        {
            List<GetAllOrdersResponse> response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            CreateOrderResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
