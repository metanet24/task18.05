using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using slider.Data;
using slider.Models;
using slider.ViewModels.Baskets;

namespace slider.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        public BasketController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.Include(m => m.ProductImages).ToListAsync();

            BasketProductVM model = new()
            {
                Products = products,
            };

            return View(model);
        }
    }
}
