using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Dtos.User;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        private UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponseDTO> CreateUserAsync(CreateUserDTO model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Email= model.Email,
                UserName = model.Username,
                NameSurname = "User"
            }, model.Password);

            CreateUserResponseDTO response = new CreateUserResponseDTO()
            {
                Succeeded = result.Succeeded
            };

            if (result.Succeeded)
                response.Message = "Kullanıcı başarılı bir şekilde oluşturuldu.";
            
            else
                foreach (var error in result.Errors)
                {
                    response.Message = $"{error.Code} - {error.Description}";
                }
            return response;
        }
    }

}
