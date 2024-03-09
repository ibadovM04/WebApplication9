using Microsoft.AspNetCore.Mvc;
using WebApplication9.Data;
using WebApplication9.DTOs;
using WebApplication9.ViewModels;

namespace WebApplication9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbcontext _context;
        private readonly IConfiguration _configuration;

        public HomeController(ApplicationDbcontext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }
        public IActionResult Index()
        {
            HomeIndexVm ındexVm = new HomeIndexVm()
            {
                Sliders = _context.Sliders.Select(s => new SliderDto
                {
                    SliderId = s.Id,
                    ImageUrl = _configuration["Folders:Sliders"] + s.ImageUrl,
                    Text = s.Slogan,


                }).OrderByDescending(s => s.SliderId).ToList()
            };
            return View(ındexVm);

        }
    }
}
