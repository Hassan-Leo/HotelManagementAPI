using HotelManagementAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Emit;

namespace HotelManagementAPI.Models
{
	public class HotelBookingManagementContext : DbContext
	{
		public HotelBookingManagementContext(DbContextOptions<HotelBookingManagementContext> options)
		: base(options)
		{
		}

		public HotelBookingManagementContext(DbContextOptions options)
		: base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<RequestStatus> RequestStatuses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
