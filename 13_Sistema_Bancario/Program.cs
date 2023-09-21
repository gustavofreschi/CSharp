using System;
using Banco;


class Program
{
    public static void Main(string[] args)
    { 
        ContaCorrente conta = new ContaCorrente("Roberto", 0);
        ContaCorrente conta2 = new ContaCorrente("Fernando", 5);
        conta2.Logar();
        
        conta2.Menu();
        
        Console.ReadLine();
    }
}