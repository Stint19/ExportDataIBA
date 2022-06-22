using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExportData.Data.Models;
using ExportData.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace ExportData.UI.ViewModels
{
    internal partial class DataBaseViewModel : ObservableObject
    {
        private readonly IRepository<Person> _persons;
        [ObservableProperty]
        private List<Person> persons;
        [ObservableProperty]
        private string buttonLoadingDbText = Properties.Resource.Update;
        [ObservableProperty]
        private bool isEnable = true;
        [ObservableProperty]
        private bool isEnableProgress;
        public DataBaseViewModel(IRepository<Person> persons)
        {
            _persons = persons;
        }

        [ICommand]
        async Task Update()
        {
            try
            {
                IsEnable = false;
                IsEnableProgress = true;
                ButtonLoadingDbText = Properties.Resource.Loading;
                Persons = await _persons.Items.ToListAsync();
                ButtonLoadingDbText = Properties.Resource.Update;
                IsEnableProgress = false;
                IsEnable = true;
                MessageBox.Show("Done");
            }
            catch (System.Exception)
            {
                MessageBox.Show(Properties.Resource.ConnectError);
            }
        }
    }
}
