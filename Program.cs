using System;

namespace DIO.Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario)
                {
                    case "1":
                        //ListarContas();
                        break;
                    case "2":
                        //InserirConta();
                        break;
                    case "3":
                        //Transferir();
                        break;
                    case "4":
                        //Sacar();
                        break;
                    case "5":
                        //Depositar();
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

            Console.Write("Digite seu nome: ");
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
            Console.ReadLine();
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
