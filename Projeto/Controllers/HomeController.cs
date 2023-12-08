using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using Projeto.Context;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Projeto.Controllers;

public class HomeController : Controller
{


    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Produto
    public IActionResult Index(string? txtFiltro, int pagina = 1)
    {
        int pageSize = 4;

        IQueryable<Produto> listaView = _context.Produtos.Include(p => p.Categoria);

        if (txtFiltro != null && txtFiltro != "")
        {
            ViewData["txtFiltro"] = txtFiltro;
            listaView = listaView.Where(item =>
            item.ProdutoNome.ToLower().Contains(txtFiltro.ToLower())
            ||
            item.Categoria.CategoriaNome.ToLower().Contains(txtFiltro.ToLower()));
        }

        ProdutoCategoriaViewModel vm = new ProdutoCategoriaViewModel
        {
            ListaProdutos = listaView.ToPagedList(pagina, pageSize),
            ListaCategorias = _context.Categorias.OrderBy(item => item.CategoriaNome).ToList()
        };
        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
