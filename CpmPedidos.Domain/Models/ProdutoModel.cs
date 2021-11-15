using CpmPedidos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain.Entities
{
    public class ProdutoModel : BaseDomain, IExibivel
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }

        public virtual CategoriaProdutoModel CategoriaProduto { get; set; }
        public virtual List<ComboModel> Combos { get; set; }
        public virtual List<ImagemModel> Imagens { get; set; }

        public virtual List<PromocaoProdutoModel> Promocoes { get; set; }
    }
}
