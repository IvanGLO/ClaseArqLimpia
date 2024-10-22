using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.LS
{
    public interface IAve
    {
        void volar();
        void nadar();
        void correr();

    }

    public class Pinguino : IAve
    {
        public void correr()
        {
            Console.WriteLine("Correo chistoso");
        }

        public void nadar()
        {
            Console.WriteLine("Si nada muy rápido!!");
        }

        public void volar()
        {
            throw new Exception("No vuela!");
        }
    }

    public class Paloma : IAve
    {
        public void correr()
        {
            Console.WriteLine("Si corre");
        }

        public void nadar()
        {
            throw new Exception("No puede nadar!");
        }

        public void volar()
        {
            Console.WriteLine("Si vuela y muy bien!!");
        }
    }

    public class AdminAve
    {
        private List<IAve> voladores = new List<IAve>();
        public bool InsertVolador(IAve ave)
        {
            try
            {
                ave.volar();
                voladores.Add(ave);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);   
            }
            return false;
        }
    }
}
