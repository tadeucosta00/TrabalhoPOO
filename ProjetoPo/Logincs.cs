using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace ProjetoPo
{
    public partial class Logincs : Form
    {
        public class Pessoa
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
            public string DocumentoIdentidade { get; set; }
            public string Senha { get; set; } 
            public bool Adm { get; set; } 

            public Pessoa() { }

            public Pessoa(int id, string nome, string email, string telefone, string documentoIdentidade, string senha, bool adm)
            {
                Id = id;
                Nome = nome;
                Email = email;
                Telefone = telefone;
                DocumentoIdentidade = documentoIdentidade;
                Senha = senha;
                Adm = adm;
            }
            public void ClearPassword()
            {
                Senha = "";
            }
        }

        public Logincs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmailLogin.Text;
            string password = txtPassLogin.Text;

            byte[] data = Encoding.ASCII.GetBytes(password);
            data = new SHA256Managed().ComputeHash(data);
            string hash = BitConverter.ToString(data).Replace("-", "").ToLower();

            string filePath = @"C:\Users\Pedro\Documents\GitHub\TrabalhoPOO\clientes.json";

            string jsonData = File.ReadAllText(filePath);

            var clients = JsonSerializer.Deserialize<List<Pessoa>>(jsonData);

            var user = clients?.FirstOrDefault(c => c.Email == email);

            if (user != null && user.Senha == hash)
            {
                user.ClearPassword();

                if (user.Adm)
                {
                    FormAdm form1 = new FormAdm();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    FormClients form1 = new FormClients(user);
                    form1.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Email ou senha incorretos.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateAccount fcreateAccount = new CreateAccount();
            fcreateAccount.Show();
            this.Hide();
        }
    }
}
