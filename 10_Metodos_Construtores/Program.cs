using System;
using Models;


public class Program
{
    public static void Main(string[] args)
    {
        //Criar um objeto da classe Pessoa
        /*
        Instanciando objeto sem método construtor
        Pessoa pessoa1 = new Pessoa();
        pessoa1.nome = "Adalberto";
        pessoa1.idade = 16;

        Pessoa pessoa1 = new Pessoa
        {
            nome = "Adalberto",
            idade = 28
        }
        
        */


        //Instanciando objeto usando método construtor
        Pessoa pessoa1 = new Pessoa("Adalberto", 16);
        pessoa1.Cantar();

        Pessoa pessoa2 = new Pessoa("Roberto", 17);
        pessoa2.Cantar();

        Pessoa pessoa3 = new Pessoa("José", 19);
        pessoa3.Cantar();

        


        Console.ReadLine();
    }
}


