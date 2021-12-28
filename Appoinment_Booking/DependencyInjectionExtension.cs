using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Business_Appoinment;
namespace Appoinment_Booking
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterAPIDependencies(this IServiceCollection services)
        {
            services.RegisterBusinessDependencies();
            services.AddTransient<IAppointmentBusiness, AppointmentBusiness>();
            return services;
        }
    }
}
