using Estacionamento.Pessoa;
using System;
using System.Collections.Generic;
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

    }
}
