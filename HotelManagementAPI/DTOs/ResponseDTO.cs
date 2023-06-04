namespace HotelManagementAPI.DTOs
{
	public class ResponseDTO
	{
		public bool IsSucessful { get; set; }
		public IEnumerable<string>? Errors { get; set; }	
	}
}
