using Estrutural.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estrutural.Interpreter
{
    public class Numero : IExpressao
    {
        public int Valor { get; private set; }

        public Numero(int numero)
        {
            this.Valor = numero;
        }
        public int Avalia()
        {
            return this.Valor;
        }
        public void Aceita(IVisitor impressora)
        {
            impressora.ImprimeNumero(this);
        }
    }
}
