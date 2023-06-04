using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.DTOs
{
	public class RoomDTO
	{
		[Required]
		[MaxLength(10, ErrorMessage = "RoomNumber is Required")]
		public string RoomNumber { get; set; }

		[Required(ErrorMessage = "Capacity is required")]
		public int Capacity { get; set; }

		[Required(ErrorMessage = "Price is Required")]
		public decimal Price { get; set; }
	}
}
