using System;

namespace Banco
{


    public class ContaCorrente
    {
        private string titular { get; set; }

        private double saldo { get; set; }

        public ContaCorrente(string titular, double saldo)
        {
            this.titular = titular;
            this.saldo = saldo;
        }

        string nrDigitado = "";
        public void Menu()
        {
            do
            {
                Console.WriteLine("1 - Para Consultar Saldo");
                Console.WriteLine("2 - Para Depositar");
                Console.WriteLine("3 - Para Sacar");
                Console.WriteLine("0 - Para Sair");
                nrDigitado = Console.ReadLine();

                switch (nrDigitado)
                {
                    case "1":
                        ConsultarSaldo();
                        break;
                    case "2":
                        Depositar();
                        break;
                    case "3":
                        Sacar();
                        break;
                    case "0":
                        Console.WriteLine("Obrigado por visitar!");
                        break;
                }

            } while (nrDigitado != "0");
        }

        string user = "";
        public void Logar()
        {
            do
            {
                Console.WriteLine("Digite seu usuário: ");
                user = Console.ReadLine();


                if (user != titular)
                {
                    Console.WriteLine("Acesso Inválido!");
                }
                else
                {
                    Console.WriteLine($"***********  BEM-VINDO AO SISTEMA DO BANCO, {titular.ToUpper()}  ***********");
                }


            } while (user != titular);
        }

        public void ConsultarSaldo()
        {
            Console.WriteLine($"Saldo disponível: {saldo}");
        }

        public void Depositar()
        {
            Console.WriteLine("Digite o quanto deseja depositar em sua conta:");
            double deposito = Convert.ToDouble(Console.ReadLine());


            if (deposito >= 0)
            {
                Console.WriteLine("Depósito realizado com sucesso!");
                saldo = deposito + saldo;
            }
            else
            {
                Console.WriteLine("Depósito inválido!");
                saldo = saldo;
            }


        }

        public void Sacar()
        {

            Console.WriteLine("Digite o quanto deseja sacar de sua conta:");
            double saque = Convert.ToDouble(Console.ReadLine());


            if (saque > 0 && saque <= saldo)
            {
                Console.WriteLine("Saque realizado com sucesso!");
                saldo = saldo - saque;
            }
            else
            {
                Console.WriteLine("Saque inválido");
                saldo = saldo;
            }


        }
    }

}
