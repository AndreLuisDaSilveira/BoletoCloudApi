# BoletoCloudApi

API para geração e obtenção de boletos em PDF utilizando a integração com a [BoletoCloud](https://www.boletocloud.com/).

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado na máquina
- SQL Server disponível para as migrações do banco de dados

> Certifique-se de que o .NET 8 SDK está instalado executando:
> ```
> dotnet --version
> ```
> O resultado deve ser igual ou superior a 8.0.

## Funcionalidades

- Geração de boletos bancários em PDF.
- Consulta de boletos gerados via token.
- Máscaras automáticas para CPF, CNPJ e CEP.
- Busca de boletos por número, CPF e período de emissão.
- Estrutura extensível para integração com outros serviços bancários.

## Tecnologias Utilizadas

- .NET 8
- C# 12
- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- FluentValidation
- Injeção de Dependência (DI)
- HTTP Client Factory
- Swagger (OpenAPI)

## Arquitetura

O projeto segue o padrão de arquitetura em camadas, separando responsabilidades para facilitar manutenção, testes e evolução:

- **BoletoCloudApi.Api**  
  Camada de apresentação (API). Responsável por expor os endpoints REST, receber e validar requisições, retornar respostas e orquestrar as chamadas para a camada de negócio. Exemplo: `BoletosController`.

- **BoletoCloudApi.Business**  
  Camada de domínio e regras de negócio. Contém os serviços, interfaces, validações, notificações, ViewModels e lógica de integração com sistemas externos (ex: BoletoCloud). Exemplo: `BoletoService`, `BoletoCloudIntegrationService`, `IBoletoService`.

- **BoletoCloudApi.Data**  
  Camada de acesso a dados. Responsável pela persistência, mapeamento das entidades (Entity Framework Core), repositórios e migrações do banco de dados. Exemplo: `BoletoMapping`, repositórios, migrations.

### Fluxo Resumido

1. O cliente faz uma requisição para a API (`BoletoCloudApi.Api`).
2. O Controller recebe, valida e encaminha os dados para um serviço de negócio (`BoletoCloudApi.Business`).
3. O serviço executa as regras, interage com repositórios e/ou serviços externos.
4. O repositório acessa ou persiste dados no banco via camada `BoletoCloudApi.Data`.
5. O resultado é retornado ao Controller, que responde ao cliente.

## Configuração e Execução

1. **Clone o repositório:**
git clone https://github.com/seu-usuario/BoletoCloudApi.git cd BoletoCloudApi

2. **Configure o arquivo `appsettings.json`:**
{ "BoletoCloudOptions": { "ApiKey": "sua-api-key", "ApiUrl": "https://sandbox.boletocloud.com/api/v1/boletos" }, "ConnectionStrings": { "DefaultConnection": "Server=localhost;Database=SeuBanco;User Id=usuario;Password=senha;TrustServerCertificate=True;" } }

3. **Restaure os pacotes NuGet:**
dotnet restore

4. **Faça o build do projeto:**
dotnet build


5. **Execute as migrações do banco de dados:**
> ⚠️ **Atenção:** As migrações devem ser criadas e aplicadas em um banco de dados SQL Server.
>
> Se precisar criar uma nova migração, utilize:
> ```sh
> dotnet ef migrations add NomeDaMigracao --project src/BoletoCloudApi.Data --startup-project src/BoletoCloudApi.Api
> ```
> Para aplicar as migrações:
> ```sh
> dotnet ef database update --project src/BoletoCloudApi.Data --startup-project src/BoletoCloudApi.Api
> ```

6. **Rode a aplicação:**
dotnet run --project src/BoletoCloudApi.Api

## Documentação e Testes com Swagger

Após iniciar a aplicação, acesse:
http://localhost:5000/swagger
ou
http://localhost:5001/swagger
(dependendo da porta configurada)

Com o Swagger, você pode:
- Visualizar todos os endpoints disponíveis.
- Testar requisições diretamente pelo navegador.
- Ver exemplos de payloads e respostas.

## Exemplos de Uso

### Gerar um boleto

Faça um POST para `/api/boletos` com o payload do boleto.  
O serviço irá retornar o PDF e o token do boleto.

### Obter PDF de um boleto existente

Faça um GET para `/api/boletos/{id}/pdf` para obter o PDF do boleto já gerado.

## Estrutura Principal

- `BoletoCloudIntegrationService`: Serviço responsável pela comunicação com a API BoletoCloud.
- `BoletoService`: Regras de negócio para geração e consulta de boletos.
- `BoletosController`: Endpoints da API.
- `ViewModels/`: Modelos de entrada e saída da API.
- `Models/`: Modelos de domínio (Boleto, Beneficiário, Pagador, etc).

## Contribuição

Pull requests são bem-vindos! Para grandes mudanças, abra uma issue primeiro para discutir o que você gostaria de modificar.

## Licença

Este projeto está sob a licença MIT.

---

> Projeto de integração com a BoletoCloud para automação de cobranças via boleto bancário.