using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clima.Application.Models;
using Clima.Application.Context;


namespace Clima.Application.Repository
{
    public class PrevisaoClimaRepository
    {
        private readonly efDBContext db = new efDBContext();

        public List<PrevisaoClimaModel> ListaCidadesQuentes()
        {
            DateTime dataAtual = DateTime.Now.Date;
            var cidadesQuentes = from cidQuentes in db.PrevisaoClima.Where(cq => cq.DataPrevisao == dataAtual).OrderByDescending(cq => cq.TemperaturaMaxima).Take(3) select cidQuentes;
            List<PrevisaoClimaModel> listCidadesQuentes = cidadesQuentes.ToList<PrevisaoClimaModel>();
            return listCidadesQuentes;
        }

        public List<PrevisaoClimaModel> ListaCidadesFrias()
        {
            DateTime dataAtual = DateTime.Now.Date;
            var cidadesFrias = from cidFrias in db.PrevisaoClima.Where(cq => cq.DataPrevisao == dataAtual).OrderBy(cf => cf.TemperaturaMinima).Take(3) select cidFrias;
            List<PrevisaoClimaModel> listCidadesFrias = cidadesFrias.ToList<PrevisaoClimaModel>();
            return listCidadesFrias;
        }

        public List<PrevisaoClimaModel> ListaClimaProximosSeteDiasPorCidade(int codCidade)
        {
            DateTime dataAtual = DateTime.Now.Date;
            var previsao = from p in db.PrevisaoClima
                           select p;
            List<PrevisaoClimaModel> previsaoList = previsao.Where(p => p.CidadeId == codCidade && p.DataPrevisao >= dataAtual).OrderBy(p => p.DataPrevisao).Take(7).ToList<PrevisaoClimaModel>();
            return previsaoList;
        }

    }
}