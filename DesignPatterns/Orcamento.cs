using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Orcamento
    {
        #region State
        public EstadoDeUmOrcamento EstadoAtual { get; set; }

        public void AplicaDescontoExtra()
        {
            EstadoAtual.AplicaDescontoExtra(this);
        }

        public void Aprova()
        {
            EstadoAtual.Aprova(this);
        }
        public void Reprova()
        {
            EstadoAtual.Reprova(this);
        }
        public void Finaliza()
        {
            EstadoAtual.Finaliza(this);
        }
        #endregion

        public double Valor { get; set; }
        public IList<Item> Itens { get; private set; }

        public Orcamento(double valor)
        {
            this.Valor = valor;
            this.Itens = new List<Item>();
            this.EstadoAtual = new EmAprovacao();
        }

        public void AdicionaItem(Item item)
        {
            Itens.Add(item);
        }
    }
}
