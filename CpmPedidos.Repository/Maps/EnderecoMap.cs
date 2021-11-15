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
    public class EnderecoMap : BaseDomainMap<EnderecoModel>
    {
        public EnderecoMap(): base("tb_endereco")
        {
        }

        public override void Configure(EntityTypeBuilder<EnderecoModel> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.TipoEndereco).HasColumnName("tipo").IsRequired();
            builder.Property(x => x.Logradouro).HasColumnName("logradouro").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Bairro).HasColumnName("bairro").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Numero).HasColumnName("numero").HasMaxLength(10).IsRequired();
            builder.Property(x => x.Complemento).HasColumnName("complemento").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Cep).HasColumnName("cep").HasMaxLength(8).IsRequired();

            builder.Property(x => x.IdCidade).HasColumnName("id_cidade").IsRequired();

            builder.HasOne(x => x.Cliente)
                .WithOne(x => x.Endereco)
                .HasForeignKey<ClienteModel>(x => x.IdEndereco);

            builder.HasOne(x => x.Cidade)
                .WithMany()
                .HasForeignKey(x => x.IdCidade);
        }
    }
}
