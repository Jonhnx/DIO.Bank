using System;

namespace DIO.Bank
{
    public class Conta
    {
        public string Nome { get; private set; }
        private double Credito { get; set; }
        private double Saldo { get; set; }
        public TipoConta TipoConta { get; private set; }

        public Conta(string nome, double credito, double saldo, TipoConta tipoConta)
        {
            Nome = nome;
            Credito = credito;
            Saldo = saldo;
            TipoConta = tipoConta; 
        }

        public bool Sacar(double valorSaque)
        {
            if(Saldo - valorSaque + Credito < 0 )
            {
                Console.WriteLine("SaldoInsuficiente");
                return false;
            }
            if(Saldo - valorSaque < 0)
            {
                double novoCredito = (Saldo - valorSaque) *-1;
                Saldo += novoCredito;
                Credito -= novoCredito;
            }
            Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da Conta de " + Nome + " é: " + Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da Conta de " + Nome + " é: " + Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(Sacar(valorTransferencia))
                contaDestino.Depositar(valorTransferencia);
        }

        public override string ToString()
        {
            return  "Proprietario: " + Nome + "\n" +
                    "Saldo: " + Saldo + "\n" +
                    "Tipo da Conta: " + TipoConta + "\n" +
                    "Credito: " + Credito;
        }
    }
}