using System;
using System.IO;

namespace PocAutomacao.Center
{
    public class HTMLReportGenerator
    {
        public static void GenerateHTMLReportWithScreenshots(string[] results, byte[][] screenshots, string fileName)
        {
            try
            {
                // Define o caminho do diretório onde o relatório será salvo
                string directoryPath = @"C:\AutomacaoC#\PocAutomacao\Relatório de Testes";
                string filePath = Path.Combine(directoryPath, fileName);

                // Escreve o conteúdo do relatório HTML
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    // Escreve o cabeçalho HTML
                    sw.WriteLine("<!DOCTYPE html>");
                    sw.WriteLine("<html>");
                    sw.WriteLine("<head>");
                    sw.WriteLine("<meta charset=\"UTF-8\">");
                    sw.WriteLine("<title>Relatório de Teste</title>");
                    sw.WriteLine("</head>");

                    // Estilos CSS
                    sw.WriteLine("<style>");
                    sw.WriteLine("    body {");
                    sw.WriteLine("        background-image: linear-gradient(to right bottom, rgb(214, 42, 146), rgb(164, 34, 227));");
                    //sw.WriteLine("        background-color: #0045b5;");
                    sw.WriteLine("        color: #fff;"); // Adicionando cor branca ao texto do corpo
                    sw.WriteLine("        font-family: Nunito, sans-serif;");
                    sw.WriteLine("        font-weight: 400;");
                    sw.WriteLine("        margin: 0;");
                    sw.WriteLine("        padding: 0;");
                    sw.WriteLine("    }");
                    sw.WriteLine("    .titulo {");
                    sw.WriteLine("        font-family: Nunito, sans-serif;");
                    sw.WriteLine("        font-weight: 700;");
                    sw.WriteLine("        color: #fff;"); // Adicionando cor azul ao fundo
                    sw.WriteLine("        font-size: 40px;");
                    sw.WriteLine("        line-height: 48px;");
                    sw.WriteLine("        margin-bottom: 20px;");
                    sw.WriteLine("    }");
                    sw.WriteLine("</style>");
                    sw.WriteLine("</head>");

                    // Corpo do HTML
                    sw.WriteLine("<body>");

                    sw.WriteLine("<div>");

                    // Pula uma linha
                    sw.WriteLine("<br>");

                    // URL do logo
                    sw.WriteLine($"<img src=\" https://bugbank.netlify.app/_ipx/w_256,q_75/%2F_next%2Fstatic%2Fmedia%2Fbugbank.ede6fc83.png?url=%2F_next%2Fstatic%2Fmedia%2Fbugbank.ede6fc83.png&w=256&q=75\" alt=\"Logotipo da Empresa\" style=\"width: 300px; display: inline-block; vertical-align: middle; margin-left: 10px;\">");

                    // Título do relatório
                    sw.WriteLine($"<h1 style=\"display: inline-block; vertical-align: middle; margin-left: 20px; margin-right: 20px; font-family: Nunito-titulos, sans-serif; color: #fff;\">RELATÓRIO DO TESTE</h1>");
                    sw.WriteLine("</div>");

                    // Pula uma linha
                    sw.WriteLine("<br>");

                    // Inicia a tabela de resultados
                    sw.WriteLine("<table border=\"1\">");
                    sw.WriteLine("<tr><th>SCENARIO</th><th>RESULT</th><th>PRINT SCREEN</th></tr>");

                    // Itera sobre os resultados dos testes
                    for (int i = 0; i < results.Length; i++)
                    {
                        string[] partes = results[i].Split(':');
                        string cenario = partes[0];
                        string resultadoTeste = partes[1];

                        // Escreve uma linha na tabela para cada resultado de teste
                        sw.WriteLine("<tr>");
                        sw.WriteLine($"<td style=\"padding: 0 10px; text-align: center;\">{cenario}</td>");
                        sw.WriteLine($"<td style=\"padding: 0 10px; text-align: center; \">{resultadoTeste}</td>");

                        // Verifica se há screenshot disponível
                        if (screenshots.Length > i && screenshots[i] != null)
                        {
                            sw.WriteLine($"<td style=\"text-align: center; padding: 15px;\"><img src=\"data:image/png;base64,{Convert.ToBase64String(screenshots[i])}\"/></td>");
                        }
                        else
                        {
                            sw.WriteLine("<td>Sem captura de tela</td>");
                        }

                        sw.WriteLine("</tr>");
                    }

                    // Finaliza a tabela e o corpo do HTML
                    sw.WriteLine("</table>");
                    sw.WriteLine("</body>");
                    sw.WriteLine("</html>");
                }

                // Exibe a mensagem de sucesso com o caminho do relatório gerado
                Console.WriteLine($"Relatório gerado em: {filePath}");
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro se ocorrer uma exceção durante a geração do relatório
                Console.WriteLine($"Erro ao gerar relatório HTML: {ex.Message}");
            }
        }

