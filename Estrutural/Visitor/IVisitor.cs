using Estrutural.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estrutural.Visitor
{
    public interface IVisitor
    {
        void ImprimeSoma(Soma soma);

        void ImprimeSubtracao(Subtracao subtracao);

        void ImprimeNumero(Numero numero);

    }
}
