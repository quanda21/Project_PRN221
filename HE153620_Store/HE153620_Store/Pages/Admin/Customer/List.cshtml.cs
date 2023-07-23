using HE153620_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HE153620_Store.Pages.Admin.Customer
{
    public class ListModel : PageModel
    {
        private readonly StoreManagerContext _dbContext;

        public ListModel(StoreManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Models.Customer> Customers { get; set; }
        public List<Models.Invoice> Invoices { get; set; }
        public void OnGet()
        {
            // Truy vấn dữ liệu khách hàng đã mua hàng và lưu vào thuộc tính Customers
            Customers = _dbContext.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.Invoices)
                .ToList();
        }
    }
}
