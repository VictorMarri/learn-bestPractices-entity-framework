using CpmPedidos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain.Entities
{
    public class PromocaoProdutoModel : BaseDomain, IExibivel
    {
        public int IdImagem { get; set; }
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }

        public virtual ImagemModel Imagem { get; set; }
        public virtual ProdutoModel Produto { get; set; }
    }
}
