using System;
using System.Collections.Generic;
using System.Text;

namespace Dll_Estacionamento.Pessoa
{
    /// <summary>
    /// Cliente do estacionamento
    /// </summary>
    public class Cliente : Pessoa
    {
        /// <summary>
        /// Construtor de Cliente
        /// </summary>
        /// <param name="veiculo">Veiculo do cliente</param>
        /// <param name="nome">Nome da pessoa</param>
        /// <param name="cpf">CPF da pessoa</param>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="veiculo"/>, não esta definido!</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="nome"/>, não pode nulo ou vazio!</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="cpf"/>, não pode nulo ou vazio!</exception>
        public Cliente(Veiculo veiculo, string nome, string cpf)
            : base(nome, cpf)
        {
            if(veiculo == null)
            {
                throw new NullReferenceException("Referencia nao definida para veiculo!");
            }
            this.Veiculo = veiculo;
        }
        /// <summary>
        /// Veiculo do cliente
        /// </summary>
        public Veiculo Veiculo;
        /// <summary>
        /// Compara dois clientes
        /// </summary>
        /// <param name="obj">Cliente Comparado</param>
        /// <returns>Valor logico da comparação</returns>
        public override bool Equals(object obj)
        {
            var cliente = obj as Cliente;
            if(cliente == null)
            {
                return false;
            }
            return this.CPF == cliente.CPF;
        }
        /// <summary>
        /// Informações do cliente
        /// </summary>
        /// <returns>Retorna uma string com informações do cliente</returns>
        public override string ToString()
        {
            return $"{Nome},{CPF},{Veiculo.Placa},{Veiculo.Modelo},{Veiculo.Cor}";
        }
    }
}
