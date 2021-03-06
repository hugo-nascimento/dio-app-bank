using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Bank
{
    class Program
    {

        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
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

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();


        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado:");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado:");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de origem:");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido:");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void ListarContas()
        {
            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for(int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.WriteLine("#{0} - {1}", i, conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta:");

            Console.WriteLine("Digite 1 para Conta Pessoa Física ou 2 para Conta Pessoa Jurídica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente:");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial:");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito:");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

            listContas.Add(novaConta);

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
