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
    }
}
