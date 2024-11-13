using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ProjetoPo.Models
{
    public class Pessoa : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string DocumentoIdentidade { get; set; }
        public string Senha { get; set; }
        public bool Adm { get; set; }

        public Pessoa(int id, string nome, string email, string telefone, string documentoIdentidade, string senha, bool adm)
            : base(id)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            DocumentoIdentidade = documentoIdentidade;
            Senha = senha;
            Adm = adm;
        }

        public Pessoa() { }

        public void Salvar()
        {
            string query = "INSERT INTO Pessoa (Nome, Email, Telefone, DocumentoIdentidade, Senha, Adm) VALUES (@Nome, @Email, @Telefone, @DocumentoIdentidade, @Senha, @Adm)";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Telefone", Telefone);
                cmd.Parameters.AddWithValue("@DocumentoIdentidade", DocumentoIdentidade);
                cmd.Parameters.AddWithValue("@Senha", Senha);
                cmd.Parameters.AddWithValue("@Adm", Adm);

                cmd.ExecuteNonQuery();
            }
        }

        public void Atualizar()
        {
            string query = "UPDATE Pessoa SET Nome = @Nome, Email = @Email, Telefone = @Telefone, DocumentoIdentidade = @DocumentoIdentidade, Senha = @Senha, Adm = @Adm WHERE Id = @Id";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Telefone", Telefone);
                cmd.Parameters.AddWithValue("@DocumentoIdentidade", DocumentoIdentidade);
                cmd.Parameters.AddWithValue("@Senha", Senha);
                cmd.Parameters.AddWithValue("@Adm", Adm);
                cmd.Parameters.AddWithValue("@Id", Id);

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
            string query = "SELECT Id, Nome, Email, Telefone, DocumentoIdentidade, Senha, Adm FROM Pessoa";

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
                            Adm = Convert.ToBoolean(reader["Adm"])
                        };
                        pessoas.Add(pessoa);
                    }
                }
            }
            return pessoas;
        }
    }
}
