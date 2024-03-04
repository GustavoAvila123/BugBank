using OpenQA.Selenium;
using System;

namespace PocAutomacao.Center
{
    public class GlobalVariables
    {
        // Define 'driver' como trigger para os WebElements
        public IWebDriver driver;

        // Definir fechamento de navegador no final do teste como padrão
        public bool driverQuit = true;

        // Habilita | Desabilita modo Headless
        public bool headlessTest = true;

        // Construtor padrão que define variáveis de ambiente para email e senha
        public GlobalVariables()
        {
            // Definindo padrões
            string email = "joao@teste.com";
            string email2 = "maria@teste.com";
            string password = "Teste";
            string password2 = "Teste";
            string name = "João";
            string name2 = "Maria";

            Environment.SetEnvironmentVariable("EMAIL", email);
            Environment.SetEnvironmentVariable("EMAIL2", email2);
            Environment.SetEnvironmentVariable("PASSWORD", password);
            Environment.SetEnvironmentVariable("PASSWORD2", password2);
            Environment.SetEnvironmentVariable("NAME", name);
            Environment.SetEnvironmentVariable("NAME2", name2);
                                        
            // Gerar um número aleatório
            Random random = new Random();

            // Número aleatório de 4 dígitos
            int randomNumber1 = random.Next(1000, 9999);
            int randomNumber2 = random.Next(1000, 9999);

            // Concatenar o número 
            string concatenatedEmail = "joao" + randomNumber1.ToString() + "@teste.com";
            string concatenatedEmail2 = "maria" + randomNumber2.ToString() + "@teste.com";
            string concatenatedPasword = password + randomNumber1.ToString();
            string concatenatedPasword2 = password2 + randomNumber2.ToString();
            string concatenatedName = name + randomNumber1.ToString();
            string concatenatedName2 = name2 + randomNumber2.ToString();

            // Armazenar o resultado em uma variável de ambiente
            Environment.SetEnvironmentVariable("EMAIL", concatenatedEmail);
            Environment.SetEnvironmentVariable("EMAIL2", concatenatedEmail2);
            Environment.SetEnvironmentVariable("PASSWORD", concatenatedPasword);
            Environment.SetEnvironmentVariable("PASSWORD2", concatenatedPasword2);
            Environment.SetEnvironmentVariable("NAME", concatenatedName);
            Environment.SetEnvironmentVariable("NAME2", concatenatedName2);
        }       
    }
}

