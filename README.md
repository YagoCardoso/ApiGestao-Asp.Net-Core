# ApiGestao

- Clonar o repositório : https://github.com/YagoCardoso/ApiGestao.git

- Ao abrir o projeto ir no arquivo: appsettings.json, e colocar a string de conexão do banco MySql,
EX: "DefaultConnection": "server=nomeserver; port=porta; database=GESTAOAG_DB; user=nomeusuario; password=senha; Persist Security Info = False;"

- Após colocar a string de conexão, abrir o Packge Manager Console, e executar os comandos:
   add-migration Inicial
   update-database

Feito isso o projeto API  já esta pronto para ser executado.
