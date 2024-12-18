﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPo.Models
{
    internal class ComodidadesTable
    {
        public static List<Comodidades> GetComodidadesFromDB()
        {
            List<Comodidades> comodidades = new List<Comodidades>();

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

            }

            return comodidades;
        }
    }
}
