using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clima.Application.Context;

namespace Clima.Application.Repository
{
    public class CidadeRepository
    {
        private readonly efDBContext db = new efDBContext();

        public object ListarCidades(string descCidade)
        {
            var cidades = (from cid in db.Cidade
                           where cid.Nome.StartsWith(descCidade)
                           select new
                           {
                               label = cid.Nome,
                               val = cid.Id
                           }).ToList();
            return cidades;
        }
    }
}