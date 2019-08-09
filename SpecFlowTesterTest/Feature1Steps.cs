using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecFlowTesterTest
{
    [Binding]
    public class Feature1Steps
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
			_driver.Navigate().GoToUrl("http://localhost:4200/");
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
			var loginBtn = _driver.FindElement(By.Id("login-button"));
			loginBtn.Click();
        }
        
        [Then(@"Devo estar na tela de Matches")]
        public void EntaoDevoEstarNaTelaDeMatches()
        {
			var welcomeRibbon = _driver.FindElement(By.Id("welcome-ribbon")).Text;

			try
			{
				Assert.IsTrue(welcomeRibbon.Contains(usernameName, StringComparison.CurrentCultureIgnoreCase));
			}
			finally
			{
				_driver.Close();
				_driver.Quit();
			}
		}
    }
}
