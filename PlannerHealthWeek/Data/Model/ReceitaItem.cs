﻿using PlannerHealthWeek.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlannerHealthWeek.Data.Model
{
    public class ReceitaItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ReceitaItemId { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }

        public double Qty { get; set; }


        [Required]
        public Ingrediente Ingrediente { get; set; }
       
        [Required]
        [ForeignKey("Receita")]
        public Guid IdReceita { get; set; }
        public  Receita Receita { get; set; }

    }
}
