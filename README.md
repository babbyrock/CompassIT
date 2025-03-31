# CompassIT

## Projeto de Controle de Inventário de Produtos

Este projeto é uma aplicação backend simples desenvolvida em **ASP.NET Core** para gerenciar o controle de inventário de produtos. O sistema oferece operações básicas de CRUD (Criar, Ler, Atualizar, Excluir) para gerenciar os produtos no estoque.

Fiz além de GET, como foi solicitado no teste, implementando também as operações de criação, atualização e exclusão.

## Visão Geral

Para popular os dados e criar as tabelas no banco de dados, resolvi utilizar **migrations**. Basta executar o comando `update-database` pelo **Package Manager Console** para aplicar as migrations e garantir que o banco de dados esteja atualizado e populado com os dados iniciais.

Caso não consiga criar a tabela e popular os dados pela migration, você pode executar manualmente os comandos SQL abaixo.

### Código SQL para Criação e Inserção de Dados

```sql
-- Criação da Tabela Produtos
CREATE TABLE Produto (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100),
    Preco DECIMAL(18, 2),
    Quantidade INT
);

-- Inserção de Dados Iniciais
INSERT INTO Produto (Nome, Preco, Quantidade)
VALUES 
    ('Produto A', 10.50, 100),
    ('Produto B', 20.00, 200),
    ('Produto C', 30.75, 300);
```

A arquitetura do projeto segue um modelo em camadas, que ajuda a organizar o código de forma clara e modular. As principais camadas do projeto são:

1. **Domain**: Onde ficam as entidades e as regras de negócios.
2. **Persistence**: Onde ficam os repositórios responsáveis pela interação com o banco de dados.
3. **Application**: Onde fica a lógica de aplicação, como os serviços, DTOs e mapeamentos.
4. **Presentation**: Onde os controllers expõem a API para interação com o usuário.

---

### Como a Estrutura Está Organizada

```plaintext
src/
├── Application/                 # Lógica de aplicação e serviços
│   ├── Dtos/                    # Objetos para transferir dados (DTOs)
│   ├── Interfaces/              # Interfaces para serviços e repositórios
│   ├── Mappings/                # Mapeamentos do AutoMapper
│   └── Services/                # Lógica de orquestração de serviços
├── Domain/                      # Entidades e interfaces de repositórios
│   ├── Entities/                # Definição das entidades do sistema (e.g., Produto)
│   └── Interfaces/              # Interfaces dos repositórios
├── Persistence/                 # Implementações de repositórios e banco de dados
│   ├── Configuration/           # Configurações do banco de dados
│   ├── Context/                 # O DbContext, que conecta ao banco de dados
│   ├── Migrations/              # Migrações do Entity Framework
│   ├── Repositories/            # Repositórios para manipulação dos dados
│   └── ServiceExtensions/       # Métodos de extensão para configurar o serviço
└── Presentation/                # Controllers e API
    └── Controllers/             # Controllers da API que expõem os endpoints
