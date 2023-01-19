using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Dtos.User;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.User.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private IUserService _userService;
        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
           CreateUserResponseDTO response =  await _userService.CreateUserAsync(new()
            {
                Email= request.Email,
                Username= request.Username,
                Password= request.Password,
                PasswordConfirm = request.PasswordConfirm
            });

            return new CreateUserResponse()
            {
                Message = response.Message,
                Succeeded = response.Succeeded
            };
        }
    }
}
