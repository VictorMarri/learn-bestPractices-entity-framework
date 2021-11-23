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

        private void OrdenarPorNome(IQueryable<ProdutoModel> query, string ordem)
        {
            if (string.IsNullOrEmpty(ordem) || ordem.ToUpper() == "ASC")
            {
                query = query.OrderBy(x => x.Nome);
            }
            else
            {
                query = query.OrderByDescending(x => x.Nome);
            }
        }

        public dynamic Get(string ordem)
        {
            var queryProduto = _dbContext.Produtos
                .Include(x => x.CategoriaProduto)
                .Where(x => x.Ativo);

            OrdenarPorNome(queryProduto, ordem);

            var queryRetorno = queryProduto
                .Select(x => new
            {
                x.Nome,
                x.Preco,
                Categoria = x.CategoriaProduto.Nome,
                x.Imagens
            });

            return queryRetorno.ToList();
        }

        public dynamic Search(string text, int pagina, string ordem)
        {
            var queryProduto = _dbContext.Produtos
                .Include(x => x.CategoriaProduto)
                .Where(x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper()) || x.Descricao.ToUpper().Contains(text.ToUpper())))
                .Skip(TamanhoPagina * (pagina - 1))
                .Take(TamanhoPagina);

            OrdenarPorNome(queryProduto, ordem);

            var queryRetorno = queryProduto
                .Select(x => new
                {
                    x.Nome,
                    x.Preco,
                    Categoria = x.CategoriaProduto.Nome,
                    x.Imagens
                });

            var produtos = queryRetorno.ToList();

            var quantidadeProdutos = _dbContext.Produtos.Where(x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper()) || x.Descricao.ToUpper().Contains(text.ToUpper()))).Count();

            var quantidadePaginas = (quantidadeProdutos / TamanhoPagina);

            if (quantidadePaginas < 1)
            {
                quantidadePaginas = 1;
            }

            return new { produtos, quantidadePaginas };

        }

        public dynamic Detail(int id)
        {
            return _dbContext.Produtos
                .Include(x => x.Imagens)
                .Include(x => x.CategoriaProduto)
                .Where(x => x.Ativo && x.Id == id)
                .Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.Codigo,
                    x.Descricao,
                    x.Preco,
                    Categoria = new
                    {
                        x.CategoriaProduto.Id,
                        x.CategoriaProduto.Nome
                    },
                    Imagens = x.Imagens.Select(x => new 
                    { 
                        x.Id,
                        x.Nome,
                        x.NomeArquivo
                    })
                })
                .FirstOrDefault();
        }

        public dynamic Imagens(int id)
        {
            return _dbContext.Produtos
                .Include(x => x.Imagens)
                .Where(x => x.Ativo && x.Id == id)
                .SelectMany(x => x.Imagens, (produto, imagem) => new
                {
                    IdProduto = produto.Id,
                    imagem.Id,
                    imagem.Nome,
                    imagem.NomeArquivo
                })
                .FirstOrDefault();
        }

    }
}
