using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.DTOs
{
	public class BookingDTO
	{
		[Required]
		public string CustomerId { get; set; }

		[Required]
		public string CheckIn { get; set; }

		[Required]
		public string CheckOut { get; set; }

		public bool IsCancelled { get; set; }

		public bool IsCheckedOut { get; set; }
		[Required]
		public int RequestStatusId { get; set; }
		public string RequestOn { get; set; }
		public string ApprovalOn { get; set; }
		public string RejectedOn { get; set; }
	}
}
