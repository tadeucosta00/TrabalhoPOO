using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Logs;
using System;
using System.Collections.Generic;

namespace ProjetoPo.Models
{
    internal class ReservasTable
    {
        public static List<Reserva> GetAllReservasFromDB()
        {
            Logger logger = new Logger();
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
                    r.Ativo,
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
                            Ativo = reader.GetBoolean("Ativo"),
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
                logger.LogError($"Erro ao obter todas as reservas: {ex.Message}");
                throw;
            }

            return reservas;
        }

        public static Reserva GetReservaById(int reservaId)
        {
            Logger logger = new Logger();
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
                    r.Ativo,
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
                            Ativo = reader.GetBoolean("Ativo"),
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
                logger.LogError($"Erro ao obter reserva com ID {reservaId}: {ex.Message}");
                throw;
            }

            return reserva;
        }

        public static List<Reserva> GetReservaByUserId(int userId)
        {
            Logger logger = new Logger();
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
                    r.Ativo,
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
                WHERE p.Id = @UserId";

                using (var conn = ConexaoBD.GetConexao())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);

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
                            Ativo = reader.GetBoolean("Ativo"),
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
                logger.LogError($"Erro ao obter reservas para o usuário com ID {userId}: {ex.Message}");
                throw;
            }

            return reservas;
        }

        public static void AdcionarReservaNaDB(Reserva novaReserva)
        {
            Logger logger = new Logger();

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
                logger.LogError($"Erro ao adicionar reserva: {ex.Message}");
                throw;
            }
        }

        public static void AtualizarReservaNaDB(Reserva reserva)
        {
            Logger logger = new Logger();

            try
            {
                string query = @"
                UPDATE reserva 
                SET 
                    DataCheckIn = @DataCheckIn,
                    DataCheckOut = @DataCheckOut,
                    ValorTotal = @ValorTotal,
                    Hospedes = @Hospedes,
                    CheckIN = @CheckIN,
                    Ativo = @Ativo,
                    IdCliente = @IdCliente
                WHERE Id = @ReservaId";

                using (var conn = ConexaoBD.GetConexao())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ReservaId", reserva.Id);
                    cmd.Parameters.AddWithValue("@DataCheckIn", reserva.DataCheckIn);
                    cmd.Parameters.AddWithValue("@DataCheckOut", reserva.DataCheckOut);
                    cmd.Parameters.AddWithValue("@ValorTotal", reserva.ValorTotal);
                    cmd.Parameters.AddWithValue("@Hospedes", reserva.Hospedes);
                    cmd.Parameters.AddWithValue("@CheckIN", reserva.CheckIN);
                    cmd.Parameters.AddWithValue("@Ativo", reserva.Ativo);
                    cmd.Parameters.AddWithValue("@IdCliente", reserva.Pessoa.Id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao atualizar reserva com ID {reserva.Id}: {ex.Message}");
                throw;
            }
        }

        public static void CheckInReservaNaDB(Reserva reserva)
        {
            Logger logger = new Logger();

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
                logger.LogError($"Erro ao realizar check-in para a reserva com ID {reserva.Id}: {ex.Message}");
                throw;
            }
        }
        public static double CalcularValorTotal(Reserva reserva)
        {
            if (reserva.DataCheckOut <= reserva.DataCheckIn)
                throw new InvalidOperationException("Data de Check-Out deve ser posterior à Data de Check-In.");


            Alojamento alojamento = AlojamentosTable.GetAlojamentoById(reserva.Alojamento.Id);

            if (alojamento == null)
                throw new InvalidOperationException("Alojamento não encontrado.");

            int numeroDeNoites = (reserva.DataCheckOut - reserva.DataCheckIn).Days;

            return numeroDeNoites * alojamento.PrecoPorNoite;
        }
    }
}
