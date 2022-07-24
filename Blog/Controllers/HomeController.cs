using Blog.BusinessManager.Interfaces;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostBusinessManager _postBusinessManager;

        public HomeController(IPostBusinessManager postBusinessManager)
        {
            _postBusinessManager = postBusinessManager;
        }

        public IActionResult Index(string searchString, int? page)
        {
            return View(_postBusinessManager.GetIndexHomeViewModel(searchString, page));
        }
    }
}