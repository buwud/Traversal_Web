using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}