using System;
using System.Globalization;

namespace DIO.Bank
{
    public class Conta
    {
        public string Nome { get; private set; }
        private double Credito { get; set; }
        private double Saldo { get; set; }
        public int CodigoConta { get; private set; }
        public TipoConta TipoConta { get; private set; }

        public Conta(string nome, double credito, double saldo, TipoConta tipoConta)
        {
            Nome = nome;
            Credito = credito;
            Saldo = saldo;
            TipoConta = tipoConta;
            CriaCodigo();
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

            Console.WriteLine("Saldo atual da Conta de " + Nome + " é: " + 
                                Saldo.ToString("F2", CultureInfo.InvariantCulture));
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da Conta de " + Nome + " é: " + 
                                Saldo.ToString("F2",CultureInfo.InvariantCulture));
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(Sacar(valorTransferencia))
                contaDestino.Depositar(valorTransferencia);
        }

        public override string ToString()
        {
            return  "Proprietario: " + Nome + "\n" +
                    "Saldo: " + Saldo.ToString("F2",CultureInfo.InvariantCulture) + "\n" +
                    "Tipo da Conta: " + TipoConta + "\n" +
                    "Credito: " + Credito.ToString("F2",CultureInfo.InvariantCulture) + "\n" +
                    "Codigo da Conta: " + CodigoConta;
        }

        private void CriaCodigo()
        {
            Random x = new Random();
            CodigoConta = x.Next(100,400);
            System.Console.WriteLine("O codigo da sua conta é: " + CodigoConta);
        }
    }
}