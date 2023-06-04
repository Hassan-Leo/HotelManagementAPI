using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.DTOs
{
	public class UserRegisterDTO
	{

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

		[Required(ErrorMessage = "UserName is Required")]
		[MaxLength(50, ErrorMessage = "UserName exceed the defined Length")]
		public string? UserName { get; set; }

		[Required(ErrorMessage = "Password is Required")]
		[MaxLength(20, ErrorMessage = "Password Exceeds the defined Length")]
		public string Password { get; set; }

		[Compare("Password", ErrorMessage = "The Password and confirm password do not match")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "FirstName is Required")]
		[MaxLength(15, ErrorMessage = "Phone Number exceed the defined Length")]
		public string? PhoneNumber { get; set; }

		public string? Address { get; set; }

		[Required]
		public int RoleId { get; set; }
	}
}
