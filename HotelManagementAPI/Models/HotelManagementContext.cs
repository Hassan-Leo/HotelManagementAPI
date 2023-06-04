using HotelManagementAPI.Models;
using Microsoft.AspNetCore.Identity;
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
		public HotelBookingManagementContext(DbContextOptions options)
		: base(options)
		{
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new RoleConfiguration());
		}

		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<RequestStatus> RequestStatuses { get; set; }
	}
}


public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
	public void Configure(EntityTypeBuilder<IdentityRole> builder)
	{
		builder.HasData(
		new IdentityRole
		{
			Name = "Customer",
			NormalizedName = "CUSTOMER"
		},
		new IdentityRole
		{
			Name = "Admin",
			NormalizedName = "ADMIN"
		});
	}
}