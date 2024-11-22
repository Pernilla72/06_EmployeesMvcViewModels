using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _03_EmployeesMvc.Models.Entities;
using _03_EmployeesMvc.Views.Employees;
using Microsoft.EntityFrameworkCore;

namespace _03_EmployeesMvc.Models
{
    public class DBDataService : IDataService
    {
        private readonly ApplicationContext applicationContext;

        public DBDataService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        //// Fejk-DB
        //List<Employee> employees = new List<Employee>()
        //{
        //    new Employee()
        //    {
        //        Id = 451, Name = "Louis De Geer d.ä.", Email = "Louis.De.Geer@gmail.com",
        //    },
        //    new Employee()
        //    {
        //        Id = 61056, Name = "Arvid Posse", Email = "Arvid.Posse@outlook.com",
        //    },
        //    new Employee()
        //    {
        //        Id = 9355, Name = "Carl Johan Thyselius", Email = "Carl.Johan.Thyselius@brights.com",
        //    },
        //    new Employee()
        //    {
        //        Id = 93, Name = "Robert Themptander", Email = "Robert.Themptander.se",
        //    },
        //};

        public async Task AddAsync(CreateVM createVM) //Lägg till en Employee
        {
            Employee employee = new Employee()
            {
                Email = createVM.Email,
                Name = createVM.Name,
            };

            //createVM.Id = employees.Count == 0 ? 1 : employees.Max(e => e.Id) + 1;
            await applicationContext.Employees.AddAsync(employee);
            await applicationContext.SaveChangesAsync();
        }


        public async Task<IndexVM[]> GetAllAsync()  //GetAllaEmployees
        {
            return await applicationContext.Employees
                .Include(e => e.Company)
                .OrderBy(e => e.Name) // Order by last name
                .Select(e => new IndexVM()
                {
                    Email = e.Email,
                    Id = e.Id,
                    Name = e.Name,
                    //ShowAsHiglighted = e.Email.ToLower().StartsWith("admin")
                    ShowAsHiglighted = e.Email.StartsWith("admin", StringComparison.OrdinalIgnoreCase)
                })
                .ToArrayAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await applicationContext.Employees
                .FindAsync(id);
        }
    }
}
