using HE153620_Store.Models;
using Microsoft.AspNetCore.SignalR;

namespace HE153620_Store.Hubs
{
    public class CategoryHub : Hub
    {
        private StoreManagerContext _context;
        public CategoryHub(StoreManagerContext context)
        {
            _context = context;
        }

        public async Task DeleteCategory(int? id)
        {
            if (id != null)
            {
                Category category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);
                if (category != null)
                {
                    List<Product> products = _context.Products.Where(p => p.CategoryId == id).ToList();
                    _context.Products.RemoveRange(products);
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                }
            }
            await Clients.All.SendAsync("CategoryDeleted", id);
        }
    }
}