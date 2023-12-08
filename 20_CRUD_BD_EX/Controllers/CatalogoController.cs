using Microsoft.AspNetCore.Mvc;
using _20_CRUD_BD_EX.Models;
using _20_CRUD_BD_EX.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _20_CRUD_BD_EX.Controllers
{
    public class CatalogoController : Controller
    {

        private readonly AppDbContext _context;

        public CatalogoController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Filmes.Include(f => f.Categoria);
            return View(await appDbContext.ToListAsync());
        }
    }
}