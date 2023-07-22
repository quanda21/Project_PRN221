using HE153620_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HE153620_Store.Pages.Admin.Product
{
    public class EditModel : PageModel
    {
        private readonly StoreManagerContext _dbContext;

        public EditModel(StoreManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Models.Product Product { get; set; }
        public Supplier Supplier { get; set; }  

        public SelectList Suppliers { get; set; }
        public SelectList Categories { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = _dbContext.Products
                .Include(p => p.Supplier)
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ProductId == id);

            if (Product == null)
            {
                return NotFound();
            }

            Suppliers = new SelectList(_dbContext.Suppliers, "SupplierId", "Name");
            Categories = new SelectList(_dbContext.Categories, "CategoryId", "CategoryName");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Products.Update(Product);
            _dbContext.SaveChanges();

            return RedirectToPage("List");
        }
    }
}