using System;
using System.Collections.Generic;
using System.Text;

namespace Estacionamento
{
    public class Registro
    {
        public Registro(Cliente cliente, Veiculo veiculo, DateTime data)
        {
            this.cliente = cliente;
            this.veiculo = veiculo;
            DataInicio = data;
        }

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



    }
}
