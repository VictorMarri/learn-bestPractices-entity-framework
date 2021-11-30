using CpmPedidos.Domain.DTOs;
using CpmPedidos.Domain.Entities;
using CpmPedidos.Interface.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CpmPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeControler : AppBaseController
    {
        public CidadeControler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet("Cidade")]
        public dynamic Get()
        {
            return GetService<ICidadeRepository>().Get();
        }

        [HttpPost]
        public int Criar(CidadeDTO model)
        {
            return GetService<ICidadeRepository>().Criar(model);
        }
    }
}
