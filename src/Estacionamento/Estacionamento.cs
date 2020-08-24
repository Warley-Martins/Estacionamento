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
        private static List<Cliente> clientes = new List<Cliente>();

        public static void Adicionar(Registro r, bool novoCadastro)
        {
            if(novoCadastro == true)
            {
                clientes.Add(r.cliente);
            }
            Registros.Add(r);
        }
        
        public static Registro Remover(Cliente c)
        {
            Registro r = Registros.Where(x => x.cliente.CPF == c.CPF).FirstOrDefault();
            Registros.Remove(r);
            return r;
        }

        public static double GetValor(Cliente c, DateTime data)
        {
            Registro r = Registros.Where(x => x.cliente.CPF == c.CPF).FirstOrDefault();
            r.DataFim = data;
            return r.Valor;
        }
        public static Cliente LocalizarCliente(string cpf)
        {
            return clientes.Where(x => x.CPF == cpf).FirstOrDefault();
        }
    }
}
