using Logs;
using Microsoft.Extensions.Logging;
using ProjetoPo.Controllers;
using ProjetoPo.Models;
using ProjetoPo.Services;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ProjetoPo
{
    public partial class Logincs : Form
    {
        private readonly Logger logger;
        public Logincs()
        {
            InitializeComponent();
            logger = new Logger();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmailLogin.Text;
            string password = txtPassLogin.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string senhaHash = Utils.HashHelper.GerarHashSHA256(password);

            try
            {

                PessoaController controller = new PessoaController();
                Pessoa utilizador = controller.ValidarLogin(email, senhaHash);

                if (utilizador != null)
                {
                    File.WriteAllText("userId.txt", utilizador.Id.ToString());
                    PessoaManager.Instance.AdicionarPessoa(utilizador);

                    FormClients form1 = new FormClients();
                    logger.LogInfo($"Login bem-sucedido para o Utilizador ID: {utilizador.Id}");

                    form1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Email ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.LogError($"Erro de login para o email: {email}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.LogError($"Erro durante login: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateAccount fcreateAccount = new CreateAccount();
            fcreateAccount.Show();
            this.Hide();
        }

        private void Logincs_Load(object sender, EventArgs e)
        {
            string userIdFile = "userId.txt";

            if (File.Exists(userIdFile) && new FileInfo(userIdFile).Length > 0)
            {
                string storedUserId = File.ReadAllText(userIdFile);
                Pessoa utilizador = PessoaTable.GetById(int.Parse(storedUserId));

                if (utilizador != null)
                {
                    logger.LogInfo($"Login bem-sucedido para o Utilizador ID: {utilizador.Id}");
                    PessoaManager.Instance.AdicionarPessoa(utilizador);
                    FormClients form1 = new FormClients();
                    form1.Show();
                    this.Hide();
                }
            }
        }
      
    }
}
