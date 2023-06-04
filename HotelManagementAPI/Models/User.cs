﻿using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.Models
{
	public class User 
	{
		[Key]
		public string Id { get; set; }

		[Required]
		[StringLength(50)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(50)]
		public string LastName { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string? Password { get; set; }

		[Required]
		public int RoleId { get; set; }

		[Required]
		public string PhoneNumber { get; set; }

		[Required]
		[StringLength(100)]
		public string Street { get; set; }

		[Required]
		[StringLength(50)]
		public string City { get; set; }

		[Required]
		[StringLength(50)]
		public string State { get; set; }

		[Required]
		[StringLength(10)]
		public string PostalCode { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime UpdatedOn { get; set; }

		public virtual ICollection<Booking> Bookings { get; set; }


	}
}
