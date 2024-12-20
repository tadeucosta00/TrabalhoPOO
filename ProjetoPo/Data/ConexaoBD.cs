using Logs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ProjetoPo.Models
{
    public class ConexaoBD
    {
        private static readonly string _connectionString = "Server=localhost;Database=alojamentos;User ID=root;Password=;";

        public static MySqlConnection GetConexao()
        {
            Logger logger = new Logger();
            try
            {
                return new MySqlConnection(_connectionString);
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao criar conexão: {ex.Message}");
                throw;
            }
        }

        public static void ExecuteCommand(string query)
        {
            using (var conn = GetConexao())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Logger logger = new Logger();
                    logger.LogError("Conexão a BD");
                }
            }
        }
    }
}
