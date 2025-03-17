using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetShopCore.Interfaces;
using PetShopCore.Services;
using PetShopInfrastructure.Data;
using PetShopInfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCore.Helpers.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            // Respositorios
            services.AddScoped<IMascotaRepository, MascotaRepository>();
            services.AddScoped<ICitaRepository, CitaRepository>();
            services.AddScoped<IServicioRepository, ServicioRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            // Servicios
            services.AddScoped<IMascotaService, MascotaService>();
            services.AddScoped(typeof(IService<>), typeof(BaseService<>));

            return services;
        }
    }
}
