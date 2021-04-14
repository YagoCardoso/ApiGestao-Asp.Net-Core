# ApiGestao

- Clonar o repositório : https://github.com/YagoCardoso/ApiGestao.git

- Ao abrir o projeto ir no arquivo: appsettings.json, e colocar a string de conexão do banco MySql,
EX: "DefaultConnection": "server=nomeserver; port=porta; database=GESTAOAG_DB; user=nomeusuario; password=senha; Persist Security Info = False;"

- Após colocar a string de conexão, abrir o Packge Manager Console, e executar os comandos:
   add-migration Inicial
   update-database
   
   Você tera um retorno como este no Packge Manager Console:
add-migration Inicial
Build started...
Build succeeded.
To undo this action, use Remove-Migration.
PM> update-database
Build started...
Build succeeded.
Done.

Feito isso o projeto API  já esta pronto para ser executado.

***
Ferramentas e Sugestões

HTTP, REST, JSON e MVC

Projeto .NET Core

EF Core

Repositório

DTO e AutoMapper

Swagger

- Irei consumir essa API com React.js e Next.js
