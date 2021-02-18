using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WorkAccountingApp.Models;

namespace WorkAccountingApp.DataManipulation
{
    public class DataInitializer
    {
        private const string citiesPath = "Cities.json";
        private const string departmentsPath = "Departments.json";
        private const string employeesPath = "Employees.json";

        public static async Task<List<City>> GetCities(EFDbContext dbContext)
        {
            var json = File.ReadAllText(@"Seed" + Path.DirectorySeparatorChar + citiesPath);
            var list = JsonConvert.DeserializeObject<List<City>>(json);
            await dbContext.AddRangeAsync(list);
            await dbContext.SaveChangesAsync();
            return list;
        }

        public static async Task<List<Department>> GetDepartments(EFDbContext dbContext)
        {
            var json = File.ReadAllText(@"Seed" + Path.DirectorySeparatorChar + departmentsPath);
            var list = JsonConvert.DeserializeObject<List<Department>>(json);
            await dbContext.AddRangeAsync(list);
            await dbContext.SaveChangesAsync();
            return list;
        }

        public static async Task<List<Employee>> GetEmployees(EFDbContext dbContext)
        {
            var json = File.ReadAllText(@"Seed" + Path.DirectorySeparatorChar + employeesPath);
            var list = JsonConvert.DeserializeObject<List<Employee>>(json);
            await dbContext.AddRangeAsync(list);
            await dbContext.SaveChangesAsync();
            return list;
        }
    }
}
