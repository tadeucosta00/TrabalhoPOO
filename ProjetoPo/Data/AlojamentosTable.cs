using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Logs;
using Microsoft.Extensions.Logging;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;


namespace ProjetoPo.Models
{
    internal class AlojamentosTable
    {
        public static List<Alojamento> GetAllAlojamentos()
        {
            List<Alojamento> alojamentos = new List<Alojamento>();
            Logger logger = new Logger();
            try
            {
                string query = "SELECT * FROM alojamento";


                using (var conn = ConexaoBD.GetConexao())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Alojamento alojamento = new Alojamento
                        {
                            Id = reader.GetInt32("Id"),
                            Nome = reader.GetString("Nome"),
                            Tipo = (TipoAlojamento)reader.GetInt32("Tipo"),
                            Desc = reader.GetString("Descricao"),
                            Latitude = reader.GetString("Latitude"),
                            Longitude = reader.GetString("Longitude"),
                            PrecoPorNoite = reader.GetDouble("PrecoPorNoite"),
                            CapacidadeMaxima = reader.GetInt32("CapacidadeMaxima"),
                            Disponivel = reader.GetBoolean("Disponivel"),
                            Estrelas = reader.GetInt32("Estrelas"),
                            Photos = reader.GetBoolean("Photos"),
                            Local = reader.GetString("Local"),
                        };

                        string comodidadesJson = reader.IsDBNull(reader.GetOrdinal("Comodidades")) ? "[]" : reader.GetString("Comodidades");
                        alojamento.Comodidades = JsonConvert.DeserializeObject<List<string>>(comodidadesJson);


                        alojamentos.Add(alojamento);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter todos os alojamentos: {ex.Message}");
            }

            return alojamentos;
        }

        public static List<Alojamento> GetAlojamentosDisponiveis()
        {
            List<Alojamento> alojamentos = new List<Alojamento>();
            Logger logger = new Logger();
            try
            {
                string query = "SELECT * FROM alojamento where Disponivel = 1";


                using (var conn = ConexaoBD.GetConexao())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Alojamento alojamento = new Alojamento
                        {
                            Id = reader.GetInt32("Id"),
                            Nome = reader.GetString("Nome"),
                            Tipo = (TipoAlojamento)reader.GetInt32("Tipo"),
                            Desc = reader.GetString("Descricao"),
                            Latitude = reader.GetString("Latitude"),
                            Longitude = reader.GetString("Longitude"),
                            PrecoPorNoite = reader.GetDouble("PrecoPorNoite"),
                            CapacidadeMaxima = reader.GetInt32("CapacidadeMaxima"),
                            Disponivel = reader.GetBoolean("Disponivel"),
                            Estrelas = reader.GetInt32("Estrelas"),
                            Photos = reader.GetBoolean("Photos"),
                            Local = reader.GetString("Local"),
                        };

                        string comodidadesJson = reader.IsDBNull(reader.GetOrdinal("Comodidades")) ? "[]" : reader.GetString("Comodidades");
                        alojamento.Comodidades = JsonConvert.DeserializeObject<List<string>>(comodidadesJson);


                        alojamentos.Add(alojamento);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter alojamentos disponiveis: {ex.Message}");
            }

            return alojamentos;
        }

        public static Alojamento GetAlojamentoById(int idAlojamento)
        {
            Alojamento alojamento = null;
            Logger logger = new Logger();
            try
            {
                string query = "SELECT * FROM alojamento WHERE Id = @Id";
                using (var conn = ConexaoBD.GetConexao())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", idAlojamento);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        alojamento = new Models.Alojamento
                        {
                            Id = reader.GetInt32("Id"),
                            Nome = reader.GetString("Nome"),
                            Tipo = (TipoAlojamento)reader.GetInt32("Tipo"),
                            Desc = reader.GetString("Descricao"),
                            Latitude = reader.GetString("Latitude"),
                            Longitude = reader.GetString("Longitude"),
                            PrecoPorNoite = reader.GetDouble("PrecoPorNoite"),
                            CapacidadeMaxima = reader.GetInt32("CapacidadeMaxima"),
                            Disponivel = reader.GetBoolean("Disponivel"),
                            Estrelas = reader.GetInt32("Estrelas"),
                            Photos = reader.GetBoolean("Photos"),
                            Local = reader.GetString("Local"),
                        };
                        string comodidadesJson = reader.IsDBNull(reader.GetOrdinal("Comodidades")) ? "[]" : reader.GetString("Comodidades");
                        alojamento.Comodidades = JsonConvert.DeserializeObject<List<string>>(comodidadesJson);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter alojamento com ID :{idAlojamento} {ex.Message}");
            }

            return alojamento;
        }

