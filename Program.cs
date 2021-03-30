using System;
using System.Collections.Generic;
using System.Globalization;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        ListarContasCodigo();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Digite uma das opções disponiveis por favor.");
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarContasCodigo()
        {
            System.Console.WriteLine("Listar Contas pelo Numero:");
            if(listaContas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma Conta Cadastrada.");
                return;
            }
            for(int i = 0; i < listaContas.Count; i++)
            {
                Console.Write($"# {(i+1)} - ");
                Console.WriteLine(listaContas[i].Nome + ": " + listaContas[i].CodigoConta 
                                + ", tipo: " + listaContas[i].TipoConta);
                
            }
        }

        private static void Depositar()
        {
            Console.Write("Digite o numero da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());
            if(ValidaConta(ref numeroConta))
            {
            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            listaContas[numeroConta].Depositar(valorDeposito);
            }else{
                Console.WriteLine("Conta não encontrada!");
            }
        }

        private static void Sacar()
        {
            Console.Write("Digite o numero da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());
            if(ValidaConta(ref numeroConta))
            {
            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            listaContas[numeroConta].Sacar(valorSaque);
            }else{
                Console.WriteLine("Conta não encontrada!");
            }
        }

        private static bool ValidaConta(ref int numeroConta)
        {
            int indice = -1;
            for(int i = 0; i < listaContas.Count; i++)
            {
              if(numeroConta == listaContas[i].CodigoConta)
              {
                  indice = i;
              }
            }
            if (indice == -1){
                return false;
            }else{
                numeroConta = indice;
                return true;
            }

        }
        private static void Transferir()
        {
            Console.Write("Digite o numero da conta Remetente: ");
            int numeroContaO = int.Parse(Console.ReadLine());
            if(ValidaConta(ref numeroContaO))
            {
                Console.Write("Digite o numero da conta Destinatario: ");
                int numeroContaD = int.Parse(Console.ReadLine());
                if(ValidaConta(ref numeroContaD))
                {
                    Console.Write("Digite o valor a ser transferido: ");
                    double valorTransferencia = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    Console.WriteLine("\nRealizando transferencia..." + "\n");
                    listaContas[numeroContaO].Transferir(valorTransferencia,listaContas[numeroContaD]);
                }
                else
                {
                    Console.WriteLine("Conta Destinatario não encontrada!");
                }
            }
            else
            {
                Console.WriteLine("Conta Remetente não encontrada!");
            }
        }

        private static void ListarContas()
        {
            System.Console.WriteLine("Listar Contas:");
            if(listaContas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma Conta Cadastrada.");
                return;
            }
            for(int i = 0; i < listaContas.Count; i++)
            {
                Console.Write($"# {(i+1)} - ");
                Console.WriteLine(listaContas[i].Nome + ": " + listaContas[i].CodigoConta 
                                + ", tipo: " + listaContas[i].TipoConta);
                
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int tipoConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o Nome do Cliente: ");
            string nomeCliente = Console.ReadLine();

            Console.Write("Digite o saldo Inicial: ");
            double saldoInicial = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Console.Write("Digite o Credito: ");
            double credito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Conta novaConta = new Conta(nomeCliente, credito, saldoInicial, (TipoConta)tipoConta);
            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1-> Listar Contas");
            Console.WriteLine("2-> Inserir Nova Conta");
            Console.WriteLine("3-> Transferir");
            Console.WriteLine("4-> Sacar");
            Console.WriteLine("5-> Depositar");
            Console.WriteLine("6-> Listar Contas Pelo Codigo");
            Console.WriteLine("C-> limpar tela");
            Console.WriteLine("X-> Sair");
            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
