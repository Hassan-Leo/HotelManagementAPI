using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.Models
{
	public class Booking
	{
		[Key]
		public string Id { get; set; }

		[Required]
		[ForeignKey("Customer")]
		public string UserId { get; set; }

		[Required]
		public DateTime CheckIn { get; set; }

		[Required]
		public DateTime CheckOut { get; set; }

		public bool IsCancelled { get; set; } = false;

		public bool IsCheckedOut { get; set; } = false;

		public int RequestStatusId { get; set; }

		public DateTime? RequestOn { get; set; }
		
		public DateTime? ApprovalOn { get; set; }

		public DateTime? RejectedOn { get; set; }

		public DateTime? CreatedOn { get; set; }

		public DateTime? UpdatedOn { get; set; }

		public virtual User User { get; set; }
		public virtual RequestStatus RequestStatus { get; set; }
		public virtual ICollection<Room> Rooms { get; set; }
	}
}
