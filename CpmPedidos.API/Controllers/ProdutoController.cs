using CpmPedidos.Domain.Entities;
using CpmPedidos.Interface.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CpmPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : AppBaseController
    {
        public ProdutoController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet]
        public IEnumerable<ProdutoModel> Get()
        {
            var repositorio = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));

            return repositorio.Get();
        }

        [HttpGet]
        [Route("search/{text}/{pagina?}")]
        public IEnumerable<ProdutoModel> GetSearch(string text, int pagina =1)
        {
            var repositorio = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));

            return repositorio.Search(text, pagina);
        }

        [HttpGet]
        [Route("{id}")]
        public ProdutoModel Detail(int? id)
        {
            if ((id ?? 0) > 0)
            {
                var repositorio = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));

                return repositorio.Detail(id.Value);
            }

            else
            {
                return null;
            }
        }

    }
}
