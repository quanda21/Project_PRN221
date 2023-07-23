using HE153620_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HE153620_Store.Pages.Admin.Employee
{
    public class ListModel : PageModel
    {
        private readonly StoreManagerContext _dbContext;



        public ListModel(StoreManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Models.Employee> Employees { get; set; }
       
        public Models.Employee Employee{ get; set; }

        public async Task<IActionResult> OnGet()
        {
            Employees = await _dbContext.Employees.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);

            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}