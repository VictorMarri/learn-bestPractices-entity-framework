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

        public dynamic PedidosClientes()
        {
            var hoje = DateTime.Today;
            var inicioMes = new DateTime(hoje.Year, hoje.Month, 1);
            var finalMes = new DateTime(hoje.Year, hoje.Month, DateTime.DaysInMonth(hoje.Year, hoje.Month));

            return _dbContext.Pedidos
                .Where(x => x.CriadoEm.Date >= inicioMes && x.CriadoEm.Date <= finalMes)
                .GroupBy(pedido => new { pedido.IdCliente, pedido.Cliente.Nome })
                .Select(x => new
                {
                    Cliente = x.Key.Nome,
                    Pedidos = x.Count(),
                    Total = x.Sum(x => x.ValorTotal)
                })
                .ToList();
        }
    }
}
