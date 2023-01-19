using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.User.LoginUser
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string UsernameOrEmail{ get; set; }

        public string Password{ get; set; }

    }
}
