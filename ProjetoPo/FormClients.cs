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
using static ProjetoPo.FormAdm;
using static ProjetoPo.FormClients;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetoPo
{
    public partial class FormClients : Form
    {

        public class Alojamento : EntidadeBase
        {
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
                : base(id)
            {
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

        public FormClients()
        {
            InitializeComponent();
            LoadAlojamentos();
        }

        private string GetStars(int estrelas)
        {
            string starFilled = "★"; // Estrela preenchida
            string starEmpty = "☆";  // Estrela vazia

            return new string(starFilled[0], estrelas) + new string(starEmpty[0], 5 - estrelas);
        }

        private void LoadAlojamentos()
        {
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
                            Descricao =  alojamento.Desc,
                            Estrelas = GetStars(alojamento.Estrelas),
                            Preco = $"€{alojamento.PrecoPorNoite:F2}€",
                            Imagem = GetImageFromPath(alojamento)
                        };

                        item.Width = panel1.Width;
                        item.Dock = DockStyle.Top;

                        item.Controls.OfType<PictureBox>().FirstOrDefault().SizeMode = PictureBoxSizeMode.Zoom;

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

        private System.Drawing.Image GetImageFromPath(Alojamento alojamento)
        {
            string imagePath = $@"C:\Users\Pedro\Documents\GitHub\TrabalhoPOO\uploads\{alojamento.Id}\download.jpg";
            MessageBox.Show($"Caminho da imagem: {imagePath}");


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

        
    }

}
