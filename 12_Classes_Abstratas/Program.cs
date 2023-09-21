using System;
//Classe Pai abstrata (não existe)
abstract class Animal
{
    public string cor { get; set; }

    public abstract void EmitirSom();
}

//Classe filha que herdará da classe Animal
class Cachorro : Animal
{
    //Override reescreve o método da classe Pai (Animal)
    public override void EmitirSom()
    {
        Console.WriteLine($"Cachorro da cor {cor} está latindo.");
    }
}

class Gato : Animal
{
    public override void EmitirSom()
    {
        Console.WriteLine($"Gato da cor {cor} está miando.");
    }

    public void Ronronar()
    {
        Console.WriteLine("O gato está ronronando!");
    }
}

class Program
{
    public static void Main(string[] args)
    {

        /*
        //Não é permitido criar um objeto de uma classe abstrata
        //Só conseguimos criar de sua classe derivada
        Animal animalGenerico = new Animal();
        animalGenerico.cor = "Preto";
        animalGenerico.EmitirSom();
        */

        Cachorro meuCachorro = new Cachorro();
        meuCachorro.cor = "Caramelo";
        meuCachorro.EmitirSom();

        Gato meuGato = new Gato();
        meuGato.cor = "Cinza";
        meuGato.EmitirSom();
        meuGato.Ronronar();

        Console.ReadLine();
    }
}