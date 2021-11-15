using CpmPedidos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain.Entities
{
    public class CidadeModel : BaseDomain, IExibivel
    {
        public string Nome { get; set; }
        public string Uf { get; set; }
        public bool Ativo { get; set; }
    }
}
