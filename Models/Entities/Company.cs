using System.Collections.Generic;

namespace _03_EmployeesMvc.Models.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
