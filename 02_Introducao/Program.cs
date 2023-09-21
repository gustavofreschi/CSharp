//Somente declaramos a variável como inteira e não atribuimos valor
int num1;

//Declarando uma variável do tipo inteiro e atribuindo o valor 5
int num2 = 5;

//Declarando uma variável do tipo String (texto)
String nomeAluno;

//Variável do tipo lógico (verdadeiro ou falso)
bool resultado = true;

//Variável de tipo valot com casas decimais - para valores mais precisos
double coordenada = 1.80;

//Variável do tipo decimal - mais usada para valor monetário
decimal valor = 1.80M;


int idade = 16;

string nome = "Gustavo";

Console.ForegroundColor = ConsoleColor.Green;
Console.Title = "Projeto";

Console.WriteLine($"Meu nome é {nome}, e tenho {idade} anos de idade.");

Console.WriteLine("Em que cidade você nasceu?");
//Recebendo uma informação do usuário e atribuindo na variável cidade
String cidade = Console.ReadLine();
Console.WriteLine($"Você nasceu em {cidade}.");

int anoAtual = 2023;

int novaIdade = idade + 5;

int anoNascimento = anoAtual - idade;

Console.WriteLine($"Você nasceu em {anoNascimento} e daqui 5 anos terá {novaIdade} anos.");

Console.ReadLine();



