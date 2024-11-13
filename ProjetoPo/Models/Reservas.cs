using Logs;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPo.Models
{
    public class Reserva : EntidadeBase
    {
        public Pessoa Pessoa { get; set; }
        public Alojamento Alojamento { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public double ValorTotal { get; set; }
        public int Hospedes { get; set; }
        public bool CheckIN { get; set; }
        public Reserva() { }
        public Reserva(int id, Pessoa pessoa, Alojamento alojamento, DateTime dataCheckIn, DateTime dataCheckOut,double valortotal, int hospedes, bool checkIn)
            : base(id)
        {
            Pessoa = pessoa;
            Alojamento = alojamento;
            DataCheckIn = dataCheckIn;
            DataCheckOut = dataCheckOut;
            CheckIN = checkIn;
            Hospedes = hospedes;
            ValorTotal = CalcularValorTotal();
        }

        public static List<Reserva> GetReservasFromDB()
        {
            List<Reserva> reservas = new List<Reserva>();

            try
            {
                string query = @"
                SELECT 
                    r.Id AS ReservaId, 
                    r.DataCheckIn, 
                    r.DataCheckOut, 
                    r.ValorTotal, 
                    r.Hospedes, 
                    r.CheckIN,
                    p.Id AS PessoaId, 
                    p.Nome AS PessoaNome, 
                    p.Email AS PessoaEmail, 
                    p.DocumentoIdentidade AS PessoaDocumentoIdentidade, 
                    a.Id AS AlojamentoId, 
                    a.Nome AS AlojamentoNome, 
                    a.PrecoPorNoite, 
                    a.Comodidades
                FROM reserva r
                INNER JOIN pessoa p ON r.IdCliente = p.Id
                INNER JOIN alojamento a ON r.IdAlojamento = a.Id"; 

                using (var conn = ConexaoBD.GetConexao())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Reserva reserva = new Reserva
                        {
                            Id = reader.GetInt32("ReservaId"),
                            DataCheckIn = reader.GetDateTime("DataCheckIn"),
                            DataCheckOut = reader.GetDateTime("DataCheckOut"),
                            ValorTotal = reader.GetDouble("ValorTotal"),
                            Hospedes = reader.GetInt32("Hospedes"),
                            CheckIN = reader.GetBoolean("CheckIN"),
                            Pessoa = new Pessoa
                            {
                                Id = reader.GetInt32("PessoaId"), 
                                Nome = reader.GetString("PessoaNome"),
                                Email = reader.GetString("PessoaEmail"),
                                DocumentoIdentidade = reader.GetString("PessoaDocumentoIdentidade"),
                            },
                            Alojamento = new Alojamento
                            {
                                Id = reader.GetInt32("AlojamentoId"), 
                                Nome = reader.GetString("AlojamentoNome"),
                                PrecoPorNoite = reader.GetDouble("PrecoPorNoite"),
                            }
                        };

                        string comodidadesJson = reader.IsDBNull(reader.GetOrdinal("Comodidades")) ? "[]" : reader.GetString("Comodidades");
                        reserva.Alojamento.Comodidades = JsonConvert.DeserializeObject<List<string>>(comodidadesJson);

                        reservas.Add(reserva);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.LogError("Erro ao buscar reservas da base de dados: " + ex.Message);
            }

            return reservas;
        }

        public static List<Reserva> GetAllReservasFromDB()
        {
            List<Reserva> reservas = new List<Reserva>();

            try
            {
                string query = @"
                SELECT 
                    r.Id AS ReservaId, 
                    r.DataCheckIn, 
                    r.DataCheckOut, 
                    r.ValorTotal, 
                    r.Hospedes, 
                    r.CheckIN,
                    p.Id AS PessoaId, 
                    p.Nome AS PessoaNome, 
                    a.Id AS AlojamentoId, 
                    a.Nome AS AlojamentoNome, 
                    a.PrecoPorNoite, 
                    a.Comodidades
                FROM reserva r
                INNER JOIN pessoa p ON r.IdCliente = p.Id
                INNER JOIN alojamento a ON r.IdAlojamento = a.Id";

                using (var conn = ConexaoBD.GetConexao())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Reserva reserva = new Reserva
                        {
                            Id = reader.GetInt32("ReservaId"),
                            DataCheckIn = reader.GetDateTime("DataCheckIn"),
                            DataCheckOut = reader.GetDateTime("DataCheckOut"),
                            ValorTotal = reader.GetDouble("ValorTotal"),
                            Hospedes = reader.GetInt32("Hospedes"),
                            CheckIN = reader.GetBoolean("CheckIN"),
                            Pessoa = new Pessoa
                            {
                                Id = reader.GetInt32("PessoaId"),
                                Nome = reader.GetString("PessoaNome"),
                            },
                            Alojamento = new Alojamento
                            {
                                Id = reader.GetInt32("AlojamentoId"),
                                Nome = reader.GetString("AlojamentoNome"),
                                PrecoPorNoite = reader.GetDouble("PrecoPorNoite"),
                            }
                        };

                        string comodidadesJson = reader.IsDBNull(reader.GetOrdinal("Comodidades")) ? "[]" : reader.GetString("Comodidades");
                        reserva.Alojamento.Comodidades = JsonConvert.DeserializeObject<List<string>>(comodidadesJson);

                        reservas.Add(reserva);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.LogError("Erro ao buscar todas as reservas da base de dados: " + ex.Message);
            }

            return reservas;
        }

        public static Reserva GetReservaById(int reservaId)
        {
            Reserva reserva = null;

            try
            {
                string query = @"
                SELECT 
                    r.Id AS ReservaId, 
                    r.DataCheckIn, 
                    r.DataCheckOut, 
                    r.ValorTotal, 
                    r.Hospedes, 
                    r.CheckIN,
                    p.Id AS PessoaId, 
                    p.Nome AS PessoaNome, 
                    p.Email AS PessoaEmail, 
                    p.DocumentoIdentidade AS PessoaDocumentoIdentidade, 
                    a.Id AS AlojamentoId, 
                    a.Nome AS AlojamentoNome, 
                    a.PrecoPorNoite, 
                    a.Comodidades
                FROM reserva r
                INNER JOIN pessoa p ON r.IdCliente = p.Id
                INNER JOIN alojamento a ON r.IdAlojamento = a.Id
                WHERE r.Id = @ReservaId";  

                using (var conn = ConexaoBD.GetConexao())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ReservaId", reservaId); 

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        reserva = new Reserva
                        {
                            Id = reader.GetInt32("ReservaId"),
                            DataCheckIn = reader.GetDateTime("DataCheckIn"),
                            DataCheckOut = reader.GetDateTime("DataCheckOut"),
                            ValorTotal = reader.GetDouble("ValorTotal"),
                            Hospedes = reader.GetInt32("Hospedes"),
                            CheckIN = reader.GetBoolean("CheckIN"),
                            Pessoa = new Pessoa
                            {
                                Id = reader.GetInt32("PessoaId"),
                                Nome = reader.GetString("PessoaNome"),
                                Email = reader.GetString("PessoaEmail"),
                                DocumentoIdentidade = reader.GetString("PessoaDocumentoIdentidade"),
                            },
                            Alojamento = new Alojamento
                            {
                                Id = reader.GetInt32("AlojamentoId"),
                                Nome = reader.GetString("AlojamentoNome"),
                                PrecoPorNoite = reader.GetDouble("PrecoPorNoite"),
                            }
                        };

                        string comodidadesJson = reader.IsDBNull(reader.GetOrdinal("Comodidades")) ? "[]" : reader.GetString("Comodidades");
                        reserva.Alojamento.Comodidades = JsonConvert.DeserializeObject<List<string>>(comodidadesJson);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.LogError("Erro ao buscar reserva pelo ID na base de dados: " + ex.Message);
            }

            return reserva;
        }


        public static void AdcionarReservaNaDB(Reserva novaReserva)
        {
            try
            {
                string query = "INSERT INTO reserva (IdCliente, IdAlojamento, DataCheckIn, DataCheckOut, ValorTotal, Hospedes, CheckIN) " +
                               "VALUES (@IdCliente, @IdAlojamento, @DataCheckIn, @DataCheckOut, @ValorTotal, @Hospedes, @CheckIN)";

                using (var conn = ConexaoBD.GetConexao())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdCliente", novaReserva.Pessoa.Id);
                    cmd.Parameters.AddWithValue("@IdAlojamento", novaReserva.Alojamento.Id);
                    cmd.Parameters.AddWithValue("@DataCheckIn", novaReserva.DataCheckIn);
                    cmd.Parameters.AddWithValue("@DataCheckOut", novaReserva.DataCheckOut);
                    cmd.Parameters.AddWithValue("@ValorTotal", novaReserva.ValorTotal);
                    cmd.Parameters.AddWithValue("@Hospedes", novaReserva.Hospedes);
                    cmd.Parameters.AddWithValue("@CheckIN", novaReserva.CheckIN);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir reserva na base de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void AtualizarReservaNaDB(Reserva reserva)
        {
            try
            {
                string query = @"
                UPDATE reserva 
                SET CheckIN = @CheckIN
                WHERE Id = @ReservaId";

                using (var conn = ConexaoBD.GetConexao())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ReservaId", reserva.Id);
                    cmd.Parameters.AddWithValue("@CheckIN", reserva.CheckIN);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar reserva na base de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public double CalcularValorTotal()
        {
            if (DataCheckOut <= DataCheckIn)
                throw new InvalidOperationException("Data de Check-Out deve ser posterior à Data de Check-In.");

            int numeroDeNoites = (DataCheckOut - DataCheckIn).Days;

            return numeroDeNoites * Alojamento.PrecoPorNoite;
        }
    }
}
