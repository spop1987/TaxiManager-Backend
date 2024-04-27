using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TaxiManagerDomain.Dtos;
using TaxiManagerInfrastructure;
using TaxiManagerInfrastructure.Interfaces;
using TaxiManagerInfrastructure.Specifications;
using TaxiManagerService.Interfaces;
using TaxiManagerService.Services;

namespace TaxiManager.Api.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<TaxiManagerContext>(opts => 
            {
                opts.UseSqlServer(config.GetConnectionString("TaxiManagement"));
            });
            services.AddScoped<IUserSpecification>(_ => new UserSpecification(x => string.IsNullOrEmpty(x.FirstName)));
            services.AddScoped<IVehicleSpecification>(_ => new VehicleSpecification(x => string.IsNullOrEmpty(x.Registration)));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IAutoPartService, AutoPartService>();
            services.AddTransient<IEnrollmentService, EnrollmentService>();
            services.AddScoped(typeof(IQueries<>), typeof(Queries<>));
            services.AddScoped(typeof(ICommands<>), typeof(Commands<>));

            return services;
        }
    }
}