using Directo.Wari.Application.Common.Interfaces;
using Directo.Wari.Application.Features.SPParametrosLista.Interfaces;
using Directo.Wari.Domain.Interfaces;
using Directo.Wari.Infrastructure.Caching;
using Directo.Wari.Infrastructure.Persistence;
using Directo.Wari.Infrastructure.Persistence.Interceptors;
using Directo.Wari.Infrastructure.Persistence.Repositories;
using Directo.Wari.Infrastructure.Services;
using Directo.Wari.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Directo.Wari.Infrastructure
{
    /// <summary>
    /// Extensión para registrar los servicios de infraestructura en el contenedor DI.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Interceptors
            services.AddSingleton<AuditableEntityInterceptor>();

            // PostgreSQL + EF Core
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                var interceptor = sp.GetRequiredService<AuditableEntityInterceptor>();

                options.UseNpgsql(
                        configuration.GetConnectionString("Postgres"),
                        npgsqlOptions =>
                        {
                            npgsqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                            npgsqlOptions.EnableRetryOnFailure(
                                maxRetryCount: 3,
                                maxRetryDelay: TimeSpan.FromSeconds(30),
                                errorCodesToAdd: null);
                        })
                    .AddInterceptors(interceptor);
            });

            

            // Registrar DbContext interfaces
            services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IReadDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<SqlServerSPRepository>();

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ISqlServerRepository, SqlServerSPRepository>();


            // Redis Cache
            var redisConnectionString = configuration.GetValue<string>("Redis:ConnectionString");
            if (!string.IsNullOrEmpty(redisConnectionString))
            {
                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = redisConnectionString;
                    options.InstanceName = "WariDirecto:";
                });
                services.AddScoped<ICacheService, RedisCacheService>();
            }

            // Services
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();

            return services;
        }
    }

}
