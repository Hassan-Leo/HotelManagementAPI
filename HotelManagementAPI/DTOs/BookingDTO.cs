using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.DTOs
{
	public class BookingDTO
	{
		public int Id { get; set; }

		public int CustomerId { get; set; }

		public DateTime CheckIn { get; set; }

		public DateTime CheckOut { get; set; }

		public bool IsCancelled { get; set; }

		public bool IsCheckedOut { get; set; }

		public int RequestStatusId { get; set; }

		public DateTime RequestOn { get; set; }

		public DateTime ApprovalOn { get; set; }

		public DateTime RejectedOn { get; set; }
	}
}
