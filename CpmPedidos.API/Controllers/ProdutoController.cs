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
        public ProdutoController(IServiceProvider serviceProvider):base(serviceProvider)
        {
        }

        [HttpGet]
        public IEnumerable<ProdutoModel> Get()
        {
            var repositorio = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));

            return repositorio.Get();
        }
    }
}
