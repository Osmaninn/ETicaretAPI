﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.User.CreateUser
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Username{ get; set; }

        public string Email{ get; set; }

        public string Password { get; set; }

        public string PasswordConfirm{ get; set; }
    }
}
