using FoodDelivery.Domain.Entities;
using FoodDelivery.Infrastructure.UnitOfWork;
using FoodDelivery.Shared.DTOs;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Infrastructure.Services;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(Guid userId);
    Task<UserDto> UpdateUserAsync(Guid userId, string name, string phoneNumber);
    Task<IEnumerable<AddressDto>> GetUserAddressesAsync(Guid userId);
    Task<AddressDto> AddAddressAsync(Guid userId, AddressDto addressDto);
    Task<AddressDto> UpdateAddressAsync(Guid addressId, AddressDto addressDto);
    Task<bool> DeleteAddressAsync(Guid addressId);
    Task<AddressDto> SetDefaultAddressAsync(Guid userId, Guid addressId);
}

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserService> _logger;

    public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<UserDto> GetUserByIdAsync(Guid userId)
    {
        try
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            return MapToUserDto(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving user: {UserId}", userId);
            throw;
        }
    }

    public async Task<UserDto> UpdateUserAsync(Guid userId, string name, string phoneNumber)
    {
        try
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            user.Update(name, phoneNumber);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("User updated: {UserId}", userId);
            return MapToUserDto(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating user: {UserId}", userId);
            throw;
        }
    }

    public async Task<IEnumerable<AddressDto>> GetUserAddressesAsync(Guid userId)
    {
        try
        {
            var addresses = await _unitOfWork.Addresses.FindAsync(a => a.UserId == userId);
            return addresses.Select(MapToAddressDto).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving addresses for user: {UserId}", userId);
            throw;
        }
    }

    public async Task<AddressDto> AddAddressAsync(Guid userId, AddressDto addressDto)
    {
        try
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            var address = new Address(
                userId,
                addressDto.Label,
                addressDto.Street,
                addressDto.City,
                addressDto.State,
                addressDto.PostalCode,
                addressDto.Country,
                addressDto.Latitude,
                addressDto.Longitude,
                addressDto.IsDefault
            );

            // If this is the default address, remove default from other addresses
            if (addressDto.IsDefault)
            {
                var existingAddresses = await _unitOfWork.Addresses.FindAsync(a => a.UserId == userId && a.IsDefault);
                foreach (var existingAddress in existingAddresses)
                {
                    existingAddress.Update(
                        existingAddress.Label,
                        existingAddress.Street,
                        existingAddress.City,
                        existingAddress.State,
                        existingAddress.PostalCode,
                        existingAddress.Country,
                        existingAddress.Latitude,
                        existingAddress.Longitude,
                        false
                    );
                }
            }

            await _unitOfWork.Addresses.AddAsync(address);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Address added for user: {UserId}", userId);
            return MapToAddressDto(address);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding address for user: {UserId}", userId);
            throw;
        }
    }

    public async Task<AddressDto> UpdateAddressAsync(Guid addressId, AddressDto addressDto)
    {
        try
        {
            var address = await _unitOfWork.Addresses.GetByIdAsync(addressId);
            if (address == null)
                throw new KeyNotFoundException("Address not found");

            address.Update(
                addressDto.Label,
                addressDto.Street,
                addressDto.City,
                addressDto.State,
                addressDto.PostalCode,
                addressDto.Country,
                addressDto.Latitude,
                addressDto.Longitude,
                addressDto.IsDefault
            );

            // If this is the default address, remove default from other addresses
            if (addressDto.IsDefault)
            {
                var existingAddresses = await _unitOfWork.Addresses.FindAsync(
                    a => a.UserId == address.UserId && a.Id != addressId && a.IsDefault
                );
                foreach (var existingAddress in existingAddresses)
                {
                    existingAddress.Update(
                        existingAddress.Label,
                        existingAddress.Street,
                        existingAddress.City,
                        existingAddress.State,
                        existingAddress.PostalCode,
                        existingAddress.Country,
                        existingAddress.Latitude,
                        existingAddress.Longitude,
                        false
                    );
                }
            }

            _unitOfWork.Addresses.Update(address);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Address updated: {AddressId}", addressId);
            return MapToAddressDto(address);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating address: {AddressId}", addressId);
            throw;
        }
    }

    public async Task<bool> DeleteAddressAsync(Guid addressId)
    {
        try
        {
            var address = await _unitOfWork.Addresses.GetByIdAsync(addressId);
            if (address == null)
                throw new KeyNotFoundException("Address not found");

            _unitOfWork.Addresses.Remove(address);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Address deleted: {AddressId}", addressId);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting address: {AddressId}", addressId);
            throw;
        }
    }

    public async Task<AddressDto> SetDefaultAddressAsync(Guid userId, Guid addressId)
    {
        try
        {
            var address = await _unitOfWork.Addresses.GetByIdAsync(addressId);
            if (address == null || address.UserId != userId)
                throw new KeyNotFoundException("Address not found for this user");

            // Remove default from other addresses
            var existingDefault = await _unitOfWork.Addresses.FirstOrDefaultAsync(
                a => a.UserId == userId && a.IsDefault && a.Id != addressId
            );
            if (existingDefault != null)
            {
                existingDefault.Update(
                    existingDefault.Label,
                    existingDefault.Street,
                    existingDefault.City,
                    existingDefault.State,
                    existingDefault.PostalCode,
                    existingDefault.Country,
                    existingDefault.Latitude,
                    existingDefault.Longitude,
                    false
                );
                _unitOfWork.Addresses.Update(existingDefault);
            }

            // Set as default
            address.Update(
                address.Label,
                address.Street,
                address.City,
                address.State,
                address.PostalCode,
                address.Country,
                address.Latitude,
                address.Longitude,
                true
            );
            _unitOfWork.Addresses.Update(address);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Default address set for user: {UserId}", userId);
            return MapToAddressDto(address);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error setting default address for user: {UserId}", userId);
            throw;
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

    private AddressDto MapToAddressDto(Address address)
    {
        return new AddressDto
        {
            Id = address.Id,
            UserId = address.UserId,
            Label = address.Label,
            Street = address.Street,
            City = address.City,
            State = address.State,
            PostalCode = address.PostalCode,
            Country = address.Country,
            Latitude = address.Latitude,
            Longitude = address.Longitude,
            IsDefault = address.IsDefault
        };
    }
}
