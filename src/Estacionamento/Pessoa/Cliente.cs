using System;
using System.Collections.Generic;
using System.Text;

namespace Estacionamento.Pessoa
{
    public class Cliente : Pessoa
    {
        public Cliente(Veiculo veiculo, string nome, string cpf)
            : base(nome, cpf)
        {
            this.Veiculo = veiculo;
        }
        public Veiculo Veiculo;

        public override bool Equals(object obj)
        {
            var cliente = obj as Cliente;
            if(cliente == null)
            {
                return false;
            }
            return this.CPF == cliente.CPF;
        }
        public override string ToString()
        {
            return $"{Nome},{CPF},{Veiculo.Placa},{Veiculo.Modelo},{Veiculo.Cor}";
        }
    }
}
