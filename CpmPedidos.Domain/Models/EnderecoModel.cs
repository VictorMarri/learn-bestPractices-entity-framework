using CpmPedidos.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain.Entities
{
    public class EnderecoModel : BaseDomain
    {
        public TipoEndereco TipoEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }

        public int IdCidade { get; set; }
        public virtual CidadeModel Cidade { get; set; }

        public virtual ClienteModel Cliente { get; set; }
    }
}
