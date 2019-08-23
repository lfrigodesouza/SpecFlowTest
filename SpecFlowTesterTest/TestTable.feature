#language: pt
Funcionalidade: TestTable
    Testar se o conteúdo da tabela está correto
    E também valida se a ordenação está sendo feita como esperado

@testTable
Cenario: Validar o conteudo da tabela
    Dado que eu possuo esses cadastros:
    | nome  | sobrenome | email                 |
    | Frank | Bach      | fbach@yahoo.com       |
    | Tim   | Conway    | tconway@earthlink.net |
    | Jason | Doe       | jdoe@hotmail.com      |
    | John  | Smith     | jsmith@gmail.com      |
    Quando eu acessar a pagina da tabela
    Entao todos os valores devem estar na tabela
    
@testTable
Cenario: Validar ordenacao dos dados da tabela
    Dado que eu possuo esses cadastros:
    | nome  | sobrenome | email                 |
    | Frank | Bach      | fbach@yahoo.com       |
    | Tim   | Conway    | tconway@earthlink.net |
    | Jason | Doe       | jdoe@hotmail.com      |
    | John  | Smith     | jsmith@gmail.com      |
    Quando eu acessar a pagina da tabela
    E solicitar a ordenacao pelo nome
    Entao todos os valores devem estar na tabela
    E a sequencia deve estar correta
