using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HotelManagementAPI.Common;

namespace HotelManagementAPI.DTOs
{
	public class BookingUpdateDTO
	{
		public string Id { get; set; }
		[Required]
		public string UserId { get; set; }

		[Required]
		public string RoomId { get; set; }

		[Required]
		public string CheckIn { get; set; }

		[Required]
		public string CheckOut { get; set; }

		public bool IsCancelled { get; set; } = false;
		public bool IsCheckedOut { get; set; } = false;
		[Required]
		public int RequestStatusId { get; set; } = (int)enRequestStatus.Pending;
		public string RequestOn { get; set; }
		public string ApprovalOn { get; set; }
		public string RejectedOn { get; set; }
	}
}
