using CpmPedidos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain.Entities
{
    public class CategoriaProdutoModel : BaseDomain, IExibivel
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public virtual List<ProdutoModel> Produtos { get;set; }
    }
}
