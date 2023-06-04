using HotelManagementAPI.Common;
using HotelManagementAPI.Models;
using static HotelManagementAPI.Common.HelperFunctions;

namespace HotelManagementAPI.Repository
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		public UserRepository(HotelBookingManagementContext context) : base(context)
		{
		}

		public List<Roles> GetRoles()
		{
			return GetAllRoles();
		}
	}
}
