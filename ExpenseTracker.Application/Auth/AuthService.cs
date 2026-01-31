using ExpenseTracker.Application.Auth.DTO;
using ExpenseTracker.Application.Auth.Models;
using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpenseTracker.Application.Auth
{
    public class AuthService : IAuthService
    {
        // Implementation goes here
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepository, IRoleRepository roleRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _config = config;
        }
        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
                throw new UnauthorizedAccessException();

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new UnauthorizedAccessException();

            var roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();
            var token = GenerateJwt(user, roles);
            return new AuthResponse
            {
                UserId = user.Id,
                Email = user.Email,
                Token = token,
                Roles = roles
            };
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            if (await _userRepository.ExistsAsync(request.Email))
                throw new Exception("User already exists");
            var role = await _roleRepository.GetByNameAsync(request.Role);
            if (role == null)
            {
                throw new Exception ("Role does not exist");
            }

            var user = new User
            {
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                FirstName = request.FirstName,
                LastName = request.LastName,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };
            user.UserRoles.Add(new UserRole
            {
                RoleId = role.Id
            });

            await _userRepository.AddUserAsync(user);

            return new AuthResponse
            {
                UserId = user.Id,
                Email = user.Email,
                Roles = new List<string> { (role.Name) }
            };
        }

        private string GenerateJwt(User user, List<string> roles)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
