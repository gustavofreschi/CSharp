using Microsoft.AspNetCore.Mvc;
using Projeto.Filters;


namespace Projeto.Controllers
{
    public class AdminController : Controller
    {
        [Area("Admin")]
        [AdminAuthorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}