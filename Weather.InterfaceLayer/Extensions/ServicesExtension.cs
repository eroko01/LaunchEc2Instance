using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Ec2.InterfaceLayer.Mapping;

namespace Ec2.InterfaceLayer.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddInterfaceServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            return services;
        }
    }
}
