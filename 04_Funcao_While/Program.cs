class Metodos 
{
    //Método Main é o ponto de entrada de um programa em C#
    public static void Main()
    {
      Console.WriteLine("Estou no método main");
      Metodo();
      ImprimeDataHora();
      //Chamando o método Somar enviando os parâmetros 3 e 8
      Console.WriteLine(Somar(3, 5));
      EstruturaControle();
      TabuadaFor();
      JogoQueNrSouEu();
      ContagemRegressiva(10);
      Console.ReadLine();
    }

    public static void Metodo()
    {
        Console.WriteLine("Estou no metodo / função");
    }

    public static void ImprimeDataHora() 
    {
        Console.WriteLine(DateTime.Now.ToShortDateString());
        Console.WriteLine(DateTime.Now.ToShortTimeString());
        Console.WriteLine(DateTime.Now.ToString());
    }

    public static int Somar(int num1, int num2) 
    {
      return num1 + num2;
    }


    public static void EstruturaControle()
    {
     int num = 5;
     int contador = 1;


     while (contador <= 10)
     {
        Console.WriteLine($"{contador}ª execução {num} x {contador} = {num * contador}");
        contador++;
     }
    }

    public static void TabuadaFor()
    {
        Console.WriteLine("Digite um número:");
        int numero = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{i}ª execução: {numero} x {i} = {numero * i}");
        }
    }

    public static void ContagemRegressiva(int n)
    {
        while (n >= 0)
        {
            Console.WriteLine(n);
            n--;
            System.Threading.Thread.Sleep(1000); //Pausa de um segundo
        }

        Console.WriteLine("Feliz ano novo!");
    }

    public static void JogoQueNrSouEu()
    {
        Console.WriteLine("************");
        Console.WriteLine("Bem-vindo ao jogo!");
        Console.WriteLine("Sorteei um nº de 1 a 20, tente adivinhá-lo");
        Console.WriteLine("************");
        Console.WriteLine("");

        Random rnd = new Random();

       int nrSorteado = rnd.Next(1,20);
       int nrDigitado = -1;

       int tentativas = 0;

        do {
            Console.WriteLine("Digite um nº:");
            nrDigitado = Convert.ToInt32(Console.ReadLine());
            if (nrDigitado > nrSorteado)
            {
                Console.WriteLine($"O número digitado ({nrDigitado}) é MAIOR que o sorteado.");
            } else if (nrDigitado < nrSorteado)
            {
                Console.WriteLine($"O número digitado ({nrDigitado}) é MENOR que o sorteado.");
            }
            tentativas++;
        } while (nrDigitado != nrSorteado);

        Console.WriteLine($"Parabéns, você acertou em {tentativas} tentativas! O número sorteado é {nrSorteado}");
    }


}