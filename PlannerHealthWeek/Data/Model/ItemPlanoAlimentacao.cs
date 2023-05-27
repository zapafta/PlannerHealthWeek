using PlannerHealthWeek.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerHealthWeek.Data.Model
{
    public class ItemPlanoAlimentacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MealPlanItemId { get; set; }
        [Required]
        public MealType MealType { get; set; }
        [Required]
        public Receita Receita { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey("PlanoAlimentacao")]
        public int IdPlanoAlimentacao { get; set; }
        public PlanoAlimentacao PlanoAlimentacao { get; set; }
    }
}
