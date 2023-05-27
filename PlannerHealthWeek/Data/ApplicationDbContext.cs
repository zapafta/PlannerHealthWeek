using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlannerHealthWeek.Data.Model;

namespace PlannerHealthWeek.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }




        public DbSet<ReceitaItem> ReceitaItem { get; set; } = default!;
        public DbSet<PlanoAlimentacao> PlanoAlimentacao { get; set; } = default!;
        public DbSet<ItemPlanoAlimentacao> ItemPlanoAlimentacao { get; set; } = default!;
        public DbSet<Receita> Receita { get; set; } = default!;
        public DbSet<Ingrediente> Ingrediente { get; set; } = default!;
        public DbSet<TipoPlano> TipoPlano { get; set; } = default!;
        public DbSet<TipoDieta> TipoDieta { get; set; } = default!;

    }
}