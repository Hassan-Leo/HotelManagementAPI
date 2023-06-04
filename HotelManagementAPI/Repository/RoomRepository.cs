using HotelManagementAPI.Common;
using HotelManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementAPI.Repository
{
	public class RoomRepository : GenericRepository<Room>, IRoomRepository
	{
		private readonly HotelBookingManagementContext _context;

		public RoomRepository(HotelBookingManagementContext context) : base(context)
		{
			_context = context;
		}

		public async Task<bool> CheckRoomAvailabilityAsync(string roomId, DateTime checkIn, DateTime checkOut)
		{
			var existingBookings = await _context.Bookings
				.Where(b => b.RoomId == roomId && !(bool)b.IsCancelled && b.RequestStatusId != (int)enRequestStatus.Accepted)
				.ToListAsync();

			bool isAvailable = !existingBookings.Any(b => checkIn < b.CheckOut && checkOut > b.CheckIn);
			return isAvailable;
		}
	}
}
