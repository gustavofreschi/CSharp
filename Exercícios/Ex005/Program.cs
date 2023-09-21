class Program
{
    public static void Main(string[] args)
    {
      ListaDoChurrasco();
      SonhosDeConsumo();

      Console.ReadLine();
    }

    public static void ListaDoChurrasco()
    {
        string[] churrasco = new string[4];
        

        for (int i = 0; i < churrasco.Length; i++)
        {
            Console.WriteLine("Digite um produto para o churrasco:");
            churrasco[i] = Console.ReadLine();
        }
        
        Array.Sort(churrasco);

        foreach (string item in churrasco)
        {
            Console.WriteLine($"Produto: {item}");
        }
    }

    public static void SonhosDeConsumo()
    {
        string[] sonhos = new string[3];

        int[] valor = new int[3];

        int soma = 0;

        for (int i = 0; i < sonhos.Length; i++)
        {
            Console.WriteLine("Digite um sonho de consumo:");
            sonhos[i] = Console.ReadLine();
            Console.WriteLine("Digite o preço desse produto:");
            valor[i] = Convert.ToInt32(Console.ReadLine());

            soma = valor[i] + soma;
        }

        Array.Sort(sonhos);

        foreach (string item in sonhos)
        {
            Console.WriteLine($"Sonho: {item}");

        }
        Console.WriteLine($"Preço total: {soma}");
    }
}