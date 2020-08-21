using System;
using System.Collections.Generic;
using System.Text;

namespace Estacionamento.Pessoa
{
    public abstract class Pessoa
    {
        public Pessoa(string nome, string cpf)
        {
            this.Nome = nome;
            this.CPF = cpf;
        }
        public string Nome { get; }
        public string CPF { get;}
    }
}
