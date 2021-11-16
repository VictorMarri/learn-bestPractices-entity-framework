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
        List<ProdutoModel> Get();
        List<ProdutoModel> Search(string text, int pagina);
        ProdutoModel Detail(int id);
    }
}
