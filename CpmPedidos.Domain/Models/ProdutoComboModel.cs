using CpmPedidos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain.Models
{
    public class ProdutoComboModel
    {
        public int IdProduto { get; set; }
        public int IdCombo { get; set; }

        public virtual ProdutoModel Produto { get; set; }
        public virtual ComboModel Combo { get; set; }
    }
}
