using System;
using System.Collections.Generic;
using System.Text;

namespace Dll_Estacionamento.Pessoa
{
    public abstract class Pessoa
    {
        /// <summary>
        /// Construtor de Pessoa
        /// </summary>
        /// <param name="nome">Nome da pessoa</param>
        /// <param name="cpf">CPF da pessoa</param>
        public Pessoa(string nome, string cpf)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("O nome não pode ser nulo ou vazio!");
            }
            if (String.IsNullOrEmpty(cpf))
            {
                throw new ArgumentException("O cpf não pode ser nulo ou vazio!");
            }
            this.Nome = nome;
            this.CPF = cpf;
        }
        public string Nome { get; }
        public string CPF { get;}
    }
}
