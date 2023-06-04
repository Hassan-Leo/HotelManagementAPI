using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.DTOs
{
	public class UserDTO
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }

		[Required(ErrorMessage = "Email is Required")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Password is Required")]
		public string? Password { get; set; }

		[Required(ErrorMessage = "Password and Confirm Password do not match")]
		public string? ConfirmPassword { get; set; }
	}
}
