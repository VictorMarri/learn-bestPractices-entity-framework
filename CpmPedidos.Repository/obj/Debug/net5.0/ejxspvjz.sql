﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE tb_categoria_produto (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    nome character varying(50) NOT NULL,
    ativo boolean NOT NULL,
    criado_em timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tb_categoria_produto" PRIMARY KEY (id)
);

CREATE TABLE tb_cidade (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    nome character varying(100) NOT NULL,
    uf character varying(2) NOT NULL,
    ativo boolean NOT NULL,
    criado_em timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tb_cidade" PRIMARY KEY (id)
);

CREATE TABLE tb_imagem (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    nome character varying(20) NOT NULL,
    nome_arquivo character varying(20) NOT NULL,
    principal boolean NOT NULL,
    criado_em timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tb_imagem" PRIMARY KEY (id)
);

CREATE TABLE tb_produto (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    id_categoria integer NOT NULL,
    nome character varying(50) NOT NULL,
    codigo character varying(50) NOT NULL,
    descricao character varying(50) NOT NULL,
    preco numeric(17,2) NOT NULL,
    ativo boolean NOT NULL,
    criado_em timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tb_produto" PRIMARY KEY (id),
    CONSTRAINT "FK_tb_produto_tb_categoria_produto_id_categoria" FOREIGN KEY (id_categoria) REFERENCES tb_categoria_produto (id) ON DELETE CASCADE
);

CREATE TABLE tb_endereco (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    tipo integer NOT NULL,
    logradouro character varying(50) NOT NULL,
    bairro character varying(50) NOT NULL,
    numero character varying(10) NOT NULL,
    complemento character varying(50) NOT NULL,
    cep character varying(8) NOT NULL,
    id_cidade integer NOT NULL,
    criado_em timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tb_endereco" PRIMARY KEY (id),
    CONSTRAINT "FK_tb_endereco_tb_cidade_id_cidade" FOREIGN KEY (id_cidade) REFERENCES tb_cidade (id) ON DELETE CASCADE
);

CREATE TABLE tb_combo (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    id_imagem integer NOT NULL,
    nome character varying(50) NOT NULL,
    preco numeric(17,2) NOT NULL,
    criado_em timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tb_combo" PRIMARY KEY (id),
    CONSTRAINT "FK_tb_combo_tb_imagem_id_imagem" FOREIGN KEY (id_imagem) REFERENCES tb_imagem (id) ON DELETE CASCADE
);

CREATE TABLE tb_imagem_produto (
    id_imagem integer NOT NULL,
    id_produto integer NOT NULL,
    CONSTRAINT "PK_tb_imagem_produto" PRIMARY KEY (id_imagem, id_produto),
    CONSTRAINT "FK_tb_imagem_produto_tb_imagem_id_imagem" FOREIGN KEY (id_imagem) REFERENCES tb_imagem (id) ON DELETE CASCADE,
    CONSTRAINT "FK_tb_imagem_produto_tb_produto_id_produto" FOREIGN KEY (id_produto) REFERENCES tb_produto (id) ON DELETE CASCADE
);

CREATE TABLE tb_promocao_produto (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    id_imagem integer NOT NULL,
    id_produto integer NOT NULL,
    nome character varying(50) NOT NULL,
    preco numeric(17,2) NOT NULL,
    ativo boolean NOT NULL,
    criado_em timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tb_promocao_produto" PRIMARY KEY (id),
    CONSTRAINT "FK_tb_promocao_produto_tb_imagem_id_imagem" FOREIGN KEY (id_imagem) REFERENCES tb_imagem (id) ON DELETE CASCADE,
    CONSTRAINT "FK_tb_promocao_produto_tb_produto_id_produto" FOREIGN KEY (id_produto) REFERENCES tb_produto (id) ON DELETE CASCADE
);

CREATE TABLE tb_cliente (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    nome character varying(50) NOT NULL,
    cpf character varying(11) NOT NULL,
    id_endereco integer NOT NULL,
    ativo boolean NOT NULL,
    criado_em timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tb_cliente" PRIMARY KEY (id),
    CONSTRAINT "FK_tb_cliente_tb_endereco_id_endereco" FOREIGN KEY (id_endereco) REFERENCES tb_endereco (id) ON DELETE CASCADE
);

CREATE TABLE tb_produto_combo (
    id_produto integer NOT NULL,
    id_combo integer NOT NULL,
    CONSTRAINT "PK_tb_produto_combo" PRIMARY KEY (id_produto, id_combo),
    CONSTRAINT "FK_tb_produto_combo_tb_combo_id_combo" FOREIGN KEY (id_combo) REFERENCES tb_combo (id) ON DELETE CASCADE,
    CONSTRAINT "FK_tb_produto_combo_tb_produto_id_produto" FOREIGN KEY (id_produto) REFERENCES tb_produto (id) ON DELETE CASCADE
);

CREATE TABLE tb_pedido (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    id_cliente integer NOT NULL,
    numero character varying(10) NOT NULL,
    valor_total numeric(17,2) NOT NULL,
    entrega interval NOT NULL,
    criado_em timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tb_pedido" PRIMARY KEY (id),
    CONSTRAINT "FK_tb_pedido_tb_cliente_id_cliente" FOREIGN KEY (id_cliente) REFERENCES tb_cliente (id) ON DELETE CASCADE
);

CREATE TABLE tb_produto_pedido (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    id_produto integer NOT NULL,
    id_pedido integer NOT NULL,
    quantidade integer NOT NULL,
    preco numeric(17,2) NOT NULL,
    criado_em timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tb_produto_pedido" PRIMARY KEY (id),
    CONSTRAINT "FK_tb_produto_pedido_tb_pedido_id_pedido" FOREIGN KEY (id_pedido) REFERENCES tb_pedido (id) ON DELETE CASCADE,
    CONSTRAINT "FK_tb_produto_pedido_tb_produto_id_produto" FOREIGN KEY (id_produto) REFERENCES tb_produto (id) ON DELETE CASCADE
);

CREATE UNIQUE INDEX "IX_tb_cliente_id_endereco" ON tb_cliente (id_endereco);

CREATE INDEX "IX_tb_combo_id_imagem" ON tb_combo (id_imagem);

CREATE INDEX "IX_tb_endereco_id_cidade" ON tb_endereco (id_cidade);

CREATE INDEX "IX_tb_imagem_produto_id_produto" ON tb_imagem_produto (id_produto);

CREATE INDEX "IX_tb_pedido_id_cliente" ON tb_pedido (id_cliente);

CREATE INDEX "IX_tb_produto_id_categoria" ON tb_produto (id_categoria);

CREATE INDEX "IX_tb_produto_combo_id_combo" ON tb_produto_combo (id_combo);

CREATE INDEX "IX_tb_produto_pedido_id_pedido" ON tb_produto_pedido (id_pedido);

CREATE INDEX "IX_tb_produto_pedido_id_produto" ON tb_produto_pedido (id_produto);

CREATE INDEX "IX_tb_promocao_produto_id_imagem" ON tb_promocao_produto (id_imagem);

CREATE INDEX "IX_tb_promocao_produto_id_produto" ON tb_promocao_produto (id_produto);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20211115013043_PrimeiraMigration', '5.0.12');

COMMIT;

