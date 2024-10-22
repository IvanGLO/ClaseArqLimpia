using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OC
{
    public interface IArea
    {
        double Area();
    }
    public class Square: IArea
    {
        public double Lado { get; set; }

        public double Area()
        {
            return Lado * Lado;
        }
    }
    public class Triangle:IArea
    {
        public double Base { get; set; }
        public double Altura { get; set; }

        public double Area()
        {
            return Base * Altura / 2;
        }
    }

    public class Circulo : IArea
    {
        public double Radio { get; set; }

        public double Area()
        {
            return Math.PI * Radio * Radio;
        }
    }

    public class Rectangulo : IArea
    {
        public double Base { get; set; }
        public double Altura { get;set; }

        public double Area()
        {
            return Base * Altura;
        }
    }
    public class Calculadora
    {
        //public double Area(object obj)
        //{
        //    if (obj is Square square)
        //    {
        //        return square.Lado * square.Lado;
        //    }else if(obj is Triangle triangle)
        //    { 
        //        return triangle.Base * triangle.Altura / 2;
        //    }
        //    return 0.0;
        //}
        public double Area(IArea obj)
        {
            return obj.Area();
        }
    }
}
