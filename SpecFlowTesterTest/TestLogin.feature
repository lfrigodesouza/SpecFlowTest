#language: pt 
Funcionalidade: TestLogin
				Testa o login

Cenario: Teste de Login
	Dado Que navego para pagina Inicial
	Quando Informo o usuario "tomsmith"
	E Informo a senha "SuperSecretPassword!"
	E Clico no botao Login
	Entao Devo estar Logado

Esquema do Cenario: Teste de multiplos logins
    Dado Que navego para pagina Inicial
    Quando Informo o usuario "<username>"
    E Informo a senha "<password>"
    E Clico no botao Login
    Então Deve ser apresentada a mensagem <mensagem>

    Exemplos: 
    | username | password             | mensagem            |
    | tomsmith | SuperSecretPassword! | secure area         |
    | admin    | 17111997             | username is invalid |
    | admin    | admin                | username is invalid |
    | tomsmith | 17111997             | username is invalid |
