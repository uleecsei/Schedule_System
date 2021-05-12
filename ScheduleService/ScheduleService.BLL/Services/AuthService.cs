using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ScheduleService.BLL.Services.Abstractions;
using ScheduleService.Models.ContractModels;
using ScheduleService.Models.CoreModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleService.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthService(IMapper mapper,
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> GenerateToken(DetailedUserDto user, string keyWord)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var roles = await _userManager.GetRolesAsync(_mapper.Map<User>(user));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyWord));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<DetailedUserDto> LogIn(UserForLoginDto user)
        {
            var mainUser = await _userManager.FindByNameAsync(user.Username);
            if (mainUser == null)
            {
                return null;
            }

            var result = await _signInManager
                .CheckPasswordSignInAsync(mainUser, user.Password, false);

            if (result.Succeeded)
            {
                var appUser = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.NormalizedUserName == mainUser.UserName.ToUpper());

                return _mapper.Map<DetailedUserDto>(appUser);
            }

            return null;
        }

        public async Task<DetailedUserDto> Register(UserForRegisterDto user)
        {
            var userToCreate = _mapper.Map<User>(user);

            var result = await _userManager.CreateAsync(userToCreate, user.Password);

            if (result.Succeeded)
            {
                var userToReturn = _mapper.Map<DetailedUserDto>(userToCreate);
                var usertoAddRole = _userManager.FindByNameAsync(userToReturn.Username).Result;
                _userManager.AddToRolesAsync(usertoAddRole, new[] { "Student" }).Wait();
                return userToReturn;
            }
            return null;
        }
    }
}
