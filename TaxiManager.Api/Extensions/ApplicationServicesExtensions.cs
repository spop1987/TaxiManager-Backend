using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaxiManager.Api.Policies.Handlers;
using TaxiManager.Api.Policies.Requirements;
using TaxiManagerInfrastructure;
using TaxiManagerInfrastructure.Interfaces;
using TaxiManagerInfrastructure.Specifications;
using TaxiManagerService;
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
            services.AddSingleton<IAuthorizationHandler, ValidDriverLicenseHandler>();

            services.AddAuthentication(
                JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => 
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configurations.JwtSecret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                        ClockSkew = TimeSpan.Zero
                    };
                }
            );

            services.AddAuthorizationBuilder()
                .AddPolicy("AllowedToDrive", policy => 
                    policy.Requirements.Add(new ValidDriverLicenseRequirement(DateTime.UtcNow)));

            return services;
        }
    }
}