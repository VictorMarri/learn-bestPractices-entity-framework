using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain.Entities
{
    public class ProdutoPedidoModel : BaseDomain
    {
        public int IdProduto { get; set; }
        public int IdPedido { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public virtual ProdutoModel Produto { get; set; }
        public virtual PedidoModel Pedido { get; set; }
    }
}
