using System;

namespace PocAutomacao.Center

{
    public class CredentialsManager
    {
        // Propriedades para armazenamento
        public string Email { get; }
        public string Email2 { get; }
        public string Password { get; }
        public string Password2 { get; }
        public string Name { get; }
        public string Name2 { get; }

        // Construtor da classe CredentialsManager para inicializar as credenciais de e-mail e senha
        public CredentialsManager(string email, string password, string name, string email2, string password2, string name2)
        {
            Email = email;
            Password = password;
            Name = name;
            Email2 = email2;
            Password2 = password2;
            Name2 = name2;
        }

        // // Obtém as credenciais de acesso a partir das variáveis de ambiente EMAIL e PASSWORD
        public static CredentialsManager GetCredentialsFromEnvironment()
        {
            // Obtém o valor da variável de ambiente EMAIL
            string email = Environment.GetEnvironmentVariable("EMAIL");

            // Obtém o valor da variável de ambiente EMAIL2
            string email2 = Environment.GetEnvironmentVariable("EMAIL2");

            // Obtém o valor da variável de ambiente PASSWORD
            string password = Environment.GetEnvironmentVariable("PASSWORD");

            // Obtém o valor da variável de ambiente PASSWORD2
            string password2 = Environment.GetEnvironmentVariable("PASSWORD2");

            // Obtém o valor da variável de ambiente NAME
            string name = Environment.GetEnvironmentVariable("NAME");

            // Obtém o valor da variável de ambiente NAME2
            string name2 = Environment.GetEnvironmentVariable("NAME2");

            // Verifica se as variáveis de ambiente estão configuradas
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(email2) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(password2) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(name2))
            {
                // Se uma ou ambas as variáveis de ambiente não estiverem configuradas, lança uma exceção
                throw new ApplicationException("As variáveis de ambiente EMAIL e PASSWORD não estão configuradas.");
            }

            // Retorna uma instância de CredentialsManager com as credenciais obtidas das variáveis de ambiente
            return new CredentialsManager(email, password, name, email2, password2, name2);
        }
    }
}



