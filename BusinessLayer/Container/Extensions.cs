using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Validations.Announcement;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<ICommentService, CommentManager>();
            serviceDescriptors.AddScoped<ICommentDal, EfCommentDal>();

            serviceDescriptors.AddScoped<IDestinationService, DestinationManager>();
            serviceDescriptors.AddScoped<IDestinationDal, EfDestinationDal>();

            serviceDescriptors.AddScoped<IReservationService, ReservationManager>();
            serviceDescriptors.AddScoped<IReservationDal, EfReservationDal>();

            serviceDescriptors.AddScoped<IAppUserService, AppUserManager>();
            serviceDescriptors.AddScoped<IAppUserDal, EfAppUserDal>();

            serviceDescriptors.AddScoped<IGuideService, GuideManager>();
            serviceDescriptors.AddScoped<IGuideDal, EfGuideDal>();

            serviceDescriptors.AddScoped<IContactUsService, ContactUsManager>();
            serviceDescriptors.AddScoped<IContactUsDal, EfContactUsDal>();

            serviceDescriptors.AddScoped<IExcelService, ExcelManager>();

            serviceDescriptors.AddScoped<IAnnouncementService, AnnouncementManager>();
            serviceDescriptors.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
        }
        public static void CustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AnnouncementAddValidatorDTO>, AnnouncementValidator>();
        }
    }
}