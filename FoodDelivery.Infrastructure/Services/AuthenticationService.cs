using FoodDelivery.Domain.Entities;
using FoodDelivery.Domain.Enums;
using FoodDelivery.Infrastructure.UnitOfWork;
using FoodDelivery.Shared.DTOs;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Infrastructure.Services;

public interface IAuthenticationService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request);
    Task<AuthResponse> LoginAsync(LoginRequest request);
    Task<AuthResponse> RefreshTokenAsync(string refreshToken, Guid userId);
}

public class AuthenticationService : IAuthenticationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordService _passwordService;
    private readonly ITokenService _tokenService;
    private readonly ILogger<AuthenticationService> _logger;

    public AuthenticationService(
        IUnitOfWork unitOfWork,
        IPasswordService passwordService,
        ITokenService tokenService,
        ILogger<AuthenticationService> logger)
    {
        _unitOfWork = unitOfWork;
        _passwordService = passwordService;
        _tokenService = tokenService;
        _logger = logger;
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return new AuthResponse { Success = false, Message = "Email and password are required" };

            var existingUser = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (existingUser != null)
                return new AuthResponse { Success = false, Message = "User with this email already exists" };

            var passwordHash = _passwordService.HashPassword(request.Password);
            var user = new User(request.Email, request.Name, request.PhoneNumber, passwordHash, UserRole.Customer);

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("User registered: {Email}", user.Email);

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            return new AuthResponse
            {
                Success = true,
                Message = "Registration successful",
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                User = MapToUserDto(user)
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Registration failed for: {Email}", request.Email);
            return new AuthResponse { Success = false, Message = "Registration failed" };
        }
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return new AuthResponse { Success = false, Message = "Email and password are required" };

            var user = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
                return new AuthResponse { Success = false, Message = "Invalid email or password" };

            if (!_passwordService.VerifyPassword(request.Password, user.PasswordHash))
                return new AuthResponse { Success = false, Message = "Invalid email or password" };

            if (!user.IsActive)
                return new AuthResponse { Success = false, Message = "User account is deactivated" };

            _logger.LogInformation("User logged in: {Email}", user.Email);

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            return new AuthResponse
            {
                Success = true,
                Message = "Login successful",
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                User = MapToUserDto(user)
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Login failed for: {Email}", request.Email);
            return new AuthResponse { Success = false, Message = "Login failed" };
        }
    }

    public async Task<AuthResponse> RefreshTokenAsync(string refreshToken, Guid userId)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(refreshToken))
                return new AuthResponse { Success = false, Message = "Refresh token is required" };

            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null || !user.IsActive)
                return new AuthResponse { Success = false, Message = "User not found" };

            var newAccessToken = _tokenService.GenerateAccessToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            return new AuthResponse
            {
                Success = true,
                Message = "Token refreshed",
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                User = MapToUserDto(user)
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Token refresh failed");
            return new AuthResponse { Success = false, Message = "Token refresh failed" };
        }
    }

    private UserDto MapToUserDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            PhoneNumber = user.PhoneNumber,
            Role = user.Role.ToString(),
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt
        };
    }
}
