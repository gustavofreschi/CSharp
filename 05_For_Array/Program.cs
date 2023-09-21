using System;
class Program
{
    public static void Main(string[] args)
    {

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Estou passando pela {i}ª vez no bloco.");
            Thread.Sleep(200);
        }


        //Criando uma tabuada utilizando For
        Console.WriteLine("Digite um número:");
        int numero = Convert.ToInt32(Console.ReadLine());
        for (int cont = 1; cont <= 10; cont++)
        {
            Console.WriteLine($"{numero} X {cont} = {numero * cont}");
        }

        //Declarando um vetor do tipo inteiro com 4 espaços
        int[] notas = new int[4];
        //Declarando um vetor atribuindo valores
        string[] meses = { "Janeiro", "Fevereiro" };

        int[] alunos = new int[6];

        alunos[4] = 3;
        alunos[5] = 11;
        alunos[3] = 7;
        alunos[0] = 20;
        alunos[2] = 8;
        alunos[1] = 12;

        int soma = 0;
        int maior = 0;
        int menor = 10000;

        for (int i = 0; i < alunos.Length; i++)
        {
            Console.WriteLine($"Aluno na posição {i} tem o valor {alunos[i]}");
        }

        foreach (int item in alunos)
        {
            soma = item + soma;

            if (item > maior)
            {
                maior = item;
            }

            if (item < menor)
            {
                menor = item;
            }

        }
        Console.WriteLine($"Soma total: {soma}");
        Console.WriteLine($"Maior número: {maior}");
        Console.WriteLine($"Menor número: {menor}");

        Array.Sort(alunos);

        Console.ReadLine();

    }

}
