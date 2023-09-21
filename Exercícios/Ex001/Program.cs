Console.WriteLine("Digite seu nome:");
String nome = Console.ReadLine();


Console.WriteLine("Digite a primeira nota:");
int nota1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Digite a segunda nota:");
int nota2 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Digite a terceira nota:");
int nota3 = Convert.ToInt32(Console.ReadLine());


int media = (nota1 + nota2 + nota3) / 3;

String result = (media < 7) ? $"{nome}, você ficou com média {media}, portanto você não passou." : $"Parabéns {nome}, você ficou com média {media}, portanto você passou.";

Console.WriteLine(result);

Console.ReadKey();