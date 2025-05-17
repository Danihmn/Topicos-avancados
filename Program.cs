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

            // Cria novo diretório
            Arquivo.CriarDiretorio(@"C:\Users\danie\OneDrive\Documentos\Arquivos PDF\ArquivosCriadosDeProgramas");

            // Cria novo arquivo
            Arquivo.CriarArquivo(@"C:\Users\danie\OneDrive\Documentos\Arquivos PDF\ArquivosCriadosDeProgramas\Texto.txt");

            // Copia arquivo
            Arquivo.CopiarArquivo(
                @"C:\Users\danie\OneDrive\Documentos\Arquivos PDF\ArquivosCriadosDeProgramas\Texto.txt",
                @"C:\Users\danie\OneDrive\Documentos\Arquivos PDF\ArquivosCriadosDeProgramas\Cópia.txt"
                ); // Ele não move o arquivo, apenas copia, ou seja, duplica

            // Move o arquivo
            Arquivo.MoverArquivo(
                @"C:\Users\danie\OneDrive\Documentos\Arquivos PDF\ArquivosCriadosDeProgramas\Texto.txt",
                @"C:\Users\danie\OneDrive\Documentos\Arquivos PDF\ArquivosCopiados\Texto.txt"
                ); // Ele move o arquivo, passa de uma pasta para outra

            // Deleta o arquivo
            Arquivo.DeletarArquivo(@"C:\Users\danie\OneDrive\Documentos\Arquivos PDF\ArquivosCopiados\Texto.txt");

            // Deleta o diretório
            Arquivo.DeletarDiretorio(@"C:\Users\danie\OneDrive\Documentos\Arquivos PDF\ArquivosCopiados");
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

        public static void CriarDiretorio(string local)
        {
            if (!Directory.Exists(local))
            {
                Directory.CreateDirectory(local); // Cria um diretório no caminho especificado
            }
        }

        public static void CriarArquivo(string arquivo)
        {
            if (!File.Exists(arquivo))
            {
                File.Create(arquivo); // Cria um arquivo
            }
        }

        public static void CopiarArquivo(string origem, string destino)
        {
            if (File.Exists(origem) && !File.Exists(destino))
            {
                File.Copy(origem, destino); // Copia o arquivo e cola no destino
            }
        }

        public static void MoverArquivo(string origem, string destino)
        {
            if (File.Exists(origem) && !File.Exists(destino))
            {
                File.Move(origem, destino); // Move o arquivo para o destino
            }
        }

        public static void DeletarArquivo(string arquivo)
        {
            File.Delete(arquivo); // Deleta o caminho do arquivo
        }

        public static void DeletarDiretorio(string diretorio)
        {
            Directory.Delete(diretorio); // Deleta o caminho do diretório
        }
    }
}