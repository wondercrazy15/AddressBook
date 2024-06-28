using AutoMapper;
using ContactBook.DBL.Models;
using ContactBook.Services.Models;

namespace ContactBook.Services.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Contacts, ContactsModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (src.Id)))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => (src.FirstName)))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => (src.LastName)))
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => (src.ProfileImage)))
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => (src.Company)))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => (src.Phone)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => (src.Email)))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => (src.Address)))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => (src.Latitude)))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => (src.Longitude)))
                .ForMember(dest => dest.birthdate, opt => opt.MapFrom(src => (src.birthdate)))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => (
                src.ProfileImage != null ?
                Convert.ToBase64String(src.ProfileImage)
                : null
                )))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => (src.Note)));

            CreateMap<ContactsModel, Contacts>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (src.Id)))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => (src.FirstName)))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => (src.LastName)))
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => (src.ProfileImage)))
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => (src.Company)))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => (src.Phone).ToString()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => (src.Email)))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => (src.Address).ToString()))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => (src.Latitude)))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => (src.Longitude)))
                .ForMember(dest => dest.birthdate, opt => opt.MapFrom(src => (src.birthdate)))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => (src.Note)));
        }
    }
}
