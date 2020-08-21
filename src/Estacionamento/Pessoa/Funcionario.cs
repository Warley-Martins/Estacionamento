using System;
using System.Collections.Generic;
using System.Text;

namespace Estacionamento.Pessoa
{
    public class Funcionario : Pessoa
    {
        public Funcionario(string nome, string cpf)
            : base(nome, cpf)
        {

        }
        public void CadastrarRegistro(Cliente cliente ,bool clienteNovo)
        { 
            var data = DateTime.Now;
            var registro = new Registro(cliente, data);
            Estacionamento.Adicionar(registro, clienteNovo);
        }

        public double MostrarPreco(Cliente cliente, DateTime data)
        {
            return Estacionamento.GetValor(cliente, data);
        }

        public void FinalizarRegistro(Cliente cliente, DateTime data, bool pagamento)
        {
            if (pagamento == true)
            {
                Estacionamento.Remover(cliente);
            }
            return;
        }

        public Cliente LocalizarCliente(string cpf)
        {
            return Estacionamento.LocalizarCliente(cpf);
        }

        public override bool Equals(object obj)
        {
            var funcionario = obj as Funcionario;
            if (funcionario == null)
            {
                return false;
            }
            return this.CPF == funcionario.CPF;
        }
        public override string ToString()
        {
            return $"{Nome},{CPF}";
        }
    }
}
