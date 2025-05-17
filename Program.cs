using System.Runtime.InteropServices;

namespace TopicosAvancados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arquivo.LeituraArquivo(@"C:\Users\danie\OneDrive\Documentos\Arquivos PDF\ArquivosCriadosDeProgramas\Texto.txt");
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
            if (Directory.Exists(Path.GetDirectoryName(arquivo)))
            {
                if (!File.Exists(arquivo))
                {
                    File.Create(arquivo); // Cria um arquivo
                }
                else
                {
                    throw new Exception("O arquivo já existe");
                }
            }
            else
            {
                throw new Exception("O diretório para criar o arquivo não existe");
            }
        }

        public static void CopiarArquivo(string origem, string destino)
        {
            if (File.Exists(origem) && !File.Exists(destino))
            {
                File.Copy(origem, destino); // Copia o arquivo e cola no destino
            }
            else
            {
                throw new Exception("Não foi possível copiar o arquivo");
            }
        }

        public static void MoverApenasArquivos(string origem, string destino)
        {
            try
            {
                // Pega todos os arquivos do caminho especificado
                var arquivos = Directory.GetFiles(origem, "*.*", SearchOption.AllDirectories);

                foreach (var arquivo in arquivos)
                {
                    // Combina o nome do caminho do destino com o nome do arquivo
                    string novoCaminho = Path.Combine(destino, Path.GetFileName(arquivo));
                    File.Move(arquivo, novoCaminho);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

        public static void LeituraArquivo(string caminho)
        {
            using (StreamReader leitor = new StreamReader(caminho))
            {
                string? linha;
                while ((linha = leitor.ReadLine()) != null)
                {
                    // Exibe cada linha enquanto houver algo escrito nelas
                    Console.WriteLine(linha);
                }
            } // O arquivo é fechado automaticamente
        }

        public static void Escrever(string caminho)
        {
            using (StreamWriter escritor = new StreamWriter(caminho))
            {
                escritor.WriteLine("Olá, Mundo!"); // Escrevendo com StreamWriter
            } // O arquivo é fechado automaticamente
        }
    }

    class Threadings
    {

    }
}