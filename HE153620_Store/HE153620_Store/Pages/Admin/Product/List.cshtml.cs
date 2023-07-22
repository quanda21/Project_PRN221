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

        public List<Pages_Admin_Product_List> Products { get; set; }

        public void OnGet()
        {
            Products = new List<Pages_Admin_Product_List>();   
        }
    }
}