﻿using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.Models
{
	public class RequestStatus
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }
	}
}
