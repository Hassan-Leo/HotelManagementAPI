using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.DTOs
{
	public class UserUpdateDTO
	{
		public string Id { get; set; }

		[Required(ErrorMessage = "FirstName is Required")]
		[MaxLength(100, ErrorMessage = "First Name exceed the defined Length")]
		public string? FirstName { get; set; }

		[Required(ErrorMessage = "LastName is Required")]
		[MaxLength(100, ErrorMessage = "Last Name exceed the defined Length")]
		public string? LastName { get; set; }

		[Required(ErrorMessage = "FirstName is Required")]
		[MaxLength(150, ErrorMessage = "Email exceed the defined Length")]
		[EmailAddress]
		public string? Email { get; set; }

		[Required(ErrorMessage = "FirstName is Required")]
		[MaxLength(15, ErrorMessage = "Phone Number exceed the defined Length")]
		public string? PhoneNumber { get; set; }

		public string? Street { get; set; }

		public string? City { get; set; }

		public string? State { get; set; }

		public string? PostalCode { get; set; }
	}
}
