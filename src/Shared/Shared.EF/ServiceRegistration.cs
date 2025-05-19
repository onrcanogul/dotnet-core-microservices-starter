using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.EF.Repositories;
using Shared.EF.Repositories.UnitOfWork;
using Shared.EF.Services;
using Shared.EF.Utils.Mappings;

namespace Shared.EF;

public static class ServiceRegistration
{
    public static IServiceCollection AddEfCoreServices<TContext>(
        this IServiceCollection services,
        Action<DbContextOptionsBuilder> optionsAction)
    where TContext : DbContext
    {
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped(typeof(ICrudService<,,>), typeof(CrudService<,,>));
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        services.AddDbContext<TContext>(optionsAction);
        return services;
    }
}