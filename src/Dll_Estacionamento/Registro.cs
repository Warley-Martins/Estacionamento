using Dll_Estacionamento.Pessoa;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll_Estacionamento
{
    /// <summary>
    /// Registro de um cliente em um estacionamento
    /// </summary>
    public class Registro
    {
        /// <summary>
        /// Construtor do registro
        /// </summary>
        /// <param name="cliente">Cliente do estacionamento</param>
        /// <param name="data">Data na qual o carro foi deixado</param>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="cliente"/>, não pode ser nulo ou vazio!</exception>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="data"/>, não pode ser nulo ou vazio!</exception>
        public Registro(Cliente cliente, DateTime data)
        {
            if(cliente == null)
            {
                throw new NullReferenceException("O cliente não pode ser nulo ou vazio");
            }
            if (cliente == null)
            {
                throw new NullReferenceException("A data não pode ser nula ou vazia");
            }
            this.cliente = cliente;
            this.veiculo = cliente.Veiculo;
            DataInicio = data;
            QuantidadeDeRegistros++;
            Id = QuantidadeDeRegistros;
        }
        public int Id { get; internal set; }
        private static int QuantidadeDeRegistros = 0;
        public Cliente cliente;
        public Veiculo veiculo;
        public readonly DateTime DataInicio;
        public DateTime DataFim = DateTime.Now;
        public double Valor
        {
            get
            {
                TimeSpan diferenca = DataFim - DataInicio;
                return 5 + (10 * diferenca.TotalHours);
            }
        }

        public override bool Equals(object obj)
        {
            var registro = obj as Registro;
            if(registro == null)
            {
                return false;
            }
            return this.Id == registro.Id;
        }
        public override string ToString()
        {
            return $"{Id},{cliente.CPF},{cliente.Nome},{DataInicio},{DataFim},{veiculo.Placa},{veiculo.Modelo},{veiculo.Cor}";
        }


    }
}
