using Estacionamento.Pessoa;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estacionamento
{
    public class Registro
    {
        public Registro(Cliente cliente, DateTime data)
        {
            this.cliente = cliente;
            this.veiculo = cliente.Veiculo;
            DataInicio = data;
            QuantidadeDeRegistros++;
            Id = QuantidadeDeRegistros;
        }
        private static int QuantidadeDeRegistros = 0;
        public int Id;
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
            return $"{Id},{cliente.CPF},{cliente.Nome},{DataInicio},{veiculo.Placa},{veiculo.Modelo},{veiculo.Cor}";
        }


    }
}
