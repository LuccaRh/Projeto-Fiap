# ProjetoFiap
Projeto de prova de estágio fiap
A prova é uma simulação da criação de uma landpage para a uma grande empresa de varejo. Esse github é a parte do backend do site.
Ele foi feito utilizando a linguagem c# no .net 6, com visual studio 2022, com as bibliotecas Dapper e MySqlClient. O banco de dados usado foi o sql server, com microsoft managment studio 18.
## Divisão do projeto
o projeto foi dividido em 4 partes:
* MOD
* Controller
* BLL
* DAL

MOD é o objeto utilizado no projeto. Ele tem os parâmetros baseados nas colunas do sql, ou seja: Nome, Email, Telefone, Cpf, Data de Nascimento e Id.

Controller é a comunicação desta parte do projeto com o FrontEnd, ele possui todos os métodos http usados nele.

BLL é o intermediário entre a Controller e a DAL, ele quem faz o "filtro" dos valores enviados pela controller, para a DAL.

DAL é a comunicação com o banco de dados (sql server), assim pegando ou enviando informações para ele.
