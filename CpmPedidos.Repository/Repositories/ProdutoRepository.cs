using CpmPedidos.Domain.Entities;
using CpmPedidos.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Repository.Repositories
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {

        public ProdutoRepository(ApplicationDbContext dbContext):base(dbContext)
        {
        }

        public List<ProdutoModel> Get()
        {
            return _dbContext.Produtos.ToList();
        }
    }
}
