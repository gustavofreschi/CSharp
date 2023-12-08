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

    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Usuario
        public IActionResult Index(string botao, string? txtFiltro, string? selOrdenacao, int pagina = 1)
        {
            int pageSize = 5; // Número de itens por página

            IQueryable<Usuario> listaView = _context.Usuarios;

            if (botao == "Relatorio")
            {
                pageSize = listaView.Count();
            }

            if (!string.IsNullOrEmpty(txtFiltro))
            {
                ViewData["txtFiltro"] = txtFiltro;
                listaView = listaView.Where(item => item.Nome.ToLower().Contains(txtFiltro) || item.Login.ToLower().Contains(txtFiltro));
            }

            if (selOrdenacao == "Nome" || selOrdenacao == null)
            {
                listaView = listaView.OrderBy(item => item.Nome.ToLower());
            }
            else if (selOrdenacao == "Nome_Desc")
            {
                listaView = listaView.OrderByDescending(item => item.Nome.ToLower());
            }
            else if (selOrdenacao == "Login")
            {
                listaView = listaView.OrderBy(item => item.Login.ToLower());
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

        // GET: Admin/Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Admin/Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,Nome,Login,Senha")] Usuario usuario)
        {

            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            return View(usuario);
        }

        // GET: Admin/Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Admin/Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,Nome,Login,Senha")] Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }


            try
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(usuario.UsuarioId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            return View(usuario);
        }

        // GET: Admin/Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Admin/Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'AppDbContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.UsuarioId == id)).GetValueOrDefault();
        }

        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login", new { area = "" });
        }

        private IActionResult ExportarXML(List<Usuario> lista)
        {
            var stream = new StringWriter();
            var xml = new XmlTextWriter(stream);
            xml.Formatting = System.Xml.Formatting.Indented;
            xml.WriteStartDocument();
            xml.WriteStartElement("Dados");
            xml.WriteStartElement("Usuários");
            foreach (var item in lista)
            {
                xml.WriteStartElement("Usuário");
                xml.WriteElementString("Id", item.UsuarioId.ToString());
                xml.WriteElementString("Nome", item.Nome);
                xml.WriteElementString("Login", item.Login);
                xml.WriteEndElement(); // </Usuario>
            }
            xml.WriteEndElement(); // </Usuarios>
            xml.WriteEndElement(); // </Dados>
            return File(Encoding.UTF8.GetBytes(stream.ToString()), "application/xml", "dados_usuarios.xml");
        }

        private IActionResult ExportarJson(List<Usuario> lista)
        {
            var json = new StringBuilder();
            json.AppendLine("{");
            json.AppendLine(" \"Usuarios\": [");
            int total = 0;
            foreach (var item in lista)
            {
                json.AppendLine(" {");
                json.AppendLine($" \"Id\": {item.UsuarioId},");
                json.AppendLine($" \"Nome\": \"{item.Nome}\",");
                json.AppendLine($" \"Login\": \"{item.Login}\"");
                json.AppendLine(" }");
                total++;
                if (total < lista.Count())
                {
                    json.AppendLine(" ,");
                }
            }
            json.AppendLine(" ]");
            json.AppendLine("}");
            return File(Encoding.UTF8.GetBytes(json.ToString()), "application/json", "dados_usuarios.json");
        }
    }
}
