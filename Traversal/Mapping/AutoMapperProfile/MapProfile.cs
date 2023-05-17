using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.DestinationDTOs;
using DTOLayer.DTOs.MailDTOs;
using EntityLayer.Concrete;

namespace Traversal.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        protected MapProfile()
        {
            CreateMap<AnnouncementAddDTOs, Announcement>();
            CreateMap<Announcement, AnnouncementAddDTOs>();

            CreateMap<AppUserLoginDTOs, AppUser>();
            CreateMap<AppUser, AppUserLoginDTOs>();

            CreateMap<AppUserRegisterDTOs, AppUser>();
            CreateMap<AppUser, AppUserRegisterDTOs>();

            CreateMap<DestinationAddDTOs,Destination>();
            CreateMap<Destination, DestinationAddDTOs>();
        }
    }
}
