using ContaBancaria.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContaBancaria.Classes
{
    class Conta
    {
        private string Nome { get; set; }
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }

        private double ChequeEspecial { get; set; }

        public Conta(string nome, TipoConta tipoConta, double saldo, double chequeEspecial)
        {
            Nome = nome;
            TipoConta = tipoConta;
            Saldo = saldo;
            ChequeEspecial = chequeEspecial;
        }

        public void Saque(double valorSaque)
        {
            if (this.Saldo < valorSaque)
            {
                Console.Write("Saldo insuficiente, deseja retirar do Credito Especial? S ou N? ");
                char opcao = char.Parse(Console.ReadLine().ToUpper());
                if (opcao == 'S')
                {
                    this.Saldo = (this.Saldo + this.ChequeEspecial) - valorSaque;
                }
            }
            else
            {
                this.Saldo -= valorSaque;
            }
            Console.WriteLine("O Saldo da conta de {0} é de {1}", this.Nome, this.Saldo);
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("O Saldo da conta de {0} é de {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            this.Saque(valorTransferencia);
            contaDestino.Depositar(valorTransferencia);

        }

        public override string ToString()
        {
            string retorno = "A conta de " + this.Nome + " do tipo " + this.TipoConta + " está atualmente com o saldo de " + this.Saldo + ".";
            return retorno;
        }
    }
}
