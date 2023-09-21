using System;

public class Program
{
    public static string[] carros = {};
    public static void Main(string[] args)
    {
        //Criando uma classe anônima
        var pessoa = new {nome = "João", idade = 16};
        Console.WriteLine($"Nome: {pessoa.nome}, Idade: {pessoa.idade}");

        var pessoa2 = new 
        {
            nome = "Roberto",
            idade = 14
        };

        Console.WriteLine($"a Pessoa 1 se chama {pessoa.nome}, e a Pessoa 2 se chama {pessoa2.nome}.");

        Console.WriteLine("Digite a marca do carro:");
        string marcaCarro = Console.ReadLine();

        Console.WriteLine("Digite o modelo do carro:");
        string modeloCarro = Console.ReadLine();

        Console.WriteLine("Digite o ano do carro:");
        int anoCarro = Convert.ToInt32(Console.ReadLine());
        

        /* 
        var carro = new 
        {
            marca = Console.ReadLine(),
            modelo = Console.ReadLine(),
            ano =  Console.ReadLine()
        };
         */

        var carro = new 
        {
            marca = marcaCarro,
            modelo = modeloCarro,
            ano =  anoCarro
        };

        Console.WriteLine($"O carro é da Marca {carro.marca}, Modelo {carro.modelo}, Ano {carro.ano}");
        
        Console.ReadLine();     
          
    }


}

