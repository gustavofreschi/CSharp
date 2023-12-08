using Microsoft.AspNetCore.Mvc;
using App.Filters;

namespace _21_LOGIN_ADMIN.Areas.Admin.Controllers
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