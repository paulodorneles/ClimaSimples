using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clima.Application.Models;
using Clima.Application.Repository;

namespace Clima.Application.Controllers
{
    public class HomeController : Controller
    {        
        PrevisaoClimaRepository climaRepository = new PrevisaoClimaRepository();
        public ActionResult Index()
        {           
            List<PrevisaoClimaModel> listCidadesFrias = climaRepository.ListaCidadesFrias();
            List<PrevisaoClimaModel> listVazia = new List<PrevisaoClimaModel>();
            List<PrevisaoClimaModel> listCidadesQuentes = climaRepository.ListaCidadesQuentes();

            ViewData["CidadesQuentes"] = listCidadesQuentes;
            ViewData["CidadesFrias"] = listCidadesFrias;
            ViewData["PrevisaoSeteDiasPorCidade"] = listVazia;
            return View();
        }

        [HttpGet]
        public PartialViewResult PrevisaoProximosSeteDiasGet(int codCidade)
        {          
            List<PrevisaoClimaModel> previsaoList = climaRepository.ListaClimaProximosSeteDiasPorCidade(codCidade);
            ViewBag.cidadesearch = "Clima para os próximos sete dias na cidade de " + previsaoList.First<PrevisaoClimaModel>().Cidade.Nome;
            return PartialView("PrevisaoSeteDiasPorCidade", previsaoList);
        }

        [HttpPost]
        public JsonResult BuscarCidades(string prefix)
        {
            CidadeRepository cidRep = new CidadeRepository();
            var cidades = cidRep.ListarCidades(prefix);       
            return Json(cidades);
        }        

        public ActionResult Contact()
        {            
            return View();
        }
    }
}