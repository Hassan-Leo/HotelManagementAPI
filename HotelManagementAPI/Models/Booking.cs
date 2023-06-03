using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.Models
{
	public class Booking
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[ForeignKey("Customer")]
		public int CustomerId { get; set; }

		[Required]
		public DateTime CheckIn { get; set; }

		[Required]
		public DateTime CheckOut { get; set; }

		public bool IsCancelled { get; set; }

		public bool IsCheckedOut { get; set; }

		public int RequestStatusId { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime UpdatedOn { get; set; }

		public virtual Customer Customer { get; set; }
		public virtual RequestStatus RequestStatus { get; set; }
		public virtual ICollection<Room> Rooms { get; set; }
	}
}
