namespace HotelManagementAPI.DTOs
{
	public class BookingReadDTO
	{
		public string UserId { get; set; }
		public string UserName { get; set; }
		public string RoomNumber { get; set; }
		public string CheckIn { get; set; }
		public string CheckOut { get; set; }
		public bool IsCancelled { get; set; }
		public bool IsCheckedOut { get; set; }
		public string RequestStatus { get; set; }	
		public int RequestStatusId { get; set; }
	}
}
