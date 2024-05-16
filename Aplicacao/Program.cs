using DesignPatterns;
using Estrutural.Adapter;
using Estrutural.Bridge;
using Estrutural.Command;
using Estrutural.Facade;
using Estrutural.Factory;
using Estrutural.Flyweight;
using Estrutural.Interpreter;
using Estrutural.Memento;
using Estrutural.Singleton_e_Facade;
using Estrutural.Visitor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Serialization;

namespace Aplicacao
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Padrão De Projeto Comportamental

            #region Strategy

            /*
             Diferente ideias de imposto implementadas a partir de uma chamada sem criar "IF" para cada imposto
             */

            //Imposto iss = new ISS();
            //Imposto icms = new ICMS();

            //Orcamento orcamento = new Orcamento(500.0);

            //CalculadorDeImpostos calculador = new CalculadorDeImpostos();

            //calculador.RealizaCalculo(orcamento, iss);
            //calculador.RealizaCalculo(orcamento, icms);

            #endregion

            #region Chain Of Responsability
            /* 
             condiçoes diferentes para implementaçoes separando por classes 
             onde cada uma delas tem uma unica responsabilidade criando uma corrente de responsabilidade
             */

            //CalculadorDeDescontos calculador = new CalculadorDeDescontos();
            //Orcamento orcamento = new Orcamento(500.0);
            //orcamento.AdicionaItem(new Item("Caneta", 250));
            //orcamento.AdicionaItem(new Item("Lapis", 250));
            //orcamento.AdicionaItem(new Item("Lapis", 250));
            //orcamento.AdicionaItem(new Item("Lapis", 250));
            //orcamento.AdicionaItem(new Item("Lapis", 250));
            //orcamento.AdicionaItem(new Item("Lapis", 250));

            //double desconto = calculador.Calcula(orcamento);
            //Console.WriteLine(desconto);
            #endregion

            #region Template Method

            /*
             Visando que uma responsabilidade possui uma estrutura que pode ser reutilizada, é possivel 
             aplica um modelo a ser seguido por outras classes para sua implementação
             */

            //Imposto ikcv = new IKCV();
            //Imposto icpp = new ICPP();

            //Orcamento orcamento = new Orcamento(500.0);

            //CalculadorDeImpostos calculador = new CalculadorDeImpostos();

            //calculador.RealizaCalculo(orcamento, ikcv);
            //calculador.RealizaCalculo(orcamento, icpp);

            #endregion

            #region Decorator
            /* Um objeto pode usar outras classes aplicando comportamentos distintos em um mesmo objeto */

            //Imposto iss = new ISS(new ICMS(new IKCV()));

            //Orcamento orcamento = new Orcamento(500);

            //double valor = iss.Calcula(orcamento);

            //Console.WriteLine(valor);

            #endregion

            #region State

            /* Mudança de estado em momentos diferentes nos calculos metodos do objeto, se preocupando com a transiçao entre estados */

            //Orcamento reforma = new Orcamento(500);
            //Console.WriteLine(reforma.Valor);

            //reforma.AplicaDescontoExtra();
            //Console.WriteLine(reforma.Valor);

            //reforma.Aprova();

            //reforma.AplicaDescontoExtra();
            //Console.WriteLine(reforma.Valor);

            //reforma.Finaliza();

            #endregion

            #region Builder

            /* Criador de objetos, encapsulando em uma classe criadora de objetos facilitando e tornando legivel o construtor
             * Fluent Interface
             * Method Chain
             */

            NotaFiscalBuilder criador = new NotaFiscalBuilder();
            criador
                .ParaEmpresa("Empresa XYZ")
                .ComCNPJ("00.000.000/0001-01")
                .ComItem(new ItemDaNota("Item 1", 100.00))
                .ComItem(new ItemDaNota("Item 2", 200.00))
                .NaDataAtual()
                .ComObservacoes("Observaçoes vao aqui!");


            //NotaFiscal nf = criador.Constroi();

            //Console.WriteLine(nf.CNPJ);
            //Console.WriteLine(nf.DataEmissao);
            //Console.WriteLine(nf.ValorBruto);
            //Console.WriteLine(nf.Impostos);
            //Console.WriteLine(nf.Observacao);
            #endregion

            #region Observer

            /*
             Acoes genericas para ajudam a qualquer acao criada ser acionada sem interferir uma nas outras, desacoplando metodos
             */

            //NotaFiscalBuilder criador = new NotaFiscalBuilder();
            //criador
            //    .ParaEmpresa("Empresa XYZ")
            //    .ComCNPJ("00.000.000/0001-01")
            //    .ComItem(new ItemDaNota("Item 1", 100.00))
            //    .ComItem(new ItemDaNota("Item 2", 200.00))
            //    .NaDataAtual()
            //    .ComObservacoes("Observaçoes vao aqui!");

            criador.AdicionaAcao(new NotaFiscalDAO()); // salva no banco
            criador.AdicionaAcao(new EnviadorDeEmail());
            criador.AdicionaAcao(new EnviadorDeSMS());


            NotaFiscal nf = criador.Constroi();

            Console.WriteLine(nf.CNPJ);
            Console.WriteLine(nf.DataEmissao);
            Console.WriteLine(nf.ValorBruto);
            Console.WriteLine(nf.Impostos);
            Console.WriteLine(nf.Observacao);

            #endregion
            #endregion

            #region Padrão de Projeto Estrutural

            #region Factory

            /*
             Constroi estrutura isolada para criacao de objetos complicados(objetos que raramente alteram seu construtor ou parametros)
            Temos o costume de usar o sufixo Factory nas nossas classes que são fábricas. Muitas vezes vale a pena 
            seguir a convenção, já que, dessa forma, outros desenvolvedores entenderão mais facilmente o código.

            Qual a diferença entre Factory e Builder?
            Ambos são padrões de projeto que visam resolver problemas de criação de objetos. O que muda de 
            um pro outro é basicamente a semântica. Geralmente usamos um builder quando precisamos passar 
            diversas informações para a lógica que monta o objeto. No caso da Nota Fiscal, passamos nome, ítens, etc.
            Usamos uma fábrica quando temos que isolar o processo de criação de um objeto em um único lugar. 
            Essa fábrica pode descobrir como criar o objeto dentro dela própria, mas geralmente ela não precisa 
            de muitas informações para criar o objeto.
             */

            //IDbConnection conexao = new ConnectionFactory().GetConnection();
            //conexao.ConnectionString = "User Id=root;Password=;Server=localhost;DataBase=meuBanco";
            //conexao.Open();

            //IDbCommand commando = conexao.CreateCommand();
            //commando.CommandText = "Select * from minhaTabela";

            #endregion

            #region Flyweight
            /* Reutilizaçao de objeto alterando apenas o parametro
             Qual a diferença entre Factory e Flyweight?
            Uma Factory instancia uma classe que é importante/complexa, e seu processo de criação deve ser isolado.
            Um Flyweight serve para quando temos muitas instâncias do mesmo objeto andando pelo sistema, e precisamos 
            economizar. Para tal, o Flyweight faz uso de uma fábrica modificada, que guarda essas instâncias.

            O que você acha do Singleton? Ele se parece com um FlyWeight?
            A ideia de ambos é garantir que existam apenas uma única referência para o objeto ao longo do programa.
            A diferença é que o Flyweight garante que existam apenas uma única instância de vários elementos. É um "singleton maior".
             
             */

            //NotasMusicais notas = new NotasMusicais();
            //IList<INota> musica = new List<INota>() 
            //{
            //    notas.Pega("Do"),
            //    notas.Pega("Re"),
            //    notas.Pega("Mi"),
            //    notas.Pega("Fa"),
            //    notas.Pega("Fa"),
            //    notas.Pega("Fa")
            //};

            //Piano piano = new Piano();

            //piano.Toca(musica);
            #endregion

            #region Memento
            /*
             Toda vez que precisar salvar estado de um objeto utiliza esse metodo para a necessidade de recuperaçao

            Para que serve a classe Estado? Não poderíamos simplesmente guardar a classe Contrato de uma vez na lista?
            Sim, poderíamos guardar diretamente a lista de Contratos. Mas veja que isso depende do problema. 
            No nosso caso, não tínhamos outra informação para associar ao "estado". Se tivéssemos que armazenar,
            por exemplo, a data que o estado foi salvo, a classe Estado faria sentido.
            As definições de padrões de projeto são geralmente as mais genéricas possíveis para dar suporte a qualquer 
            problema. Mas você obviamente deve implementar o padrão de acordo com o seu problema.

            Você consegue ver algum possível problema do padrão Memento? Se sim, qual?
            Um possível problema é a quantidade de memória que ele pode ocupar, afinal estamos guardando muitas 
            instâncias de objetos que podem ser pesados. Por isso, dependendo do tamanho dos seus objetos, a 
            classe Estado pode passar a guardar não o objeto todo, mas sim somente as propriedades que mais 
            fazem sentido. Nada impede você também de limitar a quantidade máxima de objetos no histórico que
            será armazenado.

             */

            //Historico historico = new Historico();
            //Contrato c = new Contrato(DateTime.Now, "NomeCliente", TipoContrato.Novo);
            //historico.Adiciona(c.SalvaEstado());
            //Console.WriteLine(historico.Pega(0).Contrato.Tipo);

            //Console.WriteLine(c.Tipo);

            //c.Avanca();
            //historico.Adiciona(c.SalvaEstado());
            //Console.WriteLine(historico.Pega(1).Contrato.Tipo);

            //c.Avanca();
            //historico.Adiciona(c.SalvaEstado());
            //Console.WriteLine(historico.Pega(2).Contrato.Tipo);

            //Console.WriteLine(c.Tipo);
            #endregion

            #region Interpreter
            /*
             Permite avaliação em arvore facilitando a recursividade para processamento de objetos.

            Você consegue dar algum exemplo de onde o Interpreter pode ser útil?
            O padrão Interpreter é geralmente útil para interpretar DSLs. É comum que, ao ler a 
            string (como por exemplo 2+3/4), o programa transforme-a em uma estrutura de dados 
            melhor (como as nossas classes Expressao) e aí interprete essa árvore. É realmente um 
            padrão de projeto bem peculiar, e com utilização bem específica.

             */
            IExpressao esquerda = new Soma(new Numero(1), new Numero(10));
            IExpressao direita = new Subtracao(new Numero(20), new Numero(10));

            IExpressao soma = new Soma(esquerda, direita);

            Console.WriteLine(soma.Avalia());

            esquerda = new Soma(new Soma(new Numero(1), new Numero(100)), new Numero(10));
            direita = new Subtracao(new Numero(20), new Numero(10));

            IExpressao subtracao = new Subtracao(esquerda, direita);

            Console.WriteLine(soma.Avalia());


            Expression soma_1 = Expression.Add(Expression.Constant(10), Expression.Constant(100)); // Classe do C# que faz esse trabalho de analise em 
            Func<int> funcao = Expression.Lambda<Func<int>>(soma_1).Compile();

            Console.WriteLine(funcao());
            #endregion

            #region Visitor
            /*
             toda vez que a estrutura de dados precisa visitar uma parte para executar uma acao, é possivel atraves do acesso como arvore binaria

            Para nosso exemplo de calculadora, você consegue pensar em mais alguma situação em que poderíamos utilizar o visitor?
            A finalidade do visitor dentro do código é simplesmente percorrer toda a árvore de expressão para 
            executar alguma lógica. Nesse capítulo, ele foi utilizado para imprimir as expressões, mas ele 
            também poderia ser utilizado para realizar cálculos com a expressão ou qualquer outra tarefa que dependa
            do processamento dos nós de nossa árvore de expressão. Por esse motivo, os métodos do visitor
            normalmente tem o nome começado com Visita ao invés de Imprime.

             */

            //IExpressao esquerda = new Soma(new Numero(1), new Numero(10));
            //IExpressao direita = new Subtracao(new Numero(20), new Numero(10));

            //IExpressao soma = new Soma(esquerda, direita);

            //Console.WriteLine(soma.Avalia());

            //Impressora impressora = new Impressora();

            //soma.Aceita(impressora);

            #endregion

            #region Bridge
            /*
             Separa as responsabilidades por hierarquia de classe criando pontes com interfaces

            Você consegue ver alguma relação entre o Bridge e o Strategy? Qual?
            Na implementação do bridge que fizemos nesse capítulo, podemos ver que o bridge 
            pode utilizar o strategy em sua implementação: a mensagem em seu método Envia 
            utiliza o strategy para decidir qual é a estratégia de envio que será utilizada pela aplicação.
             */

            //IMensagem mensagem = new MensagemAdministrativa("Nome do Cliente");
            //IEnviador enviador = new EnviaPorEmail();
            //mensagem.Enviador = enviador;
            //mensagem.Envia();

            #endregion

            #region Command
            /*
             * Toda vez que criar uma classe que executa um comando posteriormente esse metodo guarda e executa conforme o comando for acionado 
             * 
             * Qual a diferença entre Command e Strategy?
             * Novamente, em termos de implementação, eles são bem parecidos, pois dependem de interfaces.
             * A ideia do Command é abstrair um comando que deve ser executado, pois não é possível 
             * executá-lo naquele momento (pois precisamos por em uma fila ou coisa do tipo).
             * Já no Strategy, a ideia é que você tenha uma estratégia (um algoritmo) para resolver um problema.
             * 
             * Você consegue ver o Command trabalhando junto com algum outro padrão?
             * Podemos ser criativos e usar outros padrões de projeto de acordo com o problema que temos em mãos.
             * Podemos usar Memento para restaurar estados de objetos que foram alterados por um Command.
             * Lembre-se. Aprenda a motivação de cada padrão, e aí use-os sempre que precisar.
             */

            FilaDeTrabalho fila = new FilaDeTrabalho();
            Pedido pedido1 = new Pedido("Nome Cliente", 100.00);
            Pedido pedido2 = new Pedido("Nome Cliente 2", 250.00);
            fila.Adiciona(new PagaPedido(pedido1));
            fila.Adiciona(new PagaPedido(pedido2));


            fila.Adiciona(new FinalizaPedido(pedido1));
            fila.Adiciona(new FinalizaPedido(pedido2));

            fila.Processa();


            #endregion

            #region Adapter
            /*
             Isolar codigo legado dentro de uma classe que se adapte ao meu codigo

            Quais são as diferenças que existem entre os padrões Adapter e Strategy?
            A diferença que existe entre os padrões é o propósito. No Adapter estamos 
            adaptando a interface de um sistema antigo para que ela possa se encaixar
            em um sistema novo. Já no Strategy a ideia é utilizar diferentes estratégias
            para resolver um dado problema no sistema.

            Quais são as diferenças entre os padrões Adapter e Command?
            Como dito no exercício anterior, o Adapter serve para adaptar o código 
            de um sistema legado ou biblioteca para que ele possa ser utilizado 
            no novo sistema. Já o command serve para guardarmos um trecho de 
            código que precisa ser executado posteriormente.
             */

            //Estrutural.Adapter.Cliente cliente = new Estrutural.Adapter.Cliente();
            //cliente.Nome = "";
            //cliente.Endereco = "";
            //cliente.DataNascimento = DateTime.Now;

            //String xml = new GeradorXML().GeraXML(cliente);

            //Console.WriteLine(xml);

            #endregion

            #region Facede
            /*
                facade = fachada, esconde sistemas legados colocando metodos em outra classe
                Você consegue ver alguma semelhança/diferença entre o Façade o Adapter?
                O Façade cria uma interface amigável para que clientes consigam consumir sub-sistemas (ou serviços).
                Já o Adapter tem um propósito diferente. Ele visa adaptar um conjunto de classes que já existem, 
                para uma outra interface, que é a requerida pelo outro sistema.
             */

            //String cpf = "11212312312";

            //EmpresaFacade facade = new EmpresaFacade();

            //Cliente cliente = facade.BuscaCliente(cpf);

            //var fatura = facade.CriaFatura(cliente, 5000);
            //facade.GeraCobranca(tipo.Boleto, fatura);

            #endregion

            #region Singleton
            /*
             igual ao facade porem como variavel global

            Quais são os problemas do Singleton?
            O Singleton possibilita que o usuário crie uma instância global para 
            determinado objeto. Isso pode ser interessante, mas tem problemas similares
            ao de variáveis globais no mundo procedural, afinal o objeto é único e
            disponível para todos. Se não usar com parcimônia, o seu código 
            sofrerá problemas de manutenção.

             */

            //EmpresaFacade facadeSingleton = new EmpresaFacadeSingleton().Instancia;

            //Cliente cliente = facade.BuscaCliente(cpf);

            //var fatura = facade.CriaFatura(cliente, 5000);
            //facade.GeraCobranca(tipo.Boleto, fatura);

            #endregion

            #endregion

            #region Padrão de Projeto Criacional



            #endregion

            Console.ReadKey();
        }
    }
}
