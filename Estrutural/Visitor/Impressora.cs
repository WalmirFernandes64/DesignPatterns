using Estrutural.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estrutural.Visitor
{
    public class Impressora:IVisitor
    {
        public void ImprimeSoma(Soma soma)
        {
            Console.Write("(");
            // expressao da esquerda 
            soma.Esquerda.Aceita(this);
            Console.Write("+");
            // expressao da direita
            soma.Direita.Aceita(this);
            Console.Write(")");
        }

        public void ImprimeSubtracao(Subtracao subtracao)
        {
            Console.Write("(");
            // expressao da esquerda
            subtracao.Esquerda.Aceita(this);
            Console.Write("-");
            // expressao da direita
            subtracao.Direita.Aceita(this);
            Console.Write(")");
        }

        public void ImprimeNumero(Numero numero)
        {
            Console.Write(numero.Valor);
        }
    }
}
