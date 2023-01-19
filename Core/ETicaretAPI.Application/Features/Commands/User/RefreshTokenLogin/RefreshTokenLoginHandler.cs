using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.Dtos;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.User.RefreshTokenLogin
{
    public class RefreshTokenLoginHandler : IRequestHandler<RefreshTokenLoginRequest, RefreshTokenLoginResponse>
    {
        private UserManager<AppUser> _userManager;
        private ITokenHandler _tokenHandler;

        public RefreshTokenLoginHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler)
        {
            _userManager= userManager;
            _tokenHandler = tokenHandler;
        }
        public async Task<RefreshTokenLoginResponse> Handle(RefreshTokenLoginRequest request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == request.RefreshToken && u.RefreshTokenExpireDate > DateTime
            .Now); 

            if (user is not null)
            {
                Token token = _tokenHandler.CreateAccessToken();
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddSeconds(15);
                await _userManager.UpdateAsync(user);
                return new RefreshTokenLoginResponse()
                {
                    Token = token,
                };
            }
            throw new NotFoundUserException();
        }
    }
}
