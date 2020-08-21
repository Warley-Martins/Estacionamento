using System;

namespace Estacionamento
{
    public class Veiculo
    {
        public Veiculo(string placa, string modelo, string cor)
        {
            this.Placa = placa;
            this.Modelo = modelo;
            this.Cor = cor;
        }
        public string Modelo { get; set; }
        public string Placa { get;}
        public string Cor { get; set; }

        public override bool Equals(object obj)
        {
            var veiculo = obj as Veiculo;
            if(veiculo == null)
            {
                return false;
            }
            return this.Placa == veiculo.Placa;
        }
        public override string ToString()
        {
            return $"{this.Placa},{this.Modelo},{this.Cor}";
        }
    }
}