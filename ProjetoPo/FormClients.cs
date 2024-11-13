using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjetoPo.Form1;
using static ProjetoPo.FormAdm;
using ProjetoPo.Models;
using static ProjetoPo.FormClients;
using static ProjetoPo.Logincs;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic.ApplicationServices;
using Logs;
using MySql.Data.MySqlClient;
using System.Diagnostics;


namespace ProjetoPo
{
    public partial class FormClients : Form
    {


        public FormClients()
        {
            InitializeComponent();
            Models.Pessoa usuarioAtual = PessoaManager.Instance.ObterUtilziadorLogado();
            LoadAlojamentos();
            LoadComodidades();

            comboBox1.Items.Clear();
            if (usuarioAtual.Adm == true)
            {
                label18.Visible = true;
            }

            for (int i = 1; i <= 5; i++)
            {
                comboBox1.Items.Add(i);
            }
        }

        private void LoadComodidades()
        {

            /*List<Models.Comodidades> comodidades = Models.Comodidades.GetComodidadesFromDB();
            if (comodidades != null && comodidades.Count > 0)
            {
                foreach (var comodidade in comodidades)
                {
                }
            }*/
        }

        private string GetStars(int estrelas)
        {
            string starFilled = "★";
            string starEmpty = "☆";

            return new string(starFilled[0], estrelas) + new string(starEmpty[0], 5 - estrelas);
        }

