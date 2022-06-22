using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExportData.Data.Models;
using System.Collections.Generic;
using ExportData.DialogService.Interfaces;
using System.Threading.Tasks;
using ExportData.Data.Repository;

namespace ExportData.UI.ViewModels
{
    internal partial class LoadFileViewModel : ObservableObject
    {
        private readonly IDialogService _dialogService;
        private readonly IFileService<Person> _fileService;
        private readonly IRepository<Person> _repository;

        [ObservableProperty]
        private List<Person> persons = new List<Person>();
        [ObservableProperty]
        private string buttonImportText = Properties.Resource.LoadToDb;
        [ObservableProperty]
        private string buttonLoadText = Properties.Resource.LoadFileMenu;
        [ObservableProperty]
        private bool isEnableButtons = true;
        [ObservableProperty]
        private bool isEnableProgress;
        public LoadFileViewModel(IDialogService dialog, IFileService<Person> fileService, IRepository<Person> repo)
        {
            _dialogService = dialog;
            _fileService = fileService;
            _repository = repo;
        }

        [ICommand]
        async Task Open()
        {
            try
            {
                IsEnableButtons = false;
                if (await Task.Run(() => _dialogService.OpenFileDialog()))
                {
                    IsEnableProgress = true;
                    ButtonLoadText = Properties.Resource.Loading;
                    Persons = await _fileService.ReadAsync(_dialogService.FilePath);
                    IsEnableProgress = false;
                    IsEnableButtons = true;
                    ButtonLoadText = Properties.Resource.LoadFileMenu;
                    _dialogService.ShowMessage(Properties.Resource.SuccessOpen);
                }

            }
            catch (System.Exception)
            {
                IsEnableButtons = true;
                _dialogService.ShowMessage(Properties.Resource.FileOpenError);
            }
        }
        [ICommand]
        async Task ImportToDB()
        {
            if (Persons.Count != 0)
            {
                IsEnableProgress = true;
                ButtonImportText = Properties.Resource.Loading;
                await _repository.AddAsync(persons);
                ButtonImportText = Properties.Resource.LoadToDb;
                IsEnableProgress = false;
                _dialogService.ShowMessage(Properties.Resource.SuccessAddingDB);
            }
            else
            {
                _dialogService.ShowMessage(Properties.Resource.ErrorAddingDB);
            }
        }
    }
}
