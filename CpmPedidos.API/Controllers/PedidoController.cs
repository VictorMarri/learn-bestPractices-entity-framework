using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CpmPedidos.API.Controllers
{
    public class PedidoController : AppBaseController
    {
        public PedidoController(IServiceProvider serviceProvider):base(serviceProvider)
        {
        }
    }
}
