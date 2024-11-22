using System;
using System.Collections.Generic;
using System.Linq;
using _03_EmployeesMvc.Models.Entities;

namespace _03_EmployeesMvc.Models
{
    public class DataService //TODO : IDataservice
    {
        public DataService()
        {
        }

        // Fejk-DB
        static List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = 4562, Name = "Pontus WittenMark", Email = "pontus.wittenmark@gmail.com",
            },
            new Employee()
            {
                Id = 65, Name = "Håkan Johansson", Email = "watchrepairer@outlook.com",
            },
            new Employee()
            {
                Id = 4562, Name = "Oliver Björklund", Email = "oliver.bjorklund@brights.com",
            },
            new Employee()
            {
                Id = 45624, Name = "Adamsson", Email = "adam@adamsson.se",
            },
        };

        public void AddAsync(Employee employee)
        {
            employee.Id = employees.Count == 0 ? 1 : employees.Max(e => e.Id) + 1;
            employees.Add(employee);
        }

        public Employee[] GetAllAsync()
        {
            return employees
                .OrderBy(e => e.Name.Split(' ')[^1]) // Order by last name
                .ToArray();
        }

        public Employee GetByIdAsync(int id)
        {
            return employees
                .SingleOrDefault(e => e.Id == id);
        }
    }
}
