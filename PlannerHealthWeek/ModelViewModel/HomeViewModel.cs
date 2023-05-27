using PlannerHealthWeek.Data.Model;
using PlannerHealthWeek.Data.ModelView;

namespace PlannerHealthWeek.ModelViewModel
{
    public class HomeViewModel
    {
            public List<TipoPlano> TipoPlanos { get; set; }
            public List<TipoDieta> TipoDieta { get; set; }
            public List<ElementOfScheduler> ElementOfScheduler { get; set; }

    }
}
