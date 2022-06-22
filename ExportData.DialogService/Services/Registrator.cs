using ExportData.Data.Models;
using ExportData.DialogService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ExportData.DialogService.Services
{
    public static class Registrator
    {
        public static IServiceCollection AddDialogServices(this IServiceCollection services) => services
            .AddSingleton<IDialogService, DialogService>()
            .AddSingleton<IFileService<Person>, FileService<Person>>()
        ;
    }
}
