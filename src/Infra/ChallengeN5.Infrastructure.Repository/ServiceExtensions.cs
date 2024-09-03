
namespace ChallengeN5.Infrastructure.Repository;
public static class ServiceExtensions
{
    public static IServiceCollection AddServicesInfrastructurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(x => x.UseSqlServer(GetDatabaseConnectionString(configuration)));
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static string GetDatabaseConnectionString(IConfiguration configuration)
    {
        return configuration.GetConnectionString("BDCONSTR")
            ?? throw new ArgumentNullException(nameof(configuration), "La cadena de conexión de Base de Datos no puede ser nula.");
    }
    
}
