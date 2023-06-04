using AutoMapper;
using HotelManagementAPI.DTOs;
using HotelManagementAPI.Models;
using HotelManagementAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _userRepo;
		private readonly IMapper _mapper;

		public UserController(IUserRepository userRepo, IMapper mapper)
		{
			_userRepo = userRepo;
			_mapper = mapper;
		}

		[HttpGet("GetRoles")]
		public async Task<IActionResult> GetAllRoles()
		{
			return Ok(_userRepo.GetRoles());
		}

		[HttpGet, Authorize]
		public async Task<ActionResult<List<UserReadDTO>>> GetUsers()
		{
			try
			{
				var list = await _userRepo.GetAllAsync();
				if (list != null)
				{
					List<UserReadDTO> readList = new List<UserReadDTO>();
					foreach (User item in list)
					{
						readList.Add(_mapper.Map<UserReadDTO>(item));
					}
					return Ok(readList);
				}
				else
				{
					return NotFound(new {message = "No User availale for Display"});
				}
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(500, "An error occurred while retrieving customers.");
			}
		}

		[HttpGet("{id}"), Authorize]
		public async Task<ActionResult<UserReadDTO>> GetUser(string id)
		{
			try
			{
				var user = _mapper.Map<UserReadDTO>(await _userRepo.GetByIdAsync(id));
				if (user == null)
					return NotFound();

				return Ok(user);
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(500, "An error occurred while retrieving the customer.");
			}
		}

		[HttpPost("Registration")]
		public async Task<IActionResult> CreateUser([FromBody] UserRegisterDTO dto)
		{
			try
			{
				if (dto == null || !ModelState.IsValid)
				{
					return BadRequest(new { message = "Invalid data for the user creation" });
				}

				ResponseDTO result = null;
				if (ModelState.IsValid)
				{
					User user = _mapper.Map<User>(dto);
					result = await _userRepo.CreateUserAsync(dto.Password, dto.RoleId, user);
					if (result.IsSucessful)
					{
						return StatusCode(201);
					}
					else
					{
						return BadRequest(result);
					}
				}
				else
				{
					return BadRequest(new { message = "Invalid data for the user creation" });
				}
				
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(500, "An error occurred while creating the customer.");
			}
		}

		[HttpPut("{id}"), Authorize]
		public async Task<IActionResult> UpdateUser(string id, UserUpdateDTO dto)
		{
			try
			{
				if (string.IsNullOrEmpty(id) || dto == null)
				{
					return BadRequest();
				}
				if (id != dto.Id)
					return BadRequest();
				User user = await _userRepo.GetByIdAsync(id);
				if (user != null)
				{
					user = _mapper.Map<User>(dto);
					ResponseDTO result = await _userRepo.UpdateUserAsync(user);
					if (result.IsSucessful)
					{
						return Ok();
					}
					else
					{
						return BadRequest(result);
					}
				}
				return NotFound(new { message = "No user exist in the database" });
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(500, "An error occurred while updating the customer.");
			}
		}

		[HttpDelete("{id}"), Authorize]
		public async Task<IActionResult> DeleteUser(string id)
		{
			try
			{
				await _userRepo.DeleteAsync(await _userRepo.GetByIdAsync(id));
				return Ok();
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(500, "An error occurred while deleting the customer.");
			}
		}

		[HttpGet("GetAllBookingRequest"), Authorize]
		public async Task<ActionResult> GetAllBookingRequest(string id)
		{
			try
			{
				var data = await _userRepo.GetAllBookingRequest(id);
				if (data != null)
				{
					return Ok(data);
				}
				return NotFound();
			}
			catch
			{
				return StatusCode(500, "Error occurred while getting user booking request");
			}
		}
	}

}
