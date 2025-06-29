-- Tabela de clientes
CREATE TABLE IF NOT EXISTS clientes (
    id UUID PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    status INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS cartoes_credito (
    id UUID PRIMARY KEY,
    cliente_id UUID NOT NULL,
    numero_cartao VARCHAR(20) NOT NULL,
    validade DATE NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES clientes(id)
);

CREATE TABLE IF NOT EXISTS aprovacoes_credito (
    id UUID PRIMARY KEY,
    cliente_id UUID NOT NULL,
    aprovado BOOLEAN NOT NULL,
    data_aprovacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (cliente_id) REFERENCES clientes(id)
);
