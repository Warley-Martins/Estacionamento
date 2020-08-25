using Dll_Estacionamento.Pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dll_Estacionamento
{
    /// <summary>
    /// Estacionamento 
    /// </summary>
    public static class Estacionamento
    {
        private static List<Registro> Registros = new List<Registro>();
        private static List<Cliente> clientes = new List<Cliente>();

        /// <summary>
        /// Adiciona um novo registro
        /// </summary>
        /// <param name="r">Novo registro</param>
        /// <param name="novoCadastro">Valor logico se novo cliente</param>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="r"/>, não possui referencia definida!</exception>
        public static void Adicionar(Registro r, bool novoCadastro)
        {
            if (r == null)
            {
                throw new NullReferenceException("O registro não possui referencia definida");
            }
            if (novoCadastro == true)
            {
                clientes.Add(r.cliente);
            }
            Registros.Add(r);
        }
        /// <summary>
        /// Finaliza um registro
        /// </summary>
        /// <param name="c">Cliente que buscou o carro</param>
        /// <returns>Retorna o registro finalizado</returns>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="c"/>, não possui referencia definida!</exception>
        public static Registro Remover(Cliente c)
        {
            if(c == null)
            {
                throw new NullReferenceException("O cliente não pode apontar para null!");
            }
            Registro r = Registros.Where(x => x.cliente.CPF == c.CPF).FirstOrDefault();
            Registros.Remove(r);
            return r;
        }
        /// <summary>
        /// Valor do estacionamento
        /// </summary>
        /// <param name="c">Cliente</param>
        /// <param name="data">Data de retirada do veiculo</param>
        /// <returns>Retorna o valor do estacionamento</returns>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="c"/>, não possui referencia definida!</exception>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="data"/>, não possui referencia definida!</exception>
        public static double GetValor(Cliente c, DateTime data)
        {
            if (c == null)
            {
                throw new NullReferenceException("O cliente não pode apontar para null!");
            }
            if (data == null)
            {
                throw new NullReferenceException("A data não pode apontar para null!");
            }
            Registro r = Registros.Where(x => x.cliente.CPF == c.CPF).FirstOrDefault();
            r.DataFim = data;
            return r.Valor;
        }
        /// <summary>
        /// Localiza um cliente no estacionamento
        /// </summary>
        /// <param name="cpf">Cpf do cliente</param>
        /// <returns>Retorna o cliente</returns>
        /// <exception cref="ArgumentException">O parametro: <paramref name="cpf"/>, não pode ser nulo ou vazio!</exception>
        public static Cliente LocalizarCliente(string cpf)
        {
            if (String.IsNullOrEmpty(cpf))
            {
                throw new ArgumentException("O cpf não pode ser nulo ou vazio!");
            }
            return clientes.Where(x => x.CPF == cpf).FirstOrDefault();
        }
    }
}
