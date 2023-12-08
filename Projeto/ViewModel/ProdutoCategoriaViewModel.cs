using Projeto.Models;
using X.PagedList;

namespace Projeto.Models;

public class ProdutoCategoriaViewModel
{
    public IPagedList<Produto> ListaProdutos { get; set; }
    public IEnumerable<Categoria> ListaCategorias { get; set; }
}