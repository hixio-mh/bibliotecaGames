using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.DAL
{
    public class GeneroDao
    {
        public List<Genero> ObterTodosOsGeneros()
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM GENEROS ORDER BY DESCRICAO";

                Conexao.Conectar();

                var reader = command.ExecuteReader();
                var generos = new List<Genero>();

                while (reader.Read())
                {
                    var genero = new Genero();

                    genero.Id = Convert.ToInt32(reader["id"]);
                    genero.Descricao = reader["descricao"].ToString();
                    

                    generos.Add(genero);
                }

                return generos;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
