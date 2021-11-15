using CpmPedidos.Domain.Entities;
using CpmPedidos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Repository.Maps
{
    public class ProdutoMap : BaseDomainMap<ProdutoModel>
    {
        public ProdutoMap() : base("tb_produto") { }

        public override void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17,2).IsRequired(); //HasPrecision para decimais
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();
            builder.Property(x => x.IdCategoria).HasColumnName("id_categoria").IsRequired();

            builder.HasOne(x => x.CategoriaProduto)
                .WithMany(x => x.Produtos)
                .HasForeignKey(x => x.IdCategoria)
                .IsRequired();

            builder.HasMany(x => x.Imagens)
                .WithMany(x => x.Produtos)
                .UsingEntity<ImagemProdutoModel>(
                       x => x.HasOne(x => x.Imagem).WithMany().HasForeignKey(x => x.IdImagem),
                       x => x.HasOne(x => x.Produto).WithMany().HasForeignKey(x => x.IdProduto),
                       x =>
                       {
                           x.ToTable("tb_imagem_produto");

                           x.HasKey(x => new { x.IdImagem, x.IdProduto });

                           x.Property(x => x.IdImagem).HasColumnName("id_imagem").IsRequired();
                           x.Property(x => x.IdProduto).HasColumnName("id_produto").IsRequired();
                       }
                );
        }
    }
}
