using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain.Entities
{
    public class PedidoModel : BaseDomain
    {
        public int IdCliente { get; set; }
        public string Numero { get; set; }
        public decimal ValorTotal { get; set; }
        public TimeSpan Entrega { get; set; }
        public virtual ClienteModel Cliente { get; set; }

        public virtual List<ProdutoPedidoModel> ProdutosPedidos { get; set; }
    }
}
