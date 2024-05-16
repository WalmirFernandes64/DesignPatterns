using Estrutural.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estrutural.Interpreter
{
    public interface IExpressao
    {
        int Avalia();

        void Aceita(IVisitor impressora);
    }
}
