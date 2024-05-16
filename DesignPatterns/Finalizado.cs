using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Finalizado : EstadoDeUmOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("Orcamentos Finalizados não recebem descontos extras!");
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orcamento já esta finalizado!");
        }

        public void Finaliza(Orcamento orcamento)
        {
            throw new Exception("Orcamento já esta finalizado!");
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orcamento já esta finalizado!");
        }
    }
}
