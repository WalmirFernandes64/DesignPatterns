using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estrutural.Command
{
    public class PagaPedido : ICommand
    {
        private Pedido Pedido;

        public PagaPedido(Pedido pedido)
        {
            this.Pedido = pedido;
        }
        public void Executa()
        {
            Console.WriteLine("Pagando o pedido cliente {0}", Pedido.Cliente);
            Pedido.Paga();
        }
    }
}
