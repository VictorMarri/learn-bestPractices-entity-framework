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
    public class PedidoController : AppBaseController
    {
        public PedidoController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet]
        [Route("ticket-maximo")]
        public decimal TicketMaximo()
        {
            var repositorio = (IPedidoRepository)_serviceProvider.GetService(typeof(IPedidoRepository));

            return repositorio.TicketMaximo();
        }

    }
}
