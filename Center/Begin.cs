using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace PocAutomacao.Center
{
    public class Begin : Methods
    {
        protected CredentialsManager credentials;

        // Abrindo o navegador
        private void OpeningBrowser()
        {
            // Configuração das opções do Chrome para executar em modo headless
            var headlessMode = new ChromeOptions();

            // Simulando o tamanho da tela do Notebook
            headlessMode.AddArgument("window-size=1366x768");

            // Apagando qualquer cache deixado
            headlessMode.AddArgument("disk-cache-size=0");
            headlessMode.AddArgument("headless");

            // Configuração das opções do Chrome para modo de desenvolvimento
            var devMode = new ChromeOptions();
            devMode.AddArgument("disk-cache-size=0");
            devMode.AddArgument("start-maximized");

            // Se TRUE, executará anonimamente | Se FALSE, executará abrindo navegador
            if (headlessTest) { driver = new ChromeDriver(headlessMode); }
            else { driver = new ChromeDriver(devMode); }
        }

        public ExtentTest test;
        [SetUp]
        // Início do teste
        public void TestStart()
        {
            OpeningBrowser();

            // Obtém as credenciais do ambiente
            credentials = CredentialsManager.GetCredentialsFromEnvironment();

            // Navega para a URL
            driver.Navigate().GoToUrl("https://bugbank.netlify.app/");
        }

        [TearDown]
        // Fim do teste
        public void EndOfTest()
        {
            if (driverQuit) driver.Quit();
        }

    }
}