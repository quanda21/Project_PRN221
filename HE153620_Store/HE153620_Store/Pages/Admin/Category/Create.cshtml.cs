using HE153620_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HE153620_Store.Pages.Admin.Category
{
    public class CreateModel : PageModel
    {
        private readonly StoreManagerContext _dbContext;

        public CreateModel(StoreManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Models.Category NewCategory { get; set; }

        public void OnGet()
        {
            // Nothing to do on GET request
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save the new category to the database
            _dbContext.Categories.Add(NewCategory);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}