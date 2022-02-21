Clima Simples

Projeto criado para realizar as seguintes consultas de um banco populado:
1.	Informar quais são as 3 cidades que terão a maior temperatura
2.	Informar quais são as 3 cidades que terão a menor temperatura
3.	Qual será a previsão do tempo para os próximos 7 dias na cidade selecionada	

Framework utilizados:
1.	 .NetFramework 4.6.1
2.	 Microsoft.AspNet.Mvc 5.2.7
3.	 EntityFramework para repositório com SQLServer

Como executar na sua maquina:
1.	Baixe o projeto do repositório
2.	No SQLServer execute os scripts que estão na raiz do projeto (Create database.sql, Create tables.sql)
3.	No Visual Studio abra o projeto Clima.sln
4.	Modifique o arquivo Web.config na tag “connectionString” de acordo com as configurações do seu banco
5.	Compile e execute o projeto
6.  Pronto!
