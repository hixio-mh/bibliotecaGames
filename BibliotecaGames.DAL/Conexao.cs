using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BibliotecaGames.DAL
{
    public class Conexao
     {
        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ConnectionString;
        public static SqlConnection connection = new SqlConnection(connectionString);

        public static void Conectar()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            
        }

        public static void Desconectar()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }

        }
    }
}
