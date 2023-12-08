using App.Models;
using X.PagedList;
namespace App.Models;
public class PaisContinenteViewModel
{
    public IPagedList<Pais> ListaPaises { get; set; }
    public IEnumerable<Continente> ListaContinentes { get; set; }
}