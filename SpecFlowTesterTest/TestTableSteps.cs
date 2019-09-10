using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecFlowTesterTest
{
    public class StepTable
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
    }


    [Binding]
    public class TestTableSteps
    {
        private List<StepTable> stepTableList = new List<StepTable>();
		private IWebDriver _driver;

        [Given(@"que eu possuo esses cadastros:")]
        public void DadoQueEuPossuoEssesCadastros(Table table)
        {
            foreach (var row in table.Rows)
            {
                stepTableList.Add(new StepTable
                {
                    Nome = row["nome"],
                    Sobrenome = row["sobrenome"],
                    Email = row["email"]
                });
            }

        }
        
        [When(@"eu acessar a pagina da tabela")]
        public void QuandoEuAcessarAPaginaDaTabela()
        {
			_driver = new ChromeDriver(Environment.CurrentDirectory);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");
        }
        
        [When(@"solicitar a ordenacao pelo nome")]
        public void QuandoSolicitarAOrdenacaoPeloNome()
        {
            var nameHeader = _driver.FindElement(By.XPath("//*[@id='table2']/thead/tr/th[2]/span"));
            nameHeader.Click();
        }
        
        [Then(@"todos os valores devem estar na tabela")]
        public void EntaoTodosOsValoresDevemEstarNaTabela()
        {
            var table = _driver.FindElement(By.Id("table2"));
            var tBody = table.FindElement(By.TagName("tbody"));
            var trs = tBody.FindElements(By.CssSelector("tr"));
            foreach (var tr in trs)
            {
                var name = tr.FindElement(By.ClassName("first-name")).Text;
                var sobrenome = tr.FindElement(By.ClassName("last-name")).Text;
                var email = tr.FindElement(By.ClassName("email")).Text;

                Assert.IsTrue(stepTableList.Any(x => x.Nome == name && x.Sobrenome == sobrenome && x.Email == email));
            }
        }
        
        [Then(@"a sequencia deve estar correta")]
        public void EntaoASequenciaDeveEstarCorreta()
        {
            var table = _driver.FindElement(By.Id("table2"));
            var tBody = table.FindElement(By.TagName("tbody"));
            var trs = tBody.FindElements(By.CssSelector("tr"));
            stepTableList = stepTableList.OrderBy(x => x.Nome).ToList();

            for (int i = 0; i < trs.Count; i++)
            {
                var name = trs[i].FindElement(By.ClassName("first-name")).Text;
                var sobrenome = trs[i].FindElement(By.ClassName("last-name")).Text;
                var email = trs[i].FindElement(By.ClassName("email")).Text;

                Assert.AreEqual(stepTableList[i].Nome, name);
                Assert.AreEqual(stepTableList[i].Sobrenome, sobrenome);
                Assert.AreEqual(stepTableList[i].Email, email);
            }
        }

        [AfterScenario("@testTable")]
        public void after()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
