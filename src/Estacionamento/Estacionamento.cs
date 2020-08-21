using Estacionamento.Pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estacionamento
{
    public static class Estacionamento
    {
        private static List<Registro> Registros = new List<Registro>();
        
        private static bool Logar()
        {
            return true;
        }

        public static void Adicionar(Registro r)
        {
            Registros.Add(r);
        }
        
        public static void Remover(Cliente c)
        {
            Registro r = Registros.Where(x => x.cliente.CPF == c.CPF).FirstOrDefault();
            Registros.Remove(r);
        }

        public static double GetValor(Cliente c, DateTime data)
        {
            Registro r = Registros.Where(x => x.cliente.CPF == c.CPF).FirstOrDefault();
            r.DataFim = data;
            return r.Valor;
        }
    }
}
