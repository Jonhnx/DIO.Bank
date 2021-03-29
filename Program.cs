using System;
using System.Collections.Generic;

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
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();

            /*Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();
            Console.Write("Qual o seu credito? ");
            double credito = double.Parse(Console.ReadLine());
            Console.Write("Digite o seu Salario: ");
            double salario = double.Parse(Console.ReadLine());

            Conta minhaConta = new Conta(nome,credito,salario,TipoConta.PessoaFisica);

            Console.WriteLine("\n" + minhaConta);
            Console.WriteLine("\nDigite o valor que vai sacar: ");
            minhaConta.Sacar(double.Parse(Console.ReadLine()));

            Console.WriteLine("\n" + minhaConta);
            Console.ReadLine();*/
        }

        private static void Depositar()
        {
            throw new NotImplementedException();
        }

        private static void Sacar()
        {
            
        }

        private static void Transferir()
        {
            throw new NotImplementedException();
        }

        private static void ListarContas()
        {
            System.Console.WriteLine("Listar Contas:");
            if(listaContas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma Conta Cadastrada.");
                return;
            }
            foreach(Conta conta in listaContas)
            {
                int i = 0;
                Console.Write("# (0) - ", i);
                System.Console.WriteLine(conta);
                i++;
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
            double saldoInicial = double.Parse(Console.ReadLine());

            Console.Write("Digite o Credito: ");
            double credito = double.Parse(Console.ReadLine());

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
            Console.WriteLine("C-> limpar tela");
            Console.WriteLine("X-> Sair");
            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
