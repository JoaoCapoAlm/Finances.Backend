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
        private SignInManager<User> _signInManaer;
        private TokenService _tokenService;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManaer, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManaer = signInManaer;
            _tokenService = tokenService;
        }

        private enum UserRoles
        {
            User = 1,
            Admin = 2
        }

        public async Task CreateUser(NewUserDto dto)
        {
            User user = _mapper.Map<User>(dto);

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, UserRoles.User.ToString());
                if (result.Succeeded)
                    return;
                await _userManager.DeleteAsync(user);
            }

            string errorMessage = string.Empty;
            foreach (var e in result.Errors)
            {
                errorMessage += $"{e.Description}\n";
            }
            throw new ArgumentException(errorMessage.Trim());
        }

        public async Task<string> Login(LoginDto dto)
        {
            var result = await _signInManaer.PasswordSignInAsync(dto.Username, dto.Password, false, false);
            if (!result.Succeeded)
                throw new ApplicationException("Usuário e/ou senha incorretos!");

            var user = _signInManaer
                .UserManager
                .Users
                .Where(u => u.NormalizedUserName == dto.Username.ToUpper())
                .FirstOrDefault() ?? throw new Exception("Usuário não encontrado!");

            var token = _tokenService.GenerateToken(user);
            return token;
        }
    }
}
