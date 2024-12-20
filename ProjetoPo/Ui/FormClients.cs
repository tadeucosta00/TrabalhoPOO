using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjetoPo.FormAdm;
using ProjetoPo.Models;
using static ProjetoPo.FormClients;
using static ProjetoPo.Logincs;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic.ApplicationServices;
using Logs;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Diagnostics;
using Mono.Unix.Native;
using static IronPython.Modules._ast;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using ProjetoPo.Services;
using ProjetoPo.Controllers;


namespace ProjetoPo
{
    public partial class FormClients : Form
    {


        public FormClients()
        {
            InitializeComponent();
            Models.Pessoa utilizadorAtual = PessoaManager.Instance.ObterUtilziadorLogado();
            LoadAlojamentos();

            comboBox1.Items.Clear();
            if (utilizadorAtual.Adm == true)
            {
                label18.Visible = true;
            }

            for (int i = 1; i <= 5; i++)
            {
                comboBox1.Items.Add(i);
            }

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
                AlojamentoController controller = new AlojamentoController();
                List<Alojamento> alojamentos = controller.GetAlojamentosDisponiveis();


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
                            Local = "   "+alojamento.Local
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
                    

                    panel1.VerticalScroll.Value = Math.Min(panel1.VerticalScroll.Maximum, 0);


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
            Models.Pessoa utilizadorAtual = PessoaManager.Instance.ObterUtilziadorLogado();

            try
            {

                ReservasController controller = new ReservasController();
                List<Reserva> reservas = controller.GetReservasByUserId(utilizadorAtual.Id);



                if (reservas != null && reservas.Count > 0)
                {
                    panel5.Controls.Clear();

                    foreach (var reserva in reservas)
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
                ReservasController controller = new ReservasController();
                controller.CheckIn(reserva);

                MessageBox.Show("Check-In realizado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Logger logger = new Logger();
                logger.LogInfo($"Check-In realizado para a ReservaId: {reserva.Id} - UserId: {reserva.Pessoa.Id}");

                LoadReservas();
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
                panel6.Visible = false;


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
            { "Wi-Fi", "WiFi.png" },
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
            string pastaDestino = $@"C:\Users\tadeu\Documents\GitHub\TrabalhoPOO\uploads\{alojamento.Id}";

            if (Directory.Exists(pastaDestino))
            {
                try
                {
                    string[] arquivosImagem = Directory.GetFiles(pastaDestino, $"{alojamento.Id}.*")
                        .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                        .ToArray();

                    if (arquivosImagem.Length > 0)
                    {
                        return System.Drawing.Image.FromFile(arquivosImagem[0]);
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma imagem encontrada na pasta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar a imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Pasta não encontrada: {pastaDestino}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return null;
        }


        private void label5_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel8.Visible = true;
            label33.Visible = true;
            label33.Text = "Alojamentos";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Models.Pessoa utilizadorAtual = PessoaManager.Instance.ObterUtilziadorLogado();

            int idAlojamento = int.Parse(textBox3.Text);
            AlojamentoController controllerAlojamento = new AlojamentoController();
            Alojamento alojamento = controllerAlojamento.GetAlojamentoById(idAlojamento);

            if (alojamento == null)
            {
                MessageBox.Show("Alojamento não encontrado.");
                return;
            }

            DateTime dataCheckIn = DateTime.Parse(dateTimePicker1.Text);
            DateTime dataCheckOut = DateTime.Parse(dateTimePicker2.Text);
            int hospedes = 0;
            string hospedesSelecionado = comboBox1.Text;
            if (!string.IsNullOrEmpty(hospedesSelecionado))
            {
                 hospedes = int.Parse(hospedesSelecionado);

            }

            Reserva novaReserva = new Reserva
            {
                Pessoa = utilizadorAtual,
                Alojamento = alojamento,
                DataCheckIn = dataCheckIn,
                DataCheckOut = dataCheckOut,
                Hospedes = hospedes,
                ValorTotal = 0,
                CheckIN = false,
            };


            DialogResult dr = MessageBox.Show("Confirmar Reserva?", "Deseja confirmar a reserva?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            try
            {
                if (dr == DialogResult.Yes)
                {
                    ReservasController controllerReservas = new ReservasController();
                    controllerReservas.CriarReserva(novaReserva);
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void label6_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
            panel8.Visible = false;
            panel8.Visible = false;
            label33.Visible = true;
            label33.Text = "Minhas Reservas";
            LoadReservas();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Models.Pessoa utilizadorAtual = PessoaManager.Instance.ObterUtilziadorLogado();
            if (utilizadorAtual.Adm == true)
            {
                FormAdm form1 = new FormAdm();
                form1.Show();
                this.Hide();
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;

            Models.Pessoa utilizadorAtual = PessoaManager.Instance.ObterUtilziadorLogado();

            textBox4.Text = utilizadorAtual.Id.ToString();
            textBox5.Text = utilizadorAtual.Nome.ToString();
            textBox6.Text = utilizadorAtual.Email.ToString();
            textBox7.Text = utilizadorAtual.Telefone.ToString();
            textBox8.Text = utilizadorAtual.DocumentoIdentidade.ToString();

            string folderPath = @"C:\Users\tadeu\Documents\GitHub\TrabalhoPOO\usersProfilePhotos\" + utilizadorAtual.Id.ToString();

            if (Directory.Exists(folderPath))
            {
                string[] imageExtensions = { ".jpg", ".jpeg", ".png" };

                var imageFiles = Directory.GetFiles(folderPath)
                                           .Where(file => imageExtensions.Contains(Path.GetExtension(file).ToLower()))
                                           .ToList();

                if (imageFiles.Count > 0)
                {
                    pictureBox3.ImageLocation = imageFiles[0];
                }
                else
                {
                    MessageBox.Show("Nenhuma imagem foi encontrada na pasta.");
                }
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string valorMin;
            string valorMax;

            valorMin = textBox1.Text;
            valorMax = textBox2.Text;

            string selectedTipo = string.Join(", ", checkedListBox1.CheckedItems.Cast<string>());
            string selectedIComodidades = string.Join(", ", checkedListBox2.CheckedItems.Cast<string>());

            AlojamentoController controller = new AlojamentoController();
            List<Alojamento> resultados = controller.FiltrarAlojamentos(valorMin, valorMax, selectedTipo, selectedIComodidades);
            
            if (resultados != null && resultados.Count > 0)
            {
                panel1.Controls.Clear();

                foreach (var alojamento in resultados)
                {
                    Listitem item = new Listitem
                    {
                        Titulo = alojamento.Nome,
                        Descricao = alojamento.Desc,
                        Estrelas = GetStars(alojamento.Estrelas),
                        Preco = $"€{alojamento.PrecoPorNoite:F2}€",
                        Imagem = GetImageFromPath(alojamento),
                        Tag = alojamento,
                        Local = "   " + alojamento.Local
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



        private void button5_Click(object sender, EventArgs e)
        {
            Models.Pessoa utilizadorAtual = PessoaManager.Instance.ObterUtilziadorLogado();

            string folderPath = @"C:\Users\tadeu\Documents\GitHub\TrabalhoPOO\usersProfilePhotos\" + utilizadorAtual.Id;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imagens|*.jpg;*.jpeg;*.png;";
                openFileDialog.Title = "Selecione uma foto";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string sourceFilePath = openFileDialog.FileName;

                        string fileName = Path.GetFileName(sourceFilePath);
                        string destinationFilePath = Path.Combine(folderPath, fileName);

                        File.Copy(sourceFilePath, destinationFilePath, overwrite: true);
                        pictureBox3.ImageLocation = destinationFilePath;


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocorreu um erro ao copiar a foto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pessoa utilizadorAtual = PessoaManager.Instance.ObterUtilziadorLogado();

            if (utilizadorAtual != null)
            {
                try
                {
                    string nome = textBox5.Text;
                    string documentoid = textBox8.Text;
                    string telefone = textBox7.Text;

                    PessoaController controller = new PessoaController();
                    controller.EditarPerfil(utilizadorAtual.Id, nome, documentoid, telefone);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Nenhum utilizador encontrado para atualizar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
        }

        private void label31_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Models.Pessoa utilizadorAtual = PessoaManager.Instance.ObterUtilziadorLogado();

            string password = textBox11.Text;
            string passwordNova = textBox10.Text;
            string passwordNovaRepetida = textBox9.Text;

            try
            {
                PessoaController controller = new PessoaController();
                controller.AlterarSenha(utilizadorAtual.Id, password, passwordNova, passwordNovaRepetida);
                panel7.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = "userId.txt";
            File.WriteAllText(filePath, string.Empty);
            Logincs flogin = new Logincs();
            flogin.Show();
            this.Hide();
        }

        private void label32_Click(object sender, EventArgs e)
        {
            string pesquisa = textBox12.Text;

            AlojamentoController controller = new AlojamentoController();
            List<Alojamento> resultados = controller.PesquisarAlojamentos(pesquisa);

            if (resultados != null && resultados.Count > 0)
            {
                panel1.Controls.Clear();

                foreach (var alojamento in resultados)
                {
                    Listitem item = new Listitem
                    {
                        Titulo = alojamento.Nome,
                        Descricao = alojamento.Desc,
                        Estrelas = GetStars(alojamento.Estrelas),
                        Preco = $"€{alojamento.PrecoPorNoite:F2}€",
                        Imagem = GetImageFromPath(alojamento),
                        Tag = alojamento,
                        Local = " " + alojamento.Local
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
    }
}
