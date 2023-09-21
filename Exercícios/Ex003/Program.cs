Console.WriteLine("Digite a placa do seu carro:");
string placa = Console.ReadLine();

placa = placa.Substring(placa.Length - 1, 1);

switch (placa) {
    case "1":
    case "2":
    Console.WriteLine("Seu carro não está autorizado a andar  na Segunda-feira.");
    break;
    case "3":
    case "4":
    Console.WriteLine("Seu carro não está autorizado a andar  na Terça-Feira.");
    break;
    case "5":
    case "6":
    Console.WriteLine("Seu carro não está autorizado a andar  na Quarta-Feira.");
    break;
    case "7":
    case "8":
    Console.WriteLine("Seu carro não está autorizado a andar  na Quinta-Feira.");
    break;
    case "9":
    case "0":
    Console.WriteLine("Seu carro não está autorizado a andar  na Sexta-Feira.");
    break;
    default:
    Console.WriteLine("Placa inválida");
    break;
}

Console.ReadLine();
