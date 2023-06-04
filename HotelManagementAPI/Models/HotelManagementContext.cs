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
			modelBuilder.ApplyConfiguration(new RoomConfiguration());
			modelBuilder.ApplyConfiguration(new RequestStatusConfiguration());
		}

		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<RequestStatus> RequestStatuses { get; set; }
	}
}


public class RequestStatusConfiguration : IEntityTypeConfiguration<RequestStatus>
{
	public void Configure(EntityTypeBuilder<RequestStatus> builder)
	{
		builder.HasData(
		new RequestStatus
		{
			Id = 1,
			Name = "Pending"
		},
		new RequestStatus
		{
			Id = 2,
			Name = "Accepted"
		},
		new RequestStatus
		{
			Id = 3,
			Name = "Rejected"
		});
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

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
	public void Configure(EntityTypeBuilder<Room> builder)
	{
		builder.HasData(
		new Room
		{
			Id = Guid.NewGuid().ToString(),
			RoomNumber = "101",
			Capacity = 2,
			Price = 150M,
		},
		new Room
		{
			Id = Guid.NewGuid().ToString(),
			RoomNumber = "102",
			Capacity = 2,
			Price = 150M,
		},
		new Room
		{
			Id = Guid.NewGuid().ToString(),
			RoomNumber = "201",
			Capacity = 2,
			Price = 200M,
		},
		new Room
		{
			Id = Guid.NewGuid().ToString(),
			RoomNumber = "202",
			Capacity = 2,
			Price = 250M,
		},
		new Room
		{
			Id = Guid.NewGuid().ToString(),
			RoomNumber = "203",
			Capacity = 2,
			Price = 200M,
		},
		new Room
		{
			Id = Guid.NewGuid().ToString(),
			RoomNumber = "301",
			Capacity = 3,
			Price = 400M,
		},
		new Room
		{
			Id = Guid.NewGuid().ToString(),
			RoomNumber = "302",
			Capacity = 3,
			Price = 400M,
		},
		new Room
		{
			Id = Guid.NewGuid().ToString(),
			RoomNumber = "303",
			Capacity = 3,
			Price = 550M,
		});
	}
}