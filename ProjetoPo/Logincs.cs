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

namespace ProjetoPo
{
    public partial class Logincs : Form
    {
        public Logincs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();

            string email = txtEmailLogin.Text;
            string password = txtPassLogin.Text;


            byte[] data = Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hash = BitConverter.ToString(data).Replace("-", "").ToLower();

            string filePath = @"c:\Users\tadeu\Desktop\POO\ProjetoPo\clientes.json";

            string jsonData = File.ReadAllText(filePath);

            var clients = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonData);

            var user = clients?.FirstOrDefault(c => c["Email"].ToString() == email);

            if (user != null && user["Senha"].ToString() == hash)
            {
                if (user["Adm"] != "false")
                {
                    //Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
                else
                {

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
