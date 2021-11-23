using CpmPedidos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Interface.Repositories
{
    public interface IProdutoRepository
    {
        dynamic Get(string ordem);
        dynamic Search(string text, int pagina, string ordem);
        dynamic Detail(int id);

        dynamic Imagens(int id);
    }
}
