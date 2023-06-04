using HotelManagementAPI.Common;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.DTOs
{
	public class BookingCreateDTO
	{
		[Required]
		public string UserId { get; set; }

		[Required]
		public string RoomId { get; set; }

		[Required]
		public string CheckIn { get; set; }

		[Required]
		public string? CheckOut { get; set; }

		public bool IsCancelled { get; set; } = false;
		public bool IsCheckedOut { get; set; } = false;
		[Required]
		public int RequestStatusId { get; set; } = (int)enRequestStatus.Pending;
		public string? RequestOn { get; set; }
	}
}
