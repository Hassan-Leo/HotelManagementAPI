using HotelManagementAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Emit;

namespace HotelManagementAPI.Models
{
	public class HotelBookingManagementContext : IdentityDbContext<User>
	{
		public HotelBookingManagementContext(DbContextOptions<HotelBookingManagementContext> options)
		: base(options)
		{
		}

		public HotelBookingManagementContext(DbContextOptions options)
		: base(options)
		{
		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<RequestStatus> RequestStatuses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>()
			.Property(c => c.Id)
			.ValueGeneratedOnAdd();

			modelBuilder.Entity<Booking>()
			.Property(c => c.Id)
			.ValueGeneratedOnAdd();

			modelBuilder.Entity<Room>()
			.Property(c => c.Id)
			.ValueGeneratedOnAdd();

			base.OnModelCreating(modelBuilder);

		}
	}
}

public class ApplicationNewUserEntityConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.Property(x => x.FirstName).HasMaxLength(256);
		builder.Property(x => x.LastName).HasMaxLength(256);
		builder.Property(x=>x.Street).HasMaxLength(50);
		builder.Property(x => x.PostalCode).HasMaxLength(10);
		builder.Property(x => x.City).HasMaxLength(50);
		builder.Property(x => x.State).HasMaxLength(50);
	}
}