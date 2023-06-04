using HotelManagementAPI.Models;

namespace HotelManagementAPI.Repository
{
	public interface ICustomerRepository : IGenericRepository<Customer>
	{
		Task<IEnumerable<Booking>> GetAllBookingRequest(string customerId);
		
	}
}
