using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GerenciadorCartoesCredito.Data_Access_Layer
{
    public class Dal
    {
        public static readonly string Server = "DESKTOP-EJP79KA";
        public static readonly string Database = "ControleCartoes";
        public static readonly string User = "sa";

        public static readonly string Password = "Paradoxo22";

        public static readonly string StrSql = $"Server = {Server}; Database = {Database}; Uid ={User}; Pwd ={Password}";

        public SqlConnection Conexao()
        {
            return new SqlConnection(StrSql);
        }

        public void FecharConexao()
        {
            try
            {
                SqlConnection conn = Conexao();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw  new Exception (ex.Message);
            }
        }

        private SqlParameterCollection Colecao = new SqlCommand().Parameters;

        public void LimparParametros()
        {
            try
            {
                Colecao.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddParametros(string nome, object valor)
        {
            try
            {
                Colecao.Add(new SqlParameter(nome,valor));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object ExecutarManipulacao(CommandType commandType, string Sp_Ou_Texto)
        {
            try
            {
                SqlConnection conn = Conexao();
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = commandType;
                cmd.CommandText = Sp_Ou_Texto;
                cmd.CommandTimeout = 3600;

                foreach(SqlParameter param in Colecao)
                {
                    cmd.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                }
                return cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ExecutarConsulta(CommandType commandType, string Sp_Ou_Texto)
        {
            try
            {
                SqlConnection conn = Conexao();
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = commandType;
                cmd.CommandText = Sp_Ou_Texto;
                cmd.CommandTimeout = 3600;

                foreach(SqlParameter param in Colecao)
                {
                    cmd.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                }
                DataTable dt = new DataTable ();
                SqlDataAdapter da = new SqlDataAdapter (cmd);
                da.Fill(dt);
                return dt;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable RetDatatable(string sql)
        {
            try
            {
                DataTable dt = new DataTable ();
                SqlCommand cmd = new SqlCommand (sql, Conexao());
                SqlDataAdapter da = new SqlDataAdapter (cmd);
                da.Fill(dt);
                return dt;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Polimorfismo para evitar ataque de injeção de SQL
        public DataTable RetDatatable(SqlCommand cmd)
        {
            try
            {
                DataTable dt = new DataTable ();
                cmd.Connection = Conexao();
                SqlDataAdapter da = new SqlDataAdapter (cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}