//O namespace é um nome em que usaremos para fazer referência
namespace Sesi.Model
{
    //Declarando a classe Aluno
    public class Aluno
    {
      //Declarando os atributos (propriedades) da classe Aluno
      public string nome { get; set; }
      public int idade { get; set; }
      public string turma { get; set; }
    //Declarando um atributo privado
      private int nrFaltas { get; set; }

    //Criando um método
      public void Apresentar()
      {
       Console.WriteLine($"Olá, meu nome é {nome}, tenho {idade} anos, estudo na turma {turma}, e tenho {nrFaltas} faltas.");
      }

      public void AdicionarFaltas(int nr)
      {
        nrFaltas+=nr;
      }

      public void ResumoFaltas()
      {
        Console.WriteLine($"O aluno {nome} tem {nrFaltas} faltas.");
      }

    }
}