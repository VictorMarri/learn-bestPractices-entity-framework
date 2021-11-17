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


        public dynamic Get()
        {
            return _dbContext.Produtos
                .Include(x => x.CategoriaProduto)
                .Where(x => x.Ativo)
                .Select(x => new
                {
                    x.Nome,
                    x.Preco,
                    Categoria = x.CategoriaProduto.Nome,
                    x.Imagens
                })
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public dynamic Search(string text, int pagina)
        {
            var produtos = _dbContext.Produtos
                .Include(x => x.CategoriaProduto)
                .Where(x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper()) || x.Descricao.ToUpper().Contains(text.ToUpper())))
                .Skip(TamanhoPagina * (pagina - 1))
                .Take(TamanhoPagina)
                .Select(x => new
                {
                    x.Nome,
                    x.Preco,
                    Categoria = x.CategoriaProduto.Nome,
                    x.Imagens
                })
                .OrderBy(x => x.Nome)
                .ToList(); //Precisamos ir no banco de dados e retornar os dados dessa query em forma de lista

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
