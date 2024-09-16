﻿using System;
using System.Diagnostics.SymbolStore;
using System.Globalization;

namespace Questao1
{
    class Program
    {
        static void Main(string[] args)
        {

            ContaBancaria contaBancaria;

            Console.Write("Entre o número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Entre o titular da conta: ");
            string titular = Console.ReadLine();

            Console.Write("Haverá depósito inicial (s/n)? ");
            char resp = char.Parse(Console.ReadLine());

            if (resp == 's' || resp == 'S')
            {
                Console.Write("Entre o valor de depósito inicial: ");
                double depositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                contaBancaria = new ContaBancaria(numero, titular, depositoInicial);
            }
            else
            {
                contaBancaria = new ContaBancaria(numero, titular);
            }

            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            ConsutarConta(contaBancaria);

            Console.WriteLine();
            Console.Write("Entre um valor para depósito: ");
            double quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            contaBancaria.Deposito(quantia);

            Console.WriteLine("Dados da conta atualizados:");
            ConsutarConta(contaBancaria);
            Console.WriteLine();

            Console.Write("Entre um valor para saque: ");
            quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            contaBancaria.Saque(quantia);

            Console.WriteLine("Dados da conta atualizados:");
            ConsutarConta(contaBancaria);
            Console.WriteLine();
            Console.WriteLine("Fim");
            Console.WriteLine("Pressione uma tecla para encerrar o programa");
            Console.ReadKey();


        }
        private static void ConsutarConta(ContaBancaria contaBancaria)
        {
            double saldoAtual = contaBancaria.ConsultarSaldo();
            Console.WriteLine($"Conta: {contaBancaria.Numero}, Titular: {contaBancaria.Titular}, Saldo: {saldoAtual:F2}");
        }

    }
    /* Output expected:
    Exemplo 1:

    Entre o número da conta: 5447
    Entre o titular da conta: Milton Gonçalves
    Haverá depósito inicial(s / n) ? s
    Entre o valor de depósito inicial: 350.00

    Dados da conta:
    Conta 5447, Titular: Milton Gonçalves, Saldo: $ 350.00

    Entre um valor para depósito: 200
    Dados da conta atualizados:
    Conta 5447, Titular: Milton Gonçalves, Saldo: $ 550.00

    Entre um valor para saque: 199
    Dados da conta atualizados:
    Conta 5447, Titular: Milton Gonçalves, Saldo: $ 347.50

    Exemplo 2:
    Entre o número da conta: 5139
    Entre o titular da conta: Elza Soares
    Haverá depósito inicial(s / n) ? n

    Dados da conta:
    Conta 5139, Titular: Elza Soares, Saldo: $ 0.00

    Entre um valor para depósito: 300.00
    Dados da conta atualizados:
    Conta 5139, Titular: Elza Soares, Saldo: $ 300.00

    Entre um valor para saque: 298.00
    Dados da conta atualizados:
    Conta 5139, Titular: Elza Soares, Saldo: $ -1.50
    */
}
