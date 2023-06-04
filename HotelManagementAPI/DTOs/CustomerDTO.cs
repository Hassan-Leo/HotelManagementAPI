using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.DTOs
{
	public class CustomerDTO
	{
		public string? Id { get; set; }

		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string? Email { get; set; }

		public string? PhoneNumber { get; set; }

		public string? Street { get; set; }

		public string? City { get; set; }

		public string? State { get; set; }

		public string? PostalCode { get; set; }
	}
}
