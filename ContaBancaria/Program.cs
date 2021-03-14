using ContaBancaria.Classes;
using ContaBancaria.Enums;
using System;
using System.Collections.Generic;

namespace ContaBancaria
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            int opcao = 0;
            int numeroConta = 0;

            while (opcao != 6)
            {
                Console.WriteLine("Conta Bancaria");
                Console.WriteLine("O que deseja fazer:");
                Console.WriteLine("1 - Adicionar Conta");
                Console.WriteLine("2 - Depositar");
                Console.WriteLine("3 - Sacar");
                Console.WriteLine("4 - Transferir");
                Console.WriteLine("5 - Listar Contas");
                Console.WriteLine("6 - Sair");
                Console.Write("\nSua opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarConta();
                        break;

                    case 2:
                        Console.Write("Qual o Numero da Conta: ");
                        numeroConta = int.Parse(Console.ReadLine());
                        
                        Console.Write("Quanto deseja depositar: ");
                        listaContas[numeroConta].Depositar(double.Parse(Console.ReadLine()));
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.Write("Qual o Numero da Conta: ");
                        numeroConta = int.Parse(Console.ReadLine());

                        Console.Write("Quanto deseja Sacar: ");
                        listaContas[numeroConta].Saque(double.Parse(Console.ReadLine()));
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.Write("Qual o Numero da Conta: ");
                        numeroConta = int.Parse(Console.ReadLine());

                        Console.Write("Qual o Numero da Conta de Destino: ");
                        int numeroContaDestino = int.Parse(Console.ReadLine());


                        Console.Write("Quanto deseja transferir: ");
                        listaContas[numeroConta].Transferir(double.Parse(Console.ReadLine()), listaContas[numeroContaDestino]);

                        break;

                    case 5:
                        Console.WriteLine();
                        int i = 0;
                        foreach (Conta x in listaContas) { 
                        Console.WriteLine("Conta Nº: " + i + " " + x.ToString());
                        i++; 
                        }
                        Console.WriteLine();
                        break;

                    default:
                        break;
                }

            }
        }

        private static void AdicionarConta()
        {

            Console.WriteLine("\nAdicionar nova conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o valor do Cheque Especial: ");
            double chequeEspecial = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(nome, (TipoConta)tipoConta, saldo, chequeEspecial);

            listaContas.Add(novaConta);

        }
    }
}
