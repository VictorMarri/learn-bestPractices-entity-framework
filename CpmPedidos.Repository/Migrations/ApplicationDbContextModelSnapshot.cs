﻿// <auto-generated />
using System;
using CpmPedidos.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CpmPedidos.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CpmPedidos.Domain.Entities.CategoriaProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_categoria_produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.CidadeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("uf");

                    b.HasKey("Id");

                    b.ToTable("tb_cidade");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.ClienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("integer")
                        .HasColumnName("id_endereco");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco")
                        .IsUnique();

                    b.ToTable("tb_cliente");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.ComboModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<int>("IdImagem")
                        .HasColumnType("integer")
                        .HasColumnName("id_imagem");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.Property<decimal>("Preco")
                        .HasPrecision(17, 2)
                        .HasColumnType("numeric(17,2)")
                        .HasColumnName("preco");

                    b.HasKey("Id");

                    b.HasIndex("IdImagem");

                    b.ToTable("tb_combo");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.EnderecoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)")
                        .HasColumnName("cep");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("complemento");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<int>("IdCidade")
                        .HasColumnType("integer")
                        .HasColumnName("id_cidade");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("logradouro");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("numero");

                    b.Property<int>("TipoEndereco")
                        .HasColumnType("integer")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.HasIndex("IdCidade");

                    b.ToTable("tb_endereco");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.ImagemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("nome");

                    b.Property<string>("NomeArquivo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("nome_arquivo");

                    b.Property<bool>("Principal")
                        .HasColumnType("boolean")
                        .HasColumnName("principal");

                    b.HasKey("Id");

                    b.ToTable("tb_imagem");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.PedidoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<TimeSpan>("Entrega")
                        .HasColumnType("interval")
                        .HasColumnName("entrega");

                    b.Property<int>("IdCliente")
                        .HasColumnType("integer")
                        .HasColumnName("id_cliente");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("numero");

                    b.Property<decimal>("ValorTotal")
                        .HasPrecision(17, 2)
                        .HasColumnType("numeric(17,2)")
                        .HasColumnName("valor_total");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.ToTable("tb_pedido");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.ProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("codigo");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("descricao");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("integer")
                        .HasColumnName("id_categoria");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.Property<decimal>("Preco")
                        .HasPrecision(17, 2)
                        .HasColumnType("numeric(17,2)")
                        .HasColumnName("preco");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("tb_produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.ProdutoPedidoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<int>("IdPedido")
                        .HasColumnType("integer")
                        .HasColumnName("id_pedido");

                    b.Property<int>("IdProduto")
                        .HasColumnType("integer")
                        .HasColumnName("id_produto");

                    b.Property<decimal>("Preco")
                        .HasPrecision(17, 2)
                        .HasColumnType("numeric(17,2)")
                        .HasColumnName("preco");

                    b.Property<int>("Quantidade")
                        .HasPrecision(2)
                        .HasColumnType("integer")
                        .HasColumnName("quantidade");

                    b.HasKey("Id");

                    b.HasIndex("IdPedido");

                    b.HasIndex("IdProduto");

                    b.ToTable("tb_produto_pedido");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.PromocaoProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<int>("IdImagem")
                        .HasColumnType("integer")
                        .HasColumnName("id_imagem");

                    b.Property<int>("IdProduto")
                        .HasColumnType("integer")
                        .HasColumnName("id_produto");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nome");

                    b.Property<decimal>("Preco")
                        .HasPrecision(17, 2)
                        .HasColumnType("numeric(17,2)")
                        .HasColumnName("preco");

                    b.HasKey("Id");

                    b.HasIndex("IdImagem");

                    b.HasIndex("IdProduto");

                    b.ToTable("tb_promocao_produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Models.ImagemProdutoModel", b =>
                {
                    b.Property<int>("IdImagem")
                        .HasColumnType("integer")
                        .HasColumnName("id_imagem");

                    b.Property<int>("IdProduto")
                        .HasColumnType("integer")
                        .HasColumnName("id_produto");

                    b.HasKey("IdImagem", "IdProduto");

                    b.HasIndex("IdProduto");

                    b.ToTable("tb_imagem_produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Models.ProdutoComboModel", b =>
                {
                    b.Property<int>("IdProduto")
                        .HasColumnType("integer")
                        .HasColumnName("id_produto");

                    b.Property<int>("IdCombo")
                        .HasColumnType("integer")
                        .HasColumnName("id_combo");

                    b.HasKey("IdProduto", "IdCombo");

                    b.HasIndex("IdCombo");

                    b.ToTable("tb_produto_combo");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.ClienteModel", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Entities.EnderecoModel", "Endereco")
                        .WithOne("Cliente")
                        .HasForeignKey("CpmPedidos.Domain.Entities.ClienteModel", "IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.ComboModel", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Entities.ImagemModel", "Imagem")
                        .WithMany()
                        .HasForeignKey("IdImagem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imagem");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.EnderecoModel", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Entities.CidadeModel", "Cidade")
                        .WithMany()
                        .HasForeignKey("IdCidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.PedidoModel", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Entities.ClienteModel", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.ProdutoModel", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Entities.CategoriaProdutoModel", "CategoriaProduto")
                        .WithMany("Produtos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaProduto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.ProdutoPedidoModel", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Entities.PedidoModel", "Pedido")
                        .WithMany("ProdutosPedidos")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CpmPedidos.Domain.Entities.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.PromocaoProdutoModel", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Entities.ImagemModel", "Imagem")
                        .WithMany()
                        .HasForeignKey("IdImagem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CpmPedidos.Domain.Entities.ProdutoModel", "Produto")
                        .WithMany("Promocoes")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imagem");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Models.ImagemProdutoModel", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Entities.ImagemModel", "Imagem")
                        .WithMany()
                        .HasForeignKey("IdImagem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CpmPedidos.Domain.Entities.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imagem");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Models.ProdutoComboModel", b =>
                {
                    b.HasOne("CpmPedidos.Domain.Entities.ComboModel", "Combo")
                        .WithMany()
                        .HasForeignKey("IdCombo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CpmPedidos.Domain.Entities.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Combo");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.CategoriaProdutoModel", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.ClienteModel", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.EnderecoModel", b =>
                {
                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.PedidoModel", b =>
                {
                    b.Navigation("ProdutosPedidos");
                });

            modelBuilder.Entity("CpmPedidos.Domain.Entities.ProdutoModel", b =>
                {
                    b.Navigation("Promocoes");
                });
#pragma warning restore 612, 618
        }
    }
}
