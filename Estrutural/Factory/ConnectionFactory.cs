using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estrutural.Factory
{
    public class ConnectionFactory
    {
        public IDbConnection GetConnection()
        {
            /*
             */
            IDbConnection conexao = new SqlConnection();
            //conexao.ConnectionString = new LeitorDeConfiguracao().LerConnectionString();
            conexao.Open();

            return conexao;
        }
    }
}
