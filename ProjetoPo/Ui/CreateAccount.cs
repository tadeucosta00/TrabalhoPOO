using Logs;
using MySql.Data.MySqlClient;
using ProjetoPo.Controllers;
using ProjetoPo.Models;
using ProjetoPo.Services;
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
            try
            {
                string name = txtNameCreate.Text;
                string email = txtEmailCreate.Text;
                string password = txtPassCreate.Text;
                string phone = txtPhoneCreate.Text;
                string documentId = txtIdCreate.Text;
            
                Pessoa novaPessoa = new Pessoa
                {
                    Nome = name,
                    Email = email,
                    Telefone = phone,
                    DocumentoIdentidade = documentId,
                    Senha = password,
                    Adm = false
                };

                
                PessoaController controller = new PessoaController();
                controller.CriarConta(novaPessoa);

                MessageBox.Show("Conta criada com sucesso!");

                Logger logger = new Logger();
                logger.LogInfo("Conta Criada: " + email);

                Logincs flogin = new Logincs();
                flogin.Show();
                this.Hide();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
