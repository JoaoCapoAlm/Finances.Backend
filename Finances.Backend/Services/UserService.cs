using AutoMapper;
using Finances.Backend.Data.Dtos;
using Finances.Backend.Model;
using Microsoft.AspNetCore.Identity;

namespace Finances.Backend.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;

        public UserService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task CreateUser(NewUserDto dto)
        {
            User user = _mapper.Map<User>(dto);

            var result = await _userManager.CreateAsync(user, dto.Password);
            _userManager.AddToRoleAsync(user, "User");

            if (result.Succeeded)
                return;

            string errorMessage = string.Empty;
            foreach (var e in result.Errors)
            {
                errorMessage += $"{e.Description}\n";
            }
            throw new ArgumentException(errorMessage);
        }
    }
}
