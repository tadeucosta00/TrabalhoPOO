using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ProjetoPo.Models
{
    public class Pessoa : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string DocumentoIdentidade { get; set; }
        public string Senha { get; set; }
        public bool Adm { get; set; }
        public bool Ativo { get; set; }


        public Pessoa(int id, string nome, string email, string telefone, string documentoIdentidade, string senha, bool adm, bool ativo)
            : base(id)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            DocumentoIdentidade = documentoIdentidade;
            Senha = senha;
            Adm = adm;
            Ativo = ativo;
        }

        public Pessoa() { }

     
    }
}
