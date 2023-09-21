using System;
using System.Collections.Generic;
using Sesi.Models;

class Program
{
    public static void Main(string[] args)
    {
        //Criando uma lista de números inteiros
        List<int> listaNumeros = new List<int>();

        //Adicionando elementos à lista
        listaNumeros.Add(10); //posição [0]
        listaNumeros.Add(20); //posição [1]
        listaNumeros.Add(45); //posição [2]

        //Contando a quantidade de elementos em nossa lista
        Console.WriteLine($"Neste momento temos {listaNumeros.Count} números.");

        //Acessando os dados da lista pelo índice
        Console.WriteLine(listaNumeros[1]);

        listaNumeros.Add(6); //posição [3]
        Console.WriteLine($"Neste momento temos {listaNumeros.Count} números.");

        Console.WriteLine("-----------------------------------------------------");

        //Nova lista de nomes e adicionando alguns nomes à ela e exibindo a quantidade de nomes que contém nessa lista

        List<string> listaNomes = new List<string>();

        listaNomes.Add("Gustavo"); //posição [0]
        listaNomes.Add("Heitor"); //posição [1]
        listaNomes.Add("Guilherme"); //posição [2]


        Console.WriteLine($"Atualmente, há {listaNomes.Count} nomes na lista.");

        foreach (string item in listaNomes)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("-----------------------------------------------------");

        //Criando uma lista já atribuindo valores
        List<int> numbers = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9};
        numbers.Add(10);

        //Iterando sobre todos os itens da lista
        
        foreach (int item in numbers)
        {
            Console.WriteLine(item);
        }
        
        /*for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine($"Número {numbers[i]} na posição {i}.");
        }*/

        numbers.Remove(2); //Remove o elemento buscando pelo conteúdo dele
        numbers.RemoveAt(4); //Remove o elemento pela posição
        numbers.RemoveRange(2, 2); //Remove o elemento da posição 2 e os próximos dois elementos

        foreach (int item in numbers)
        {
            Console.WriteLine(item);
        }


        //Criando uma nova lista com objetos da classe Aluno
        List<Aluno> listaAlunos = new List<Aluno>();

        //Adicionado um novo aluno à listaAlunos
        Aluno novoAluno = new Aluno("Marcos", 15);
        listaAlunos.Add(novoAluno);

        listaAlunos.Add(new Aluno("Gustavo", 16));
        listaAlunos.Add(new Aluno("Fernando", 15));
        listaAlunos.Add(new Aluno("Heitor", 20));

        foreach (Aluno item in listaAlunos)
        {
            Console.WriteLine($"Nome: {item.nome} || Idade: {item.idade}");
        }

        Console.WriteLine("-----------------------------------------------------");

        //Criando uma nova lista, filtrando e ordenano por nome
        //LINQ utilizando Sintaxe de consulta
        var consulta = from Aluno in listaAlunos
                        where Aluno.idade > 18
                        orderby Aluno.nome
                        select Aluno;

        
        Console.WriteLine("Lista de alunos maiores de 18 anos");
        foreach (var item in consulta)
        {
            Console.WriteLine($"Nome: {item.nome} || Idade: {item.idade}");
        }

        Console.WriteLine("-----------------------------------------------------");

        //LINQ utilizando Sintaxe de método
        var metodo = listaAlunos
                        .Where(Aluno => Aluno.idade < 18)
                        .OrderBy(Aluno => Aluno.nome);

        foreach (var item in metodo)
        {
            Console.WriteLine($"Nome: {item.nome} || Idade: {item.idade}");
        }

        Console.ReadLine();
    }
}
