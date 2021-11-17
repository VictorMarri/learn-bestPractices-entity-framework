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
    public class PedidoRepository : BaseRepository, IPedidoRepository
    {

        public PedidoRepository(ApplicationDbContext dbContext):base(dbContext)
        {
        }

        public decimal TicketMaximo()
        {
            var hoje = DateTime.Today;

            return _dbContext.Pedidos
                .Where(x => x.CriadoEm.Date == hoje)
                .Max(x => (decimal?)x.ValorTotal) ?? 0;
        }
    }
}
