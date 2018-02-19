using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.DAL
{
    public class EditorDao
    {
        public List<Editor> ObterTodosOsEditores()
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM EDITORES ORDER BY NOME";

                Conexao.Conectar();

                var reader = command.ExecuteReader();
                var editores = new List<Editor>();

                while (reader.Read())
                {
                    var editor = new Editor();

                    editor.Id = Convert.ToInt32(reader["id"]);
                    editor.Nome = reader["nome"].ToString();

                    editores.Add(editor);
                }

                return editores;
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
