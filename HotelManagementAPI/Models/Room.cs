using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.Models
{
	public class Room
	{
		[Key]
		public string Id { get; set; }

		[Required]
		[StringLength(10)]
		public string RoomNumber { get; set; }

		[Required]
		public int Capacity { get; set; }

		[Required]
		public decimal Price { get; set; }

		public virtual ICollection<Booking> Bookings { get; set; }
	}
}
