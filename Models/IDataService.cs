using _03_EmployeesMvc.Models.Entities;
using _03_EmployeesMvc.Views.Employees;
using System.Threading.Tasks;

namespace _03_EmployeesMvc.Models
{
    public interface IDataService
    {
        Task AddAsync(CreateVM createVM);
        Task<IndexVM[]> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
    }
}
