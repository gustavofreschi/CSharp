using System.Reflection;

class Dobro
{
    public static void Main(string []args)
    {
        Console.WriteLine("Digite um número:");
        int n1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Dobro: {DobroNumero(n1)}");
        Console.WriteLine($"Metade: {MetadeNumero(n1)}");
        TabuadaComWhile();
        SomaComDoWhile();
        Console.ReadLine();
    }
    public static int DobroNumero(int n)
    {
        return n * 2;
    }

    public static int MetadeNumero(int num)
    {
        return num / 2;
    }

    public static void TabuadaComWhile()
    {
        Console.WriteLine("Digite um número:");
        int number = Convert.ToInt32(Console.ReadLine());
        int tabuada = 1;
        while (tabuada <= 10)
        {
            Console.WriteLine($"{number} x {tabuada} = {number * tabuada}");
            tabuada++;
        }
    }

    public static void SomaComDoWhile()
    {
        int numeroDigitado;
        int maior = 0;
        int menor = 1000;
        int somar = 0;
        do
        {
            Console.WriteLine("Digite um número positivo:");
            numeroDigitado = Convert.ToInt32(Console.ReadLine());


            if (numeroDigitado > maior)
            {
                maior = numeroDigitado;

            }

            if (numeroDigitado < menor && numeroDigitado > 0)
            {
                menor = numeroDigitado;
            }

            if (numeroDigitado > 0)
            {
                somar = numeroDigitado + somar;
            }



        } while (numeroDigitado > 0);
        Console.WriteLine($"Soma total: {somar}");
        Console.WriteLine($"O maior número: {maior}");
        Console.WriteLine($"O menor número : {menor}");
    }


}