using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _20_CRUD_BD_EX.Models
{
    [Table("Filmes")]
    public class Filme
    {
        [Key] //Falando para o BD que este atributo será uma chave
        public int JogoId { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        [Display(Name = "Nome do Filme")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public bool Ativo { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}