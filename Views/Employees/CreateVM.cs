using System.ComponentModel.DataAnnotations;

namespace _03_EmployeesMvc.Views.Employees
{
    public class CreateVM
    {
        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "The E-mail is required")]
        [EmailAddress(ErrorMessage = "Invalid E-mail address format")]
        public string Email { get; set; }

        [Display(Name = "E´What is 2 + 2?")]
        [Required(ErrorMessage = "Answer to the question is required")]
        [Range(4, 4, ErrorMessage = "Wrong answer, try again")]
        public int BotChecked { get; set; }
    }
}
