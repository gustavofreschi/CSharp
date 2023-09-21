using System;

namespace Models
{
    public class Pessoa
    {
        //Atributos da nossa Classe Pessoa
        private string nome { get; set; }

        private int idade { get; set; }

        //Criando nosso Método Construtor
        public Pessoa (string nomePessoa, int idadePessoa)
        {
            this.nome = nomePessoa;
            this.idade = idadePessoa;
        }

        //Métodos da Classe Pessoa
        public void Cantar()
        {
            Console.WriteLine($"{nome} está cantando.");
        }

    }
}