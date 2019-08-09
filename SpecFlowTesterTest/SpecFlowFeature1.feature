#language: pt 
Funcionalidade: Feature 1
				Testa o login

@mytag
Cenario: Teste de Login
	Dado Que navego para pagina Inicial
	Quando Informo o usuario "admin"
	E Informo a senha "17111997"
	E Clico no botao Login
	Entao Devo estar na tela de Matches
