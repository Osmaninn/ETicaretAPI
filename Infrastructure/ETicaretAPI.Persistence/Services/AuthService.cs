using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.Dtos;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public AuthService(UserManager<AppUser> userManager, ITokenHandler tokenHandler, SignInManager<AppUser> signInManager)
        {
            _userManager= userManager;
            _tokenHandler= tokenHandler;
            _signInManager = signInManager;
        }
        public async Task<Token> LoginAsync(string usernameOrEmail, string password)
        {
            AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(usernameOrEmail);
            }

            if(user == null)
            {
                throw new NotFoundUserException();
            }
                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result == SignInResult.Success)
            {
                Token token = _tokenHandler.CreateAccessToken();
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddSeconds(15);
                await _userManager.UpdateAsync(user);
                return token;
            }

            throw new NotFoundUserException();

        }
    }
}
