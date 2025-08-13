using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using LondonStock.Application.DTOs.Auth;
using LondonStock.Application.Interfaces;
using LondonStock.Application.Interfaces.Repositories;
using LondonStock.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace LondonStock.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly ILoginTokenRepository _tokenRepo;
        private readonly IConfiguration _config;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            IUserRepository userRepo,
            ILoginTokenRepository tokenRepo,
            IConfiguration config,
            ILogger<AuthService> logger)
        {
            _userRepo = userRepo;
            _tokenRepo = tokenRepo;
            _config = config;
            _logger = logger;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepo.GetByUsernameAsync(request.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                _logger.LogWarning("Failed login attempt for username: {Username}", request.Username);
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            _logger.LogInformation("User {Username} logged in successfully", request.Username);

            var accessToken = GenerateJwtToken(user);

            var refreshToken = Guid.NewGuid().ToString();
            var refreshHash = BCrypt.Net.BCrypt.HashPassword(refreshToken);

            var tokenEntity = new LoginToken
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                TokenHash = refreshHash,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            };

            await _tokenRepo.AddAsync(tokenEntity);

            return new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddMinutes(30)
            };
        }

        public async Task<LoginResponseDto> RefreshTokenAsync(string refreshToken)
        {
            var tokenEntity = await _tokenRepo.GetByTokenAsync(refreshToken);
            if (tokenEntity == null || tokenEntity.ExpiresAt < DateTime.UtcNow)
            {
                _logger.LogWarning("Invalid or expired refresh token");
                throw new UnauthorizedAccessException("Invalid or expired refresh token");
            }

            var user = tokenEntity.User;
            var accessToken = GenerateJwtToken(user);

            // Optional: Rotate refresh tokens for better security
            var newRefreshToken = Guid.NewGuid().ToString();
            tokenEntity.TokenHash = BCrypt.Net.BCrypt.HashPassword(newRefreshToken);
            tokenEntity.CreatedAt = DateTime.UtcNow;
            tokenEntity.ExpiresAt = DateTime.UtcNow.AddDays(7);
            await _tokenRepo.UpdateAsync(tokenEntity);

            _logger.LogInformation("Refresh token renewed for user {Username}", user.Username);

            return new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = newRefreshToken,
                ExpiresAt = DateTime.UtcNow.AddMinutes(30)
            };
        }

        public async Task LogoutAsync(string refreshToken)
        {
            var tokenEntity = await _tokenRepo.GetByTokenAsync(refreshToken);
            if (tokenEntity != null)
            {
                await _tokenRepo.RevokeAsync(tokenEntity);
                _logger.LogInformation("User {UserId} logged out", tokenEntity.UserId);
            }
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()) // ✅ Proper role claim
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
