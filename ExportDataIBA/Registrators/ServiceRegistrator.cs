using ExportData.Data.Models;
using ExportData.DialogService.Services;
using ExportData.Excel.Services;
using ExportData.Xml.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExportData.UI.Registrators
{
    static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddDialogServices()
            .AddSingleton<IXmlExporter<Person>,XmlExporter<Person>>()
            .AddSingleton<IExcelExporter<Person>, ExcelExporter<Person>>()
        ;
    }
}
