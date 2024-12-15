using Logs;
using MySql.Data.MySqlClient;
using ProjetoPo.Models;
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
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(documentId))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            byte[] data = Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hash = BitConverter.ToString(data).Replace("-", "").ToLower();

            if (PessoaTable.EmailJaExistente(email))
            {
                MessageBox.Show("Este e-mail já está em uso. Por favor, utilize um e-mail diferente.");
                return;
            }

            Pessoa novaPessoa = new Pessoa
            {
                Nome = name,
                Email = email,
                Telefone = phone,
                DocumentoIdentidade = documentId,
                Senha = hash,
                Adm = false
            };

            try
            {
                PessoaTable.Salvar(novaPessoa);

                MessageBox.Show("Conta criada com sucesso!");

                Logger logger = new Logger();
                logger.LogInfo("Conta Criada: " + email);

                Logincs flogin = new Logincs();
                flogin.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar conta: " + ex.Message);
            }
        }

        private void txtPhoneCreate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtIdCreate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
