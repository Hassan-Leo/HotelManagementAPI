using static HotelManagementAPI.Common.Constants;

namespace HotelManagementAPI.Common
{
	public class HelperFunctions
	{
		public static DateTime GetDateFromString(string dateTime)
		{
			return DateTime.Parse(dateTime);
		}

		public static DateTime GetDateTimeWithOffSet()
		{
			return DateTime.UtcNow.AddHours(DEFAULT_PAKISTAN_OFFSET_DATETIME);
		}
	}
}
