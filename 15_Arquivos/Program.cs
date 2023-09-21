using System;
using System.IO;

public class Program
{
    public static void Main(string[] args) 
    {
       GravarArquivo();
       LerArquivo();

       Console.ReadLine();
    }

    public static void GravarArquivo()
    {
        try
        {
            //Gravando no arquivo de texto
            using (StreamWriter arquivo = new StreamWriter("arquivo.txt", true))
            {
                Console.WriteLine("Digite um texto para gravar no arquivo:");
                arquivo.WriteLine(Console.ReadLine());
                
            }
        }
        catch (Exception erro)
        {
            Console.WriteLine($"Ocorreu um erro no arquivo: {erro.Message}");
        }
    }

    public static void LerArquivo()
    {
        using (StreamReader arquivo = new StreamReader("arquivo.txt"))
        {
            string linha;
            while ((linha = arquivo.ReadLine()) != null)
            {
                Console.WriteLine(linha);
            }
        }
    }
}
