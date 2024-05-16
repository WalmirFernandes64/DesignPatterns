using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Reprovado : EstadoDeUmOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("Orcamentos Reprovados não recebem descontos extras!");
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orcamento ja em estado de aprovação!");
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orcamento ja em estado de aprovado, não pode ser reprovado agora!");
        }
    }
}
