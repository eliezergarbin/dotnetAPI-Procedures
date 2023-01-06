using MinhaAPI.Model;
using System.Data;
using System.Data.SqlClient;

namespace MinhaAPI.Dao
{
    public class DaoPessoa
    {
        string conexao = @"Data Source=DESKTOP-NQK9MJ8;Initial Catalog=MINHA_API;Integrated Security=True";

        public List<Pessoa> GetPessoas()
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetPessoas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var pessoa = new Pessoa();
                                pessoa.Nome = reader["Nome"].ToString();
                                pessoa.Email = reader["Email"].ToString();
                                pessoas.Add(pessoa);
                            }
                        }
                    }
                }
            }
            return pessoas;
        }

        public void InsertPessoa(Pessoa pessoa)
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("InserirPessoas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOME", pessoa.Nome);
                    cmd.Parameters.AddWithValue("@EMAIL", pessoa.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
