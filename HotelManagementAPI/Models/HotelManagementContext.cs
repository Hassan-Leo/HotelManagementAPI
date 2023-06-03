using Microsoft.EntityFrameworkCore;
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

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<RequestStatus> RequestStatuses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Customer>()
			.Property(c => c.Id)
			.ValueGeneratedOnAdd();

			modelBuilder.Entity<Booking>()
			.Property(c => c.Id)
			.ValueGeneratedOnAdd();

			modelBuilder.Entity<Room>()
			.Property(c => c.Id)
			.ValueGeneratedOnAdd();
		}
	}
}
