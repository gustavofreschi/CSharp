Console.WriteLine("Digite o valor de x:");
int x = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Digite o valor de y:");
int y = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(x + y);

//Exemplos de operadores aritmético
int soma = x + y;
int subtracao = x - y;
int multiplicacao = x * y;
int divisao = x / y;
int resto = x % y;
int RestoDiv2 = x % 2;

Console.WriteLine($"Soma: {soma}");
Console.WriteLine($"Subtração: {subtracao}");
Console.WriteLine($"Multiplicação: {multiplicacao}");
Console.WriteLine($"Divisão: {divisao}");
Console.WriteLine($"Resto: {resto}");

if (RestoDiv2 == 0)
{
    Console.WriteLine($"{x} é par.");
}
else
{
    Console.WriteLine($"{x} é ímpar.");
}

// Condição ? se verdade : senão
String ePar = (RestoDiv2 == 0) ? " par " : " impar ";


Random aleatorio = new Random();

int diaSemana = aleatorio.Next(1,7);

switch (diaSemana)
{
    case 1:
        Console.WriteLine("Hoje é domingo");
        break;
    case 2:
        Console.WriteLine("Hoje é segunda");
        break;
    case 3:
        Console.WriteLine("Hoje é terça");
        break;
    case 4:
        Console.WriteLine("Hoje é quarta");
        break;
    case 5:
        Console.WriteLine("Hoje é quinta");
        break;
    case 6:
        Console.WriteLine("Hoje é sexta");
        break;
    case 7:
        Console.WriteLine("Hoje é sábado");
        break;
    default:
        Console.WriteLine("Dia inválido");
        break;
}

//Aprendendo switch case

Console.ReadLine();