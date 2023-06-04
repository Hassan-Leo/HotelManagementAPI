using HotelManagementAPI.Models;
using HotelManagementAPI.Common;

namespace HotelManagementAPI.Repository
{
	public interface IUserRepository : IGenericRepository<User>
	{
		List<Roles> GetRoles();
	}
}
