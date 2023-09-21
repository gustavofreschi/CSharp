Console.WriteLine("Digite a placa do seu carro:");
string placa = Console.ReadLine();

int numeroFinal = Convert.ToInt32(placa.Substring(6));

if (numeroFinal == 1 || numeroFinal == 2) {
    Console.WriteLine("Está autorizado a andar na Segunda.");
} else if (numeroFinal == 3 || numeroFinal == 4) {
    Console.WriteLine("Está autorizado a andar na Terça.");
} else if (numeroFinal == 5 || numeroFinal == 6) {
    Console.WriteLine("Está autorizado a andar na Quarta.");
} else if (numeroFinal == 7 || numeroFinal == 8) {
    Console.WriteLine("Está autorizado a andar na Quinta.");
} else if (numeroFinal == 9 || numeroFinal == 0) {
    Console.WriteLine("Está autorizado a andar na Sexta.");
}

Console.ReadLine();


