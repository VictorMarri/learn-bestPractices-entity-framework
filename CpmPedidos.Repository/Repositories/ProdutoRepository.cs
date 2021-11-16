using CpmPedidos.Domain.Entities;
using CpmPedidos.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
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
            return _dbContext.Produtos
                .Include(x => x.CategoriaProduto)
                .Where(x => x.Ativo)
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public List<ProdutoModel> Search(string text, int pagina)
        {
            return _dbContext.Produtos
                .Include(x => x.CategoriaProduto)
                .Where(x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper()) || x.Descricao.ToUpper().Contains(text.ToUpper())))
                .Skip(TamanhoPagina * (pagina - 1))
                .Take(TamanhoPagina)
                .ToList(); //Precisamos ir no banco de dados e retornar os dados dessa query em forma de lista
        }

        public ProdutoModel Detail(int id)
        {
            return _dbContext.Produtos
                .Include(x => x.Imagens)
                .Include(x => x.CategoriaProduto)
                .Where(x => x.Ativo && x.Id == id)
                .FirstOrDefault();
        }

    }
}
