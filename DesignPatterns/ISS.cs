using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class ISS : Imposto
    {

        //public double CalculaISS(Orcamento orcamento)
        //{
        //    return orcamento.Valor * 0.06;
        //}


        /* Decorator*/
        public ISS(Imposto outroImposto) : base(outroImposto) { }
        public ISS() : base() { }
        
        public override double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06 + CalculoDoOutroImposto(orcamento);
        }
    }
}
