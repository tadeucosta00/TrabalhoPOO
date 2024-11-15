using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPo.Models
{
    using Logs;
    using MySql.Data.MySqlClient;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using static ProjetoPo.Form1;


    public enum TipoAlojamento
    {
        Hotel = 1,
        Hostel = 2,
        Apartamento = 3,
        Casa = 4,
        Resort = 5
    }
    public class Alojamento : EntidadeBase
    {
        public string Nome { get; set; }
        public TipoAlojamento Tipo { get; set; }
        public string Desc { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public double PrecoPorNoite { get; set; }
        public int CapacidadeMaxima { get; set; }
        public bool Disponivel { get; set; }
        public int Estrelas { get; set; }
        public bool Photos { get; set; }
        public List<string> Comodidades { get; set; }
        public string Local { get; set; }

        public Alojamento()
        {
            Comodidades = new List<string>();
        }

        public Alojamento(int id, string nome, string local, TipoAlojamento tipo, string desc, string latitude, string longitude, double precoPorNoite, int capacidadeMaxima, bool disponivel, int estrelas, bool photos, List<string> comodidades)
            : base(id)
        {
            Nome = nome;
            Tipo = tipo;
            Local = local;
            Desc = desc;
            Latitude = latitude;
            Longitude = longitude;
            PrecoPorNoite = precoPorNoite;
            CapacidadeMaxima = capacidadeMaxima;
            Disponivel = disponivel;
            Estrelas = estrelas;
            Photos = photos;
            Comodidades = comodidades;
        }

        public static List<Alojamento> GetAlojamentosFromDB()
        {
            List<Alojamento> alojamentos = new List<Alojamento>();

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
                Logger logger = new Logger();
                logger.LogError("Erro ao buscar alojamentos da base de dados: " + ex.Message);
            }

            return alojamentos;
        }

        public static Alojamento GetAlojamentoById(int idAlojamento)
        {
            Alojamento alojamento = null;
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
                MessageBox.Show($"Erro ao pesquisar alojamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return alojamento;
        }

        public int AdicionarAlojamento()
        {
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
                    cmd.Parameters.AddWithValue("@Nome", Nome);
                    cmd.Parameters.AddWithValue("@Desc", Desc);
                    cmd.Parameters.AddWithValue("@Tipo", (int)Tipo);
                    cmd.Parameters.AddWithValue("@Latitude", Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", Longitude);
                    cmd.Parameters.AddWithValue("@PrecoPorNoite", PrecoPorNoite);
                    cmd.Parameters.AddWithValue("@CapacidadeMaxima", CapacidadeMaxima);
                    cmd.Parameters.AddWithValue("@Disponivel", Disponivel);
                    cmd.Parameters.AddWithValue("@Estrelas", Estrelas);
                    cmd.Parameters.AddWithValue("@Photos", Photos);
                    cmd.Parameters.AddWithValue("@Local", Local);
                    cmd.Parameters.AddWithValue("@Comodidades", JsonConvert.SerializeObject(Comodidades));

                    int novoId = Convert.ToInt32(cmd.ExecuteScalar());
                    return novoId; 
                }
            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.LogError("Erro ao adicionar alojamento: " + ex.Message);
                return 0; 
            }
        }


        public bool EditarAlojamento()
        {
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
                WHERE Id = @Id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Nome", Nome);
                    cmd.Parameters.AddWithValue("@Desc", Desc);
                    cmd.Parameters.AddWithValue("@Tipo", (int)Tipo);
                    cmd.Parameters.AddWithValue("@Latitude", Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", Longitude);
                    cmd.Parameters.AddWithValue("@PrecoPorNoite", PrecoPorNoite);
                    cmd.Parameters.AddWithValue("@CapacidadeMaxima", CapacidadeMaxima);
                    cmd.Parameters.AddWithValue("@Disponivel", Disponivel);
                    cmd.Parameters.AddWithValue("@Estrelas", Estrelas);
                    cmd.Parameters.AddWithValue("@Photos", Photos);
                    cmd.Parameters.AddWithValue("@Local", Local);
                    cmd.Parameters.AddWithValue("@Comodidades", JsonConvert.SerializeObject(Comodidades));

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.LogError("Erro ao editar alojamento: " + ex.Message);
                return false;
            }
        }
    }
}
