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
    public class CategoriaController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Categoria
        public IActionResult Index(string botao, string? txtFiltro, string? selOrdenacao, int pagina = 1)
        {
            int pageSize = 5;

            IQueryable<Categoria> listaView = _context.Categorias;

            if (botao == "Relatorio")
            {
                pageSize = listaView.Count();
            }

            if (!string.IsNullOrEmpty(txtFiltro))
            {
                ViewData["txtFiltro"] = txtFiltro;
                listaView = listaView.Where(item => item.CategoriaNome.ToLower().Contains(txtFiltro) || item.Descricao.ToLower().Contains(txtFiltro));
            }

            if (selOrdenacao == "Categoria" || selOrdenacao == null)
            {
                listaView = listaView.OrderByDescending(item => item.CategoriaNome.ToLower());
            }
            else if (selOrdenacao == "Descricao")
            {
                listaView = listaView.OrderByDescending(item => item.Descricao.ToLower());
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

        // GET: Categoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categorias == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaId,CategoriaNome,Descricao")] Categoria categoria)
        {

            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            return View(categoria);
        }

        // GET: Categoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categorias == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaId,CategoriaNome,Descricao")] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return NotFound();
            }


            try
            {
                _context.Update(categoria);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(categoria.CategoriaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            return View(categoria);
        }

        // GET: Categoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categorias == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categorias == null)
            {
                return Problem("Entity set 'AppDbContext.Categorias'  is null.");
            }
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
            return (_context.Categorias?.Any(e => e.CategoriaId == id)).GetValueOrDefault();
        }

        private IActionResult ExportarXML(List<Categoria> lista)
        {
            var stream = new StringWriter();
            var xml = new XmlTextWriter(stream);
            xml.Formatting = System.Xml.Formatting.Indented;
            xml.WriteStartDocument();
            xml.WriteStartElement("Dados");
            xml.WriteStartElement("Categorias");
            foreach (var item in lista)
            {
                xml.WriteStartElement("Categoria");
                xml.WriteElementString("Id", item.CategoriaId.ToString());
                xml.WriteElementString("Categoria", item.CategoriaNome);
                xml.WriteElementString("Descrição", item.Descricao);
                xml.WriteEndElement(); // </Categoria>
            }
            xml.WriteEndElement(); // </Categorias>
            xml.WriteEndElement(); // </Dados>
            return File(Encoding.UTF8.GetBytes(stream.ToString()), "application/xml", "dados_categorias.xml");
        }

        private IActionResult ExportarJson(List<Categoria> lista)
        {
            var json = new StringBuilder();
            json.AppendLine("{");
            json.AppendLine(" \"Categorias\": [");
            int total = 0;
            foreach (var item in lista)
            {
                json.AppendLine(" {");
                json.AppendLine($" \"Id\": {item.CategoriaId},");
                json.AppendLine($" \"Nome\": \"{item.CategoriaNome}\",");
                json.AppendLine($" \"Login\": \"{item.Descricao}\"");
                json.AppendLine(" }");
                total++;
                if (total < lista.Count())
                {
                    json.AppendLine(" ,");
                }
            }
            json.AppendLine(" ]");
            json.AppendLine("}");
            return File(Encoding.UTF8.GetBytes(json.ToString()), "application/json", "dados_categorias.json");
        }
    }
}
