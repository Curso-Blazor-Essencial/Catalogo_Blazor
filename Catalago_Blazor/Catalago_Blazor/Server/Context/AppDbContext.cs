using Catalago_Blazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalago_Blazor.Server.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Mapeamento para acessar as tabelas atráves das entidades
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

    }
}
