using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExportData.Data.Models;
using ExportData.Data.Repository;
using ExportData.UI.ViewModels;
using ExportDataIBA;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

using System.Windows;

namespace ExportData.UI
{
    public partial class MainWindowViewModel : ObservableObject
    {

        private readonly IRepository<Person> _persons;
        public MainWindowViewModel(IRepository<Person> persons)
        {
            _persons = persons;
        }

        [ObservableProperty]
        private object currentView = App.Services.GetService<LoadFileViewModel>();
        [ObservableProperty]
        internal static int countProgress = 0;
        [ICommand]
        void DataBaseView()
        {
            CurrentView = App.Services.GetService<DataBaseViewModel>();
        }
        [ICommand]
        void ExportView()
        {
            CurrentView = App.Services.GetService<ExportViewModel>();
        }
        [ICommand]
        void LoadFileView()
        {
            CurrentView = App.Services.GetService<LoadFileViewModel>();
        }
        [ICommand]
        void CloseButton()
        {
            MessageBoxResult Result = MessageBox.Show(Properties.Resource.CloseApp, "", MessageBoxButton.YesNo); ;
            if (Result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        } 
    }
}
