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

namespace WorkAccountingApp.ViewModels
{
    public class AccountingViewModel : INotifyPropertyChanged
    {
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
                Departments = new ObservableCollection<Department>
                    (departmentsList.Where(x => x.CityId == SelectedCity.Id));
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
                Employees = new ObservableCollection<Employee>
                    (employeesList.Where(x => x.DepartmentId == SelectedDepartment.Id));
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
                SelectedShift = SelectedEmployee.IsNightShift ? "с 20:00 до 8:00" : "с 8 до 20:00";
                SelectedTeam = SelectedEmployee.IsNightShift ? "Первая" : "Вторая";
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

        public AccountingViewModel()
        {
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
