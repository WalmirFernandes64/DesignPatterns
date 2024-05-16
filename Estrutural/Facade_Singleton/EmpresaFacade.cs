using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estrutural.Singleton_e_Facade
{
    public class Cliente
    {

    }

    public class ClienteDAO
    {
        public Cliente BuscaPorCPF(string cpf)
        {
            return new Cliente();
        }
    }

    public class Fatura
    {
        public Cliente Cliente { get; private set; }
        public double Valor { get; private set; }
        public Fatura(Cliente cliente, double valor)
        {
            this.Cliente = cliente;
            this.Valor = valor;
        }

    }

    public class Cobranca
    {
        public Tipo Tipo { get; private set; }
        public Fatura Fatura { get; private set; }

        public Cobranca(Tipo tipo, Fatura fatura)
        {
            this.Tipo = tipo;
            this.Fatura = fatura;
        }

        public Cobranca Emite()
        {
            return new Cobranca(this.Tipo, this.Fatura);
        }
    }

    public class ContatoCliente
    {
        public Cliente Cliente { get; private set; }
        public Cobranca Cobranca { get; private set; }
        public ContatoCliente(Cliente cliente, Cobranca cobranca)
        {
            this.Cliente = cliente;
            this.Cobranca = cobranca;
        }

        public void Dispara()
        {

        }
    }

    public enum Tipo
    {
        Tipo1,
        Tipo2
    }

    public class EmpresaFacade
    {
        public Cliente BuscaCliente(string cpf)
        {
            return new ClienteDAO().BuscaPorCPF(cpf);
        }

        public Fatura CriaFatura(Cliente cliente,double valor)
        {
            return new Fatura(cliente, valor);
        }

        public Cobranca GeraCobranca(Tipo tipo, Fatura fatura)
        {
            Cobranca cobranca = new Cobranca(tipo, fatura);
            return cobranca.Emite();
        }

        public ContatoCliente FazContato(Cliente cliente, Cobranca cobranca)
        {
            ContatoCliente contato = new ContatoCliente(cliente, cobranca);
            contato.Dispara();
            return contato;
        }
    }
}
