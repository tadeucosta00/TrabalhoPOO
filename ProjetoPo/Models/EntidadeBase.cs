using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPo.Models
{
    public class EntidadeBase
    {
        public int Id { get; set; }

        public EntidadeBase() { }

        public EntidadeBase(int id)
        {
            Id = id;
        }
    }
}
