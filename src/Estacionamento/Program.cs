using Dll_Estacionamento.Pessoa;
using System;

namespace Estacionamento
{
    public partial class Program
    {
        private static Funcionario funcionario;
        static void Main(string[] args)
        {
            int indiceMenu;
            do
            {
                do
                {
                    PrintarMenu();
                    indiceMenu = int.Parse(Console.ReadLine());
                } while (indiceMenu < 0 || indiceMenu > 2);
                switch (indiceMenu)
                {
                    case 1: //Iniciar registro
                        IniciarRegistro();
                        break;
                    case 2: //Encerrar registro
                        FinalizarRegistro();
                        break;
                    case 0:
                        break;
                }

            } while (indiceMenu != 0);
        }


    }
}
