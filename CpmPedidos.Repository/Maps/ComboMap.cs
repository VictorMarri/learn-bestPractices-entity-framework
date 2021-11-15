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
    public class ComboMap : BaseDomainMap<ComboModel>
    {
        public ComboMap() : base("tb_combo") { }

        public override void Configure(EntityTypeBuilder<ComboModel> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.IdImagem).HasColumnName("id_imagem").IsRequired();

            builder.HasOne(x => x.Imagem)
                .WithMany()
                .HasForeignKey(x => x.IdImagem);

            builder.HasMany(x => x.Produtos)
                   .WithMany(x => x.Combos)
                   .UsingEntity<ProdutoComboModel>(
                            x => x.HasOne(y => y.Produto).WithMany().HasForeignKey(x => x.IdProduto),
                            x => x.HasOne(y => y.Combo).WithMany().HasForeignKey(x => x.IdCombo),
                            x =>
                            {
                                x.ToTable("tb_produto_combo");

                                x.HasKey(x => new { x.IdProduto, x.IdCombo });

                                x.Property(x => x.IdProduto).HasColumnName("id_produto").IsRequired();
                                x.Property(x => x.IdCombo).HasColumnName("id_combo").IsRequired();
                            }
                   );
        }
    }
}
