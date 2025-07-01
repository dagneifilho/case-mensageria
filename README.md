# Microsserviços com .NET, RabbitMQ e PostgreSQL

Este projeto é composto por três microsserviços construídos em .NET 8, que se comunicam entre si via mensagens assíncronas com RabbitMQ, utilizando PostgreSQL como banco de dados.

---

## 📦 Serviços

- **ClienteService** – Responsável por cadastro de clientes (API REST).
- **CreditoService** – Responsável por análise de crédito (Worker).
- **CartaoCreditoService** – Responsável por emissão de cartões (Worker).

---

## 🔗 Dependências

- **[Docker](https://www.docker.com/)**
- **[Docker Compose](https://docs.docker.com/compose/)**
- **RabbitMQ** – Broker de mensagens AMQP.
- **PostgreSQL** – Banco de dados relacional.

---

## ▶️ Como rodar

### 1. Clone o repositório

```bash
git clone https://github.com/dagneifilho/case-mensageria
cd case-mensageria
```
### 2. Suba os containers com Docker Compose
```
docker compose up --build
```
## 🌐 Acessos

| Serviço              | URL/Porta                 | Descrição                                   |
|----------------------|---------------------------|---------------------------------------------|
| ClienteService API   | [http://localhost:5080](http://localhost:5080) | API de cadastro de clientes                |
| RabbitMQ UI          | [http://localhost:15672](http://localhost:15672) | Interface de administração RabbitMQ (user:`guest`, senha:`guest`)        |
| PostgreSQL           | localhost:5432            | Acesso ao banco (user: `postgres`, senha: `minha_senha`)         |
