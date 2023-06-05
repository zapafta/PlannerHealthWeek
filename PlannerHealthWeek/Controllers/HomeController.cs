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


        public IActionResult GerarReceita (Guid IdTipoPlano, Guid IdTipoDieta)
        {
           
            PlanoAlimentacao planoAlimentacao = new PlanoAlimentacao();

            planoAlimentacao.StartDate= DateTime.Now;
            planoAlimentacao.EndDate= DateTime.Now;
            //planoAlimentacao.User = "" associate user logged;
            planoAlimentacao.Descricao = "concatenação dos tipos de plano data e user talvez";
            //Todo, genereate items plano de alimentacao
            //Based on tipo de dieta e tipo de plano
            //
            _genericRepositoryPlano.Insert(planoAlimentacao);
            

            return BadRequest();
        }

        public IActionResult Gerarcompras(Guid idPlano)
        {


            //Gerar compras baseado nos planos acima mencionados,
            //Ovos mexidos
            //3 ovos, 3 kg sal, 1 folha de oregaos
            //Criar checklist com todas essas compras
            //PeqAlmoco
             // - 3 ovos, 3 kg sal, 1 folha oregaos,
             //Ordenar a receita de compras pela area do supermercado (tudo na leitaria, tudo no talho etc)

            PlanoAlimentacao planoAlimentacao = new PlanoAlimentacao();

            planoAlimentacao.StartDate = DateTime.Now;
            planoAlimentacao.EndDate = DateTime.Now;
            //planoAlimentacao.User = "" associate user logged;
            planoAlimentacao.Descricao = "concatenação dos tipos de plano data e user talvez";
            //Todo, genereate items plano de alimentacao
            //Based on tipo de dieta e tipo de plano
            //
            _genericRepositoryPlano.Insert(planoAlimentacao);


            return BadRequest();
        }



    }
}