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
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Microsoft.VisualBasic.ApplicationServices;
using static Community.CsharpSqlite.Sqlite3;

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

            Pessoa utilizador = ValidarLogin(email, hash);

            if (utilizador != null)
            {
                PessoaManager.Instance.AdicionarPessoa(utilizador);

                FormClients form1 = new FormClients();
                logger.LogInfo("Login bem-sucedido para o Usuário ID: " + utilizador.Id);

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
            string pythonPath = @"C:\Users\tadeu\AppData\Local\Microsoft\WindowsApps\python.exe";  
            string scriptPath = @"C:\Users\tadeu\Desktop\te\verify.py";  

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = pythonPath,
                Arguments = scriptPath,  
                RedirectStandardOutput = true,  
                RedirectStandardError = true,  
                UseShellExecute = false,  
                CreateNoWindow = true
            };

            try
            {
                using (Process process = Process.Start(startInfo))
                {
                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (e.Data != null)
                        {
                            MessageBox.Show(e.Data);
                            Console.WriteLine("Output: " + e.Data);  
                        }
                    };

                    // Lê erros do script Python (se houver)
                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if (e.Data != null)
                        {
                            Console.WriteLine("Error: " + e.Data);  
                        }
                    };

                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao executar o script Python: " + ex.Message);
            }
        
        }


    }
}