        public static int AdicionarAlojamento(Alojamento alojamneto)
        {
            Logger logger = new Logger();
            try
            {
                using (var conn = ConexaoBD.GetConexao())
                {
                    conn.Open();
                    string query = @"
                    INSERT INTO alojamento (Nome, Descricao, Tipo, Latitude, Longitude, PrecoPorNoite, CapacidadeMaxima,
                                            Disponivel, Estrelas, Photos, Local, Comodidades)
                    VALUES (@Nome, @Desc, @Tipo, @Latitude, @Longitude, @PrecoPorNoite, @CapacidadeMaxima, @Disponivel,
                            @Estrelas, @Photos, @Local, @Comodidades);
                    SELECT LAST_INSERT_ID();";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nome", alojamneto.Nome);
                    cmd.Parameters.AddWithValue("@Desc", alojamneto.Desc);
                    cmd.Parameters.AddWithValue("@Tipo", (int)alojamneto.Tipo);
                    cmd.Parameters.AddWithValue("@Latitude", alojamneto.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", alojamneto.Longitude);
                    cmd.Parameters.AddWithValue("@PrecoPorNoite", alojamneto.PrecoPorNoite);
                    cmd.Parameters.AddWithValue("@CapacidadeMaxima", alojamneto.CapacidadeMaxima);
                    cmd.Parameters.AddWithValue("@Disponivel", alojamneto.Disponivel);
                    cmd.Parameters.AddWithValue("@Estrelas", alojamneto.Estrelas);
                    cmd.Parameters.AddWithValue("@Photos", alojamneto.Photos);
                    cmd.Parameters.AddWithValue("@Local", alojamneto.Local);
                    cmd.Parameters.AddWithValue("@Comodidades", JsonConvert.SerializeObject(alojamneto.Comodidades));

                    int novoId = Convert.ToInt32(cmd.ExecuteScalar());
                    return novoId;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao adicionar alojamento: {ex.Message}");

                return 0;
            }
        }


        public static bool EditarAlojamento(Alojamento alojamneto)
        {
            Logger logger = new Logger();
            try
            {
                using (var conn = ConexaoBD.GetConexao())
                {
                    conn.Open();
                    string query = @"
                    UPDATE alojamento
                    SET Nome = @Nome, Descricao = @Desc, Tipo = @Tipo, Latitude = @Latitude, Longitude = @Longitude,
                        PrecoPorNoite = @PrecoPorNoite, CapacidadeMaxima = @CapacidadeMaxima, Disponivel = @Disponivel,
                        Estrelas = @Estrelas, Photos = @Photos, Local = @Local, Comodidades = @Comodidades
                    WHERE Id = @Id"
                        ;

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", alojamneto.Id);
                    cmd.Parameters.AddWithValue("@Nome", alojamneto.Nome);
                    cmd.Parameters.AddWithValue("@Desc", alojamneto.Desc);
                    cmd.Parameters.AddWithValue("@Tipo", (int)alojamneto.Tipo);
                    cmd.Parameters.AddWithValue("@Latitude", alojamneto.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", alojamneto.Longitude);
                    cmd.Parameters.AddWithValue("@PrecoPorNoite", alojamneto.PrecoPorNoite);
                    cmd.Parameters.AddWithValue("@CapacidadeMaxima", alojamneto.CapacidadeMaxima);
                    cmd.Parameters.AddWithValue("@Disponivel", alojamneto.Disponivel);
                    cmd.Parameters.AddWithValue("@Estrelas", alojamneto.Estrelas);
                    cmd.Parameters.AddWithValue("@Photos", alojamneto.Photos);
                    cmd.Parameters.AddWithValue("@Local", alojamneto.Local);
                    cmd.Parameters.AddWithValue("@Comodidades", JsonConvert.SerializeObject(alojamneto.Comodidades));

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao editar alojamento com ID :{alojamneto.Id}  {ex.Message}");
                return false;
            }
        }

        public static List<Alojamento> getByFiltros(string valorMin, string valorMax, string selectedTipo, string selectedIComodidades)
        {
            List<Alojamento> alojamentos = new List<Alojamento>();
            Logger logger = new Logger();
            try
            {
                string query = "SELECT * FROM alojamento WHERE 1=1";

                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrWhiteSpace(valorMin))
                {
                    query += " AND PrecoPorNoite >= @valorMin";
                    parameters.Add(new MySqlParameter("@valorMin", Convert.ToDouble(valorMin)));
                }

                if (!string.IsNullOrWhiteSpace(valorMax))
                {
                    query += " AND PrecoPorNoite <= @valorMax";
                    parameters.Add(new MySqlParameter("@valorMax", Convert.ToDouble(valorMax)));
                }

                if (!string.IsNullOrWhiteSpace(selectedTipo))
                {
                    var tipos = selectedTipo.Split(',').Select(tipo => (int)Enum.Parse(typeof(TipoAlojamento), tipo.Trim()));
                    query += $" AND Tipo IN ({string.Join(", ", tipos)})";
                }

                if (!string.IsNullOrWhiteSpace(selectedIComodidades))
                {
                    var comodidades = selectedIComodidades.Split(',').Select(c => c.Trim());
                    foreach (var comodidade in comodidades)
                    {
                        query += " AND JSON_CONTAINS(Comodidades, @comodidade" + comodidade.GetHashCode() + ")";
                        parameters.Add(new MySqlParameter($"@comodidade{comodidade.GetHashCode()}", $"\"{comodidade}\""));
                    }
                }

                using (var conn = ConexaoBD.GetConexao())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var alojamento = new Models.Alojamento
                        {
                            Id = reader.GetInt32("Id"),
                            Nome = reader.GetString("Nome"),
                            Tipo = (TipoAlojamento)reader.GetInt32("Tipo"),
                            Desc = reader.GetString("Descricao"),
                            Latitude = reader.GetString("Latitude"),
                            Longitude = reader.GetString("Longitude"),
                            PrecoPorNoite = reader.GetDouble("PrecoPorNoite"),
                            CapacidadeMaxima = reader.GetInt32("CapacidadeMaxima"),
                            Disponivel = reader.GetBoolean("Disponivel"),
                            Estrelas = reader.GetInt32("Estrelas"),
                            Photos = reader.GetBoolean("Photos"),
                            Local = reader.GetString("Local"),
                        };

                        string comodidadesJson = reader.IsDBNull(reader.GetOrdinal("Comodidades")) ? "[]" : reader.GetString("Comodidades");
                        alojamento.Comodidades = JsonConvert.DeserializeObject<List<string>>(comodidadesJson);

                        alojamentos.Add(alojamento);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao filtrar alojamentos: {ex.Message}");
            }
            return alojamentos;
        }

        public static List<Alojamento> GetAlojamentosPorLocal(string local)
        {
            List<Alojamento> alojamentos = new List<Alojamento>();
            Logger logger = new Logger();

            try
            {
                string query = "SELECT * FROM alojamento WHERE 1=1";

                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrWhiteSpace(local))
                {
                    query += " AND Local LIKE @local";
                    parameters.Add(new MySqlParameter("@local", $"%{local}%"));
                }

               
                using (var conn = ConexaoBD.GetConexao())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var alojamento = new Models.Alojamento
                        {
                            Id = reader.GetInt32("Id"),
                            Nome = reader.GetString("Nome"),
                            Tipo = (TipoAlojamento)reader.GetInt32("Tipo"),
                            Desc = reader.GetString("Descricao"),
                            Latitude = reader.GetString("Latitude"),
                            Longitude = reader.GetString("Longitude"),
                            PrecoPorNoite = reader.GetDouble("PrecoPorNoite"),
                            CapacidadeMaxima = reader.GetInt32("CapacidadeMaxima"),
                            Disponivel = reader.GetBoolean("Disponivel"),
                            Estrelas = reader.GetInt32("Estrelas"),
                            Photos = reader.GetBoolean("Photos"),
                            Local = reader.GetString("Local"),
                        };

                        string comodidadesJson = reader.IsDBNull(reader.GetOrdinal("Comodidades")) ? "[]" : reader.GetString("Comodidades");
                        alojamento.Comodidades = JsonConvert.DeserializeObject<List<string>>(comodidadesJson);

                        alojamentos.Add(alojamento);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao procurar alojamentos: {ex.Message}");
            }

            return alojamentos;
        }
    }
}
