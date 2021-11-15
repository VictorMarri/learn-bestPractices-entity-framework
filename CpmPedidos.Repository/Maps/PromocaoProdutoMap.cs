using CpmPedidos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Repository.Maps
{
    public class PromocaoProdutoMap : BaseDomainMap<PromocaoProdutoModel>
    {
        public PromocaoProdutoMap() : base("tb_promocao_produto") { }

        public override void Configure(EntityTypeBuilder<PromocaoProdutoModel> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17,2).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();
            builder.Property(x => x.IdImagem).HasColumnName("id_imagem").IsRequired();
            builder.Property(x => x.IdProduto).HasColumnName("id_produto").IsRequired();

            builder.HasOne(x => x.Imagem)
                .WithMany()
                .HasForeignKey(x => x.IdImagem);

            builder.HasOne(x => x.Produto)
                .WithMany(x => x.Promocoes)
                .HasForeignKey(x => x.IdProduto);
        }
    }
}
