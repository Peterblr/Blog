using Blog.Models.PostViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new CreateViewModel());
        }

        [HttpPost]
        public IActionResult Add(CreateViewModel createViewModel)
        {
            return View();
        }
    }
}
