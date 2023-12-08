using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace _20_CRUD_BD_EX.Models
{
    //Mapeamento com o nome que será criado na tabela
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public List<Filme> Filmes { get; set; }
    }
}