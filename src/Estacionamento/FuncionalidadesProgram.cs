using Estacionamento.Pessoa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Estacionamento
{
    public partial class Program
    {
        private static void PrintarMenu()
        {
            Console.Write("\nDigite a opção desejada:" +
                              "\n(1). Inciar um registro" +
                              "\n(2). Finalizar um registro" +
                              "\n(0). Encerrar" +
                              "\nOpção: ");
        }
        private static void IniciarRegistro()
        {
            int cadastroExistente;
            do
            {
                Console.Write("\nO cliente ja possui cadastro no sistema? " +
                              "\n(1). Sim" +
                              "\n(0). Nao" +
                              "\nOpção: ");
                cadastroExistente = int.Parse(Console.ReadLine());
            } while (cadastroExistente < 0 || cadastroExistente > 1);
            switch (cadastroExistente)
            {
                case 1:
                    Console.Write("Digite seu cpf: ");
                    var cpf = int.Parse(Console.ReadLine());
                    var cliente = funcionario.LocalizarCliente(cpf);
                    funcionario.CadastrarRegistro(cliente, false);
                    break;
                case 0:
                    Cliente novoCliente = CadastrarCliente();
                    funcionario.CadastrarRegistro(novoCliente, true);
                    break;
            }
            }

        private static Cliente CadastrarCliente()
        {
            Console.Write("Digite o nome do cliente: ");
            var nome = Console.ReadLine();
            Console.Write("Digite o cpf: ");
            var cpf = int.Parse(Console.ReadLine());
            Console.Write("Digite a placa do veiculo: ");
            var placa = Console.ReadLine();
            Console.Write("Digite o modelo do veiculo: ");
            var modelo = Console.ReadLine();
            Console.Write("Digite a cor do veiculo: ");
            var cor = Console.ReadLine();
            var cliente = new Cliente(new Veiculo(placa, modelo, cor), nome, cpf);
            EscreverClienteArq(cliente);
            return cliente;
        }

        private static void FinalizarRegistro()
        {
            Console.Write("Digite o ano: ");
            var yyyy = int.Parse(Console.ReadLine());
            Console.Write("Digite o mes: ");
            var MM = int.Parse(Console.ReadLine());
            Console.Write("Digite o dia: ");
            var dd = int.Parse(Console.ReadLine());
            Console.Write("Digite as horas: ");
            var hh = int.Parse(Console.ReadLine());
            Console.Write("Digite os minutos: ");
            var mm = int.Parse(Console.ReadLine());
            var data = new DateTime(yyyy,MM,dd,hh,mm,0);
            Console.Write("Digite o cpf do cliente: ");
            var cpf = int.Parse(Console.ReadLine());
            var cliente = funcionario.LocalizarCliente(cpf);
            int opcaoPagamento;
            do
            {
                Console.Write($"\nO valor do estacionamento é: {funcionario.MostrarPreco(cliente, data)}" +
                              $"\nO cliente reaslizou o pagamento? " +
                              $"\n(1). Sim" +
                              $"\n(0). Nao" +
                              $"\nOpção: ");
                opcaoPagamento = int.Parse(Console.ReadLine());
            } while (opcaoPagamento != 1);
            var r = funcionario.FinalizarRegistro(cliente, data, true);
            EscreverRegistroArq(r);
        }

        private static void EscreverRegistroArq(Registro r)
        {
            string arq = "registros.txt";
            using (var fluxoDeArquivo = new FileStream(arq, FileMode.OpenOrCreate))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                escritor.Write(r);
            }
        }
        private static void EscreverClienteArq(Cliente novoCliente)
        {
            string arq = "clientes.txt";
            using (FileStream fluxoDeArquivo = new FileStream(arq, FileMode.OpenOrCreate))
            using (StreamWriter escritor = new StreamWriter(fluxoDeArquivo))
            {
                escritor.Write(novoCliente);
            }
        }
    }
}
