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
			CreateMap<UserRegisterDTO, User>().ReverseMap();
			CreateMap<User, UserDTO>();
			CreateMap<UserDTO, User>();
		}
	}
}
