using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class NotaFiscal
    {
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataEmissao { get; set; }
        public double ValorBruto { get; set; }
        public double Impostos { get; set; }
        public IList<ItemDaNota> Itens { get; set; }
        public string Observacao { get; set; }

        public NotaFiscal(string razaoSocial, string cNPJ, DateTime dataEmissao, double valorBruto, double impostos, IList<ItemDaNota> itens, string observacao)
        {
            this.RazaoSocial = razaoSocial;
            this.CNPJ = cNPJ;
            this.DataEmissao = dataEmissao;
            this.ValorBruto = valorBruto;
            this.Impostos = impostos;
            this.Itens = itens;
            this.Observacao = observacao;
        }
    }
}
