using HE153620_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace HE153620_Store.Pages.Admin.Employee
{
    public class CreateModel : PageModel
    {
        private readonly StoreManagerContext _dbContext;

        public CreateModel(StoreManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Role> Roles { get; set; }
     
        public IActionResult OnGet()
        {
            Roles = _dbContext.Roles.ToList();
            return Page();
        }

        public IActionResult OnPost(string FirstName, string LastName, string Gender, string Address, string Phone, string Email, int RoleID)
        {
            var employee = new Models.Employee
            {
                FirstName = FirstName,
                LastName = LastName,
                Gender = Gender,
                Address = Address,
                Phone = Phone,
                Email = Email,
                RoleId= RoleID
            };

            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();

            return RedirectToPage("List");
        }
    }
}