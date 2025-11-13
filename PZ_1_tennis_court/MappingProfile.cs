using AutoMapper;
using PZ_1_tennis_court.Models;
using PZ_1_tennis_court.Models.DTO;

namespace PZ_1_tennis_court
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Court
            CreateMap<Court, CourtDTO>().ReverseMap();
            CreateMap<Court, CreateCourtDTO>().ReverseMap();
            CreateMap<Court, UpdateCourtDTO>().ReverseMap();

            // Booking
            CreateMap<Booking, BookingDTO>()
                .ForMember(dest => dest.Court, opt => opt.MapFrom(src => src.Court))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Pricing, opt => opt.MapFrom(src => src.Pricing))
                .PreserveReferences()
                .MaxDepth(1);
            CreateMap<Booking, CreateBookingDTO>().ReverseMap();
            CreateMap<Booking, UpdateBookingDTO>().ReverseMap();

            // Pricing
            CreateMap<Pricing, PricingDTO>().ReverseMap();
            CreateMap<Pricing, CreatePricingDTO>().ReverseMap();
            CreateMap<Pricing, UpdatePricingDTO>().ReverseMap();

            // Review
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<Review, CreateReviewDTO>().ReverseMap();
            CreateMap<Review, UpdateReviewDTO>().ReverseMap();

            // User
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
                .PreserveReferences()
                .MaxDepth(1);
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
        }
    }
}
