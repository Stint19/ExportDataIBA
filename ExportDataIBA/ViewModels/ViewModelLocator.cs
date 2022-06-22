using ExportDataIBA;
using Microsoft.Extensions.DependencyInjection;

namespace ExportData.UI.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetService<MainWindowViewModel>();
        public DataBaseViewModel DataBaseModel => App.Services.GetService<DataBaseViewModel>();

        public ExportViewModel ExportModel => App.Services.GetService<ExportViewModel>();
        public LoadFileViewModel LoadFileModel => App.Services.GetService<LoadFileViewModel>();
    }
}
