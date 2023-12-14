using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DAL;

public static class Extensions
{
    private static string OptionsSectionName = "Postgres";
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PostgresOptions>(configuration.GetRequiredSection(OptionsSectionName));
        var postgresOptions = configuration.GetOptions<PostgresOptions>(OptionsSectionName);
        services.AddDbContext<ComContext>(opt =>
        {
            opt.UseNpgsql(postgresOptions.ConnectionString);
        });
        return services;
    }
    
    
    

}