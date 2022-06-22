using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExportData.Data.Models;
using ExportData.Data.Repository;
using ExportData.DialogService.Interfaces;
using ExportData.Excel.Services;
using ExportData.UI.Services;
using ExportData.Xml.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace ExportData.UI.ViewModels
{
    internal partial class ExportViewModel : ObservableObject
    {
        private readonly IExcelExporter<Person> _excelExporter;
        private readonly IXmlExporter<Person> _xmlExporter;
        private readonly IDialogService _dialogService;
        private readonly IRepository<Person> _persons;
        public ExportViewModel(
            IExcelExporter<Person> excelExporter,
            IXmlExporter<Person> xmlExporter,
            IDialogService dialogService,
            IRepository<Person> persons)
        {
            _xmlExporter = xmlExporter;
            _excelExporter = excelExporter;
            _dialogService = dialogService;
            _persons = persons;
        }
        #region Properties
        [ObservableProperty]
        private List<Person> persons = new List<Person>();
        [ObservableProperty]
        private string buttonLoadingDbText = Properties.Resource.Update;
        [ObservableProperty]
        private string? criterionValue = null;
        [ObservableProperty]
        private string? criterionName = null;
        [ObservableProperty]
        private bool isEnableProgress;
        [ObservableProperty]
        private bool isDbLoad;
        [ObservableProperty]
        private bool dbButton = true;
        #endregion
        [ICommand]
        async Task AddCriterion()
        {
            if (criterionValue == null || CriterionValue == null)
            {
                MessageBox.Show(Properties.Resource.EmptyCriterion);
            }
            else
            {
                try
                {
                    IsEnableProgress = true;
                    IsDbLoad = false;
                    DbButton = false;
                    Persons = await Task.Run(() => LinqCreateService.EnterQuery(persons, criterionName, criterionValue));
                    DbButton = true;
                    IsDbLoad = true;
                    IsEnableProgress = false;
                    MessageBox.Show(Properties.Resource.SuccessAddingCriterion);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Properties.Resource.FilterError);
                }

            }
        }
        [ICommand]
        async Task Update()
        {
            try
            {
                IsEnableProgress = true;
                ButtonLoadingDbText = Properties.Resource.Loading;
                Persons = await _persons.Items.ToListAsync();
                ButtonLoadingDbText = Properties.Resource.Update;
                IsDbLoad = true;
                IsEnableProgress = false;
                MessageBox.Show("Done");
            }
            catch (System.Exception)
            {
                MessageBox.Show(Properties.Resource.ConnectError);
            }
        }
        [ICommand]
        async Task ExportExcel()
        {
            DbButton = false;
            IsDbLoad = false;
            if (await Task.Run(() => _dialogService.SaveFileDialog("Excel files(*.xlsx)|*.xlsx")))
            {
                IsEnableProgress = true;
                await _excelExporter.ExportAsync(persons, _dialogService.FilePath);
                IsEnableProgress = false;
            }
            DbButton = true;
            IsDbLoad = true;
        }
        [ICommand]
        async Task ExportXml()
        {
            IsDbLoad = false;
            DbButton = false;
            if (await Task.Run(() => _dialogService.SaveFileDialog("Xml files(*.xml)|*.xml")))
            {
                IsEnableProgress = true;
                await _xmlExporter.ExportAsync(persons, _dialogService.FilePath);
                IsEnableProgress = false;
            }
            IsDbLoad = true;
            DbButton = true;
        }
    }
}
