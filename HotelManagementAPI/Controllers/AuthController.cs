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

        public AuthController(HotelBookingManagementContext context, IUserRepository userRepo)
        {
			_context = context;
			_userRepo = userRepo;
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
						var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
						var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
						string role = await _userRepo.GetUserRoleAsync(user);
						var claims = new List<Claim>
						{
							new Claim(ClaimTypes.Name, user.Email),
							new Claim(ClaimTypes.Role, role)
						};

						var tokeOptions = new JwtSecurityToken(
							issuer: "https://localhost:5001",
							audience: "https://localhost:5001",
							claims: claims,
							expires: DateTime.Now.AddMinutes(60),
							signingCredentials: signinCredentials
						);
						var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
						return Ok(new AuthenticatedResponse { Token = tokenString });
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
