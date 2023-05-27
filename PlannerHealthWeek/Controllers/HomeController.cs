using Microsoft.AspNetCore.Mvc;
using PlannerHealthWeek.Data.Model;
using PlannerHealthWeek.Data.Repository;
using PlannerHealthWeek.Models;
using PlannerHealthWeek.ModelViewModel;
using System.Diagnostics;

namespace PlannerHealthWeek.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GenericRepository<TipoPlano> _genericRepositoryTipoPlano;
        private readonly GenericRepository<TipoDieta> _genericRepositoryTipoDieta;
        private readonly GenericRepository<PlanoAlimentacao> _genericRepositoryPlano;

        public HomeController(ILogger<HomeController> logger,
            
            GenericRepository<TipoPlano> genericTipoPlano, GenericRepository<TipoDieta> genericTipoDieta , GenericRepository<PlanoAlimentacao> genericRepositoryPlano


            )
        {
            _logger = logger;
            _genericRepositoryTipoPlano = genericTipoPlano;
            _genericRepositoryTipoDieta = genericTipoDieta;
            _genericRepositoryPlano= genericRepositoryPlano;

        }

        public IActionResult Index()
        {


            HomeViewModel homeViewModel = new();


            if (User.Identity.IsAuthenticated)
            {



                homeViewModel.TipoPlanos = _genericRepositoryTipoPlano.GetAll();
                homeViewModel.TipoDieta = _genericRepositoryTipoDieta.GetAll();

                var LoggedUser = User.Identity.Name.ToString();


                homeViewModel.ElementOfScheduler = _genericRepositoryPlano.GetByDate(DateTime.Now, DateTime.Now, LoggedUser);

            }

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}