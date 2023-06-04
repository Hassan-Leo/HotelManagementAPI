using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.Models
{
	public class User : IdentityUser
	{
		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string? Address { get; set; }

		public string? PostalCode { get; set; }

		public DateTime? CreatedOn { get; set; }

		public DateTime? UpdatedOn { get; set; }

		public virtual ICollection<Booking> Bookings { get; set; }
	}
}
