using HotelManagementAPI.Models;

namespace HotelManagementAPI.Repository
{
	public class BookingRepository : GenericRepository<Booking>, IBookingRepository
	{
		private readonly HotelBookingManagementContext _context;

		public BookingRepository(HotelBookingManagementContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<Booking>> GetAllBookingsAsync()
		{
			List<Booking> data = await GetAllAsync();
			foreach(Booking item in data)
			{
				item.User = _context.Users.FirstOrDefault(x => x.Id == item.UserId);
				item.RequestStatus = _context.RequestStatuses.FirstOrDefault(x => x.Id == item.RequestStatusId);
				item.Room = _context.Rooms.FirstOrDefault(x => x.Id == item.RoomId);
			}
			return data;
		}
	}
}
