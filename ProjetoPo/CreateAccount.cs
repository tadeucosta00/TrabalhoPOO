using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetoPo
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logincs flogin = new Logincs();
            flogin.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = txtNameCreate.Text;
            string email = txtEmailCreate.Text;
            string password = txtPassCreate.Text;
            string phone = txtPhoneCreate.Text;
            string documentId = txtIdCreate.Text;

            byte[] data = Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hash = BitConverter.ToString(data).Replace("-", "").ToLower();

            string filePath = @"C:\Users\Pedro\Documents\GitHub\TrabalhoPOO\clientes.json";

            List<Dictionary<string, object>> clients;

            if (File.Exists(filePath))
            {
                string existingData = File.ReadAllText(filePath);
                clients = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(existingData) ?? new List<Dictionary<string, object>>();
            }
            else
            {
                clients = new List<Dictionary<string, object>>();
                File.WriteAllText(filePath, JsonSerializer.Serialize(clients, new JsonSerializerOptions { WriteIndented = true }));

            }

            if (clients.Any(c => c["Email"].ToString() == email))
            {
                MessageBox.Show("Este e-mail já está cadastrado. Por favor, use um e-mail diferente.");
                return; 
            }

            int nextId = clients.Count + 1;

            var newClient = new Dictionary<string, object>
            {
                { "Id", nextId },
                { "Adm", false },
                { "Nome", name },
                { "Email", email },
                { "Telefone", phone },
                { "DocumentoIdentidade", documentId },
                { "Senha", hash }
            };

            clients.Add(newClient);

            string jsonData = JsonSerializer.Serialize(clients, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonData);

            MessageBox.Show("Conta criada com sucesso!");

            Logincs flogin = new Logincs();
            flogin.Show();
            this.Hide();
        }
    }
}
