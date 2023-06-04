namespace HotelManagementAPI.Common
{
	public record Roles(int Id, string Name);
	public class HelperFunctions
	{
		public static List<Roles> GetAllRoles()
		{
			return new()
			{
				new(1, "Customer"),
				new(2, "Admin" )
			};
		}	
	}
}
