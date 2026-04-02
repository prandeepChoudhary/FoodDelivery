namespace FoodDelivery.Shared.DTOs;

public class RegisterRequest
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class AuthResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public UserDto User { get; set; }
}

public class RefreshTokenRequest
{
    public string RefreshToken { get; set; }
}
