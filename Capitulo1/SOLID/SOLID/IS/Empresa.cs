using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SOLID.IS
{
    public interface ICommons
    {
        void EntrarAReuniones();
        void Registro();

    }

    public interface IDevelop
    {
        void Desarrolla();
        void EjecutaTest();
    }

    public interface IGerente
    {
        void Gerenciar();
    
    }
    public interface IFinanzas
    {
        void AdministrarFacturas();
    }
    public interface IFunciones
    {
        void Desarrollar();
        void Gerenciar();
        void EntrarAReuniones();
        void AdministrarFacturas();

    }

    public class Developer : ICommons, IDevelop
    {
        public void Desarrolla()
        {
            throw new NotImplementedException();
        }

        public void EjecutaTest()
        {
            throw new NotImplementedException();
        }

        public void EntrarAReuniones()
        {
            throw new NotImplementedException();
        }

        public void Registro()
        {
            throw new NotImplementedException();
        }
    }
    public class Empresa
    {

    }
}
