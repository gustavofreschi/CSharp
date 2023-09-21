using System;
using Sesi.Model;
class Program
{
  public static void Main(string[] args)
  {
    //Criando uma variável aluno1 e instanciando a classe aluno
    //Criando nosso objeto
    var aluno1 = new Aluno();
    aluno1.nome = "Gustavo";
    aluno1.idade = 16;
    aluno1.turma = "2º EM";
    aluno1.AdicionarFaltas(2);
    
    aluno1.Apresentar();
    

    Aluno aluno2 = new Aluno();
    Console.WriteLine("Digite seu nome:");
    aluno2.nome = Console.ReadLine();

    Console.WriteLine("Digite sua idade:");
    aluno2.idade = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Digite sua turma:");
    aluno2.turma = Console.ReadLine();
    
    Console.WriteLine("Digite quantas faltas você tem:");
    aluno2.AdicionarFaltas(Convert.ToInt32(Console.ReadLine()));

    aluno2.Apresentar();

    aluno1.ResumoFaltas();
    aluno2.ResumoFaltas();

    Console.ReadLine();
  }
}
