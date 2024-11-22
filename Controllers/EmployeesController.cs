using _03_EmployeesMvc.Models;
using _03_EmployeesMvc.Models.Entities;
using _03_EmployeesMvc.Views.Employees;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _03_EmployeesMvc.Controllers
{
    public class EmployeesController : Controller
    {
        IDataService dataService;

        public EmployeesController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpGet("/")]
        [HttpGet("/Index")]
        public async Task<IActionResult> IndexAsync()
        {
            //ViewBag.Title = "All Employees";
            IndexVM[] employees = await dataService.GetAllAsync();
            return View(employees);
        }

        [HttpGet("/Create")]
        public IActionResult Create()
        {
            //ViewBag.Title = "Add New Employee";
            return View();
        }

        [HttpPost("/Create")]
        public async Task<IActionResult> CreateAsync(CreateVM createVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Title = "Add New Employee";
                return View();
            }

            await dataService.AddAsync(createVM);
            return RedirectToAction(nameof(IndexAsync).Replace("Async", string.Empty));
        }
    }
}