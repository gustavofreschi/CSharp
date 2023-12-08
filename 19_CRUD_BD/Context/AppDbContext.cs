using Microsoft.EntityFrameworkCore;
using _19_CRUD_BD.Models;

namespace _19_CRUD_BD.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Jogo> Jogos {get; set;}
    }
}