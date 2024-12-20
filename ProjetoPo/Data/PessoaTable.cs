using MySql.Data.MySqlClient;
using Logs;

namespace ProjetoPo.Models
{
    internal class PessoaTable
    {
        public static void Salvar(Pessoa pessoa)
        {
            Logger logger = new Logger();
            string query = "INSERT INTO Pessoa (Nome, Email, Telefone, DocumentoIdentidade, Senha, Adm) VALUES (@Nome, @Email, @Telefone, @DocumentoIdentidade, @Senha, @Adm)";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                try
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
                catch (Exception ex)
                {
                    logger.LogError($"Erro ao salvar pessoa: {ex.Message}");
                    throw;
                }
            }
        }

        public static Pessoa GetByEmailAndPassword(string email, string senhaHash)
        {
            Logger logger = new Logger();
            string query = "SELECT Id, Nome, Email, Telefone, DocumentoIdentidade, Senha, Adm FROM Pessoa WHERE Email = @Email AND Senha = @Senha";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senhaHash);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Pessoa
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
                catch (Exception ex)
                {
                    logger.LogError($"Erro ao obter pessoa pelo email e senha: {ex.Message}");
                    throw;
                }
            }
            return null;
        }

        public static void Atualizar(Pessoa pessoa)
        {
            Logger logger = new Logger();
            string query = "UPDATE Pessoa SET Nome = @Nome, Email = @Email, Telefone = @Telefone, DocumentoIdentidade = @DocumentoIdentidade, Senha = @Senha, Adm = @Adm, Ativo = @Ativo WHERE Id = @Id";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                try
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
                catch (Exception ex)
                {
                    logger.LogError($"Erro ao atualizar pessoa com ID {pessoa.Id}: {ex.Message}");
                    throw;
                }
            }
        }

        public static Pessoa GetById(int id)
        {
            Logger logger = new Logger();
            string query = "SELECT Id, Nome, Email, Telefone, DocumentoIdentidade, Senha, Adm FROM Pessoa WHERE Id = @Id";
            Pessoa pessoa = null;

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                try
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
                catch (Exception ex)
                {
                    logger.LogError($"Erro ao obter pessoa com ID {id}: {ex.Message}");
                    throw;
                }
            }
            return pessoa;
        }

        public static bool EmailJaExistente(string email)
        {
            Logger logger = new Logger();
            string query = "SELECT COUNT(1) FROM Pessoa WHERE Email = @Email";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
                catch (Exception ex)
                {
                    logger.LogError($"Erro ao verificar existência de email: {ex.Message}");
                    throw;
                }
            }
        }

        public static List<Pessoa> GetAll()
        {
            Logger logger = new Logger();
            List<Pessoa> pessoas = new List<Pessoa>();
            string query = "SELECT Id, Nome, Email, Telefone, DocumentoIdentidade, Senha, Adm, Ativo FROM Pessoa";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                try
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
                catch (Exception ex)
                {
                    logger.LogError($"Erro ao obter todas as pessoas: {ex.Message}");
                    throw;
                }
            }
            return pessoas;
        }

        public static void Editar(int id, string nome, string documentoid, string telefone)
        {
            Logger logger = new Logger();
            string query = "UPDATE Pessoa SET Nome = @Nome, DocumentoIdentidade = @DocumentoIdentidade, Telefone = @Telefone WHERE Id = @Id";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@DocumentoIdentidade", documentoid);
                    cmd.Parameters.AddWithValue("@Telefone", telefone);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    logger.LogError($"Erro ao editar pessoa com ID {id}: {ex.Message}");
                    throw;
                }
            }
        }

        public static void AtualizarSenha(Pessoa user)
        {
            Logger logger = new Logger();
            string query = "UPDATE Pessoa SET Senha = @Senha WHERE Id = @Id";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Senha", user.Senha);
                    cmd.Parameters.AddWithValue("@Id", user.Id);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    logger.LogError($"Erro ao atualizar senha para o utilizador com ID {user.Id}: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
