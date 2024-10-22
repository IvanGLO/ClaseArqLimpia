using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Polimorfismo
{
    public interface IFuncion
    {
        void Insertar();
        void Saludar(string mensaje);
    }

    public class Implementacion1 : IFuncion
    {
        public void Insertar()
        {
            Console.WriteLine("Implementeacion 1");
        }

        public void Saludar(string mensaje)
        {
            Console.Write("Implementacion 1, MSJ:" + mensaje);
        }
    }
}
