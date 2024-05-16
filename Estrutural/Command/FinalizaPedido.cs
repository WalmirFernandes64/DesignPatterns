using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estrutural.Command
{
    public class FinalizaPedido:ICommand
    {
        private Pedido Pedido;

        public FinalizaPedido(Pedido pedido)
        {
            this.Pedido = pedido;
        }
        public void Executa()
        {
            Console.WriteLine("Finalizando o pedido cliente {0}", Pedido.Cliente);
            Pedido.Finaliza();
        }

    }
}
