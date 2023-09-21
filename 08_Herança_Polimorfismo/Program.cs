using System;
using Heranca;

class Program
{
    public static void Main(string[] args)
    {
        Gato meuGato = new Gato();
        meuGato.nome = "Bichano";
        meuGato.cor = "Preto";
        meuGato.idade = 6;
        meuGato.especie = "Vira-Lata";
        meuGato.genero = "Macho";
        meuGato.peso = 3;


        Peixe meuPeixe = new Peixe();
        meuPeixe.especie = "Palhaço";
        meuPeixe.cor = "Laranja";
        meuPeixe.tamanho = 0.20M;
        meuPeixe.peso = 0.100M;

        meuGato.EmitirSom();

        Console.ReadLine();        
        
    }
}