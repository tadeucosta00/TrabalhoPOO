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
using static IronPython.Modules._ast;

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

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] data = Encoding.ASCII.GetBytes(password);
            data = new SHA256Managed().ComputeHash(data);
            string hash = BitConverter.ToString(data).Replace("-", "").ToLower();

            Pessoa utilizador = ValidarLogin(email, hash);

            if (utilizador != null)
            {
                File.WriteAllText("userId.txt", utilizador.Id.ToString());
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

        private void Logincs_Load(object sender, EventArgs e)
        {
            string userIdFile = "userId.txt";
            if (File.Exists(userIdFile) && new FileInfo(userIdFile).Length > 0)
            {
                string storedUserId = File.ReadAllText(userIdFile);
                Models.Pessoa utilizador = Models.PessoaTable.GetById(Int32.Parse(storedUserId));
                PessoaManager.Instance.AdicionarPessoa(utilizador);
                FormClients form1 = new FormClients();
                form1.Show();
                this.Hide();
            }
        }
    }
}