        private void LoadAlojamentos()
        {
            try
            {
                List<Models.Alojamento> alojamentos = Models.Alojamento.GetAlojamentosFromDB();
                if (alojamentos != null && alojamentos.Count > 0)
                {
                    panel1.Controls.Clear();

                    foreach (var alojamento in alojamentos)
                    {
                        Listitem item = new Listitem
                        {
                            Titulo = alojamento.Nome,
                            Descricao = alojamento.Desc,
                            Estrelas = GetStars(alojamento.Estrelas),
                            Preco = $"€{alojamento.PrecoPorNoite:F2}€",
                            Imagem = GetImageFromPath(alojamento),
                            Tag = alojamento,
                            Local = alojamento.Local
                        };

                        item.Width = panel1.Width;
                        item.Dock = DockStyle.Top;

                        item.Controls.OfType<PictureBox>().FirstOrDefault().SizeMode = PictureBoxSizeMode.Zoom;

                        item.Click += ListItem_Click;
                        foreach (Control control in item.Controls)
                        {
                            control.Click += (s, e) => ListItem_Click(item, e);
                        }

                        panel1.Controls.Add(item);

                        var spacer = new Panel
                        {
                            Height = 10,
                            Dock = DockStyle.Top
                        };
                        panel1.Controls.Add(spacer);
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum alojamento encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReservas()
        {
            Models.Pessoa usuarioAtual = PessoaManager.Instance.ObterUtilziadorLogado();

            try
            {
                List<Models.Reserva> reservas = Models.Reserva.GetReservasFromDB();

                if (reservas != null && reservas.Count > 0)
                {
                    panel5.Controls.Clear();

                    foreach (var reserva in reservas)
                    {
                        if (reserva.Pessoa.Id == usuarioAtual.Id)
                        {
                            string checkInStatus = "none";
                            Color buttonColor = Color.Transparent;

                            if (reserva.CheckIN == false)
                            {
                                checkInStatus = "Check-In não efetuado!";
                                buttonColor = ColorTranslator.FromHtml("#800000");
                            }
                            else
                            {
                                checkInStatus = "Check-In efetuado!";
                                buttonColor = ColorTranslator.FromHtml("#008000");
                            }

                            ListviewCheckIn item = new ListviewCheckIn
                            {
                                Titulo = reserva.Alojamento.Nome,
                                Preco = reserva.ValorTotal.ToString("0.00") + "€",
                                Estrelas = GetStars(reserva.Alojamento.Estrelas),
                                Descricao = "Entrada: " + reserva.DataCheckIn.ToString("dd/MM/yyyy") + "\nSaída: " + reserva.DataCheckOut.ToString("dd/MM/yyyy"),
                                Imagem = GetImageFromPath(reserva.Alojamento),
                                ChekcIn = checkInStatus,
                                Button = "Check-In",
                                Tag = reserva,
                                CheckinColor = buttonColor,
                                Hospedes = reserva.Hospedes + " Pessoas",
                                ButtonFatura = "Fatura"
                            };

                            item.Width = panel5.Width;
                            item.Dock = DockStyle.Top;
                            item.Controls.OfType<PictureBox>().FirstOrDefault().SizeMode = PictureBoxSizeMode.Zoom;

                            item.Controls.OfType<System.Windows.Forms.Button>().FirstOrDefault().Click += (s, e) =>
                            {
                                if (reserva != null)
                                {
                                    fatura(reserva);
                                }
                            };

                            item.Controls.OfType<System.Windows.Forms.Button>().LastOrDefault().Click += (s, e) =>
                            {
                                if (reserva != null)
                                {
                                    checkIn(reserva);
                                }
                            };

                            panel5.Controls.Add(item);

                            var spacer = new Panel
                            {
                                Height = 10,
                                Dock = DockStyle.Top
                            };
                            panel5.Controls.Add(spacer);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nenhuma reserva encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void fatura(Models.Reserva reserva)
        {
            var fatura = new FaturaPDF();

            string clienteNome = reserva.Pessoa.Nome;
            string clienteEmail = reserva.Pessoa.Email;
            string clienteDocumentoId = reserva.Pessoa.DocumentoIdentidade;



            double imposto = reserva.ValorTotal * 0.24;
            double simposto = reserva.ValorTotal - imposto;
            var itens = new List<ItemFatura>
            {
                new ItemFatura { Descricao = reserva.Alojamento.Nome, Quantidade = reserva.Hospedes, PrecoUnitario =  simposto},
            };


            fatura.GerarFatura(@"C:\Users\tadeu\Desktop\faturas\faturaAlojamento_" + reserva.Id + ".pdf", clienteNome, clienteEmail, itens, imposto, reserva.ValorTotal, clienteDocumentoId);
            MessageBox.Show($"Fatura gerada para ID da reserva: {reserva.Id}", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Logger logger = new Logger();
            logger.LogInfo("Fatura ReservaId: " + reserva.Id + " UserId: " + reserva.Pessoa.Id);
        }


        private void checkIn(Models.Reserva reserva)
        {
            try
            {
                if (reserva.CheckIN)
                {
                    MessageBox.Show("Check-In já realizado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reserva.CheckIN = true;

                Models.Reserva.AtualizarReservaNaDB(reserva);

                MessageBox.Show("Check-In realizado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Logger logger = new Logger();
                logger.LogInfo($"Check-In realizado para a ReservaId: {reserva.Id} - UserId: {reserva.Pessoa.Id}");

                LoadReservas();
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show($"Erro ao aceder a bd: {sqlEx.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ListItem_Click(object sender, EventArgs e)
        {
            if (sender is Listitem item && item.Tag is Models.Alojamento alojamento)
            {
                panel4.Visible = false;
                panel3.Visible = true;
                label1.Visible = false;

                pictureBox1.Image = GetImageFromPath(alojamento);
                label2.Text = alojamento.Nome;
                label3.Text = GetStars(alojamento.Estrelas);
                label4.Text = alojamento.Desc;
                textBox3.Text = alojamento.Id.ToString();


                label7.Text = $"€{alojamento.PrecoPorNoite:F2}";
                webView21.Source = new Uri("https://www.openstreetmap.org/?mlat=" + alojamento.Latitude + "&mlon=" + alojamento.Longitude + "#map=19");

                flowLayoutPanel1.Controls.Clear();

                foreach (var comodidade in alojamento.Comodidades)
                {
                    var panelComodidade = new Panel();
                    panelComodidade.AutoSize = true;
                    panelComodidade.Margin = new Padding(10);
                    panelComodidade.Padding = new Padding(3);

                    PictureBox pictureBoxIcon = new PictureBox();
                    pictureBoxIcon.Size = new Size(16, 16);
                    pictureBoxIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxIcon.Image = GetIconForComodidade(comodidade);
                    pictureBoxIcon.Margin = new Padding(0, 0, 5, 0);

                    panelComodidade.Controls.Add(pictureBoxIcon);

                    Label labelComodidade = new Label();
                    labelComodidade.ForeColor = ColorTranslator.FromHtml("#20924d");
                    labelComodidade.Text = comodidade;
                    labelComodidade.Margin = new Padding(0);
                    labelComodidade.AutoSize = true;
                    labelComodidade.Padding = new Padding(30, 0, 0, 0);


                    panelComodidade.Controls.Add(labelComodidade);

                    flowLayoutPanel1.Controls.Add(panelComodidade);
                }

            }
        }

        private static readonly Dictionary<string, string> IconPaths = new Dictionary<string, string>
        {
            { "Piscina", "Piscina.png" },
            { "Ginasio", "Ginasio.png" },
            { "Estacionamento", "Estacionamento.png" },
            { "Wi-Fi gratuito", "WiFi.png" },
            { "Lavanderia", "Lavanderia.png" },
            { "Spa", "Spa.png" }
        };

        private System.Drawing.Image GetIconForComodidade(string comodidade)
        {
            string iconPath = @"C:\Users\tadeu\Documents\GitHub\TrabalhoPOO\icons";

            if (IconPaths.TryGetValue(comodidade, out string iconFile))
            {
                string fullPath = Path.Combine(iconPath, iconFile);
                if (File.Exists(fullPath))
                {
                    return System.Drawing.Image.FromFile(fullPath);
                }
            }

            return null;
        }



        private System.Drawing.Image GetImageFromPath(Models.Alojamento alojamento)
        {
            string imagePath = $@"C:\Users\tadeu\Documents\GitHub\TrabalhoPOO\uploads\{alojamento.Id}\download.jpg";

            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                return System.Drawing.Image.FromFile(imagePath);
            }
            else
            {
                MessageBox.Show($"Imagem não encontrada em: {imagePath}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return null;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            label1.Visible = true;
            label1.Text = "Alojamentos";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Models.Pessoa usuarioAtual = PessoaManager.Instance.ObterUtilziadorLogado();

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Por favor, preencha o número de hóspedes.");
                return;
            }

            int idCliente = usuarioAtual.Id;

            int idAlojamento = int.Parse(textBox3.Text);
            DateTime dataCheckIn = DateTime.Parse(dateTimePicker1.Text);
            DateTime dataCheckOut = DateTime.Parse(dateTimePicker2.Text);

            string hospedesSelecionado = comboBox1.Text;
            int hospedes = int.Parse(hospedesSelecionado);

            TimeSpan diferenca = dataCheckOut - dataCheckIn;
            int numeroDeDias = diferenca.Days;

            if (numeroDeDias <= 0)
            {
                MessageBox.Show("A data de Check-Out deve ser posterior à data de Check-In.");
                return;
            }

            Models.Alojamento alojamento = Models.Alojamento.GetAlojamentoById(idAlojamento);

            if (alojamento == null)
            {
                MessageBox.Show("Alojamento não encontrado.");
                return;
            }

            double valorTotal = alojamento.PrecoPorNoite * numeroDeDias;

            Models.Reserva novaReserva = new Models.Reserva
            {
                Pessoa = usuarioAtual,
                Alojamento = alojamento,
                DataCheckIn = dataCheckIn,
                DataCheckOut = dataCheckOut,
                Hospedes = hospedes,
                ValorTotal = valorTotal,
                CheckIN = false,
            };

            try
            {
                novaReserva.ValorTotal = novaReserva.CalcularValorTotal();

                DialogResult dr = MessageBox.Show("Confirmar Reserva?", "Deseja confirmar a reserva?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    Models.Reserva.AdcionarReservaNaDB(novaReserva);

                    MessageBox.Show("Reserva efetuada com sucesso.");
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            label1.Visible = true;
            label1.Text = "Minhas Reservas";
            LoadReservas();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Models.Pessoa usuarioAtual = PessoaManager.Instance.ObterUtilziadorLogado();
            if (usuarioAtual.Adm == true)
            {
                FormAdm form1 = new FormAdm();
                form1.Show();
                this.Hide();
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            Models.Pessoa usuarioAtual = PessoaManager.Instance.ObterUtilziadorLogado();

            string scriptPath = @"C:\Users\tadeu\Desktop\te\script.py";
            string pythonPath = @"C:\Users\tadeu\AppData\Local\Microsoft\WindowsApps\python.exe";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = pythonPath,
                Arguments = $"\"{scriptPath}\" {usuarioAtual.Id}\"",
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

                    if (result.Trim().Contains("Captura concluída"))
                    {
                        MessageBox.Show("Rosto Validado.");

                        /*if (usuario != null)
                        {
                            PessoaManager.Instance.AdicionarPessoa(usuario);
                        }
                        FormClients form1 = new FormClients();
                        form1.Show();
                        this.Hide();*/
                    }
                    else
                    {
                        MessageBox.Show("Pessoa não reconhecida.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar o script: " + ex.Message);
            }
        }
    }
}
