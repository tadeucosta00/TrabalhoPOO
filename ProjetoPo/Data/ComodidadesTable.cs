using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logs;
using Microsoft.Extensions.Logging;


namespace ProjetoPo.Models
{
    internal class ComodidadesTable
    {
        public static List<Comodidades> GetComodidadesFromDB()
        {
            List<Comodidades> comodidades = new List<Comodidades>();
            Logger logger = new Logger();
            try
            {
                string query = @"SELECT * FROM comodidades";

                using (var conn = ConexaoBD.GetConexao())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Comodidades comodidade = new Comodidades
                        {
                            Id = reader.GetInt32("Id"),
                            Nome = reader.GetString("Nome")
                        };
                        comodidades.Add(comodidade);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro ao obter comodidades: {ex.Message}");
            }

            return comodidades;
        }
    }
}
