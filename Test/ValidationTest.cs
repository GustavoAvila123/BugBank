using NUnit.Framework;
using PocAutomacao.Page;

namespace PocAutomacao.Test
{
    public class ValidationTest : ValidationPage
    {
        [Test]
        public void TransationExecution()
        {
            // Executando o primiero CADASTRO
            ClickRegisterButton();
            EnterYourEmail(credentials.Email);
            ProvideYourName(credentials.Name);
            InformYourPassword(credentials.Password);
            PasswordConfirmation();
            ClickcreateAccountWithBalanceButton();
            ClickOnTheRegisterButton();
            var valuesRegistration1 = ExtractValues();
            ClickTheCloseButton();

            // Executando o segundo CADASTRO
            ClickRegisterButton();
            EnterYourEmail(credentials.Email2);
            ProvideYourName(credentials.Name2);
            InformYourPassword(credentials.Password2);
            PasswordConfirmation();
            ClickOnTheRegisterButton();
            var valuesRegistration2 = ExtractValues();
            ClickTheCloseButton();

            // Logando com o primeiro CADASTRO realizado
            EmailCreated(credentials.Email);
            PasswordCreated(credentials.Password);
            ClickOnTheAccessButton();
            TestNameField(credentials.Name);

            // Executando TRANSFERÊNCIA de valores do PRIMEIRO CADASTRO para o SEGUNDO CADASTRO
            ClickTheTransferButton();
            EnterTheAccountNumber(valuesRegistration2.accountNumber);
            EnterTheAccountDigit(valuesRegistration2.digitAccountVerificationType);
            EnterTheTransferAmount();
            EnterTransferDescription(credentials.Name2);
            ClickTheTransferNowButton();
            ClickTheCloseButton();

            // Validando a TRANSFERÊNCIA efetuada com sucesso
            ClickOnTheBackButton();
            ClickTheExtractButton();
            AssertTransfer(transferValue, credentials.Name2);

            // Deslogando do PRIMEIRO cliente cadastrado
            ClickTheExitButton();

            // Logando com o segundo CADASTRO realizado
            EmailCreated(credentials.Email2);
            PasswordCreated(credentials.Password2);
            ClickOnTheAccessButton();
            TestNameField(credentials.Name2);

            // Validando a TRANSFERÊNCIA recebida com sucesso
            ClickTheExtractButton();
            AssertTransferReceived(transferValue, credentials.Name2);
        }

        // Executar relatório de geração de evidências ao final de cada teste
        [TearDown]
        public void RunReport()
        {
            RunReportGeneration(TestContext.CurrentContext.Test.MethodName);
        }
    }
}

