\# Sistema de Cadastro de Produtos (CRUD)



Este projeto é composto por dois microsserviços:  

\- \*\*Back-end\*\*: API em .NET Core 5+ (`api-produtos-dotnet`)

\- \*\*Front-end\*\*: Angular 6+ (`frontend-angular-produtos`)



O objetivo é permitir o cadastro, consulta, atualização e exclusão lógica de produtos para e-commerce, com integração via API.



---



\## 📦 Estrutura do Projeto



api-produtos-dotnet/ # Projeto .NET Core (API)

frontend-angular-produtos/ # Projeto Angular (Front-end)

banco/ # Scripts SQL do banco de dados

README.md # Manual de instalação (este arquivo)



markdown

Copiar

Editar



---



\## 🚀 Passo a Passo para Instalação



\### 1. Banco de Dados (PostgreSQL)



\- Instale o PostgreSQL em sua máquina.

\- Execute o script SQL fornecido em `banco/script\_postgresql.sql` para criar a tabela de produtos.

\- Exemplo de conexão padrão:  

&nbsp; - Usuário: `postgres`

&nbsp; - Senha: `postgres`

&nbsp; - Banco: `produtos\_db` (ou altere conforme sua necessidade)



\### 2. API .NET Core



\- Abra o projeto `api-produtos-dotnet` no Visual Studio ou VS Code.

\- Ajuste a string de conexão no `appsettings.json` caso seja necessário.

\- Restaure os pacotes NuGet (`dotnet restore`).

\- Rode a aplicação:  

&nbsp; ```bash

&nbsp; dotnet build

&nbsp; dotnet run

Por padrão, a API estará disponível em http://localhost:5000/api.



Acesse o Swagger em: http://localhost:5000/swagger para testar e validar os endpoints.



3\. Front-end Angular

Instale o Node.js (versão recomendada: 14+).



Instale o Angular CLI, caso não tenha:



bash

Copiar

Editar

npm install -g @angular/cli

Navegue até a pasta do front-end:



bash

Copiar

Editar

cd frontend-angular-produtos

npm install

ng serve

O sistema estará disponível em: http://localhost:4200/



4\. Configuração de Integração

Certifique-se de que a URL da API (apiUrl) no arquivo src/environments/environment.ts do Angular esteja apontando para http://localhost:5000/api (ou ajuste conforme necessário).



❗ Observações

O fluxo de autenticação está mockado.



Os departamentos são fornecidos via endpoint da API.



Exclusão é lógica: produtos excluídos não aparecem na listagem, mas continuam no banco de dados.



🌍 English Version

Product Registration System (CRUD)

This project consists of two microservices:



Back-end: .NET Core 5+ API (api-produtos-dotnet)



Front-end: Angular 6+ (frontend-angular-produtos)



The goal is to allow registration, consultation, update and logical deletion of products for e-commerce, with API integration.



📦 Project Structure

bash

Copiar

Editar

api-produtos-dotnet/       # .NET Core Project (API)

frontend-angular-produtos/  # Angular Project (Front-end)

banco/                      # SQL Scripts

README.md                   # This manual

🚀 Setup Guide

1\. Database (PostgreSQL)

Install PostgreSQL on your machine.



Run the provided SQL script in banco/script\_postgresql.sql to create the product table.



Example default connection:



User: postgres



Password: postgres



Database: produtos\_db (change as needed)



2\. .NET Core API

Open the api-produtos-dotnet project in Visual Studio or VS Code.



Adjust the connection string in appsettings.json if needed.



Restore NuGet packages (dotnet restore).



Run the application:



bash

Copiar

Editar

dotnet build

dotnet run

The API will be available at http://localhost:5000/api.



Access Swagger at: http://localhost:5000/swagger to test endpoints.



3\. Angular Front-end

Install Node.js (recommended: v14+).



Install Angular CLI if needed:



bash

Copiar

Editar

npm install -g @angular/cli

Go to the front-end folder:



bash

Copiar

Editar

cd frontend-angular-produtos

npm install

ng serve

Access the system at: http://localhost:4200/



4\. Integration Setup

Make sure the API URL (apiUrl) in Angular's src/environments/environment.ts points to http://localhost:5000/api (adjust as needed).



❗ Notes

Authentication flow is mocked.



Departments are provided via API endpoint.



Deletion is logical: deleted products are not listed, but remain in the database.

