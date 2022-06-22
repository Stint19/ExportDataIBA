using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using ExportData.Data;
using ExportData.Data.Repository;

namespace ExportData.UI.Registrators
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config) => services
            .AddDbContext<PersonContext>(opt =>
            {
                var type = config["Type"];
                switch (type)
                {
                    case null: throw new InvalidOperationException("Type of Database isn`t initialize");
                    default: throw new InvalidOperationException($"Invalid type - {type}");
                    case "MSSQL":
                        opt.UseSqlServer(config.GetConnectionString(type));
                        break;
                }
            })
            .AddRepositoriesDB()
        ;
    }
}
