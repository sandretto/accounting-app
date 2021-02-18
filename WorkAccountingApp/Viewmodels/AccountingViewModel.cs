using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WorkAccountingApp.DataManipulation;
using WorkAccountingApp.Models;
using WorkAccountingApp.Utility;

namespace WorkAccountingApp.ViewModels
{
    public class AccountingViewModel : INotifyPropertyChanged
    {
        private IFileService<SelectedInformation> fileService;
        private IDialogService dialogService;
        private SelectedInformation information; 

        private List<City> citiesList;
        private List<Department> departmentsList;
        private List<Employee> employeesList;

        private ObservableCollection<City> cities;
        private ObservableCollection<Department> departments;
        private ObservableCollection<Employee> employees;

        public ObservableCollection<City> Cities
        {
            get => cities;
            set
            {
                cities = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Department> Departments
        {
            get => departments;
            set
            {
                departments = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set
            {
                employees = value;
                OnPropertyChanged();
            }
        }

        private City selectedCity;
        public City SelectedCity 
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                OnPropertyChanged();
                if(SelectedCity != null)
                {
                    Departments = new ObservableCollection<Department>
                        (departmentsList.Where(x => x.CityId == SelectedCity.Id));
                }
                else InitCollections();
            }
        }

        private Department selectedDepartment;
        public Department SelectedDepartment
        {
            get { return selectedDepartment; }
            set
            {
                selectedDepartment = value;
                OnPropertyChanged();
                if (SelectedDepartment != null)
                {
                    Employees = new ObservableCollection<Employee>
                        (employeesList.Where(x => x.DepartmentId == SelectedDepartment.Id));
                }
                else InitCollections();
            }
        }

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged();
                SelectedShift = ShiftType;
                SelectedTeam = TeamType;
            }
        }

        public string ShiftType 
        {
            get
            {
                return SelectedEmployee.IsNightShift ? "с 20:00 до 8:00" : "с 8 до 20:00";
            }
        }

        public string TeamType
        {
            get
            {
                return SelectedEmployee.IsNightShift ? "Первая" : "Вторая";
            }
        }

        private string selectedShift;
        public string SelectedShift
        {
            get { return selectedShift; }
            set
            {
                selectedShift = value;
                OnPropertyChanged();
            }
        }

        private string selectedTeam;
        public string SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                selectedTeam = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand saveToJson; 
        public RelayCommand SaveToJson
        {
            get
            {
                return saveToJson ??= new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              AddInformationToList();
                              fileService.Save(dialogService.FilePath, information);
                              dialogService.ShowMessage("Файл сохранен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  });
            }
        }

        private RelayCommand saveToSql;
        public RelayCommand SaveToSql
        {
            get
            {
                return saveToSql ??= new RelayCommand(obj =>
                {
                    try
                    {
                        AddInformationToList();

                        using (var context = new EFDbContext())
                        {
                            context.SelectedInformation.Add(information);
                            context.SaveChanges();
                        }

                        dialogService.ShowMessage("Запись сохранена");
                    }
                    catch (Exception ex)
                    {
                        dialogService.ShowMessage(ex.Message);
                    }
                }); 
            }
        }

        private RelayCommand selectionChangedCommand;
        public RelayCommand CitySelectionChangedCommand 
        {
            get
            {
                return selectionChangedCommand ??= new RelayCommand(obj =>
                {
                    try
                    {
                        InitCollections();
                    }
                    catch (Exception ex)
                    {
                        dialogService.ShowMessage(ex.Message);
                    }
                });
            }
        }


        private void AddInformationToList()
        {
            information = new SelectedInformation
            {
                Id = Guid.NewGuid().ToString(),
                City = SelectedCity.Name,
                Department = SelectedDepartment.Name,
                Employee = SelectedEmployee.ToString(),
                Shift = ShiftType,
                Team = TeamType
            };
        }

        public AccountingViewModel(IDialogService dialogService, IFileService<SelectedInformation> fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;
            information = new SelectedInformation();

            Load().Wait();

            InitCollections();
        }

        private async Task Load()
        {
            using var context = new EFDbContext();
            citiesList = await DataInitializer.GetCities(context);
            departmentsList = await DataInitializer.GetDepartments(context);
            employeesList = await DataInitializer.GetEmployees(context);
        }

        private void InitCollections()
        {
            cities = new ObservableCollection<City>(citiesList);
            departments = new ObservableCollection<Department>(departmentsList);
            employees = new ObservableCollection<Employee>(employeesList);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string v = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
