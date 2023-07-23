using HE153620_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HE153620_Store.Pages.Admin.Category
{
    public class EditModel : PageModel
    {
        private readonly StoreManagerContext _dbContext;

        public EditModel(StoreManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Models.Category Category { get; set; }

        public IActionResult OnGet(int id)
        {
            // Retrieve the category from the database based on the provided id
            Category = _dbContext.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (Category == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update the category in the database
            _dbContext.Categories.Update(Category);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}