using Dll_Estacionamento.Pessoa;
using System;

namespace Dll_Estacionamento
{
    /// <summary>
    /// Veiculo no estacionamento
    /// </summary>
    public class Veiculo
    {
        /// <summary>
        /// Construtor do veiculo
        /// </summary>
        /// <param name="placa">Placa do veiculo</param>
        /// <param name="modelo">Modelo do veiculo</param>
        /// <param name="cor">Cor do veiculo</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="placa"/>, não pode nulo ou vazio!</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="modelo"/>, não pode nulo ou vazio!</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="cor"/>, não pode nulo ou vazio!</exception>
        public Veiculo(string placa, string modelo, string cor)
        {
            if (String.IsNullOrEmpty(placa))
            {
                throw new ArgumentException("A placa não pode ser nula ou vazia!");
            }
            if (String.IsNullOrEmpty(modelo))
            {
                throw new ArgumentException("O modelo não pode ser nulo ou vazio!");
            }
            if (String.IsNullOrEmpty(cor))
            {
                throw new ArgumentException("A cor não pode ser nula ou vazia!");
            }
            this.Placa = placa;
            this.Modelo = modelo;
            this.Cor = cor;
        }
        public int ID { get; internal set; }
        public string Modelo { get; set; }
        public string Placa { get;}
        public string Cor { get; set; }
        public Cliente Dono { get; set; }

        /// <summary>
        /// Realiza a comparação entre dois veiculos
        /// </summary>
        /// <param name="obj">Veiculo comparado</param>
        /// <returns>Retorna o valor logico da expressao</returns>
        public override bool Equals(object obj)
        {
            var veiculo = obj as Veiculo;
            if(veiculo == null)
            {
                return false;
            }
            return this.Placa == veiculo.Placa;
        }
        /// <summary>
        /// Informações do veiculo
        /// </summary>
        /// <returns>Retorna um string com informações do veiculo</returns>
        public override string ToString()
        {
            return $"{this.Placa},{this.Modelo},{this.Cor}";
        }
    }
}