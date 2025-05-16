using System.Runtime.InteropServices;

namespace TopicosAvancados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Trabalhando com o SO");
            SistemaOperacional.ExibirSO(); // Exibe o sistema operacional
            SistemaOperacional.ExibirTipoSO(); // Exibe o tipo do sistema operacional

            Console.WriteLine("========================================================");

            Console.WriteLine("Trabalhando com arquivos e diretórios");

            // Exibe os diretórios
            Arquivo.ExibirDiretorios(@"C:\Users\danie\Downloads");

            // Exibe os arquivos
            Arquivo.ExibirArquivos(@"C:\Users\danie\OneDrive\Documentos\Arquivos PDF\Documentos pessoais");

            // Exibe o tamanho dos arquivos
            Arquivo.ExibirTamanhoArquivo(@"C:\Users\danie\OneDrive\Documentos\Arquivos PDF\Documentos pessoais");

            // Verifica se o caminho existe
            bool existencia = Arquivo.VerificarExistencia(@"C:\Users\danie\OneDrive\Documentos\Arquivos PDF\Documentos pessoais");
            Console.WriteLine(existencia == false ? "O caminho não existe" : "O caminho existe"); // Escreve a existência
        }
    }

    public class SistemaOperacional
    {
        public static void ExibirSO()
        {
            Console.WriteLine(Environment.OSVersion.VersionString); // Exibe o sistema operacional
        }

        public static void ExibirTipoSO()
        {
            // Verifica se o sistema é Windows
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) // Se for Windows
            {
                Console.WriteLine("Sistema operacional: Windows");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) // Se for Mac
            {
                Console.WriteLine("Sistema operacional: MacOS");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) // Se for Linux
            {
                Console.WriteLine("SIstema operacional: Linux");
            }
        }
    }

    public class Arquivo
    {
        public static void ExibirDiretorios(string caminho)
        {
            // Armazena as pastas dentro do caminho especificado em um array
            string[] diretorios = Directory.GetDirectories(caminho, "*", SearchOption.AllDirectories);

            /*
             Directory.GetDirectories(caminho, "*", SearchOption.AllDirectories);
                Procura todos os diretórios e subdiretórios do caminho especificado

             Directory.GetDirectories(caminho);
                Procura apenas os diretórios encontrados no caminho especificado
            */

            // Percorre o array de diretorios
            foreach (string diretorio in diretorios)
            {
                Console.WriteLine(diretorio);
            }
        }

        public static void ExibirArquivos(string caminho)
        {
            // Pega apenas os arquivos da última pasta do caminho
            var arquivos = Directory.GetFiles(caminho, "*.*", SearchOption.AllDirectories);

            /*
             Directory.GetDirectories(caminho, "*", SearchOption.TopDirectoryOnly);
                Procura todos os arquivos apenas da última pasta do caminho

             Directory.GetDirectories(caminho, "*.*", SearchOption.AllDirectories);
                Procura todos arquivos encontrados a partir do caminho especificado
            */

            foreach (string arquivo in arquivos)
            {
                Console.WriteLine(arquivo);
            }
        }

        public static void ExibirTamanhoArquivo(string caminho)
        {
            var arquivos = Directory.GetFiles(caminho, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string arquivo in arquivos)
            {
                Console.WriteLine(arquivo.Length); // Exibe o tamanho do arquivo em bytes
            }
        }

        public static bool VerificarExistencia(string caminho)
        {
            bool existencia = Directory.Exists(caminho); // Verifica se o caminho existe
            return existencia;
        }
    }
}