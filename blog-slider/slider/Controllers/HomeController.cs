using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using slider.Data;
using slider.Models;
using slider.Services.Interface;
using slider.ViewModels;

namespace slider.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;
        private readonly ICategoriyService _categoriyService;
        private readonly IExpertService _expertService;
        private readonly IExpertSliderService _expertSliderService;
        private readonly IInstagramService _instagramService;



        public HomeController(AppDbContext context, IProductService productService,
            ICategoriyService categoriyService, IExpertService expertService, IExpertSliderService expertSliderService,
            IInstagramService instagramService)
        {
            _context = context;
            _productService = productService;
            _categoriyService = categoriyService;
            _expertService = expertService;
            _expertSliderService = expertSliderService;
            _instagramService = instagramService;



        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _categoriyService.GetCategoriesAsync();
            List<Product> products = await _productService.GetAllAsync();
            AboutSuprise aboutSuprise = await _context.AboutSuprise.Where(m => !m.SoftDeleted).FirstOrDefaultAsync();
            SupriseText supriseText = await _context.SupriseTexts.FirstOrDefaultAsync();
            List<Expert> experts = await _expertService.GetExpertsAsync();
            List<Expert> expertSliders = await _expertSliderService.GetExpertSlidersAsync();
            List<Blog> blogs = await _context.Blogs.Where(m => !m.SoftDeleted).Take(3).ToListAsync();
            List<Instagram> instagrams = await _instagramService.GetInstagramAsync();

            HomeVM model = new()
            {

                Categories = categories,
                Products = products,
                AboutSuprise = aboutSuprise,
                SupriseText = supriseText,
                Experts = experts,
                ExpertSliders = expertSliders,
                Blogs = blogs,
                Instagrams = instagrams
            };
            return View(model);
        }

    }
}
