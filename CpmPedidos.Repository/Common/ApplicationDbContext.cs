using CpmPedidos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CidadeModel> Cidades { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<CategoriaProdutoModel> CategoriasProdutos { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<PromocaoProdutoModel> PromocoesProdutos { get; set; }
        public DbSet<ComboModel> Combos { get; set; }
        public DbSet<PedidoModel> Pedidos  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public ApplicationDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
