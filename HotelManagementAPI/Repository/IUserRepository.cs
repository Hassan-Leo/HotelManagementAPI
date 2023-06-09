﻿using HotelManagementAPI.Models;
using HotelManagementAPI.DTOs;
using Microsoft.AspNetCore.Identity;

namespace HotelManagementAPI.Repository
{
	public interface IUserRepository : IGenericRepository<User>
	{
		List<IdentityRole> GetRoles();

		Task<IEnumerable<Booking>> GetAllBookingRequest(string customerId);

		Task<ResponseDTO> CreateUserAsync(string password, int roleId, User user);

		Task<ResponseDTO> UpdateUserAsync(User user);

		Task<bool> CheckPasswordAsync(User user, string password);

		Task<string> GetUserRoleAsync(User user);

		Task<User> GetUserByEmailAsync(string email);
	}
}
