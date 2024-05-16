using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estrutural.Flyweight
{
    public class NotasMusicais
    {
        private static IDictionary<string, INota> notas = new Dictionary<string, INota>()
        {
            { "Do", new Do()},
            { "Re", new Re()},
            { "Mi", new Mi()},
            { "Fa", new Fa()},
            { "So", new Sol()},
            { "La", new La()},
            { "Si", new Si()}
        };

        public INota Pega(string nome)
        {
            return notas[nome];
        }
    }
}
