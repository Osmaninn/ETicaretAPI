using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IAuthService
    {
        public Task<Application.Dtos.Token> LoginAsync(string usernameOrEmail, string password);
    }
}
