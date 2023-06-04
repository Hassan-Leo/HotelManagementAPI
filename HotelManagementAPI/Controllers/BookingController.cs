using AutoMapper;
using HotelManagementAPI.Common;
using HotelManagementAPI.DTOs;
using HotelManagementAPI.Models;
using HotelManagementAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HotelManagementAPI.Common.HelperFunctions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingRepository _bookingRepo;
		private readonly IMapper _mapper;

        public BookingController(IBookingRepository bookingRepo, IMapper mapper)
        {
			_bookingRepo = bookingRepo;
			_mapper = mapper;
		}

        // GET: api/<ValuesController>
        [HttpGet]
		public async Task<ActionResult<List<BookingReadDTO>>> GetAllAsync()
		{
			try
			{
				var list = await _bookingRepo.GetAllBookingsAsync();
				if (list.Count == 0)
				{
					return NotFound(new { message = "No records found for  Bookings" });
				}
				else
				{
					List<BookingReadDTO> readDTOList = new List<BookingReadDTO>();
					foreach (var booking in list)
					{
						readDTOList.Add(_mapper.Map<BookingReadDTO>(booking));
					}
					return Ok(readDTOList);
				}
			}
			catch
			{
				return StatusCode(500, "An error occurred while retrieving the bookings.");
			}
			
		}

		// GET api/<ValuesController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<ValuesController>
		[HttpPost]
		public async Task<ActionResult> CreateBooking([FromBody] BookingCreateDTO creatDTO)
		{
			try
			{
				if (creatDTO == null || !ModelState.IsValid)
				{
					return BadRequest(new { message = "Invalid data for the Booking creation" });
				}

				ResponseDTO result = null;
				if (ModelState.IsValid)
				{
					Booking booking = _mapper.Map<Booking>(creatDTO);
					booking.RequestOn = GetDateTimeWithOffSet();
					booking.CheckIn = GetDateFromString(creatDTO.CheckIn);
					booking.CheckOut = GetDateFromString(creatDTO.CheckOut);
					result = await _bookingRepo.AddAsync(booking);
					if (result.IsSucessful)
					{
						BookingReadDTO readDTO = _mapper.Map<BookingReadDTO>(booking);
						return Created("", readDTO);
					}
					else
					{
						return BadRequest(result);
					}
				}
				else
				{
					return BadRequest(new { message = "Invalid data for the Booking creation" });
				}
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(500, "An error occurred while creating the customer.");
			}
		}

		// PUT api/<ValuesController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateBooking(string id, [FromBody] BookingUpdateDTO updateDTO)
		{
			try
			{
				if (updateDTO == null || !ModelState.IsValid)
				{
					return BadRequest(new { message = "Invalid data for the Booking creation" });
				}

				if (string.IsNullOrEmpty(id) || id == updateDTO.Id)
				{
					return BadRequest(new { message = "Invalid data for the updation of Booking" });
				}

				ResponseDTO result = null;
				if (ModelState.IsValid)
				{
					Booking booking = _mapper.Map<Booking>(updateDTO);
					booking.CheckOut = GetDateFromString(updateDTO.CheckOut);
					booking.CheckIn = GetDateFromString(updateDTO.CheckIn);
					booking = SetRequestStatusDateTime(booking, updateDTO.RequestStatusId);
					result = await _bookingRepo.UpdateAsync(booking);
					if (result.IsSucessful)
					{
						BookingReadDTO readDTO = _mapper.Map<BookingReadDTO>(booking);
						return NoContent();
					}
					else
					{
						return BadRequest(result);
					}
				}
				else
				{
					return BadRequest(new { message = "Invalid data for the Booking creation" });
				}
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(500, "An error occurred while creating the customer.");
			}
		}

		// DELETE api/<ValuesController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			return NoContent();
		}

		private Booking SetRequestStatusDateTime(Booking booking, int requestStatusId)
		{
			if (requestStatusId == (int)enRequestStatus.Accepted)
			{
				booking.ApprovalOn = GetDateTimeWithOffSet();
			}
			else if (requestStatusId == (int)enRequestStatus.Rejected)
			{
				booking.ApprovalOn = GetDateTimeWithOffSet();
			}
			return booking;
		}
	}
}
