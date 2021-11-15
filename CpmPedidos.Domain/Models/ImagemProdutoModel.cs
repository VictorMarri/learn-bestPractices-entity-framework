using CpmPedidos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain.Models
{
    public class ImagemProdutoModel
    {
        public int IdImagem { get; set; }
        public int IdProduto { get; set; }

        public virtual ImagemModel Imagem { get; set; }
        public virtual ProdutoModel Produto { get; set; }
    }
}
