using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Repository_Appoinment.Implementations;
using Repository_Appoinment.Interfaces;

namespace Business_Appoinment
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterBusinessDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            return services;
        }
    }
}
