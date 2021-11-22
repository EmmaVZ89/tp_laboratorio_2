using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interface ICalculos
    /// </summary>
    public interface ICalculos
    {
        double Imc { get; }
        EComposicionCorporal ComposicionCorporal { get;}
        EGradoObesidad GradoObesidad { get;}

        double CalcularIMC();
        EComposicionCorporal DeterminarComposicion(double imc);
        EGradoObesidad DeterminarGradoObesidad(EComposicionCorporal composicion);
    }
}
