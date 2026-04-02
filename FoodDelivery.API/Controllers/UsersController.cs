using FoodDelivery.Infrastructure.Services;
using FoodDelivery.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FoodDelivery.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserService userService, ILogger<UsersController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    /// <summary>
    /// Get current user profile
    /// </summary>
    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var parsedUserId))
                return Unauthorized("User not found in token");

            var user = await _userService.GetUserByIdAsync(parsedUserId);
            return Ok(user);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("User not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving user profile");
            return StatusCode(500, "An error occurred while retrieving the profile");
        }
    }

    /// <summary>
    /// Update user profile
    /// </summary>
    [HttpPut("profile")]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserRequest request)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var parsedUserId))
                return Unauthorized("User not found in token");

            var updatedUser = await _userService.UpdateUserAsync(parsedUserId, request.Name, request.PhoneNumber);
            return Ok(updatedUser);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("User not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating user profile");
            return StatusCode(500, "An error occurred while updating the profile");
        }
    }

    /// <summary>
    /// Get user's delivery addresses
    /// </summary>
    [HttpGet("addresses")]
    public async Task<IActionResult> GetAddresses()
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var parsedUserId))
                return Unauthorized("User not found in token");

            var addresses = await _userService.GetUserAddressesAsync(parsedUserId);
            return Ok(addresses);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving addresses");
            return StatusCode(500, "An error occurred while retrieving addresses");
        }
    }

    /// <summary>
    /// Add new delivery address
    /// </summary>
    [HttpPost("addresses")]
    public async Task<IActionResult> AddAddress([FromBody] AddressDto addressDto)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var parsedUserId))
                return Unauthorized("User not found in token");

            var newAddress = await _userService.AddAddressAsync(parsedUserId, addressDto);
            return CreatedAtAction(nameof(GetAddresses), newAddress);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("User not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding address");
            return StatusCode(500, "An error occurred while adding the address");
        }
    }

    /// <summary>
    /// Update delivery address
    /// </summary>
    [HttpPut("addresses/{addressId}")]
    public async Task<IActionResult> UpdateAddress(Guid addressId, [FromBody] AddressDto addressDto)
    {
        try
        {
            var updatedAddress = await _userService.UpdateAddressAsync(addressId, addressDto);
            return Ok(updatedAddress);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Address not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating address");
            return StatusCode(500, "An error occurred while updating the address");
        }
    }

    /// <summary>
    /// Delete delivery address
    /// </summary>
    [HttpDelete("addresses/{addressId}")]
    public async Task<IActionResult> DeleteAddress(Guid addressId)
    {
        try
        {
            var result = await _userService.DeleteAddressAsync(addressId);
            return Ok(new { success = result, message = "Address deleted successfully" });
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Address not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting address");
            return StatusCode(500, "An error occurred while deleting the address");
        }
    }

    /// <summary>
    /// Set default delivery address
    /// </summary>
    [HttpPost("addresses/{addressId}/set-default")]
    public async Task<IActionResult> SetDefaultAddress(Guid addressId)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var parsedUserId))
                return Unauthorized("User not found in token");

            var defaultAddress = await _userService.SetDefaultAddressAsync(parsedUserId, addressId);
            return Ok(defaultAddress);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Address not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error setting default address");
            return StatusCode(500, "An error occurred while setting the default address");
        }
    }
}

public class UpdateUserRequest
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}
