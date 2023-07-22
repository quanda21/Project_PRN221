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

            public void OnGet()
            {
               Suppliers=_dbContext.Suppliers.ToList();
                Products = _dbContext.Products.ToList();
            Categories = _dbContext.Categories.ToList();    
            }
    }
}
