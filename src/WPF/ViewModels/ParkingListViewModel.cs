using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using ParkingRegistry.ApplicationCore.Entities;
using ParkingRegistry.ApplicationCore.Interfaces;
using ParkingRegistry.Infrastructure.WPF.Commands;
using ParkingRegistry.Infrastructure.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace ParkingRegistry.WPF.ViewModels
{
    public class ParkingListViewModel : ViewModelBase
    {
        private readonly ISnackbarMessageQueue messageQueue;
        private readonly IRepository<Parking> parkingRepository;

        public ParkingListViewModel(
            IEnumerable<IExporter> exporters,
            ISnackbarMessageQueue messageQueue,
            IRepository<Parking> parkingRepository)
        {
            Exporters = exporters;
            this.messageQueue = messageQueue;
            this.parkingRepository = parkingRepository;
            ExportCommand = new DelegateCommand(ex => Export(), can => CanExport);
            ListCommand = new DelegateCommand(ex => List(), can => this.CanList);
            _endDate = DateTime.Today;
            _selectedExporter = Exporters.First();
        }
        public DelegateCommand ExportCommand { get; }
        public DelegateCommand ListCommand { get; }

        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get => _startDate;
            set
            {
                if (_startDate == value) return;
                _startDate = value;
                OnPropertyChanged();
            }
        }
        private DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (_endDate == value) return;
                _endDate = value;
                OnPropertyChanged();
            }
        }
        private string? _search;
        public string? Search
        {
            get => _search;
            set
            {
                if (_search == value) return;
                _search = value;
                OnPropertyChanged();
                ListCommand.InvokeCanExecuteChanged();
            }
        }

        private IExporter _selectedExporter;
        public IExporter SelectedExporter
        {
            get => _selectedExporter;
            set
            {
                if (_selectedExporter == value) return;
                _selectedExporter = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<object>? ParkingItems { get; set; }
        public IEnumerable<IExporter> Exporters { get; }

        public void List()
        {
            if (Search!.Length == 7)
            {
                var list = parkingRepository
                           .GetQuery()
                           .Where(p => p.Car.NumberPlate == Search
                                       && (StartDate == null || p.StartDate >= StartDate) && (p.EndDate != null && p.EndDate <= EndDate || p.StartDate <= EndDate))
                           .Select(p =>
                             new ParkingItemViewModel
                             {
                                 Id = p.Car.Id,
                                 NumberPlate = p.Car.NumberPlate,
                                 StartDate = p.StartDate,
                                 EndDate = p.EndDate
                             })
                            .ToList();
                ParkingItems = new ObservableCollection<object>(list);
            }
            else
            {
                if (Int32.TryParse(Search, out int prid))
                {
                    var list = parkingRepository
                        .GetQuery()
                        .Where(p =>
                             p.Car is CarCustomer && ((CarCustomer)(p.Car)).Pass.Id == prid &&
                             (StartDate == null || p.StartDate >= StartDate) && (p.EndDate != null && p.EndDate <= EndDate || p.StartDate <= EndDate))
                        .Select(p =>
                          new
                          {
                              ((CarCustomer)p.Car).Pass,
                              viewModel = new ParkingItemByCardViewModel
                              {
                                  Id = p.Id,
                                  CustomerName = ((CarCustomer)p.Car).Pass.Customer.Name,
                                  Discount = ((CarCustomer)p.Car).Pass.PaymentType.Discount,
                                  NumberPlate = p.Car.NumberPlate,
                                  StartDate = p.StartDate,
                                  EndDate = p.EndDate
                              }
                          })
                        .ToList()
                        .Select(a =>
                        {
                            a.viewModel.PassNumber = a.Pass.Number;
                            return a.viewModel;
                        });
                    ParkingItems = new ObservableCollection<object>(list);
                }
            }
            OnPropertyChanged(nameof(ParkingItems));
            ExportCommand.InvokeCanExecuteChanged();
        }
        bool CanList
        {
            get
            {
                return !String.IsNullOrEmpty(Search) && (Search.Length == 7 || Search.Length == 8);
            }
        }

        public void Export()
        {
            var selectedExporter = SelectedExporter;
            if (selectedExporter != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = "Export",
                    Filter = $"{selectedExporter.Name} (*.{selectedExporter.FileExtension})|All files(*.*)"
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllBytes($"{saveFileDialog.FileName}.{selectedExporter.FileExtension}", SelectedExporter.Export(ParkingItems!));
                    messageQueue.Enqueue("Sikeres Mentés", "OK", param => { }, null, false, true, TimeSpan.FromSeconds(2));
                }
            }
        }
        bool CanExport
        {
            get
            {
                return ParkingItems != null;
            }
        }
    }
}
