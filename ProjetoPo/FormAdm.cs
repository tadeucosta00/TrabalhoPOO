using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using static ProjetoPo.FormAdm;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ProjetoPo
{
    public partial class FormAdm : Form
    {
        public FormAdm()
        {
            InitializeComponent();
            panel3.Visible = false;
            panel4.Visible = false;
            LoadData();
            LoadAlojamentos();
            LoadReservas();
            LoadDashboard();
        }

        public class EntidadeBase
        {
            public int Id { get; set; }

            // Construtor padrão
            public EntidadeBase() { }

            // Construtor que permite definir o Id
            public EntidadeBase(int id)
            {
                Id = id;
            }
        }

        public class Pessoa : EntidadeBase
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
            public string DocumentoIdentidade { get; set; }

            // Construtor padrão
            public Pessoa() { }

            // Construtor que permite definir todas as propriedades
            public Pessoa(int id, string nome, string email, string telefone, string documentoIdentidade)
                : base(id)
            {
                Nome = nome;
                Email = email;
                Telefone = telefone;
                DocumentoIdentidade = documentoIdentidade;
            }
        }

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
            public string Local { get; set; }


            public Alojamento()
            {
                Comodidades = new List<string>();
            }

            public Alojamento(int id, string nome, string local, string tipo, string desc, string lat, string log, double precoPorNoite, int capacidadeMaxima, bool disponivel, int estrelas, bool photos, List<string> comodidades)
                : base(id)
            {
                Nome = nome;
                Tipo = tipo;
                Local = local;
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

        public class Reserva : EntidadeBase
        {
            public Pessoa Pessoa { get; set; }
            public Alojamento Alojamento { get; set; }
            public DateTime DataCheckIn { get; set; }
            public DateTime DataCheckOut { get; set; }
            public double ValorTotal { get; set; }
            public bool CheckIN { get; set; }

            // Construtor padrão
            public Reserva() { }

            // Construtor que permite definir todas as propriedades
            public Reserva(int id, Pessoa pessoa, Alojamento alojamento, DateTime dataCheckIn, DateTime dataCheckOut, double valorTotal, bool checkIn)
                : base(id)
            {
                Pessoa = pessoa;
                Alojamento = alojamento;
                DataCheckIn = dataCheckIn;
                DataCheckOut = dataCheckOut;
                ValorTotal = valorTotal;
                CheckIN = checkIn;
            }
        }

        private void LoadData()
        {
            listView1.Items.Clear();

            string filePath = @"c:\Users\Pedro\Documents\GitHub\TrabalhoPOO\clientes.json";

            try
            {
                string jsonData = File.ReadAllText(filePath);

                List<Pessoa> pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(jsonData);


                listView1.View = View.Details;
                listView1.FullRowSelect = true;

                // Adiciona as colunas à ListView
                listView1.Columns.Add("ID", 50);
                listView1.Columns.Add("Nome", 100);
                listView1.Columns.Add("Email", 250);
                listView1.Columns.Add("Telefone", 100);
                listView1.Columns.Add("Documento", 100);

                // Adiciona os dados na ListView
                foreach (var pessoa in pessoas)
                {
                    ListViewItem item = new ListViewItem(pessoa.Id.ToString());
                    item.SubItems.Add(pessoa.Nome);
                    item.SubItems.Add(pessoa.Email);
                    item.SubItems.Add(pessoa.Telefone);
                    item.SubItems.Add(pessoa.DocumentoIdentidade);

                    listView1.Items.Add(item);
                    comboBox4.Items.Add(pessoa.Nome);

                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("O ficheiro JSON não foi encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException)
            {
                MessageBox.Show("Erro ao ler o ficheiro JSON.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadAlojamentos()
        {

            listViewAlojamentos.Items.Clear();


            string filePath = @"c:\Users\Pedro\Documents\GitHub\TrabalhoPOO\alojamentos.json";

            try
            {
                string jsonData = File.ReadAllText(filePath);
                List<Alojamento> alojamentos = JsonConvert.DeserializeObject<List<Alojamento>>(jsonData);

                listViewAlojamentos.View = View.Details;
                listViewAlojamentos.FullRowSelect = true;

                listViewAlojamentos.Columns.Add("ID", 50);
                listViewAlojamentos.Columns.Add("Nome", 100);
                listViewAlojamentos.Columns.Add("Tipo", 100);
                listViewAlojamentos.Columns.Add("Localizacao", 100);
                listViewAlojamentos.Columns.Add("Preço por Noite", 100);
                listViewAlojamentos.Columns.Add("Capacidade Max", 120);
                listViewAlojamentos.Columns.Add("Disponível", 100);
                if (alojamentos != null)
                {
                    foreach (var alojamento in alojamentos)
                    {
                        ListViewItem item = new ListViewItem(alojamento.Id.ToString());
                        item.SubItems.Add(alojamento.Nome);
                        item.SubItems.Add(alojamento.Tipo);
                        item.SubItems.Add(alojamento.Lat);
                        item.SubItems.Add(alojamento.Log);
                        item.SubItems.Add(alojamento.PrecoPorNoite.ToString("F2"));
                        item.SubItems.Add(alojamento.CapacidadeMaxima.ToString());
                        item.SubItems.Add(alojamento.Disponivel ? "Sim" : "Não");

                        listViewAlojamentos.Items.Add(item);
                        comboBox3.Items.Add(alojamento.Nome);
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

        private void LoadReservas()
        {
            listView2.Columns.Clear();
            listView2.Items.Clear();

            string filePath = @"c:\Users\Pedro\Documents\GitHub\TrabalhoPOO\reservas.json";

            try
            {
                string jsonData = File.ReadAllText(filePath);
                List<Reserva> reservas = JsonConvert.DeserializeObject<List<Reserva>>(jsonData);

                listView2.View = View.Details;
                listView2.FullRowSelect = true;

                listView2.Columns.Add("ID", 50);
                listView2.Columns.Add("Nome Alojamento", 130);
                listView2.Columns.Add("Nome Cliente", 130);
                listView2.Columns.Add("Data Check-In", 130);
                listView2.Columns.Add("Data Check-Out", 130);
                listView2.Columns.Add("Valor", 120);
                listView2.Columns.Add("Check-In", 100);

                foreach (var reserva in reservas)
                {
                    ListViewItem item = new ListViewItem(reserva.Id.ToString());
                    item.SubItems.Add(reserva.Alojamento.Nome);
                    item.SubItems.Add(reserva.Pessoa.Nome);
                    item.SubItems.Add(reserva.DataCheckIn.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(reserva.DataCheckOut.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(reserva.ValorTotal.ToString());
                    listView2.Items.Add(item);
                    //comboBox3.Items.Add(reserva.Nome);
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

        private void LoadDashboard()
        {
            listView3.Columns.Clear();
            listView3.Items.Clear();

            string filePath = @"c:\Users\Pedro\Documents\GitHub\TrabalhoPOO\reservas.json";
            string filePathClientes = @"c:\Users\Pedro\Documents\GitHub\TrabalhoPOO\clientes.json";
            string filePathAlojamentos = @"c:\Users\Pedro\Documents\GitHub\TrabalhoPOO\alojamentos.json";

            double valorTotal = 0;
            int valorReservas = 0;
            int valorAlojamentos = 0;


            try
            {
                string jsonData = File.ReadAllText(filePath);
                List<Reserva> reservas = JsonConvert.DeserializeObject<List<Reserva>>(jsonData);

                string jsonDataClientes = File.ReadAllText(filePathClientes);
                List<Pessoa> pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(jsonData);

                string jsonDataAlojamentos = File.ReadAllText(filePathAlojamentos);
                List<Alojamento> alojamentos = JsonConvert.DeserializeObject<List<Alojamento>>(jsonDataAlojamentos);

                listView3.View = View.Details;
                listView3.FullRowSelect = true;

                listView3.Columns.Add("ID", 50);
                listView3.Columns.Add("Nome Alojamento", 130);
                listView3.Columns.Add("Nome Cliente", 130);
                listView3.Columns.Add("Data Check-In", 130);
                listView3.Columns.Add("Data Check-Out", 130);
                listView3.Columns.Add("Valor", 120);
                listView3.Columns.Add("Check-In", 100);

                foreach (var reserva in reservas)
                {
                    valorTotal += reserva.ValorTotal;
                    ListViewItem item = new ListViewItem(reserva.Id.ToString());
                    item.SubItems.Add(reserva.Alojamento.Nome);
                    item.SubItems.Add(reserva.Pessoa.Nome);
                    item.SubItems.Add(reserva.DataCheckIn.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(reserva.DataCheckOut.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(reserva.ValorTotal.ToString());
                    listView3.Items.Add(item);
                    valorReservas++;
                }

                label28.Text = pessoas.Count + " Clientes";
                //label27.Text = alojamentos.Count + " Alojamentos";

                label26.Text = valorReservas + " Reservas";
                label25.Text = valorTotal + "€";
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



        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox7.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;

            comboBox1.Items.Add("Sim");
            comboBox1.Items.Add("Não");


            comboBox2.Items.Add("Hotel");
            comboBox2.Items.Add("Hostel");
            comboBox2.Items.Add("Apartamento");
            comboBox2.Items.Add("Casa");
            comboBox2.Items.Add("Resort");

            webView21.Source = new Uri("https://www.openstreetmap.org/#map=3/42.29/3.16");



        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                textBox1.Text = selectedItem.SubItems[1].Text;
                textBox2.Text = selectedItem.SubItems[2].Text;
                textBox3.Text = selectedItem.SubItems[3].Text;
                textBox4.Text = selectedItem.SubItems[4].Text;
                textBox7.Text = selectedItem.SubItems[0].Text;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string filePath = @"c:\Users\tadeu\Desktop\POO\ProjetoPo\clientes.json";
            string id = textBox7.Text;
            string nome = textBox1.Text;
            string email = textBox2.Text;
            string telefone = textBox3.Text;
            string documento = textBox4.Text;

            List<Pessoa> pessoas = new List<Pessoa>();
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(jsonData);
            }
            else
            {
                MessageBox.Show("O ficheiro JSON não foi encontrado. Será criado um novo.");
            }

            if (id != "")
            {
                int id1 = int.Parse(id);
                Pessoa pessoaExistente = pessoas.FirstOrDefault(p => p.Id == id1);
                pessoaExistente.Nome = nome;
                pessoaExistente.Email = email;
                pessoaExistente.Telefone = telefone;
                pessoaExistente.DocumentoIdentidade = documento;

            }
            else
            {
                int contador = pessoas.Count;
                contador++;
                Pessoa novaPessoa = new Pessoa
                {
                    Id = contador,
                    Nome = nome,
                    Email = email,
                    Telefone = telefone,
                    DocumentoIdentidade = documento
                };

                pessoas.Add(novaPessoa);

            }

            string novoJsonData = JsonConvert.SerializeObject(pessoas, Formatting.Indented);

            File.WriteAllText(filePath, novoJsonData);

            MessageBox.Show("Dados atualizados com sucesso.");
            LoadData();
        }

        private void listViewAlojamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAlojamentos.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewAlojamentos.SelectedItems[0];

                textBox8.Text = selectedItem.SubItems[1].Text;
                textBox6.Text = selectedItem.SubItems[3].Text;
                textBox5.Text = selectedItem.SubItems[4].Text;
                textBox9.Text = selectedItem.SubItems[5].Text;
                textBox10.Text = selectedItem.SubItems[0].Text;
                string subItemValuetipo = selectedItem.SubItems[2].Text;
                if (subItemValuetipo.Equals("Hotel", StringComparison.OrdinalIgnoreCase))
                {
                    comboBox2.SelectedIndex = 0;
                }
                else if (subItemValuetipo.Equals("Hostel", StringComparison.OrdinalIgnoreCase))
                {
                    comboBox2.SelectedIndex = 1;
                }
                else if (subItemValuetipo.Equals("Apartamento", StringComparison.OrdinalIgnoreCase))
                {
                    comboBox2.SelectedIndex = 2;
                }
                else if (subItemValuetipo.Equals("Casa", StringComparison.OrdinalIgnoreCase))
                {
                    comboBox2.SelectedIndex = 3;
                }
                else if (subItemValuetipo.Equals("Resort", StringComparison.OrdinalIgnoreCase))
                {
                    comboBox2.SelectedIndex = 4;
                }

                string subItemValuedisponivel = selectedItem.SubItems[6].Text;
                if (subItemValuedisponivel.Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    comboBox1.SelectedIndex = 1;
                }
                else
                {
                    comboBox1.SelectedIndex = 0;
                }



                webView21.Source = new Uri("https://www.openstreetmap.org/?mlat=" + selectedItem.SubItems[3].Text + "&mlon=" + selectedItem.SubItems[4].Text + "#map=19");



            }
        }

        private void SavePhotos(int id, List<string> arquivos)
        {
            string pastaDestino = @"C:\Users\Pedro\Documents\GitHub\TrabalhoPOO\uploads\" + id;
            try
            {
                if (!Directory.Exists(pastaDestino))
                {
                    Directory.CreateDirectory(pastaDestino);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar a pasta: {ex.Message}");
            }

            List<string> arquivosMovidos = new List<string>();

            foreach (string arquivo in arquivos)
            {
                try
                {
                    string nomeArquivo = Path.GetFileName(arquivo);
                    string caminhoDestino = Path.Combine(pastaDestino, nomeArquivo);

                    File.Move(arquivo, caminhoDestino);

                    arquivosMovidos.Add(caminhoDestino);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao mover o arquivo {arquivo}: {ex.Message}");
                }
            }

            if (arquivosMovidos.Count > 0)
            {
                MessageBox.Show("Arquivos movidos com sucesso:\n" + string.Join("\n", arquivosMovidos));
            }
            else
            {
                MessageBox.Show("Nenhum arquivo foi movido.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string filePath = @"c:\Users\Pedro\Documents\GitHub\TrabalhoPOO\alojamentos.json";
            string id = textBox10.Text;
            string nome = textBox8.Text;
            string desc = richTextBox1.Text;
            string tipo = comboBox2.Text;
            string lat = textBox6.Text;
            string log = textBox12.Text;
            string precoPorNoite = textBox5.Text;
            string estrelas = textBox13.Text;
            string local = textBox14.Text;

            



            List<string> comodidadesSelecionadas = new List<string>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                comodidadesSelecionadas.Add(item.ToString());
            }
            string capacidadeMaxima = textBox9.Text;
            bool disponivel = comboBox1.Text.Equals("Sim", StringComparison.OrdinalIgnoreCase);
            bool photos = false;

            List<string> arquivosSelecionados = new List<string>();
            foreach (string arquivo in listBoxFotosAlojamento.Items)
            {
                arquivosSelecionados.Add(arquivo);
            }
            if (arquivosSelecionados.Count > 0)
            {
                photos = true;
            }

            List<Alojamento> alojamentos = new List<Alojamento>();
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                alojamentos = JsonConvert.DeserializeObject<List<Alojamento>>(jsonData) ?? new List<Alojamento>();
            }
            else
            {
                MessageBox.Show("O ficheiro JSON não foi encontrado. Será criado um novo.");
            }

            if (!string.IsNullOrEmpty(id))
            {
                int id1;
                if (int.TryParse(id, out id1))
                {
                    Alojamento alojamentoExistente = alojamentos.FirstOrDefault(p => p.Id == id1);
                    if (alojamentoExistente != null)
                    {
                        alojamentoExistente.Nome = nome;
                        alojamentoExistente.Tipo = tipo;
                        alojamentoExistente.Desc = desc;
                        alojamentoExistente.Lat = lat;
                        alojamentoExistente.Log = log;
                        alojamentoExistente.PrecoPorNoite = double.Parse(precoPorNoite);
                        alojamentoExistente.CapacidadeMaxima = int.Parse(capacidadeMaxima);
                        alojamentoExistente.Disponivel = disponivel;
                        alojamentoExistente.Comodidades = comodidadesSelecionadas;
                        alojamentoExistente.Photos = photos;
                        alojamentoExistente.Estrelas = int.Parse(estrelas);
                        alojamentoExistente.Local = local;


                        if (arquivosSelecionados.Count > 0)
                        {
                            SavePhotos(id1, arquivosSelecionados);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Alojamento não encontrado.");
                    }
                }
                else
                {
                    MessageBox.Show("ID inválido. Por favor, insira um número válido.");
                }
            }
            else
            {
                int contador = alojamentos.Count + 1;

                Alojamento novoAlojamento = new Alojamento
                {
                    Id = contador,
                    Nome = nome,
                    Tipo = tipo,
                    Desc = desc,
                    Lat = lat,
                    Log = log,
                    PrecoPorNoite = double.Parse(precoPorNoite),
                    CapacidadeMaxima = int.Parse(capacidadeMaxima),
                    Disponivel = disponivel,
                    Comodidades = comodidadesSelecionadas,
                    Photos = photos,
                    Estrelas = int.Parse(estrelas),
                    Local = local,
                };
                if (arquivosSelecionados.Count > 0)
                {
                    SavePhotos(contador, arquivosSelecionados);
                }
                alojamentos.Add(novoAlojamento);
            }

            string novoJsonData = JsonConvert.SerializeObject(alojamentos, Formatting.Indented);
            File.WriteAllText(filePath, novoJsonData);

            MessageBox.Show("Dados atualizados com sucesso.");
            LoadAlojamentos();
        }


        private void button7_Click(object sender, EventArgs e)
        {

            string filePath = @"c:\Users\Pedro\Documents\GitHub\TrabalhoPOO\reservas.json";
            string id = textBox11.Text;
            int idCliente = comboBox4.SelectedIndex;
            int idAlojamento = comboBox3.SelectedIndex;
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

            if (id != "")
            {


            }
            else
            {

                string filePathPessoas = @"c:\Users\Pedro\Documents\GitHub\TrabalhoPOO\clientes.json";
                string filePathAlojamentos = @"c:\Users\Pedro\Documents\GitHub\TrabalhoPOO\alojamentos.json";

                List<Pessoa> pessoas = new List<Pessoa>();
                List<Alojamento> alojamentos = new List<Alojamento>();

                if (File.Exists(filePathPessoas))
                {
                    string jsonDataPessoas = File.ReadAllText(filePathPessoas);
                    pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(jsonDataPessoas);
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

                Pessoa pessoa = pessoas[idCliente];
                Alojamento alojamento = alojamentos[idAlojamento];

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
            }
            string novoJsonData = JsonConvert.SerializeObject(reservas, Formatting.Indented);

            File.WriteAllText(filePath, novoJsonData);

            MessageBox.Show("Dados atualizados com sucesso.");
            LoadReservas();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.Title = "Selecione uma foto";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    listBoxFotosAlojamento.Items.Clear();
                    foreach (string arquivo in openFileDialog.FileNames)
                    {
                        listBoxFotosAlojamento.Items.Add(arquivo);
                    }
                }
            }
        }

        private void listBoxFotosAlojamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFotosAlojamento.SelectedItem != null)
            {
                string caminhoSelecionado = listBoxFotosAlojamento.SelectedItem.ToString();
                FormViewImage formImagem = new FormViewImage(caminhoSelecionado);
                formImagem.ShowDialog();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.Text != "")
            {
                webView21.Source = new Uri("https://www.openstreetmap.org/?mlat=" + textBox6.Text + "&mlon=" + textBox12.Text + "#map=19");
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                webView21.Source = new Uri("https://www.openstreetmap.org/?mlat=" + textBox6.Text + "&mlon=" + textBox12.Text + "#map=19");
            }
        }

       
    }
}
