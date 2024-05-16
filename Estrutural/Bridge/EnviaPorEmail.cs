using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estrutural.Bridge
{
    public class EnviaPorEmail :IEnviador
    {
        public void Envia(IMensagem mensagem)
        {
            Console.WriteLine("Enviando a mensagem por e-Mail");
            Console.WriteLine(mensagem.Formata());
        }

    }
}
