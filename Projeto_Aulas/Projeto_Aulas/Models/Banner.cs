using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
     [Table("Banners")]
    public class Banner
    {
        [Key]
        public int BannerID { get; set; }
        public string Imagem { get; set; }
        // ? = não é necessário //
        public string? Titulo { get; set; }
        public string? Subtitulo { get; set; }
        public string? Link { get; set; }
        public bool Exibir { get; set; }

    }
}
