# Backend do Forms Angular Bootstrap
Este repositório contém o backend do projeto Forms Angular Bootstrap, desenvolvido em .NET com SQL Server e Dapper, responsável por gerenciar a persistência e o acesso aos dados de pensamentos (quotes).

## 🔗 Frontend correspondente: formsAngularBootstrap

## 📌 Funcionalidades
CRUD completo para pensamentos (quotes).

API RESTful com CORS habilitado para integração com o frontend.

Respostas padronizadas em JSON.

## 🛠️ Tecnologias
.NET

SQL Server (banco de dados)

Dapper (ORM leve)

CORS (para comunicação com o frontend)

## 🗃️ Banco de Dados
Estrutura da Tabela Pensamentos

Campo	Tipo	Descrição

Id (PK)	INT	Chave primária (auto-incremento)

Pensamento	VARCHAR(300)	Texto do pensamento

Autor	VARCHAR(50)	Nome do autor

Modelo	INT	Categoria do pensamento


## 🚀 Rotas da API
### 📝 Convenções
Segue padrões RESTful (veja as boas práticas adotadas).

Respostas no formato:
json
{
    "success": true,
    "data": { ... } // ou [ ... ] para listas
}
### 📋 Endpoints
Método	Rota	Descrição	Corpo da Requisição (Exemplo)

GET	/api/pensamentos	Lista todos os pensamentos	-

POST	/api/pensamentos	Cria um novo pensamento	json { "pensamento": "...", "autor": "...", "modelo": 1 }

PUT	/api/pensamentos	Atualiza um pensamento existente	json { "id": 1, "pensamento": "...", "autor": "...", "modelo": 2 }

DELETE	/api/pensamentos	Remove um pensamento	json { "id": 1 }


### ⚙️ Configuração
Pré-requisitos
.NET SDK
SQL Server (local)

Passos para Execução
Clone o repositório:

sh
git clone https://github.com/ConradoCapistrano/formsAngularBootstrap.git
Configure a connection string no appsettings.json:

Inicie o servidor:

sh
dotnet run
A API estará disponível em: http://localhost:4200 (ou porta configurada).

## 📌 Boas Práticas de Nomenclatura de Rotas
Métodos HTTP claros: GET (leitura), POST (criação), PUT (atualização), DELETE (remoção).

Substantivos no plural: /api/pensamentos (em vez de /api/pensamento).

Sem verbos nas rotas: Use GET /api/pensamentos (não GET /api/listarPensamentos).

Códigos de status HTTP: Retorne 200 OK, 400 Bad Request, 404 Not Found, etc.

## 🔒 CORS
O CORS está configurado para permitir requisições do frontend. Modifique o arquivo Program.cs se necessário;


## 📄 Convenções de Código
PascalCase: Classes, métodos (ex: PensamentoController).

camelCase: Variáveis (ex: var novoPensamento).

Respostas da API: Propriedades em lowercase (ex: { "success": true }).
