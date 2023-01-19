using ETicaretAPI.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.User.RefreshTokenLogin
{
    public class RefreshTokenLoginResponse
    {
        public Token Token{ get; set; }
    }
}
