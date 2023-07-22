using HE153620_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HE153620_Store.Pages.Admin.Product
{
    public class DeleteModel : PageModel
    {
        private readonly StoreManagerContext _dbContext;

        public DeleteModel(StoreManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]

        public List<Supplier> Suppliers { get; set; }
        public List<Category> Categories { get; set; }

        public List<Models.Product> Products { get; set; }
        public Models.Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            Product = await _dbContext.Products
                .Include(p => p.Supplier)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var product = await _dbContext.Products.FindAsync(Product.ProductId);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToPage("List");
        }
    }
}