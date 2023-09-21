using System;
//Classe Pai que será herdada - SuperClasse
class Animal
{
    public string cor { get; set; }
    //Virtual permite que as classes filhas possam reescrever o método
    public virtual void EmitirSom()
    {
        Console.WriteLine($"Animal da cor {cor} fazendo algum som");
    }
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
        Animal animalGenerico = new Animal();
        animalGenerico.cor = "Preto";
        animalGenerico.EmitirSom();

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