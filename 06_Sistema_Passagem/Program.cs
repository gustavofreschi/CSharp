using System;
class Program
{
    public static string[] poltronas = new string[51];


    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Bem-vindo ao SesiBus ");
        Console.WriteLine("--------------------");
        Console.WriteLine("Contamos com 50 lugares disponíveis");

        Menu();

        Console.ReadLine();
    }

    public static void Menu()
    {
        string opcao = "";

        do
        {
            Console.WriteLine("***********M E N U************");
            Console.WriteLine("1 - Para comprar passagem");
            Console.WriteLine("2 - Para poltronas disponíveis");
            Console.WriteLine("3 - Para quantidade de vagas disponíveis");
            Console.WriteLine("4 - Para quantidade de passageiros do ônibus");
            Console.WriteLine("0 - Para fechar sistema");
            opcao = Console.ReadLine();
            Console.Clear();

            switch (opcao)
            {
                case "0":
                    Console.WriteLine("Obrigado, volte sempre!");
                    Thread.Sleep(2000);
                    break;
                case "1":
                    ComprarPassagem();
                    break;
                case "2":
                    PoltronasDisponiveis();
                    break;
                case "3":
                    QuantidadesDisponiveis();
                    break;
                case "4":
                    PassageirosOnibus();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;

            }

            


        } while (opcao != "0");

    }

    public static void ComprarPassagem()
    {
        Console.WriteLine("Quantas passagens deseja comprar?");
        int nrPassagens = Convert.ToInt32(Console.ReadLine());
        int nrPoltrona = 0;
        string nome = "";

        for (int i = 1; i <= nrPassagens; i++)
        {
            Console.WriteLine($"Digite a poltrona da {i}ª passagem:");
            nrPoltrona = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe o nome do passageiro");
            nome = Console.ReadLine();
            MarcarPoltrona(nrPoltrona, nome);
        }
        


    }

    public static void MarcarPoltrona(int nrPoltrona, string nome)
    {
        poltronas[nrPoltrona] = nome;
    }

    public static void PoltronasDisponiveis()
    {
        Console.WriteLine("Lista de poltronas disponíveis");

        for (int i = 1; i <= 50; i++)
        {
            if (poltronas[i] == null)
            {
                Console.WriteLine($"Nº {i}");
            }
        }
    }

    public static void QuantidadesDisponiveis()
    {
      int contador = 0;
      for (int i = 1; i < poltronas.Length; i++)
      {
        if (poltronas[i] == null)
        {
            contador++;
        }
        
      }
      Console.WriteLine($"Atualmente há {contador} vagas disponíveis.");
    }

    public static void PassageirosOnibus()
    {
        for (int i = 1; i < poltronas.Length; i++)
        {
          if (poltronas[i] != null)
          {
            Console.WriteLine($"Poltrona: {i} | Nome: {poltronas[i]}");
          }
        }
    }
}