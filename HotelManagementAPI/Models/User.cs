using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.Models
{
	public class User : IdentityUser
	{
		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string? Street { get; set; }

		public string? City { get; set; }

		public string? State { get; set; }

		public string? PostalCode { get; set; }

	}
}
