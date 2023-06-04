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


	}
}
