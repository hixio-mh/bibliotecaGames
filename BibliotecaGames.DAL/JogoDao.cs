using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.DAL
{
    public class JogoDao
    {
        public List<Jogo> ObterTodosOsJogos()
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM JOGOS";

               Conexao.Conectar();

                var reader = command.ExecuteReader();
                var jogos = new List<Jogo>();

                while (reader.Read())
                {
                    var jogo = new Jogo();

                    jogo.Id = Convert.ToInt32(reader["id"]);
                    jogo.Imagem = reader["imagem"].ToString();
                    jogo.DataCompra = reader["dataCompra"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["dataCompra"]);
                    jogo.Titulo = reader["titulo"].ToString();
                    jogo.ValorPago = reader["valorPago"] == DBNull.Value ? (double?) null : Convert.ToDouble(reader["valorPago"]);

                    jogos.Add(jogo);
                }

                return jogos;
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

        public Jogo ObterJogoPeloId(int id)
        {

            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM JOGOS where id = @id";


                command.Parameters.AddWithValue("@id", id);

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                Jogo jogo = null;

                while (reader.Read())
                {
                    jogo = new Jogo();

                    jogo.Id = Convert.ToInt32(reader["id"]);
                    jogo.Imagem = reader["imagem"].ToString();
                    jogo.DataCompra = reader["dataCompra"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["dataCompra"]);
                    jogo.Titulo = reader["titulo"].ToString();
                    jogo.ValorPago = reader["valorPago"] == DBNull.Value ? (double?)null : Convert.ToDouble(reader["valorPago"]);
                    jogo.IdEditor = Convert.ToInt32(reader["id_editor"]);
                    jogo.IdGenero = Convert.ToInt32(reader["id_genero"]);

                }

                return jogo;
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

        public int InserirJogo(Jogo jogo)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = @"INSERT INTO [dbo].[jogos] 
                                               ([titulo], 
                                                [valorPago], 
                                                [dataCompra], 
                                                [id_editor], 
                                                [id_genero], 
                                                [imagem]) 
                                        VALUES 
                                                (@TITULO,
                                                @VALOR_PAGO,
                                                @DATA_COMPRA, 
                                                @ID_EDITOR, 
                                                @ID_GENERO, 
                                                @IMAGEM)";

                command.Parameters.AddWithValue("@TITULO", jogo.Titulo);
                command.Parameters.AddWithValue("@VALOR_PAGO", jogo.ValorPago);
                command.Parameters.AddWithValue("@DATA_COMPRA", jogo.DataCompra);
                command.Parameters.AddWithValue("@ID_EDITOR", jogo.IdEditor);
                command.Parameters.AddWithValue("@ID_GENERO", jogo.IdGenero);
                command.Parameters.AddWithValue("@IMAGEM", jogo.Imagem);

                Conexao.Conectar();
                return command.ExecuteNonQuery();

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

        public int AlterarJogo(Jogo jogo)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = @"UPDATE [dbo].[jogos]
                                        SET     [titulo] = @TITULO, 
                                                [valorPago] = @VALOR_PAGO, 
                                                [dataCompra] = @DATA_COMPRA, 
                                                [id_editor] = @ID_EDITOR, 
                                                [id_genero] = @ID_GENERO 
                                        WHERE   Id = @ID";

                command.Parameters.AddWithValue("@TITULO", jogo.Titulo);
                command.Parameters.AddWithValue("@VALOR_PAGO", jogo.ValorPago);
                command.Parameters.AddWithValue("@DATA_COMPRA", jogo.DataCompra);
                command.Parameters.AddWithValue("@ID_EDITOR", jogo.IdEditor);
                command.Parameters.AddWithValue("@ID_GENERO", jogo.IdGenero);
               // command.Parameters.AddWithValue("@IMAGEM", jogo.Imagem);
                command.Parameters.AddWithValue("@ID", jogo.Id);

                Conexao.Conectar();
                return command.ExecuteNonQuery();

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

        public int ExcluirJogo(Jogo jogo)
        {

            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = @"DELETE FROM[dbo].[Jogos] WHERE id = @ID";

                command.Parameters.AddWithValue("@ID", jogo.Id);


                Conexao.Conectar();
                return command.ExecuteNonQuery();
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
