using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;

public static class StartupSetup
{
    public static void AddDbContext(
        this IServiceCollection services, 
        string connectionString
        ) =>
      services.AddDbContext<AppDbContext>(options =>
          options.UseSqlite(connectionString)); // will be created in web project root
      
    public static IServiceCollection AddInfrastructureService(
        this IServiceCollection services)
    {
        services.AddTransient<IEmailService, SmtpEmailService>();

        return services;
    }
}