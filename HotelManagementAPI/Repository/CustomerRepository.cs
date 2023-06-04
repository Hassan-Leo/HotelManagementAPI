using HotelManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementAPI.Repository
{
	public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
	{
		readonly HotelBookingManagementContext _context;
		public CustomerRepository(HotelBookingManagementContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Booking>> GetAllBookingRequest(string customerId)
		{
			return await _context.Bookings.Where(x=>x.CustomerId == customerId).ToListAsync();
		}
	}
}
