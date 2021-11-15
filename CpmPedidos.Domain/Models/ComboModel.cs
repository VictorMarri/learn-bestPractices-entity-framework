
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain.Entities
{
    public class ComboModel : BaseDomain
    {
        public int IdImagem { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public virtual List<ProdutoModel> Produtos { get; set; }
        public virtual ImagemModel Imagem { get; set; }
    }
}
