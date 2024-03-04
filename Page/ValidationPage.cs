using OpenQA.Selenium;
using PocAutomacao.Center;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace PocAutomacao.Page
{
    // Esta classe contém métodos para validar a página, estendendo as funcionalidades definidas em Begin
    public class ValidationPage : Begin
    {
        // Variáveis de controle de estado e nomes de métodos para diferentes ações e validações durante os testes
        bool resultOfTheEmailFilledInByTheUser;
        bool resultOfTheTransferAmount;
        bool resultOfTheTransferDescription;
        bool userFilledNameResult;
        bool resultCompletedPassword;
        bool resultConfirmationPasswordCompleted;
        bool resultOfTheAccountNumberFilledInByTheUser;
        bool resultOfTheAccountDigitFilledInByTheUser;
        bool emailFillingResult;
        bool passwordFillingResult;
        bool registerButtonClicked;
        bool closeButtonClicked;
        bool accessButtonClicked;
        bool transferButtonClicked;
        bool balanceButtonClicked;
        bool backButtonClicked;
        bool extractButtonClicked;
        bool exitButtonClicked;

        string emailFilledInByTheUser;
        string accountNumberFilledInByTheUser;
        string accountDigitFilledInByTheUser;
        string filledTransferAmount;
        string filledTransferDescription;
        string userFilledName;
        string userPasswordCreated;
        string userPasswordConfirmation;
        string userEmailConfirmation;
        string nameEnterYourEmail;
        string nameProvideYourName;
        string nameMethodInformYourPassword;
        string nameMethodPasswordConfirmation;
        string nameMethodClickRegisterButton;
        string nameMethodClickcreateAccountWithBalanceButton;
        string nameMethodClickOnTheRegisterButton;
        string nameMethodClickTheCloseButton;
        string nameMethodClickOnTheAccessButton;
        string nameMethodClickTheTransferNowButton;
        string nameMethodClickOnTheBackButton;
        string nameMethodEmailCreated;
        string nameMethodPasswordCreated;
        string nameMethodClickTheTransferButton;
        string nameMethodClickTheExtractButton;
        string nameMethodClickTheExitButton;
        string nameEnterTheTransferAmount;
        string nameEnterTransferDescription;
        string nameEnterTheAccountNumber;
        string nameEnterTheAccountDigit;
        string fileName;
        string summary;

        // Lista para armazenar capturas de tela como arrays de bytes
        public static List<byte[]> screenshots = new List<byte[]>();

        public string TransferDescriptionResult { get; private set; }

        // Senha gerada
        private string generatedPassword;
        // E-mail gerado
        private string generatedEmail;
        // Número da conta gerada
        public string accountNumber;
        // Dígito da conta gerada
        public string digitAccountVerificationType;
        // Valor da Transferência
        public string transferValue = "500";

        // Adicionar captura de tela
        public static void AddScreenshot(byte[] screenshot)
        {
            screenshots.Add(screenshot);
        }

        // Método para limpar a lista de screenshots
        public static void ClearScreenshots()
        {
            screenshots.Clear();
        }

        // Método para clicar no botão REGISTRAR
        public void ClickRegisterButton()
        {
            nameMethodClickRegisterButton = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                Click("//*[@id=\'__next\']/div/div[2]/div/div[1]/form/div[3]/button[2]", "Botão 'REGISTRAR'");
                registerButtonClicked = true;

                byte[] successScreenshotRegisterButton = CaptureScreenshot($"{nameMethodClickRegisterButton}_Success");
                AddScreenshot(successScreenshotRegisterButton);
            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameMethodClickRegisterButton}: Validação falhou - Botão REGISTRAR não clicado" }, fileName);
                throw;
            }
        }

        // Método para CADASTRAR - E-mail
        public string EnterYourEmail(string email)
        {
            nameEnterYourEmail = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                var emailField = driver.FindElement(By.XPath("//*[@id=\'__next\']/div/div[2]/div/div[2]/form/div[2]/input"));

                emailField.SendKeys(Keys.Control + "a");
                emailField.SendKeys(Keys.Delete);

                bool completedSuccessfully = WriteText("//*[@id=\'__next\']/div/div[2]/div/div[2]/form/div[2]/input", email, "INFORME SEU E-MAIL");

                if (completedSuccessfully)
                {
                    resultOfTheEmailFilledInByTheUser = true;
                    emailFilledInByTheUser = email;

                    generatedEmail = email;

                    byte[] successScreenshotEmail = CaptureScreenshot($"{nameEnterYourEmail}_Success");
                    AddScreenshot(successScreenshotEmail);
                }
                else
                {
                    resultOfTheEmailFilledInByTheUser = true;
                    emailFilledInByTheUser = "N/A";
                }
                return emailFilledInByTheUser;
            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameEnterYourEmail}: Validação falhou - Preenchimento de E-MAIL não realizado" }, fileName);
                throw;
            }
        }               

        // Método para CADASTRAR/LOGAR - Nome
        public string ProvideYourName(string name)
        {
            nameProvideYourName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                var nameField = driver.FindElement(By.XPath("//*[@id='__next']/div/div[2]/div/div[2]/form/div[3]/input"));

                nameField.SendKeys(Keys.Control + "a");
                nameField.SendKeys(Keys.Delete);

                bool completedSuccessfully = WriteText("//*[@id=\'__next\']/div/div[2]/div/div[2]/form/div[3]/input", name, "INFORME SEU NOME");

                if (completedSuccessfully)
                {
                    userFilledNameResult = true;

                    userFilledName = name;

                    byte[] successScreenshotUser = CaptureScreenshot($"{nameProvideYourName}_Success");
                    AddScreenshot(successScreenshotUser);
                }
                else
                {
                    userFilledNameResult = true;
                    userFilledName = "N/A";
                }
                return userFilledName;
            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameProvideYourName}: Validação falhou - Preenchimento do NOME não realizado" }, fileName);
                throw;
            }
        }

        // Método para CADASTRAR - senha
        public string InformYourPassword(string password)
            {
            nameMethodInformYourPassword = System.Reflection.MethodBase.GetCurrentMethod().Name;

                try
                {
                    var passwordField = driver.FindElement(By.XPath("//*[@id='__next']/div/div[2]/div/div[2]/form/div[4]/div/input"));

                    passwordField.SendKeys(Keys.Control + "a");
                    passwordField.SendKeys(Keys.Delete);

                    bool completedSuccessfully = WriteText("//*[@id=\'__next\']/div/div[2]/div/div[2]/form/div[4]/div/input", password, "INFORME SUA SENHA");

                    if (completedSuccessfully)
                    {
                        resultCompletedPassword = true;

                        userPasswordCreated = "Senha criada com sucesso !";

                        generatedPassword = password;

                        byte[] successScreenshotPassword = CaptureScreenshot($"{nameMethodInformYourPassword}_Success");
                        AddScreenshot(successScreenshotPassword);
                }
                    else
                    {
                        resultCompletedPassword = false;
                        userPasswordCreated = "N/A";
                    }
                    return userPasswordCreated;
                }
                catch (Exception)
                {
                GenerateHtmlErrorReport(new string[] { $"{nameMethodInformYourPassword}: Validação falhou - Preenchimento de SENHA não realizado" }, fileName);
                throw;
            }
        }

        // Método para CADASTRAR confirmação de senha
        public string PasswordConfirmation()
        {
            nameMethodPasswordConfirmation = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                var passwordConfirmationField = driver.FindElement(By.XPath("//*[@id='__next']/div/div[2]/div/div[2]/form/div[5]/div/input"));

                passwordConfirmationField.SendKeys(Keys.Control + "a");
                passwordConfirmationField.SendKeys(Keys.Delete);

                bool completedConfirmationSuccessfully = WriteText("//*[@id=\'__next\']/div/div[2]/div/div[2]/form/div[5]/div/input", generatedPassword, "INFORME A CONFIRMAÇÃO DA SENHA");

                if (completedConfirmationSuccessfully)
                {
                    resultConfirmationPasswordCompleted = true;

                    userPasswordConfirmation = "Senha confirmada com sucesso !";

                    byte[] successScreenshotPassword = CaptureScreenshot($"{nameMethodPasswordConfirmation}_Success");
                    AddScreenshot(successScreenshotPassword);
                }
                else
                {
                    resultConfirmationPasswordCompleted = false;
                    userPasswordConfirmation = "N/A";
                }
                return userPasswordConfirmation;
            }
                catch (Exception)
                {
                GenerateHtmlErrorReport(new string[] { $"{nameMethodPasswordConfirmation}: Validação falhou - Confirmação de SENHA não realizado" }, fileName);
                throw;
                }
        }

        // Método para clicar no botão de REGISTRAR CONTA COM SALDO
        public void ClickcreateAccountWithBalanceButton()
        {
            nameMethodClickcreateAccountWithBalanceButton = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                Click("//*[@id=\'__next\']/div/div[2]/div/div[2]/form/div[6]/label", "Botão 'CRIAR CONTA COM SALDO'");

                balanceButtonClicked = true;

                byte[] successScreenshotRegisterButton = CaptureScreenshot($"{nameMethodClickcreateAccountWithBalanceButton}_Success");
                AddScreenshot(successScreenshotRegisterButton);
            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameMethodClickcreateAccountWithBalanceButton}: Validação falhou - Botão CRIAR CONTA COM SALDO não clicado" }, fileName);
                throw;
            }
        }

        // Método para clicar no botão de CADASTRAR
        public void ClickOnTheRegisterButton()
        {
            Thread.Sleep(2000);
            nameMethodClickOnTheRegisterButton = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                Click("//*[@id=\'__next\']/div/div[2]/div/div[2]/form/button", "Botão 'CADASTRAR' Conta");

                registerButtonClicked = true;

                byte[] successScreenshotRegisterButton = CaptureScreenshot($"{nameMethodClickOnTheRegisterButton}_Success");
                AddScreenshot(successScreenshotRegisterButton);
            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameMethodClickOnTheRegisterButton}: Validação falhou - Botão CADASTRAR CONTA não clicado" }, fileName);
                throw;
            }
        }

        // Método para clicar no botão de FECHAR, após o cadastro com sucesso
        public void ClickTheCloseButton()
        {
            Thread.Sleep(2000);
            nameMethodClickTheCloseButton = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                Click("//*[@id=\'btnCloseModal\']", "Botão 'FECHAR' na mensagem de Sucesso");

                closeButtonClicked = true;

                byte[] successScreenshotCloseButton = CaptureScreenshot($"{nameMethodClickTheCloseButton}_Success");
                AddScreenshot(successScreenshotCloseButton);
            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameMethodClickTheCloseButton}: Validação falhou - Botão FECHAR não clicado" }, fileName);
                throw;
            }
        }

        // Método para LOGAR com E-mail
        public string EmailCreated(string email)
        {
            Thread.Sleep(2000);
            nameMethodEmailCreated = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                bool emailFilled = WriteText("//*[@id=\'__next\']/div/div[2]/div/div[1]/form/div[1]/input", email, "Logar 'INFORME SEU E-MAIL'");

                if (emailFilled)
                {
                    emailFillingResult = true;

                    userEmailConfirmation = "E-mail preenchido com sucesso";

                    byte[] successScreenshotEmailCreated = CaptureScreenshot($"{nameMethodEmailCreated}_Success");
                    AddScreenshot(successScreenshotEmailCreated);
                }
                else
                {
                    emailFillingResult = false;
                    userEmailConfirmation = "N/A";
                }
                return userEmailConfirmation;
            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameMethodEmailCreated}: Validação falhou - Login de E-MAIL não realizada" }, fileName);
                throw;
            }
        }       

        // Método para LOGAR com SENHA criado
        public string PasswordCreated(string password)
        {
            Thread.Sleep(2000);
            nameMethodPasswordCreated = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                bool passwordlFilled = WriteText("//*[@id=\'__next\']/div/div[2]/div/div[1]/form/div[2]/div/input", password, "Logar 'INFORME SUA SENHA'");

                if (passwordlFilled)
                {
                    passwordFillingResult = true;

                    userPasswordConfirmation = "Senha preenchido com sucesso";

                    byte[] successScreenshotEmailCreated = CaptureScreenshot($"{nameMethodPasswordCreated}_Success");
                    AddScreenshot(successScreenshotEmailCreated);
                }
                else
                {
                    passwordFillingResult = false;
                    userPasswordConfirmation = "N/A";
                }
                return userPasswordConfirmation;
            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameMethodPasswordCreated}: Validação falhou - Login de SENHA não realizado" }, fileName);
                throw;
            }
        }

        // Método para clicar no botão de ACESSAR, após o cadastro
        public void ClickOnTheAccessButton()
        {
            Thread.Sleep(2000);
            nameMethodClickOnTheAccessButton = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                Click("//*[@id=\'__next\']/div/div[2]/div/div[1]/form/div[3]/button[1]", "Botão 'ACESSAR', 'Efetuou Login'");

                accessButtonClicked = true;

                byte[] successScreenshotAccessButton = CaptureScreenshot($"{nameMethodClickOnTheAccessButton}_Success");
                AddScreenshot(successScreenshotAccessButton);
            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameMethodClickOnTheAccessButton}: Validação falhou - Botão ACESSAR não clicado" }, fileName);
                throw;
            }
        }

        // Método para validar se o usuário criado é o logado
        public void TestNameField(string expectedName)
        {
            AssertNameFieldValue("Olá " + expectedName + ",");
        }

        // Método para clicar no botão de TRANSFERÊNCIA
        public void ClickTheTransferButton()
        {
            Thread.Sleep(2000);
            nameMethodClickTheTransferButton = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                Click("//*[@id=\'btn-TRANSFERÊNCIA\']", "Botão 'TRANSFERÊNCIA'");

                transferButtonClicked = true;

                byte[] successScreenshotAccessButton = CaptureScreenshot($"{nameMethodClickTheTransferButton}_Success");
                AddScreenshot(successScreenshotAccessButton);

            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameMethodClickTheTransferButton}: Validação falhou - Botão TRANSFERÊNCIA não clicado" }, fileName);
                throw;
            }
        }

        // Método para OBTER o número e digito da Conta Criada
        public (string accountNumber, string digitAccountVerificationType) ExtractValues()
        {
            try
            {
                IWebElement elemento = driver.FindElement(By.XPath("//*[@id='modalText']"));
                string texto = elemento.Text;

                // Expressão regular para extrair números da string
                Regex regex = new Regex(@"\b(\d+)\b");

                // Procurar por correspondências na string fornecida
                MatchCollection matches = regex.Matches(texto);

                // Extrair e armazenar os valores numéricos encontrados
                accountNumber = matches.Count > 0 ? matches[0].Value : string.Empty;
                digitAccountVerificationType = matches.Count > 1 ? matches[1].Value : string.Empty;

                Console.WriteLine($"Número da conta: {accountNumber}");
                Console.WriteLine($"Número do digito: {digitAccountVerificationType}");

                return (accountNumber, digitAccountVerificationType);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao extrair valores: {ex.Message}");
            }
        }

        // Método para INSERIR o Número da Conta para Transferência
        public string EnterTheAccountNumber(string conta)
        {
            Thread.Sleep(2000);
            nameEnterTheAccountNumber = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                Thread.Sleep(2000);
                bool completedSuccessfully = WriteText("//*[@id=\'__next\']/div/div[3]/form/div[1]/div[1]/input", conta);

                if (completedSuccessfully)
                {
                    Console.WriteLine($"Número da conta preenchida: {accountNumber}");
                }
                else
                {
                    resultOfTheAccountNumberFilledInByTheUser = false;
                    accountNumberFilledInByTheUser = "N/A";
                }
                return accountNumberFilledInByTheUser;
            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameEnterTheAccountNumber}: Validação falhou - Preenchimento do NÚMERO DA CONTA não realizado" }, fileName);
                throw;
            }
        }

        // Método para INSERIR o Digito da Conta para Transferência
        public string EnterTheAccountDigit(string digito)
        {
            Thread.Sleep(2000);
            nameEnterTheAccountDigit = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                bool completedSuccessfully = WriteText("//*[@id=\'__next\']/div/div[3]/form/div[1]/div[2]/input", digito);

                if (completedSuccessfully)
                {
                    Console.WriteLine($"Número do digito preenchido: {digitAccountVerificationType}");
                }
                else
                {
                    resultOfTheAccountDigitFilledInByTheUser = false;
                    accountDigitFilledInByTheUser = "N/A";
                }
                return accountDigitFilledInByTheUser;
            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameEnterTheAccountDigit}: Validação falhou - Preenchimento do DIGITO DA CONTA não realizado" }, fileName);
                throw;
            }
        }

        // Método para INSERIR o valor da transferência
        public string EnterTheTransferAmount()
        {
            Thread.Sleep(2000);
            nameEnterTheTransferAmount = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                bool completedSuccessfully = WriteText("//*[@id=\'__next\']/div/div[3]/form/div[2]/input", transferValue);

                if (completedSuccessfully)
                {
                    Console.WriteLine($"Valor da transferência é R$: {transferValue}");
                }
                else
                {
                    resultOfTheTransferAmount = false;
                    filledTransferAmount = "N/A";
                }
                return filledTransferAmount;
            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameEnterTheTransferAmount}: Validação falhou - Preenchimento INSERÇÃO DO VALOR DA TRANSFERÊNCIA não realizado" }, fileName);
                throw;
            }
        }

        // Método para INSERIR a DESCRIÇÃO da transferência
        public string EnterTransferDescription(string name)
        {
            Thread.Sleep(2000);
            nameEnterTransferDescription = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                bool completedSuccessfully = WriteText("//*[@id=\'__next\']/div/div[3]/form/div[3]/input", $"Transferência para {name}", "Transferência para: " + name);

                if (completedSuccessfully)
                {
                    TransferDescriptionResult = filledTransferDescription;
                }
                else
                {
                    resultOfTheTransferDescription = false;
                    filledTransferDescription = "N/A";
                }
                return filledTransferDescription;
            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameEnterTransferDescription}: Validação falhou - Preenchimento INSERÇÃO DA DESCRIÇÃO não realizado" }, fileName);
                throw;
            }
        }

        // Método para clicar no botão de TRANSFERIR
        public void ClickTheTransferNowButton()
        {
            Thread.Sleep(2000);
            nameMethodClickTheTransferNowButton = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                Click("//*[@id=\'__next\']/div/div[3]/form/button", "Botão 'TRANSFERIR AGORA'");

                transferButtonClicked = true;

                byte[] successScreenshotTransferNowButton = CaptureScreenshot($"{nameMethodClickTheTransferNowButton}_Success");
                AddScreenshot(successScreenshotTransferNowButton);

            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameMethodClickTheTransferNowButton}: Validação falhou - Botão TRANSFERIR não clicado" }, fileName);
                throw;
            }
        }

        // Método para clicar no botão de VOLTAR, após a transferÊncia
        public void ClickOnTheBackButton()
        {
            Thread.Sleep(2000);
            nameMethodClickOnTheBackButton = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                Click("//*[@id=\'__next\']/div/div[2]/div", "Botão 'VOLTAR' após transferência realizada");

                backButtonClicked = true;

                Thread.Sleep(2000);
                byte[] successScreenshotClickOnTheBackButton = CaptureScreenshot($"{nameMethodClickOnTheBackButton}_Success");
                AddScreenshot(successScreenshotClickOnTheBackButton);

            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameMethodClickOnTheBackButton}: Validação falhou - Botão VOLTAR não clicado" }, fileName);
                throw;
            }
        }

        // Método para clicar no botão de EXTRATO
        public void ClickTheExtractButton()
        {
            Thread.Sleep(2000);
            nameMethodClickTheExtractButton = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                Click("//*[@id=\'btn-EXTRATO\']", "Botão 'EXTRATO'");

                extractButtonClicked = true;

                Thread.Sleep(2000);
                byte[] successScreenshotExtractButton = CaptureScreenshot($"{nameMethodClickTheExtractButton}_Success");
                AddScreenshot(successScreenshotExtractButton);
            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameMethodClickTheExtractButton}: Validação falhou - Botão EXTRATO não clicado" }, fileName);
                throw;
            }
        }

        // Método para VALOR TRANSFERIDO
        public void AssertTransfer (string expectedAmount, string expectedRecipient)
        {
            // Transforma o valor esperado em negativo
            string expectedAmountNegative = string.Format("-R$\u00A0{0:N2}", double.Parse(expectedAmount.Replace("R$", "").Replace(",", "").Trim()));

            AssertTransferFields(expectedAmountNegative, $"Transferência para {expectedRecipient}");
        }

        // Método para clicar no botão de SAIR
        public void ClickTheExitButton()
        {
            Thread.Sleep(2000);
            nameMethodClickTheExitButton = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                Click("//*[@id=\'__next\']/div/div[1]/div", "Botão 'SAIR'");

                exitButtonClicked = true;

                byte[] successScreenshotExitButton = CaptureScreenshot($"{nameMethodClickTheExitButton}_Success");
                AddScreenshot(successScreenshotExitButton);
            }
            catch (Exception)
            {
                GenerateHtmlErrorReport(new string[] { $"{nameMethodClickTheExitButton}: Validação falhou - Botão SAIR não clicado" }, fileName);
                throw;
            }
        }

        // Método para VALOR RECEBIDO
        public void AssertTransferReceived(string expectedAmount, string expectedRecipient)
        {
            string expectedAmountNegative = string.Format("R$\u00A0{0:N2}", double.Parse(expectedAmount.Replace("R$", "").Replace(",", "").Trim()));

            AssertTransferFields(expectedAmountNegative, $"Transferência para {expectedRecipient}");
        }

        // Método para executar a geração de relatório HTML com base nos resultados dos testes
        public void RunReportGeneration(string testName)
        {
            fileName = $"Relatorio_{testName}_{DateTime.Now:yyyy-MM-dd_HH'h'mm'm'ss's'}.html";

            summary = $"Resumo_{testName}_{DateTime.Now:yyyy-MM-dd_HH'h'mm'm'ss's'}.html";

            List<string> results = new List<string>();

            // Adiciona os resultados das ações do usuário ao relatório
            try
            {                
                if (registerButtonClicked)
                {
                    // Adiciona o resultado do clique no botão de REGISTRAR
                    string registerButtonClicked = $"<strong>{nameMethodClickRegisterButton}:<strong> Sucesso !";
                    results.Add(registerButtonClicked);
                }

                if (resultOfTheEmailFilledInByTheUser)
                {
                    // Adiciona o resultado do CADASTRO do e-mail
                    string result = $"<strong>{nameEnterYourEmail}:<strong> {credentials.Email}";
                    results.Add(result);
                }

                if (userFilledNameResult)
                {
                    // Adiciona o resultado do CADASTRO do nome
                    string result = $"<strong>{nameProvideYourName}:<strong> {credentials.Name}";
                    results.Add(result);
                }

                if (resultCompletedPassword)
                {
                    // Adiciona o resultado do CADASTRO da senha
                    string resultsPassword = $"<strong>{nameMethodInformYourPassword}:<strong> {userPasswordCreated}";
                    results.Add(resultsPassword);
                }
               
                if (resultConfirmationPasswordCompleted)
                {
                    // Adiciona o resultado da CONFIRMAÇÃO DO CADASTRO da senha
                    string resultsConfirmationPassword = $"<strong>{nameMethodPasswordConfirmation}:<strong> {userPasswordConfirmation}";
                    results.Add(resultsConfirmationPassword);
                }
                
                if (balanceButtonClicked)
                {
                    // Adiciona o resultado do clique no botão de CRIAR CONTA COM SALDO
                    string balanceButtonClicked = $"<strong>{nameMethodClickcreateAccountWithBalanceButton}:<strong> Sucesso !";
                    results.Add(balanceButtonClicked);
                }

                if (registerButtonClicked)
                {
                    // Adiciona o resultado do clique no botão de CADASTRAR CONTA
                    string registerButtonClicked = $"<strong>{nameMethodClickOnTheRegisterButton}:<strong> Sucesso !";
                    results.Add(registerButtonClicked);
                }

                if (closeButtonClicked)
                {
                    // Adiciona o resultado do clique na mensagem de sucesso, botão de FECHAR
                    string closeButtonClicked = $"<strong>{nameMethodClickTheCloseButton}:<strong> Sucesso !";
                    results.Add(closeButtonClicked);
                }

                if (registerButtonClicked)
                {
                    // Adiciona o resultado do clique no botão de REGISTRAR
                    string registerButtonClicked = $"<strong>{nameMethodClickRegisterButton}:<strong> Sucesso !";
                    results.Add(registerButtonClicked);
                }

                if (resultOfTheEmailFilledInByTheUser)
                {
                    // Adiciona o resultado do CADASTRO do e-mail
                    string result = $"<strong>{nameEnterYourEmail}:<strong> {emailFilledInByTheUser}";
                    results.Add(result);
                }

                if (userFilledNameResult)
                {
                    // Adiciona o resultado do CADASTRO do nome
                    string result = $"<strong>{nameProvideYourName}:<strong> {userFilledName}";
                    results.Add(result);
                }

                if (resultCompletedPassword)
                {
                    // Adiciona o resultado do CADASTRO da senha
                    string resultsPassword = $"<strong>{nameMethodInformYourPassword}:<strong> {userPasswordCreated}";
                    results.Add(resultsPassword);
                }

                if (resultConfirmationPasswordCompleted)
                {
                    // Adiciona o resultado da CONFIRMAÇÃO DO CADASTRO da senha
                    string resultsConfirmationPassword = $"<strong>{nameMethodPasswordConfirmation}:<strong> {userPasswordConfirmation}";
                    results.Add(resultsConfirmationPassword);
                }

                if (registerButtonClicked)
                {
                    // Adiciona o resultado do clique no botão de CADASTRAR CONTA
                    string registerButtonClicked = $"<strong>{nameMethodClickOnTheRegisterButton}:<strong> Sucesso !";
                    results.Add(registerButtonClicked);
                }

                if (closeButtonClicked)
                {
                    // Adiciona o resultado do clique na mensagem de sucesso, botão de FECHAR
                    string closeButtonClicked = $"<strong>{nameMethodClickTheCloseButton}:<strong> Sucesso !";
                    results.Add(closeButtonClicked);
                }

                if (emailFillingResult)
                {
                    // Adiciona o resultado fazendo LOGIN com E-MAIL DO PRIMEIRO CADASTRO
                    string emailFillingResult = $"<strong>{nameMethodEmailCreated}:<strong> {userEmailConfirmation}";
                    results.Add(emailFillingResult);
                }

                if (passwordFillingResult)
                {
                    // Adiciona o resultado fazendo LOGIN com SENHA DO PRIMEIRO CADASTRO
                    string passwordFillingResult = $"<strong>{nameMethodPasswordCreated}:<strong> {userPasswordConfirmation}";
                    results.Add(passwordFillingResult);
                }

                if (accessButtonClicked)
                {
                    // Adiciona o resultado do clique, botão ACESSAR
                    string accessButtonClicked = $"<strong>{nameMethodClickOnTheAccessButton}:<strong> Sucesso !";
                    results.Add(accessButtonClicked);
                }

                if (transferButtonClicked)
                {
                    // Adiciona o resultado do botão de TRANSFERÊNCIA
                    string transferButtonClicked = $"<strong>{nameMethodClickTheTransferButton}:<strong> Sucesso !";
                    results.Add(transferButtonClicked);
                }

                if (accessButtonClicked)
                {
                    // Adiciona o resultado do clique, botão ACESSAR
                    string accessButtonClicked = $"<strong>{nameMethodClickOnTheAccessButton}:<strong> Sucesso !";
                    results.Add(accessButtonClicked);
                }

                if (closeButtonClicked)
                {
                    // Adiciona o resultado do clique na mensagem de sucesso, botão de FECHAR
                    string closeButtonClicked = $"<strong>{nameMethodClickTheCloseButton}:<strong> Sucesso !";
                    results.Add(closeButtonClicked);
                }

                if (backButtonClicked)
                {
                    // Adiciona o resultado do clique na mensagem de sucesso, botão de VOLTAR
                    string closebackButtonClicked = $"<strong>{nameMethodClickOnTheBackButton}:<strong> Sucesso !";
                    results.Add(closebackButtonClicked);
                }

                if (extractButtonClicked)
                {
                    // Adiciona o resultado do clique, botão EXTRATO
                    string extractButtonClicked = $"<strong>{nameMethodClickTheExtractButton}:<strong> Sucesso !";
                    results.Add(extractButtonClicked);
                }

                if (exitButtonClicked)
                {
                    // Adiciona o resultado do clique na mensagem de sucesso, botão de VOLTAR
                    string resultsExitButtonClicked = $"<strong>{nameMethodClickTheExitButton}:<strong> Sucesso !";
                    results.Add(resultsExitButtonClicked);
                }

                if (emailFillingResult)
                {
                    // Adiciona o resultado fazendo LOGIN com E-MAIL DO SEGUNDO CADASTRO
                    string emailFillingResult = $"<strong>{nameMethodEmailCreated}:<strong> {credentials.Email2}";
                    results.Add(emailFillingResult);
                }

                if (passwordFillingResult)
                {
                    // Adiciona o resultado fazendo LOGIN com SENHA DO PRIMEIRO CADASTRO
                    string passwordFillingResult = $"<strong>{nameMethodPasswordCreated}:<strong> {userPasswordConfirmation}";
                    results.Add(passwordFillingResult);
                }

                if (accessButtonClicked)
                {
                    // Adiciona o resultado do clique, botão ACESSAR
                    string accessButtonClicked = $"<strong>{nameMethodClickTheTransferNowButton}:<strong> Sucesso !";
                    results.Add(accessButtonClicked);
                }

                if (extractButtonClicked)
                {
                    // Adiciona o resultado do clique, botão EXTRATO
                    string extractButtonClicked = $"<strong>{nameMethodClickTheExtractButton}:<strong> Sucesso !";
                    results.Add(extractButtonClicked);
                }

                // Chama a geração do relatório HTML com os resultados coletados
                HTMLReportGenerator.GenerateHTMLReportWithScreenshots(results.ToArray(), screenshots.ToArray(), fileName);
                HTMLReportGenerator.GenerateHTMLGeneralReport(results.ToArray(), summary);   
                
            }
            catch (Exception ex)
            {
                GenerateHtmlErrorReport(results.ToArray(), summary);
                Console.WriteLine($"Erro ao gerar relatório: {ex.Message}");
            }
            finally
            {
                ClearScreenshots();
            } 
        }

        // Método para gerar um relatório HTML contendo apenas uma mensagem de erro
        public void GenerateHtmlErrorReport(string[] results, string summary)
        {
            HTMLReportGenerator.GenerateHTMLGeneralReport(results, summary);
        }
    }
} 

