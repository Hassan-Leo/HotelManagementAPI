using HotelManagementAPI.Models;

namespace HotelManagementAPI.Repository
{
	public interface IBookingRepository : IGenericRepository<Booking>
	{
		Task<List<Booking>> GetAllBookingsAsync();
	}
}
