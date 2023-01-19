using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Features.Commands.Product.CreateProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetAllProducts;
using ETicaretAPI.Application.Features.Queries.Product.GetProductById;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Unicode;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ProductsController : ControllerBase
    {

        private IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductsRequest request)
        {
            GetAllProductsResponse result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetProductByIdRequest request)
        {
            GetProductByIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}
