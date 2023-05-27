using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlannerHealthWeek.Data.Model;

namespace PlannerHealthWeek.Data
{
    public class ApplicationDbContext : IdentityDbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }




        public DbSet<ReceitaItem> ReceitaItem { get; set; } = default!;
        public DbSet<MealPlan> MealPlan { get; set; } = default!;
        public DbSet<MealPlanItem> MealPlanItem { get; set; } = default!;
        public DbSet<Receita> Recipe { get; set; } = default!;
        public DbSet<Ingrediente> Ingredient { get; set; } = default!;
        public DbSet<TipoPlano> TipoPlano { get; set; } = default!;
        public DbSet<TipoDieta> TipoDieta { get; set; } = default!;

    }
}