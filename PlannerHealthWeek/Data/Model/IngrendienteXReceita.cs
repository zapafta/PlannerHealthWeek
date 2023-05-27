using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlannerHealthWeek.Data.Model
{
    public class IngrendienteXReceita
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public double Quantity { get; set; }



        public Receita Recipe { get; set; }


        public Ingrediente Ingredients { get; set; }

    }
}
