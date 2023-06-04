using AutoMapper;
using HotelManagementAPI.Models;

namespace HotelManagementAPI.DTOs
{
	public class MapperProfile : Profile
	{
		public MapperProfile() 
		{
			CreateMap<BookingDTO, Booking>();
			CreateMap<Booking, BookingDTO>();
			CreateMap<CustomerDTO, Customer>();
			CreateMap<Customer, CustomerDTO>();
			CreateMap<User, UserDTO>();
			CreateMap<UserDTO, User>();
		}
	}
}
