using CpmPedidos.Domain.DTOs;
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
    public class CidadeRepository : BaseRepository, ICidadeRepository
    {

        public CidadeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public dynamic Get()
        {
            return _dbContext.Cidades
                .Where(x => x.Ativo)
                .Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.Uf,
                    x.Ativo
                })
                .ToList();
        }

        public int Criar(CidadeDTO model)
        {
            if (model.Id > 0)
            {
                return 0;
            }

            var nomeDuplicado = _dbContext.Cidades.Any(x => x.Ativo && x.Nome.ToUpper() == model.Nome.ToUpper()); //Se existe algum registro dentro dessa entidade

            if (nomeDuplicado)
            {
                return 0;
            }

            var entity = new CidadeModel()
            {
                Nome = model.Nome,
                Uf = model.Uf,
                Ativo = model.Ativo
            };
            try
            {
                _dbContext.Cidades.Add(entity); //Pegando o banco especifico que queremos adicionar, e adicionando

                _dbContext.SaveChanges(); //Salvar as mudanças para concretizar a alteração ou inserção.

                return entity.Id;

            }
            catch (Exception ex)
            {
            }

            return 0;

        }
    }
}
