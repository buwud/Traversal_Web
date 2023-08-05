using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using DTOLayer.DTOs.DestinationDTOs;
using EntityLayer.Concrete;

namespace Traversal.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddValidatorDTO, Announcement>().ReverseMap();

            CreateMap<AppUserLoginDTO, AppUser>().ReverseMap();

            CreateMap<AppUserRegisterDTO, AppUser>().ReverseMap();

            CreateMap<DestinationAddDTO,Destination>().ReverseMap();

            CreateMap<AnnouncementListDTO, Announcement>().ReverseMap();

            CreateMap<AnnouncementUpdateDTO,Announcement>().ReverseMap();

            CreateMap<SendMessageDto, ContactUs>().ReverseMap();

            //DTO ve entity'leri eşleştiriyoruz
  
        }
    }
}
