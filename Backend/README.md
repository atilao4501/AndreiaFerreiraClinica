# AndreiaFerreira.ClinicaApi

AndreiaFerreira.ClinicaApi é uma aplicação de API REST para gerenciar uma clínica, permitindo o controle de agendamentos, clientes e funcionários.

## Funcionalidades

- **Clientes**: Cadastrar, listar, atualizar e excluir informações dos clientes.
- **Funcionários**: Gerenciar cadastro de funcionários da clínica.
- **Agendamentos**: Criar, atualizar e visualizar agendamentos para clientes e funcionários.

## Tecnologias Utilizadas

- **C#** com .NET Core para desenvolvimento da API.
- **Entity Framework Core** para manipulação do banco de dados.
- **ASP.NET Core** para criação de endpoints REST.
- **Docker** para containerização da aplicação.

## Estrutura do Projeto

- `Controllers/`: Contém os controladores da API para manipular clientes, funcionários e agendamentos.
- `Program.cs`: Ponto de entrada para a aplicação.
- `Properties/launchSettings.json`: Configuração de ambientes de desenvolvimento.

## Pré-requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download) versão 3.1 ou superior.
- [Docker](https://www.docker.com/get-started) instalado na máquina local.

## Configuração e Execução

### Via .NET CLI

1. Clone o repositório para sua máquina local.
   ```bash
   git clone <URL_DO_REPOSITORIO>
   ```
2. Navegue até o diretório do projeto.
   ```bash
   cd AndreiaFerreira.ClinicaApi
   ```
3. Restaure as dependências do projeto.
   ```bash
   dotnet restore
   ```
4. Inicie a aplicação.
   ```bash
   dotnet run
   ```

A API estará disponível em `http://localhost:<porta>`, conforme configurado no `launchSettings.json`.

### Via Docker

1. Clone o repositório para sua máquina local.
   ```bash
   git clone <URL_DO_REPOSITORIO>
   ```
2. Navegue até o diretório do projeto.
   ```bash
   cd AndreiaFerreira.ClinicaApi
   ```
3. Construa e inicie os serviços Docker.
   ```bash
   docker-compose up
   ```

A API estará disponível em `http://localhost:5245`.

## Endpoints Principais

### Clientes

- **GET /api/clientes**: Lista todos os clientes.
- **POST /api/clientes**: Cadastra um novo cliente.
- **PUT /api/clientes/{id}**: Atualiza informações de um cliente existente.
- **DELETE /api/clientes/{id}**: Exclui um cliente.

### Funcionários

- **GET /api/funcionarios**: Lista todos os funcionários.
- **POST /api/funcionarios**: Cadastra um novo funcionário.
- **PUT /api/funcionarios/{id}**: Atualiza informações de um funcionário existente.
- **DELETE /api/funcionarios/{id}**: Exclui um funcionário.

### Agendamentos

- **GET /api/agendamentos**: Lista todos os agendamentos.
- **POST /api/agendamentos**: Cria um novo agendamento.
- **PUT /api/agendamentos/{id}**: Atualiza um agendamento.
- **DELETE /api/agendamentos/{id}**: Exclui um agendamento.
