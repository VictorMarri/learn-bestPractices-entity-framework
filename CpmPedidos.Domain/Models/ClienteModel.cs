using CpmPedidos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain.Entities
{
    public class ClienteModel : BaseDomain, IExibivel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int IdEndereco { get; set; }
        public bool Ativo { get; set; }

        public virtual EnderecoModel Endereco { get; set; }
        public virtual List<PedidoModel> Pedidos { get; set; }
    }
}
