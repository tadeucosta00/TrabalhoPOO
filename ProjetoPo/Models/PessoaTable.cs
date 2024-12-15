using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ProjetoPo.Models
{
    internal class PessoaTable
    {
        public static void Salvar(Pessoa pessoa)
        {
            string query = "INSERT INTO Pessoa (Nome, Email, Telefone, DocumentoIdentidade, Senha, Adm) VALUES (@Nome, @Email, @Telefone, @DocumentoIdentidade, @Senha, @Adm)";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("@Email", pessoa.Email);
                cmd.Parameters.AddWithValue("@Telefone", pessoa.Telefone);
                cmd.Parameters.AddWithValue("@DocumentoIdentidade", pessoa.DocumentoIdentidade);
                cmd.Parameters.AddWithValue("@Senha", pessoa.Senha);
                cmd.Parameters.AddWithValue("@Adm", pessoa.Adm);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Atualizar(Pessoa pessoa)
        {
            string query = "UPDATE Pessoa SET Nome = @Nome, Email = @Email, Telefone = @Telefone, DocumentoIdentidade = @DocumentoIdentidade, Senha = @Senha, Adm = @Adm, Ativo = @Ativo WHERE Id = @Id";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("@Email", pessoa.Email);
                cmd.Parameters.AddWithValue("@Telefone", pessoa.Telefone);
                cmd.Parameters.AddWithValue("@DocumentoIdentidade", pessoa.DocumentoIdentidade);
                cmd.Parameters.AddWithValue("@Senha", pessoa.Senha);
                cmd.Parameters.AddWithValue("@Adm", pessoa.Adm);
                cmd.Parameters.AddWithValue("@Id", pessoa.Id);
                cmd.Parameters.AddWithValue("@Ativo", pessoa.Ativo);


                cmd.ExecuteNonQuery();
            }
        }

        public static Pessoa GetById(int id)
        {
            string query = "SELECT Id, Nome, Email, Telefone, DocumentoIdentidade, Senha, Adm FROM Pessoa WHERE Id = @Id";
            Pessoa pessoa = null;

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pessoa = new Pessoa
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nome = reader["Nome"].ToString(),
                            Email = reader["Email"].ToString(),
                            Telefone = reader["Telefone"].ToString(),
                            DocumentoIdentidade = reader["DocumentoIdentidade"].ToString(),
                            Senha = reader["Senha"].ToString(),
                            Adm = Convert.ToBoolean(reader["Adm"])
                        };
                    }
                }
            }
            return pessoa;
        }

        public static bool EmailJaExistente(string email)
        {
            string query = "SELECT COUNT(1) FROM Pessoa WHERE Email = @Email";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public static List<Pessoa> GetAll()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            string query = "SELECT Id, Nome, Email, Telefone, DocumentoIdentidade, Senha, Adm, Ativo FROM Pessoa";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pessoa pessoa = new Pessoa
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nome = reader["Nome"].ToString(),
                            Email = reader["Email"].ToString(),
                            Telefone = reader["Telefone"].ToString(),
                            DocumentoIdentidade = reader["DocumentoIdentidade"].ToString(),
                            Senha = reader["Senha"].ToString(),
                            Adm = Convert.ToBoolean(reader["Adm"]),
                            Ativo = Convert.ToBoolean(reader["Ativo"])
                        };
                        pessoas.Add(pessoa);
                    }
                }
            }
            return pessoas;
        }

        public static void Editar(int id, string nome, string documentoid, string telefone)
        {
            string query = "UPDATE Pessoa SET Nome = @Nome, DocumentoIdentidade = @DocumentoIdentidade, Telefone = @Telefone WHERE Id = @Id";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@DocumentoIdentidade", documentoid);
                cmd.Parameters.AddWithValue("@Telefone", telefone);
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public static void AtualizarSenha(Pessoa user)
        {
            string query = "UPDATE Pessoa SET Senha = @Senha WHERE Id = @Id";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Senha", user.Senha);
                cmd.Parameters.AddWithValue("@Id", user.Id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
