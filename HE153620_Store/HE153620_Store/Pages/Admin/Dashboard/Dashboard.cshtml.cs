using HE153620_Store.Models;
/*using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HE153620_Store.Pages.Admin.Dashboard
{
    public class DashboardModel : PageModel
    {

        private readonly StoreManagerContext  _dbContext;

        public decimal TotalAmountSold { get; private set; }
        public  Models.Product MostSoldProduct { get; set; }
        public Models.Employee TopSalesEmployee { get;  set; }

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
          *//*  TopSalesEmployee = await _dbContext.Employees
                .OrderByDescending(e => e.Orders.Sum(o => o.Invoice.TotalAmount))
                .FirstOrDefaultAsync();*//*
        }
    }
}
   */
