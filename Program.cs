using System;
using System.Collections.Generic;

namespace DIO_bank
{
    class Program
    {   
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while( opcaoUsuario.ToUpper() != "X" )
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

            Console.WriteLine("Obrigado por Utilizar Nossos Serviços.");
            Console.ReadLine();

        }

        private static void Transferir()
        {
            Console.WriteLine("TRANSFERÊNCIA ENTRE CONTAS:");

            Console.Write("Digite a sua Conta de Origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite a Conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor de Transfência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("DEPÓSITO EM CONTA:");

            Console.Write("Digite a conta para realizar o depósito: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);

        }

        private static void Sacar()
        {
            Console.WriteLine("SAQUE EM CONTA:");

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor de Saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("LISTAGEM DE CONTAS:");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} ", i);
                Console.WriteLine(conta);
            }    
        }

        private static void InserirConta()
        {
            Console.WriteLine("INCLUSÃO DE CONTA:");

            Console.WriteLine("Digite 1 para Conta Pessoa Física e 2 para Jurídica:");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente:");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo Inicial");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Crédito");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                    saldo: entradaSaldo,
                                                    credito: entradaCredito,
                                                    nome: entradaNome);
                                                    
            listContas.Add(novaConta);
        
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");   
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario; 
        }
    }
}