        public static void GenerateHTMLGeneralReport(string[] results, string Summary)
        {
            try
            {
                // Define o caminho do diretório onde o relatório será salvo
                string directoryPath = @"C:\AutomacaoC#\PocAutomacao\Resumo de Testes";
                string filePath = Path.Combine(directoryPath, Summary);

                // Escreve o conteúdo do relatório HTML
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    // Escreve o cabeçalho HTML
                    sw.WriteLine("<!DOCTYPE html>");
                    sw.WriteLine("<html>");
                    sw.WriteLine("<head>");
                    sw.WriteLine("<meta charset=\"UTF-8\">");
                    sw.WriteLine("<title>Relatório Geral de Testes</title>");
                    sw.WriteLine("</head>");

                    // Estilos CSS
                    sw.WriteLine("<style>");
                    sw.WriteLine("    body {");
                    sw.WriteLine("        background-color: #0045b5;");
                    sw.WriteLine("        color: #fff;"); // Adicionando cor branca ao texto do corpo
                    sw.WriteLine("        font-family: Nunito, sans-serif;");
                    sw.WriteLine("        font-weight: 400;");
                    sw.WriteLine("        margin: 0;");
                    sw.WriteLine("        padding: 0;");
                    sw.WriteLine("    }");
                    sw.WriteLine("</style>");
                    sw.WriteLine("</head>");

                    // Pula uma linha
                    sw.WriteLine("<br>");

                    // Imagem de fundo
                    sw.WriteLine("<body style=\"background-image: url('https://marketplace.canva.com/EAFYIWPCudg/1/0/1600w/canva-papel-de-parede-para-computador-astronauta-gal%C3%A1xia-preto-e-branco-lKp1cXK1ybY.jpg'); background-repeat: no-repeat;background-size: 100%; margin-left: 10px;\">");

                    sw.WriteLine("<div>");
                    sw.WriteLine($"<img src=\"https://bugbank.netlify.app/_ipx/w_256,q_75/%2F_next%2Fstatic%2Fmedia%2Fbugbank.ede6fc83.png?url=%2F_next%2Fstatic%2Fmedia%2Fbugbank.ede6fc83.png&w=256&q=75\" alt=\"Logotipo da Empresa\" style=\"width: 300px; display: inline-block; vertical-align: middle;\">");
                    sw.WriteLine($"<h1 style=\"display: inline-block; vertical-align: middle; margin-left: 20px; margin-right: 20px; font-family: Nunito-titulos, sans-serif; color: #fff;\">RESUMO DO RELATÓRIO DE TESTES</h1>");
                    sw.WriteLine("</div>");

                    // Pula uma linha
                    sw.WriteLine("<br>");

                    // Inicia a tabela de resultados
                    sw.WriteLine("<table border=\"1\">");
                    sw.WriteLine("<tr><th>SCENARIO</th><th>RESULT</th>");

                    // Itera sobre os resultados dos testes
                    for (int i = 0; i < results.Length; i++)
                    {
                        string[] partes = results[i].Split(':');
                        string cenario = partes[0];
                        string resultadoTeste = partes[1];

                        // Escreve uma linha na tabela para cada resultado de teste
                        sw.WriteLine("<tr>");
                        sw.WriteLine($"<td style=\"padding: 0 10px; text-align: center;\">{cenario}</td>");
                        sw.WriteLine($"<td style=\"padding: 0 10px; text-align: center;\">{resultadoTeste}</td>");

                        sw.WriteLine("</tr>");
                    }

                    // Finaliza a tabela e o corpo do HTML
                    sw.WriteLine("</table>");
                    sw.WriteLine("</body>");
                    sw.WriteLine("</html>");
                }

                // Exibe a mensagem de sucesso com o caminho do relatório gerado
                Console.WriteLine($"Relatório geral gerado em: {filePath}");
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro se ocorrer uma exceção durante a geração do relatório
                Console.WriteLine($"Erro ao gerar relatório geral HTML: {ex.Message}");
            }
        }        
    }
}