using HE153620_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HE153620_Store.Pages.Admin.Product
{
    public class CreateModel : PageModel
    {
        private readonly StoreManagerContext _dbContext;

        public CreateModel(StoreManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Supplier> Suppliers { get; set; }
         public List<Models.Category> Categories { get; set; }  
         public List<(Supplier, Models.Category)> CategoriesByCategory { get; set; }

        public List<Models.Product> Products { get; set; }

        public void OnGet()
        {
            Suppliers = _dbContext.Suppliers.ToList();
            Categories = _dbContext.Categories.ToList();
        }

        public IActionResult OnPost(string productName, int supplierId, int categoryId, decimal unitPrice, short unitsInStock)
        {
            // Tạo đối tượng Product mới
            var newProduct = new Models.Product
            {
                ProductName = productName,
                SupplierId = supplierId,
                CategoryId= categoryId,
                UnitPrice = unitPrice,
                UnitsInStock = unitsInStock
            };

            // Thêm sản phẩm mới vào cơ sở dữ liệu
            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();

            // Chuyển hướng đến trang danh sách sản phẩm sau khi thêm thành công
            return RedirectToPage("List");
        }
    }
}
