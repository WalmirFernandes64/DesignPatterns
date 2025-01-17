﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //public abstract class TemplateDeImpostoCondicional : Imposto
    //{
    //    public double Calcula(Orcamento orcamento)
    //    {
    //        if (DeveUsarMaximaTaxacao(orcamento))
    //        {
    //            return MaximaTaxacao(orcamento);
    //        }

    //        return MinimaTaxacao(orcamento);
    //    }

    //    public abstract double MinimaTaxacao(Orcamento orcamento);
    //    public abstract double MaximaTaxacao(Orcamento orcamento);
    //    public abstract bool DeveUsarMaximaTaxacao(Orcamento orcamento);
    //}

    /* Decorator */
    public abstract class TemplateDeImpostoCondicional : Imposto
    {
        public TemplateDeImpostoCondicional(Imposto outroImposto) : base(outroImposto) { }
        public TemplateDeImpostoCondicional() : base() { }

        public override double Calcula(Orcamento orcamento)
        {
            if (DeveUsarMaximaTaxacao(orcamento))
            {
                return MaximaTaxacao(orcamento) + CalculoDoOutroImposto(orcamento);
            }
            return MinimaTaxacao(orcamento) + CalculoDoOutroImposto(orcamento);
        }

        public abstract double MinimaTaxacao(Orcamento orcamento);
        public abstract double MaximaTaxacao(Orcamento orcamento);
        public abstract bool DeveUsarMaximaTaxacao(Orcamento orcamento);
    }

}
