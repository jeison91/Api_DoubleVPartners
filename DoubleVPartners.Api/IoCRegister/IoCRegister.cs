using DoubleVPartners.Application.Services;
using DoubleVPartners.Application.Services.Interfaces;
using DoubleVPartners.Domain.IRepository;
using DoubleVPartners.Domain.IServices;
using DoubleVPartners.Domain.UseCase;
using DoubleVPartners.Infrastructure;
using DoubleVPartners.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace DoubleVPartners.Api.IoCRegister
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services, string conectionString = "")
        {
            AddRegisterDBContext(services, conectionString);
            AddRegisterRepositories(services);
            AddRegisterServices(services);
            return services;
        }

        private static void AddRegisterDBContext(this IServiceCollection services, string conectionString)
        {
            services.AddDbContext<PartnersDbContext>(cfg =>
            {
                cfg.UseSqlServer(conectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IPersonaServicesAdapter, PersonaServicesAdapter>();
            services.AddTransient<IPersonaServicesPort, PersonaUseCase>();

            services.AddTransient<IUsuarioServicesAdapter, UsuarioServicesAdapter>();
            services.AddTransient<IUsuarioServicesPort, UsuarioUseCase>();

            services.AddTransient<ITipoIdentificacionServicesAdapter, TipoIdentificacionServicesAdapter>();
            services.AddTransient<ITipoIdentificacionServicesPort, TipoIdentificacionUseCase>();

            return services;
        }

        private static void AddRegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITipoIdentificacionRepository, TipoIdentificacionRepository>();
        }
    }
}
