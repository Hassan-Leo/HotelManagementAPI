using AutoMapper;
using HotelManagementAPI.DTOs;
using HotelManagementAPI.Models;
using HotelManagementAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelManagementAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : Controller
	{
		private readonly HotelBookingManagementContext _context;
		private readonly IUserRepository _userRepo;
		private readonly IMapper _mapper;

        public AuthController(HotelBookingManagementContext context, IUserRepository userRepo, IMapper mapper)
        {
			_context = context;
			_userRepo = userRepo;
			_mapper = mapper;
        }

        [HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginModel model)
		{
			try
			{
				if (model is null)
				{
					return BadRequest("Invalid client request");
				}
				User user = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
				if (user != null && !string.IsNullOrEmpty(model.Password))
				{
					if (await _userRepo.CheckPasswordAsync(user, model.Password))
					{
						UserReadDTO readDTO = _mapper.Map<UserReadDTO>(user);
						readDTO.Role = await _userRepo.GetUserRoleAsync(user);
						return Ok(readDTO);
					}
					else
					{
						return Unauthorized(new { message = "Invalid Password" });
					}
				}
				return Unauthorized(new {message= "Invalid, no user found for the provided credentials"});
			}
			catch(Exception ex)
			{
				return StatusCode(500, "Error occurred during the authentication process");
			}
		}
	}
}
