using HE153620_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HE153620_Store.Pages.Admin.Dashboard
{
    /* public class DashboardModel : PageModel
     {

         private readonly StoreManagerContext _dbContext;

         public decimal TotalAmountSold { get; private set; }
         public Models.Product MostSoldProduct { get; set; }
         public Models.Employee TopSalesEmployee { get; set; }

         public Models.Invoice Invoice { get; set; }
         public DashboardModel(StoreManagerContext dbContext)
         {
             _dbContext = dbContext;
         }

         public async Task OnGetAsync()
         {
             // Calculate total amount sold in the current month
             var currentDate = DateTime.Now.Date;
             var currentMonth = currentDate.Month;
             var currentYear = currentDate.Year;

             TotalAmountSold = (decimal)await _dbContext.Invoices
                 .Where(i => i.InvoiceDate.HasValue && i.InvoiceDate.Value.Month == currentMonth && i.InvoiceDate.Value.Year == currentYear)
                 .SumAsync(i => i.TotalAmount);
             // Find the most sold product
             MostSoldProduct = await _dbContext.Products
                 .OrderByDescending(p => p.OrderDetails.Sum(od => od.Quantity))
                 .FirstOrDefaultAsync();

             // Find the employee with the most sales
            *//* TopSalesEmployee = await _dbContext.Employees
                 .OrderByDescending(e => e.Orders.Sum(o => o.Invoice.TotalAmount))
                 .FirstOrDefaultAsync();*//*
         }
     }
 }
 */

    public class DashboardModel : PageModel
    {
        private readonly StoreManagerContext _dbContext;

        public decimal TotalAmountSold { get; private set; }
       
        public Models.Product MostSoldProduct { get; set; }
        public Models.Employee TopSalesEmployee { get; set; }
        public Dictionary<string, decimal> MonthlySales { get; private set; } // Dictionary to store monthly sales
        public ICollection<Models.Order> Orders { get; set; }
        public DashboardModel(StoreManagerContext dbContext)
        {
            _dbContext = dbContext;
            MonthlySales = new Dictionary<string, decimal>();
        }

        public async Task OnGetAsync()
        {
            // Tính tổng số tiền đã bán trong tháng hiện tại
            // Tính tổng số tiền đã bán trong tháng hiện tại
            var currentDate = DateTime.Now.Date;
            var currentMonth = currentDate.Month;
            var currentYear = currentDate.Year;

            TotalAmountSold = (decimal)await _dbContext.Invoices
                .Where(i => i.InvoiceDate.HasValue && i.InvoiceDate.Value.Month == currentMonth && i.InvoiceDate.Value.Year == currentYear)
                .SumAsync(i => i.TotalAmount);

            // Tìm sản phẩm được bán nhiều nhất
            MostSoldProduct = await _dbContext.Products
                .OrderByDescending(p => p.OrderDetails.Sum(od => od.Quantity))
                .FirstOrDefaultAsync();




            // Tính doanh số hàng tháng
            var monthlySales = await _dbContext.Invoices
                .GroupBy(i => new { i.InvoiceDate.Value.Month, i.InvoiceDate.Value.Year })
                .Select(g => new
                {
                    Month = g.Key.Month,
                    Year = g.Key.Year,
                    TotalAmount = g.Sum(i => i.TotalAmount)
                })
                .ToListAsync();

            foreach (var sale in monthlySales)
            {
                var monthName = new DateTime(sale.Year, sale.Month, 1).ToString("MMMM yyyy");
                MonthlySales[monthName] = (decimal)sale.TotalAmount;
            }
        }
    }
}