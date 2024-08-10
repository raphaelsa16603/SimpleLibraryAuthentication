# SimpleLibraryAuthentication

## Descrição

SimpleLibraryAuthentication é uma aplicação exemplo desenvolvida em C# que demonstra como implementar autenticação de usuários utilizando uma biblioteca personalizada (`MyAuthenticationLibrary`). A aplicação inclui funcionalidades para registro e login de usuários, utilizando o Entity Framework Core para interagir com um banco de dados SQL Server.

## Funcionalidades

- **Registro de Usuário**: Permite que novos usuários se registrem com um nome de usuário e senha.
- **Autenticação de Usuário**: Verifica as credenciais de login dos usuários com base em um hash seguro gerado com SHA-256.
- **Conexão com Banco de Dados SQL Server**: Utiliza o Entity Framework Core para interagir com o banco de dados SQL Server.

## Tecnologias Utilizadas

- **C# (.NET 6.0)**: Linguagem e plataforma principal para o desenvolvimento da aplicação.
- **Entity Framework Core 6.0**: Utilizado para mapeamento objeto-relacional (ORM) e acesso ao banco de dados.
- **SQL Server**: Banco de dados utilizado para armazenar informações de usuários.
- **MSTest & Moq**: Ferramentas utilizadas para testes unitários.

## Estrutura do Projeto

- **MyAuthenticationLibrary**: Biblioteca contendo a lógica principal para hashing, autenticação e interação com o banco de dados.
  - **Interfaces**: Definem contratos para serviços de hashing e repositórios de usuários.
  - **Modelos**: Representam entidades de dados, como `User`.
  - **Serviços**: Implementam a lógica de autenticação e registro de usuários.
  - **DbContext**: Gerencia a conexão com o banco de dados SQL Server.
  
- **SimpleLibraryAuthenticationConsoleApp**: Aplicação console que utiliza a biblioteca para realizar operações de autenticação.
  
## Instalação e Configuração

1. **Clone o Repositório**:
    ```bash
    git clone https://github.com/raphaelsa16603/SimpleLibraryAuthentication/tree/main
    ```
2. **Configuração do Banco de Dados**:
    - Execute o script `CreateDatabaseAndUserTable.sql` no SQL Server para criar o banco de dados e a tabela de usuários.

3. **Configuração da String de Conexão**:
    - Configure a string de conexão no arquivo `appsettings.json` ou diretamente no código para apontar para seu servidor SQL Server local:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=SimpleLibraryAuthenticationDB;Trusted_Connection=True;"
      }
    }
    ```

4. **Instalação de Pacotes NuGet**:
    - Execute os seguintes comandos no Console do Gerenciador de Pacotes:
    ```bash
    Install-Package Microsoft.EntityFrameworkCore -Version 6.0.16
    Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 6.0.16
    Install-Package MSTest.TestFramework
    Install-Package Moq
    ```

5. **Executando a Aplicação**:
    - Compile e execute a aplicação console para registrar e autenticar usuários.

## Testes

O projeto inclui uma classe de testes unitários (`AuthenticationServiceTests`) que valida as funcionalidades principais do serviço de autenticação utilizando o MSTest e Moq.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e enviar pull requests.

## Licença

Este projeto está licenciado sob a licença MIT.
