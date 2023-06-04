using HotelManagementAPI.Common;
using HotelManagementAPI.DTOs;
using HotelManagementAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static HotelManagementAPI.Common.HelperFunctions;

namespace HotelManagementAPI.Repository
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		private readonly HotelBookingManagementContext _context;
		private readonly UserManager<User> _userManager;

		public UserRepository(HotelBookingManagementContext context, UserManager<User> userManager) : base(context)
		{
			_context = context;
			_userManager = userManager;
		}

		public List<IdentityRole> GetRoles()
		{
			return _context.Roles.ToList();
		}

		public async Task<string> GetUserRoleAsync(User user)
		{
			var roles = await _userManager.GetRolesAsync(user);
			return roles.First();
		}

		public async Task<bool> CheckPasswordAsync(User user,string password)
		{
			return await _userManager.CheckPasswordAsync(user, password);
		}

		public async Task<IEnumerable<Booking>> GetAllBookingRequest(string userId)
		{
			return await _context.Bookings.Where(x => x.UserId == userId).ToListAsync();
		}

		public async Task<ResponseDTO> CreateUserAsync(string password, int roleId, User user)
		{
			ResponseDTO response = new ResponseDTO();
			if (user != null)
			{
				user.EmailConfirmed = true;
				var result = await _userManager.CreateAsync(user, password);
				if (result.Succeeded)
				{
					response.IsSucessful = true;
					if (roleId == (int)enUserRoles.Customer)
					{
						await _userManager.AddToRoleAsync(user, enUserRoles.Customer.ToString());
					}
					else
					{
						await _userManager.AddToRoleAsync(user, enUserRoles.Admin.ToString());
					}

					return response;
				}
				else
				{
					response.IsSucessful = false;
					response.Errors = result.Errors.Select(x => x.Description);
					return response;
				}
			}
			else
			{
				response.IsSucessful = false;
				return response;
			}
		}

		public async Task<ResponseDTO> UpdateUserAsync(User user)
		{
			ResponseDTO response = new ResponseDTO();
			if (user != null)
			{
				var result = await _userManager.UpdateAsync(user);
				if (result.Succeeded)
				{
					response.IsSucessful = true;
					return response;
				}
				else
				{
					response.IsSucessful = false;
					response.Errors = result.Errors.Select(x => x.Description);
					return response;
				}
			}
			else
			{
				response.IsSucessful = false;
				return response;
			}
		}

		public Task<User> GetUserByEmailAsync(string email)
		{
			return _userManager.FindByEmailAsync(email);
		}
	}
}
