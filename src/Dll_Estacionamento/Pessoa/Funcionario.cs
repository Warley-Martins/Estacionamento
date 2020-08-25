using System;
using System.Collections.Generic;
using System.Text;

namespace Dll_Estacionamento.Pessoa
{
    /// <summary>
    /// Funcionario que realiza os registros
    /// </summary>
    public class Funcionario : Pessoa
    {

        /// <summary>
        /// Construtor de Funcionario
        /// </summary>
        /// <param name="nome">Nome da pessoa</param>
        /// <param name="cpf">CPF da pessoa</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="cpf"/>, não pode nulo ou vazio!</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="nome"/>, não pode nulo ou vazio!</exception>
        public Funcionario(string nome, string cpf)
            : base(nome, cpf)
        {

        }
        /// <summary>
        /// Realiza o cadastro do cliente em um registro
        /// </summary>
        /// <param name="cliente">Cliente</param>
        /// <param name="clienteNovo">Se o cliente ja possui cadastro</param>
        ///<exception cref="NullReferenceException">No parametro: <paramref name="cliente"/> cliente não esta definido!</exception>
        public void CadastrarRegistro(Cliente cliente ,bool clienteNovo)
        { 
            if(cliente == null)
            {
                throw new NullReferenceException("Cliente não esta definido!");
            }
            var data = DateTime.Now;
            var registro = new Registro(cliente, data);
            Estacionamento.Adicionar(registro, clienteNovo);
        }
        /// <summary>
        /// Mostra o preço do estacionamento
        /// </summary>
        /// <param name="cliente">Cliente</param>
        /// <param name="data">Data atual</param>
        ///<exception cref="NullReferenceException">No parametro: <paramref name="cliente"/> cliente não esta definido!</exception>
        ///<exception cref="NullReferenceException">No parametro: <paramref name="data"/> cliente não esta definido!</exception>
        ///<returns>Retorna o valor</returns>
        public double MostrarPreco(Cliente cliente, DateTime data)
        {
            if(cliente == null)
            {
                throw new NullReferenceException("Cliente não esta definido!");
            }
            if(data == null)
            {
                throw new NullReferenceException("A data não esta definida");
            }
            return Estacionamento.GetValor(cliente, data);
        }
        /// <summary>
        /// Finaliza o estacionamento para o sistema
        /// </summary>
        /// <param name="cliente">Cliente do estacionamento</param>
        /// <param name="data">Data atual</param>
        /// <param name="pagamento">Valor logico do pagamento</param>
        ///<exception cref="NullReferenceException">No parametro: <paramref name="cliente"/> cliente não esta definido!</exception>
        ///<exception cref="NullReferenceException">No parametro: <paramref name="data"/> cliente não esta definido!</exception>
        /// <returns>Retorna o registro do cliente</returns>
        public Registro FinalizarRegistro(Cliente cliente, DateTime data, bool pagamento)
        {
            if (cliente == null)
            {
                throw new NullReferenceException("Cliente não esta definido!");
            }
            if (data == null)
            {
                throw new NullReferenceException("A data não esta definida");
            }
            if (pagamento == true)
            {
                return Estacionamento.Remover(cliente);
            }
            return null;
        }

        /// <summary>
        /// Procura um cliente no estacionamento
        /// </summary>
        /// <param name="cpf">Cpf do cliente</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="cpf"/> não pode ser nulo ou vazio!</exception>
        /// <returns>Retorna o cliente se encontrado</returns>
        public Cliente LocalizarCliente(string cpf)
        {
            if (String.IsNullOrEmpty(cpf))
            {
                throw new ArgumentException("O cpf não pode ser nuloou vazio");
            }
            return Estacionamento.LocalizarCliente(cpf);
        }

        /// <summary>
        /// Comparação entre dois funcionarios
        /// </summary>
        /// <param name="obj">Funcionario comparado</param>
        /// <returns>Retorna o valor logico da comparação</returns>
        public override bool Equals(object obj)
        {
            var funcionario = obj as Funcionario;
            if (funcionario == null)
            {
                return false;
            }
            return this.CPF == funcionario.CPF;
        }
        /// <summary>
        /// String com dados do funcionario
        /// </summary>
        /// <returns>Retorna uma string com dados do funcionario</returns>
        public override string ToString()
        {
            return $"{Nome},{CPF}";
        }
    }
}
