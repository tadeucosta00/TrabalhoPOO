using Newtonsoft.Json;
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
using static ProjetoPo.FormClients;
using static ProjetoPo.Logincs;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetoPo
{
    public partial class FormClients : Form
    {
        private Logincs.Pessoa usuario;

        public class Alojamento
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Tipo { get; set; }
            public string Desc { get; set; }
            public string Lat { get; set; }
            public string Log { get; set; }
            public double PrecoPorNoite { get; set; }
            public int CapacidadeMaxima { get; set; }
            public bool Disponivel { get; set; }
            public int Estrelas { get; set; }
            public bool Photos { get; set; }
            public List<string> Comodidades { get; set; }

            public Alojamento()
            {
                Comodidades = new List<string>();
            }

            public Alojamento(int id, string nome, string tipo, string desc, string lat, string log, double precoPorNoite, int capacidadeMaxima, bool disponivel, int estrelas, bool photos, List<string> comodidades)
                
            {
                Id = id;
                Nome = nome;
                Tipo = tipo;
                Desc = desc;
                Lat = lat;
                Log = log;
                PrecoPorNoite = precoPorNoite;
                CapacidadeMaxima = capacidadeMaxima;
                Disponivel = disponivel;
                Estrelas = estrelas;
                Photos = photos;
                Comodidades = comodidades;
            }
        }

        public class Reserva 
        {
            public int Id { get; set; }

            public Logincs.Pessoa Pessoa { get; set; }
            public Alojamento Alojamento { get; set; }
            public DateTime DataCheckIn { get; set; }
            public DateTime DataCheckOut { get; set; }
            public double ValorTotal { get; set; }
            public bool CheckIN { get; set; }

            public Reserva() { }

            public Reserva(int id, Logincs.Pessoa pessoa, Alojamento alojamento, DateTime dataCheckIn, DateTime dataCheckOut, double valorTotal, bool checkIn)
              
            {
                Id = id;
                Pessoa = pessoa;
                Alojamento = alojamento;
                DataCheckIn = dataCheckIn;
                DataCheckOut = dataCheckOut;
                ValorTotal = valorTotal;
                CheckIN = checkIn;
            }
        }



        public FormClients(Logincs.Pessoa user)
        {
            InitializeComponent();
            usuario = user;
            LoadAlojamentos();
            comboBox1.Items.Clear();

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
            //usuario.Nome
            MessageBox.Show(this.usuario.Nome);
            string filePath = @"c:\Users\Pedro\Documents\GitHub\TrabalhoPOO\alojamentos.json";

            try
            {
                string jsonData = File.ReadAllText(filePath);
                List<Alojamento> alojamentos = JsonConvert.DeserializeObject<List<Alojamento>>(jsonData);
                if (alojamentos != null)
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
                            Tag = alojamento
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
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("O ficheiro JSON de alojamentos não foi encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException)
            {
                MessageBox.Show("Erro ao ler o ficheiro JSON de alojamentos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListItem_Click(object sender, EventArgs e)
        {
            if (sender is Listitem item && item.Tag is Alojamento alojamento)
            {
                panel4.Visible = false;
                panel3.Visible = true;
                pictureBox1.Image = GetImageFromPath(alojamento);
                label2.Text = alojamento.Nome;
                label3.Text = GetStars(alojamento.Estrelas);
                label4.Text = alojamento.Desc;
                textBox3.Text = alojamento.Id.ToString();


                label7.Text = $"€{alojamento.PrecoPorNoite:F2}";
                webView21.Source = new Uri("https://www.openstreetmap.org/?mlat=" + alojamento.Lat + "&mlon=" + alojamento.Log + "#map=19");

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

                    panelComodidade.Controls.Add(labelComodidade);

                    flowLayoutPanel1.Controls.Add(panelComodidade);
                }

                //MessageBox.Show($"Você clicou no alojamento: {alojamento.Nome}", "Alojamento Clicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string iconPath = @"C:\Users\Pedro\Documents\GitHub\TrabalhoPOO\icons";

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



        private System.Drawing.Image GetImageFromPath(Alojamento alojamento)
        {
            string imagePath = $@"C:\Users\Pedro\Documents\GitHub\TrabalhoPOO\uploads\{alojamento.Id}\download.jpg";

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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = @"c:\Users\Pedro\Documents\GitHub\TrabalhoPOO\reservas.json";
            int idCliente = this.usuario.Id;
            MessageBox.Show(idCliente.ToString());

            int idAlojamento = int.Parse(textBox3.Text);
            DateTime dataCheckIn = DateTime.Parse(dateTimePicker1.Text);
            DateTime dataCheckOut = DateTime.Parse(dateTimePicker2.Text);

            TimeSpan diferenca = dataCheckOut - dataCheckIn;

            int numeroDeDias = diferenca.Days;

            List<Reserva> reservas = new List<Reserva>();
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                reservas = JsonConvert.DeserializeObject<List<Reserva>>(jsonData);
            }
            else
            {
                MessageBox.Show("O ficheiro JSON não foi encontrado. Será criado um novo.");
            }



            string filePathPessoas = @"C:\Users\Pedro\Documents\GitHub\TrabalhoPOO\clientes.json";
            string filePathAlojamentos = @"C:\Users\Pedro\Documents\GitHub\TrabalhoPOO\alojamentos.json";

            List<Logincs.Pessoa> pessoas = new List<Logincs.Pessoa>();
            List<Alojamento> alojamentos = new List<Alojamento>();

            if (File.Exists(filePathPessoas))
            {
                string jsonDataPessoas = File.ReadAllText(filePathPessoas);
                pessoas = JsonConvert.DeserializeObject<List<Logincs.Pessoa>>(jsonDataPessoas);
            }

            if (File.Exists(filePathAlojamentos))
            {
                string jsonDataAlojamentos = File.ReadAllText(filePathAlojamentos);
                alojamentos = JsonConvert.DeserializeObject<List<Alojamento>>(jsonDataAlojamentos);
            }

            if (pessoas.Count == 0 || alojamentos.Count == 0)
            {
                MessageBox.Show("Não foi possível carregar os dados de pessoas ou alojamentos.");
                return;
            }
            MessageBox.Show(pessoas[idCliente - 1].Email);
            Logincs.Pessoa pessoa = pessoas[idCliente - 1];
            Alojamento alojamento = alojamentos[idAlojamento - 1];

            double valorTotal = alojamento.PrecoPorNoite * numeroDeDias;


            int contador = reservas.Count;
            contador++;
            Reserva novaReserva = new Reserva
            {
                Id = contador,
                Pessoa = pessoa,
                Alojamento = alojamento,
                DataCheckIn = dataCheckIn,
                DataCheckOut = dataCheckOut,
                ValorTotal = valorTotal,
                CheckIN = false
            };

            reservas.Add(novaReserva);

            string novoJsonData = JsonConvert.SerializeObject(reservas, Formatting.Indented);

            File.WriteAllText(filePath, novoJsonData);

            MessageBox.Show("Dados atualizados com sucesso.");
        }
    }

}
