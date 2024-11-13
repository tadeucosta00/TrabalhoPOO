using Microsoft.Extensions.Logging;
using ProjetoPo.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Logs;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Policy;

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
            Logger logger = new Logger();
            string email = txtEmailLogin.Text;
            string password = txtPassLogin.Text;

            byte[] data = Encoding.ASCII.GetBytes(password);
            data = new SHA256Managed().ComputeHash(data);
            string hash = BitConverter.ToString(data).Replace("-", "").ToLower();

            Pessoa usuario = ValidarLogin(email, hash);

            if (usuario != null)
            {
                PessoaManager.Instance.AdicionarPessoa(usuario);

                FormClients form1 = new FormClients();
                logger.LogInfo("Login bem-sucedido para o Usuário ID: " + usuario.Id);

                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Email ou senha incorretos.");
                logger.LogError("Erro de login: " + email);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateAccount fcreateAccount = new CreateAccount();
            fcreateAccount.Show();
            this.Hide();
        }

        private Pessoa ValidarLogin(string email, string senhaHash)
        {
            string query = "SELECT * FROM Pessoa WHERE Email = @Email AND Senha = @Senha";

            using (MySqlConnection conn = ConexaoBD.GetConexao())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Senha", senhaHash);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Pessoa
                    {
                        Id = reader.GetInt32("Id"),
                        Nome = reader.GetString("Nome"),
                        Email = reader.GetString("Email"),
                        Telefone = reader.GetString("Telefone"),
                        DocumentoIdentidade = reader.GetString("DocumentoIdentidade"),
                        Senha = reader.GetString("Senha"),
                        Adm = reader.GetBoolean("Adm")
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            string scriptPath = @"C:\Users\tadeu\Desktop\te\verify.py";
            string pythonPath = @"C:\Users\tadeu\AppData\Local\Microsoft\WindowsApps\python.exe";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = pythonPath,
                Arguments = $"\"{scriptPath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();

                    string result = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show("Erro ao executar o script Python: " + error);
                        return;
                    }

                    if (int.TryParse(result.Trim(), out int userId))
                    {
                        panel3.Visible = false;

                        Pessoa usuario = Pessoa.GetById(userId);

                        if (usuario != null)
                        {
                            PessoaManager.Instance.AdicionarPessoa(usuario);
                        }

                        FormClients form1 = new FormClients();
                        form1.Show();
                        this.Hide();
                    }
                    else
                    {
                        panel3.Visible = false;
                        MessageBox.Show("Pessoa não reconhecida.");
                    }
                }
            }
            catch (Exception ex)
            {
                panel3.Visible = false;
                MessageBox.Show("Erro ao executar o script: " + ex.Message);
            }
        }



    }
}
