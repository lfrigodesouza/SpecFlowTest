using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecFlowTesterTest
{
    [Binding]
    public class TestLoginSteps
    {
		private IWebDriver _driver;
		private string usernameName;

        [Given(@"Que navego para pagina Inicial")]
        public void DadoQueNavegoParaPaginaInicial()
        {
			_driver = new ChromeDriver();
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			_driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
			_driver.Manage().Window.Maximize();
			_driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
        }
        
        [When(@"Informo o usuario ""(.*)""")]
        public void DadoInformoOUsuario(string username)
        {
			var usernameBox = _driver.FindElement(By.Id("username"));
			usernameBox.SendKeys(username);
			usernameName = username;
        }
        
        [When(@"Informo a senha ""(.*)""")]
        public void DadoInformoASenha(string password)
        {
			var passwordBox = _driver.FindElement(By.Id("password"));
			passwordBox.SendKeys(password);
        }
        
        [When(@"Clico no botao Login")]
        public void QuandoClicoNoBotaoLogin()
        {
			var loginBtn = _driver.FindElement(By.CssSelector("#login > button > i"));
			loginBtn.Click();
        }
        
        [Then(@"Devo estar Logado")]
        public void EntaoDevoEstarLogado()
        {
			var welcomeRibbon = _driver.FindElement(By.Id("flash")).Text;

			try
			{
				Assert.IsTrue(welcomeRibbon.Contains("secure area", StringComparison.CurrentCultureIgnoreCase));
			}
			finally
			{
				_driver.Close();
				_driver.Quit();
			}
		}

        [Then(@"Deve ser apresentada a mensagem (.*)")]
        public void EntaoDeveSerApresentadaAMensagem(string mensagem)
        {
            var welcomeRibbon = _driver.FindElement(By.Id("flash")).Text;

            try
            {
                Assert.IsTrue(welcomeRibbon.Contains(mensagem, StringComparison.CurrentCultureIgnoreCase));
            }
            finally
            {
                _driver.Close();
                _driver.Quit();
            }
        }

    }
}
