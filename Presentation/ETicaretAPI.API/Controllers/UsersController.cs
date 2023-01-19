using Azure.Identity;
using ETicaretAPI.Application.Features.Commands.User.CreateUser;
using ETicaretAPI.Application.Features.Commands.User.LoginUser;
using ETicaretAPI.Application.Features.Commands.User.RefreshTokenLogin;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request) {
            CreateUserResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            LoginUserResponse response = await _mediator.Send(request); 
            return Ok(response);
        }

        [HttpGet("refreshToken")]
        public async Task<IActionResult> RefreshTokenLogin([FromQuery] RefreshTokenLoginRequest request)
        {
            RefreshTokenLoginResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
