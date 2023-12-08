using Microsoft.EntityFrameworkCore;
using _20_CRUD_BD_EX.Models;

namespace _20_CRUD_BD_EX.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //No meu DbSet carregará todos os jogos salvos no banco de dados
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set;}
    }
}