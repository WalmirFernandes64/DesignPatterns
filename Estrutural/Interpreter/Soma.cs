using Estrutural.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estrutural.Interpreter
{
    public class Soma:IExpressao
    {
        public IExpressao Esquerda { get; private set; }
        public IExpressao Direita { get; private set; }

        public Soma(IExpressao esquerda, IExpressao direita)
        {
            this.Esquerda = esquerda;
            this.Direita = direita;
        }

        public int Avalia()
        {
            int valorEsqueda = Esquerda.Avalia();
            int valorDireita = Direita.Avalia();
            return valorEsqueda + valorDireita;
        }

        public void Aceita(IVisitor impressora)
        {
            impressora.ImprimeSoma(this);
        }
    }
}
