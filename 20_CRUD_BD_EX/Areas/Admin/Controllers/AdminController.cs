using Microsoft.AspNetCore.Mvc;
using _20_CRUD_BD_EX.Filters;
namespace _20_CRUD_BD_EX.Controllers
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