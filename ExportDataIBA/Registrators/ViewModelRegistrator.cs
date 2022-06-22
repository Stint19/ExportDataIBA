using ExportData.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ExportData.UI.Registrators
{
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<LoadFileViewModel>()
            .AddSingleton<DataBaseViewModel>()
            .AddSingleton<ExportViewModel>()
        ;
    }
}
