using Microsoft.EntityFrameworkCore;
using Exemplo02.Models;
using _21_LOGIN_ADMIN.Models;

namespace Exemplo02.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //No meu DbSet carregará todos os jogos salvos no banco de dados
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Continente> Continentes { get; set; }

        public DbSet<Usuario> Usuarios { get; set;}
    }
}