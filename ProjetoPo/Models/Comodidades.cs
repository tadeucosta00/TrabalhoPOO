using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPo.Models
{
    public class Comodidades : EntidadeBase {
        public String Nome { get; set; }
     
        public Comodidades() { }

        public Comodidades(int id, string nome)
            : base(id)
        {
            Nome = nome;
        }
    }
}
