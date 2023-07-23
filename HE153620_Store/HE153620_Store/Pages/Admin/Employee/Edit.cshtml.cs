using HE153620_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HE153620_Store.Pages.Admin.Employee
{
    public class EditModel : PageModel
    {
        private readonly StoreManagerContext _dbContext;

        public EditModel(StoreManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Models.Employee Employee { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Employee = await _dbContext.Employees.FindAsync(id);

            if (Employee == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Attach(Employee).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Employees.Any(e => e.EmployeeId == Employee.EmployeeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("List");
        }
    }
}