namespace PlannerHealthWeek.Data.ModelView
{
    public class ElementOfScheduler
    {

        public Enum.MealType MealType { get; set; }
        public string NomeReceita { get; set; }
        public string ReceitaKcal { get; set; }
        public string NutriScoreReceita { get; set; }
        public DateTime DateOfDay { get; set; }

        public DayOfWeek DayOfWeek { get; set; }




        public string NutriScoreDay  { get; set; }
        public double TotalKcalDay { get; set; }
    }
}
