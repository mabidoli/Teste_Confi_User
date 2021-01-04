Antes de executar:
    1. Trocar a connection string no app.settings do projeto Confite.WebApi

Comandos para criar Banco de Dados:
    1. dotnet ef migrations add InitialMagration -p ConfitecBackend/Confitec.Infra/Confitec.Infra.csproj -s ConfiteBackend/Confitec.WebApi/Confitec.WebApi.csproj
    2. dotnet ef database update -p ConfitecBackend/Confitec.Infra/Confitec.Infra.csproj -s ConfitecBackend/Confitec.WebAp i/Confitec.WebApi.csproj

Comando para rodar o frontend:
    npm run start

Executar o backend no Visual Studio.