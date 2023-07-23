using HE153620_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HE153620_Store.Pages.Admin.Category
{
    public class ListModel : PageModel
    {
        private readonly StoreManagerContext _dbContext;

        public ListModel(StoreManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Models.Category> Categories { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await _dbContext.Categories.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int categoryId)
        {
            var category = await _dbContext.Categories.FindAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("List");
        }
    }
}
