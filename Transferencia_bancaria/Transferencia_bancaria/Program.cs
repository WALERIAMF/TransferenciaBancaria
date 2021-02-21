using System;
using System.Collections.Generic;
using System.Globalization;

namespace Transferencia_bancaria
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {


                    case "1":
                        ListarConta();
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
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }


        private static void ListarConta()
        {
            {
                Console.WriteLine("Listar contas");
                if (listContas.Count == 0)
                {
                    Console.WriteLine("Nenhuma conta cadastrada. ");
                    return;
                }
                for (int i = 0; i < listContas.Count; i++)
                {
                    Conta conta = listContas[i];
                    Console.WriteLine("Número da Conta: #{0} - {1}, ", i, conta);

                }
            }

         } 
        private static void InserirConta()
        {

                Console.WriteLine("Inserir nova conta");
                Console.WriteLine("Digite 1 para conta física e 2 para juridica");
                int entradaTipoConta = int.Parse(Console.ReadLine());
                if (entradaTipoConta == 1 && entradaTipoConta == 2) { }
                Console.WriteLine("Digite o nome do cliente: ");
                string entradaNome = Console.ReadLine();
                Console.WriteLine("Digite o saldo inicial: ");
                double entradaSaldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Digite o crédito inicial: ");
                double creditoSaldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


                Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                saldo: entradaSaldo,
                                                credito: creditoSaldo,
                                                nome: entradaNome);


            listContas.Add(novaConta);


        }
        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = Math.Abs(double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));

            listContas[indiceConta].Depositar(valorDeposito);


        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSacar = Math.Abs(double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));
            listContas[indiceConta].Sacar(valorSacar);
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("______________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao Internet Banking");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C - Limpar");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            Console.WriteLine("______________________________________________________________");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
