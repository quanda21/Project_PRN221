using HE153620_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HE153620_Store.Pages.Admin.Product
{
    public class ListModel : PageModel
    {
       
            private readonly StoreManagerContext _dbContext;

            public ListModel(StoreManagerContext dbContext)
            {
                _dbContext = dbContext;
            }

            public List<Models.Product> Products { get; set; } // Sửa lại kiểu dữ liệu

            public List<Supplier> Suppliers { get; set; }

            public List<Category> Categories { get; set; }

        public void OnGet(string searchTerm)
        {
            Suppliers = _dbContext.Suppliers.ToList();
            Categories = _dbContext.Categories.ToList();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.Trim().ToLower();
                Products = _dbContext.Products
                    .Where(p => p.ProductName.ToLower().Contains(searchTerm) || p.Category.CategoryName.ToLower().Contains(searchTerm))
                    .ToList();
            }
            else
            {
                Products = _dbContext.Products.ToList();
            }
        }
    }
}

