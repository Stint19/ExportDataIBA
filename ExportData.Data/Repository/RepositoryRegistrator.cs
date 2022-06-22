using ExportData.Data.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ExportData.Data.Repository
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesDB(this IServiceCollection services) => services
            .AddTransient<IRepository<Person>, DbRepository<Person>>()
        ;
    }
}
