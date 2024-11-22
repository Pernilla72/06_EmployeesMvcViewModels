using System.ComponentModel.DataAnnotations;

namespace _03_EmployeesMvc.Views.Employees
{
    public class IndexVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public bool ShowAsHiglighted { get; set; }
    }
}
