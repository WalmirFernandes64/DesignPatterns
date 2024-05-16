using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class ICMS : Imposto
    {
        //public double Calcula(Orcamento orcamento)
        //{
        //    return orcamento.Valor * 0.1 ;
        //}

        /* Decorator */
        public ICMS(Imposto outroImposto) : base(outroImposto) { }
        public ICMS() : base() { }
        public override double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1 + CalculoDoOutroImposto(orcamento);
        }
    }
}
