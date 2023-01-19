using ETicaretAPI.Application.Dtos;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.User.LoginUser
{
    public class LoginUserResponse
    {
        public Token Token{ get; set; }
    }
}
