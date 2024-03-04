using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Runtime.InteropServices;

namespace PocAutomacao.Center

{
    public class Methods : GlobalVariables
    {
        // Método para preencher um campo de entrada com texto
        public bool WriteText(string text, string value, [Optional] string description)
        {
            try
            {
                driver.FindElement(By.XPath(text)).SendKeys(value);

                if (description != null) Console.WriteLine("Preencheu: " + description);

                return true;
            }
            catch (Exception ex)
            {
                if (description != null) Console.WriteLine("Erro ao preencher " + description + ": " + ex.Message);

                throw;
            }
        }

        // Método para clicar em um elemento na página
        public bool Click(string element, [Optional] string description)
        {
            try
            {
                driver.FindElement(By.XPath(element)).Click();

                if (description != null) Console.WriteLine("Clicou: " + description);

                return true;
            }
            catch (Exception ex)
            {
                if (description != null) Console.WriteLine("Erro ao clicar no: " + description + ": " + ex.Message);

                throw new Exception("Erro ao clicar no: " + description + ": " + ex.Message);
            }
        }

        // Método para capturar um screenshot da página atual e converter em um array de bytes
        public byte[] CaptureScreenshot(string description)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            byte[] screenshotBytes = screenshot.AsByteArray;

            return screenshotBytes;
        }

        // Método para verificar o valor do campo de nome em uma página e compará-lo com o valor esperado
        public void AssertNameFieldValue(string expectedName)
        {
            string nameFieldXPath = "//*[@id=\'textName\']";

            try
            {
                IWebElement nameField = driver.FindElement(By.XPath(nameFieldXPath));

                string actualName = nameField.GetAttribute("textContent");

                Console.WriteLine($"Valor atual do campo de nome: {actualName}");

                Assert.That(actualName, Is.EqualTo(expectedName), $"O campo nome não contém o valor esperado '{expectedName}'.");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail($"Campo nome não foi encontrado com XPath '{nameFieldXPath}'.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Ocorreu um erro ao verificar o campo nome: {ex.Message}");
            }
        }

        // Método para verificar os campos de valor e destinatário da transferência em uma página e compará-los com os valores esperados
        public void AssertTransferFields(string expectedAmount, string expectedRecipient)
        {
            // XPath do campo de valor da transferência
            string amountFieldXPath = "(//*[@id=\'textTransferValue\'])[2]";

            // XPath do campo de destinatário da transferência
            string recipientFieldXPath = "(//*[@id=\'textDescription\'])[2]";

            try
            {
                IWebElement amountField = driver.FindElement(By.XPath(amountFieldXPath));

                string actualAmount = amountField.GetAttribute("textContent").Trim();

                Console.WriteLine($"Valor da transferência: {actualAmount}");

                Assert.That(actualAmount, Is.EqualTo(expectedAmount), $"O campo de valor da transferência não contém o valor esperado '{expectedAmount}'.");

                IWebElement recipientField = driver.FindElement(By.XPath(recipientFieldXPath));

                string actualRecipient = recipientField.GetAttribute("textContent").Trim();

                Console.WriteLine($"Descrição da transferência: {actualRecipient}");

                Assert.That(actualRecipient, Is.EqualTo(expectedRecipient), $"O campo de destinatário da transferência não contém o valor esperado '{expectedRecipient}'.");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Um dos campos da transferência não foi encontrado.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Ocorreu um erro ao verificar os campos da transferência: {ex.Message}");
            }
        }       
    }
}


    
