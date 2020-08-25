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
        public Cliente(Veiculo veiculo, string nome, string cpf)
            : base(nome, cpf)
        {
            this.Veiculo = veiculo;
        }
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
