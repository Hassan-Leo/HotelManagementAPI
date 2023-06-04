using AutoMapper;
using HotelManagementAPI.DTOs;
using HotelManagementAPI.Models;
using HotelManagementAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RoomsController : Controller
	{
		private readonly IRoomRepository _roomRepo;
		private readonly IMapper _mapper;	

		public RoomsController(IRoomRepository roomRepo, IMapper mapper)
		{
			_roomRepo = roomRepo;
		}

		[HttpGet]
		public async Task<ActionResult<List<Room>>> GetAllRooms()
		{
			return Ok(await _roomRepo.GetAllAsync());
		}

		// POST: RoomController/Create
		[HttpPost]
		public async Task<ActionResult> CreateRoom([FromBody] RoomDTO dto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					Guid guid = Guid.NewGuid();
					Room room = _mapper.Map<Room>(dto);
					room.Id = guid.ToString();
					var result = await _roomRepo.AddAsync(room);
					if (result.IsSucessful)
					{
						return Ok();
					}
					else
					{
						return BadRequest();
					}
				}
				else
				{
					return BadRequest();
				}
			}
			catch
			{
				return StatusCode(500, "Error occurred while creating a room");
			}
		}


	}
}
