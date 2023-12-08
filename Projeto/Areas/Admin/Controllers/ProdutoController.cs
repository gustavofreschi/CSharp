using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto.Context;
using Projeto.Models;
using Projeto.Filters;
using X.PagedList;
using System.Xml;
using System.Text;

namespace Projeto.Controllers
{
    [Area("Admin")]
    [AdminAuthorize]
    public class ProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Produto
        public IActionResult Index(string botao, string? txtFiltro, string? selOrdenacao, int pagina = 1)
        {


            int pageSize = 10;

            IQueryable<Produto> listaView = _context.Produtos.Include(p => p.Categoria);

            if (botao == "Relatorio")
            {
                pageSize = listaView.Count();
            }

            if (txtFiltro != null && txtFiltro != "")
            {
                ViewData["txtFiltro"] = txtFiltro;
                listaView = listaView.Where(item => item.ProdutoNome.ToLower().Contains(txtFiltro) || item.Categoria.CategoriaNome.ToLower().Contains(txtFiltro));
            }

            if (selOrdenacao == "Nome" || selOrdenacao == null)
            {
                listaView = listaView.OrderBy(item => item.ProdutoNome.ToLower());
            }
            else if (selOrdenacao == "Categoria")
            {
                listaView = listaView.OrderBy(item => item.Categoria.CategoriaNome.ToLower());
            }
            else if (selOrdenacao == "Preco")
            {
                listaView = listaView.OrderByDescending(item => item.Preco);
            }
            ViewData["Ordem"] = selOrdenacao;

            //Verificando se o botão clicado foi o XML
            if (botao == "XML")
            {
                //Chamando o método para exportar o XML enviando como parâmentro a lista já filtrada
                return ExportarXML(listaView.ToList());
            }
            else if (botao == "Json")
            {
                //Chamando o método para exportar o Json enviando como parâmentro a lista já filtrada
                return ExportarJson(listaView.ToList());
            }
            return View(listaView.ToPagedList(pagina, pageSize));
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,ProdutoNome,Descricao,Preco,Imagem,EmEstoque,CategoriaId")] Produto produto)
        {

            _context.Add(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", produto.CategoriaId);
            return View(produto);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", produto.CategoriaId);
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,ProdutoNome,Descricao,Preco,Imagem,EmEstoque,CategoriaId")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }


            try
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(produto.ProdutoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", produto.CategoriaId);
            return View(produto);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'AppDbContext.Produtos'  is null.");
            }
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return (_context.Produtos?.Any(e => e.ProdutoId == id)).GetValueOrDefault();
        }

        private IActionResult ExportarXML(List<Produto> lista)
        {
            var stream = new StringWriter();
            var xml = new XmlTextWriter(stream);

            xml.Formatting = System.Xml.Formatting.Indented;

            xml.WriteStartDocument();
            xml.WriteStartElement("Dados");

            xml.WriteStartElement("Produtos");
            foreach (var produto in lista)
            {
                xml.WriteStartElement("Produto");
                xml.WriteElementString("Id", produto.ProdutoId.ToString());
                xml.WriteElementString("Nome", produto.ProdutoNome);
                xml.WriteElementString("Preço", produto.Preco.ToString());
                xml.WriteElementString("Categoria", produto.Categoria.CategoriaNome);
                xml.WriteElementString("Descrição", produto.Descricao);
                xml.WriteEndElement(); // </produto>
            }
            xml.WriteEndElement(); // </Produtos>

            xml.WriteEndElement(); // </Data>
            return File(Encoding.UTF8.GetBytes(stream.ToString()), "application/xml", "dados_produtos.xml");
        }

        private IActionResult ExportarJson(List<Produto> lista)
        {
            var json = new StringBuilder();
            json.AppendLine("{");
            json.AppendLine("  \"Países\": [");
            int total = 0;
            foreach (var produto in lista)
            {
                json.AppendLine("    {");
                json.AppendLine($"      \"Id\": {produto.ProdutoId.ToString()},");
                json.AppendLine($"      \"Nome\": \"{produto.ProdutoNome}\",");
                json.AppendLine($"      \"Preço\": \"{produto.Preco.ToString()}\",");
                json.AppendLine($"      \"Categoria\": \"{produto.Categoria.CategoriaNome}\",");
                json.AppendLine($"      \"Descrição\": {produto.Descricao}");
                json.AppendLine("    }");
                total++;
                if (total < lista.Count())
                {
                    json.AppendLine("    ,");
                }
            }
            json.AppendLine("  ]");
            json.AppendLine("}");

            return File(Encoding.UTF8.GetBytes(json.ToString()), "application/json", "dados_produtos.json");
        }
    }
}
