using AutoMapper;
using HotelManagementAPI.Models;

namespace HotelManagementAPI.DTOs
{
	public class MapperProfile : Profile
	{
		public MapperProfile() 
		{
			CreateMap<BookingUpdateDTO, Booking>().ReverseMap();
			CreateMap<UserRegisterDTO, User>().ReverseMap();
			CreateMap<User, UserReadDTO>();
			CreateMap<UserReadDTO, User>();
			CreateMap<RoomDTO, Room>().ReverseMap();
			CreateMap<Booking, BookingReadDTO>()
				.ForMember(x => x.RoomNumber, opt => opt.MapFrom(x => x.Room.RoomNumber))
				.ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.FirstName + ' ' + x.User.LastName))
				.ForMember(x => x.RequestStatus, opt => opt.MapFrom(x => x.RequestStatus.Name));
			CreateMap<BookingCreateDTO, Booking>().ReverseMap();
		}
	}
}
