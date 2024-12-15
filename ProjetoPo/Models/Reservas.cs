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
        public bool Ativo { get; set; }

        public Reserva() { }
        public Reserva(int id, Pessoa pessoa, Alojamento alojamento, DateTime dataCheckIn, DateTime dataCheckOut,double valortotal, int hospedes, bool checkIn, bool ativo)
            : base(id)
        {
            Pessoa = pessoa;
            Alojamento = alojamento;
            DataCheckIn = dataCheckIn;
            DataCheckOut = dataCheckOut;
            CheckIN = checkIn;
            Hospedes = hospedes;
            ValorTotal = valortotal;
            Ativo = ativo;
        }
    }
}
