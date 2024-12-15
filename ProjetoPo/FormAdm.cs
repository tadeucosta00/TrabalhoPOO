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
using ProjetoPo.Models;
using System.Text;
using Mono.Unix.Native;
using Logs;
using Microsoft.Extensions.Logging;
using static IronPython.Modules._ast;
using System.Globalization;

namespace ProjetoPo
{
    public partial class FormAdm : Form
    {
        public FormAdm()
        {
            InitializeComponent();
            panel3.Visible = false;
            panel4.Visible = false;
            LoadPessoas();
            LoadAlojamentos();
            LoadReservas();
            LoadDashboard();
        }

        private void LoadPessoas()
        {
            listView1.Items.Clear();
            comboBox4.DataSource = null; 

            try
            {
                List<Models.Pessoa> pessoas = Models.PessoaTable.GetAll();

                if (listView1.Columns.Count == 0)
                {
                    listView1.View = View.Details;
                    listView1.FullRowSelect = true;

                    listView1.Columns.Add("ID", 50);
                    listView1.Columns.Add("Nome", 100);
                    listView1.Columns.Add("Email", 250);
                    listView1.Columns.Add("Telefone", 100);
                    listView1.Columns.Add("Documento", 100);
                    listView1.Columns.Add("Permissão", 100);
                    listView1.Columns.Add("Estado", 100);
                }

                foreach (var pessoa in pessoas)
                {
                    ListViewItem item = new ListViewItem(pessoa.Id.ToString());
                    item.SubItems.Add(pessoa.Nome);
                    item.SubItems.Add(pessoa.Email);
                    item.SubItems.Add(pessoa.Telefone);
                    item.SubItems.Add(pessoa.DocumentoIdentidade);
                    if (pessoa.Adm == true)
                    {
                        item.SubItems.Add("Admin");
                    }
                    else
                    {
                        item.SubItems.Add("Normal");
                    }
                    if (pessoa.Ativo == true)
                    {
                        item.SubItems.Add("Ativo");
                    }
                    else
                    {
                        item.BackColor = Color.Red;
                        item.SubItems.Add("Desativo");
                    }
                    listView1.Items.Add(item);
                }
                comboBox4.DataSource = pessoas;
                comboBox4.DisplayMember = "Nome";
                comboBox4.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAlojamentos()
        {
            listViewAlojamentos.Items.Clear();

            try
            {
                comboBox3.DataSource = null;
                comboBox3.Items.Clear();

                List<Models.Alojamento> alojamentos = Models.AlojamentosTable.GetAlojamentosFromDB();

                if (listViewAlojamentos.Columns.Count == 0)
                {
                    listViewAlojamentos.View = View.Details;
                    listViewAlojamentos.FullRowSelect = true;

                    listViewAlojamentos.Columns.Add("ID", 100);
                    listViewAlojamentos.Columns.Add("Nome", 150);
                    listViewAlojamentos.Columns.Add("Tipo", 150);
                    listViewAlojamentos.Columns.Add("Latitude", 150);
                    listViewAlojamentos.Columns.Add("Longitude", 150);
                    listViewAlojamentos.Columns.Add("Localizacao", 150);
                    listViewAlojamentos.Columns.Add("Preço por Noite", 150);
                    listViewAlojamentos.Columns.Add("Capacidade Max", 150);
                    listViewAlojamentos.Columns.Add("Estrelas", 150);
                }

                foreach (var alojamento in alojamentos)
                {
                    ListViewItem item = new ListViewItem(alojamento.Id.ToString());
                    item.SubItems.Add(alojamento.Nome);
                    item.SubItems.Add(alojamento.Tipo.ToString());
                    item.SubItems.Add(alojamento.Latitude);
                    item.SubItems.Add(alojamento.Longitude);
                    item.SubItems.Add(alojamento.Local);
                    item.SubItems.Add(alojamento.PrecoPorNoite.ToString("F2") + "€");
                    item.SubItems.Add(alojamento.CapacidadeMaxima.ToString());
                    item.SubItems.Add(alojamento.Estrelas.ToString());
                    listViewAlojamentos.Items.Add(item);

                    
                }
                comboBox3.DataSource = alojamentos;
                comboBox3.DisplayMember = "Nome";
                comboBox3.ValueMember = "Id";
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

            try
            {
                List<Models.Reserva> reservas = Models.ReservasTable.GetAllReservasFromDB();

                listView2.View = View.Details;
                listView2.FullRowSelect = true;

                listView2.Columns.Add("ID", 80);
                listView2.Columns.Add("Nome Alojamento", 150);
                listView2.Columns.Add("Nome Cliente", 150);
                listView2.Columns.Add("Data Check-In", 150);
                listView2.Columns.Add("Data Check-Out", 150);
                listView2.Columns.Add("Valor", 100);
                listView2.Columns.Add("Check-In", 100);
                listView2.Columns.Add("Estado", 100);


                foreach (var reserva in reservas)
                {
                    ListViewItem item = new ListViewItem(reserva.Id.ToString());
                    item.SubItems.Add(reserva.Alojamento.Nome);
                    item.SubItems.Add(reserva.Pessoa.Nome);
                    item.SubItems.Add(reserva.DataCheckIn.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(reserva.DataCheckOut.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(reserva.ValorTotal.ToString("F2") + "€");
                    item.SubItems.Add(reserva.CheckIN ? "Sim" : "Não");
                    item.SubItems.Add(reserva.Ativo ? "Ativa" : "Cancelada");
                    if (!reserva.Ativo)
                    {
                        item.BackColor = Color.Red;
                    }

                    listView2.Items.Add(item);
                }

                comboBox6.Items.Clear();
                for (int i = 1; i <= 5; i++)
                {
                    comboBox6.Items.Add(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao carregar as reservas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadDashboard()
        {
            listView3.Columns.Clear();
            listView3.Items.Clear();

            double valorTotal = 0;
            int valorReservas = 0;

            try
            {
                List<Models.Reserva> reservas = Models.ReservasTable.GetAllReservasFromDB();
                List<Models.Pessoa> pessoas = Models.PessoaTable.GetAll();
                List<Models.Alojamento> alojamentos = Models.AlojamentosTable.GetAlojamentosFromDB();

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
                    item.SubItems.Add(reserva.ValorTotal.ToString("F2") + "€");
                    item.SubItems.Add(reserva.CheckIN ? "Sim" : "Não");

                    listView3.Items.Add(item);
                    valorReservas++;
                }

                label28.Text = pessoas.Count.ToString();
                label27.Text = alojamentos.Count.ToString();
                label26.Text = valorReservas.ToString();
                label25.Text = valorTotal.ToString("F2") + "€";
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
            foreach (Control control in panel5.Controls)
            {
                if (control is System.Windows.Forms.TextBox textBox)
                {
                    textBox.Text = "";
                }
                if (control is System.Windows.Forms.ComboBox comboBox)
                {
                    comboBox.SelectedIndex = 0;
                    //comboBox.Text = "";
                }
                if (control is System.Windows.Forms.DateTimePicker datetimepicker)
                {
                    datetimepicker.Value = DateTime.Now;
                }
            }

            string id = textBox11.Text;
            if (string.IsNullOrEmpty(id))
            { 
                button10.Enabled = false;
                comboBox3.Enabled = true;
            }
            

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
            comboBox5.SelectedIndex = 0;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control control in panel4.Controls)
            {
                if (control is System.Windows.Forms.TextBox textBox)
                {
                    textBox.Text = "";
                }
                if (control is System.Windows.Forms.RichTextBox richTextBox)
                {
                    richTextBox.Text = "";
                }
            }

            listBoxFotosAlojamento.Items.Clear();

            checkedListBox1.Items.Clear();

            List<Models.Comodidades> comodidades = Models.ComodidadesTable.GetComodidadesFromDB();
            if (comodidades != null && comodidades.Count > 0)
            {
                foreach (var comodidade in comodidades)
                {
                    int index = checkedListBox1.Items.Add(comodidade.Nome);
                }
            }


            comboBox1.Items.Clear();
            comboBox1.Items.Add("Sim");
            comboBox1.Items.Add("Não");

            comboBox2.Items.Clear();
            comboBox2.Items.Add("Hotel");
            comboBox2.Items.Add("Hostel");
            comboBox2.Items.Add("Apartamento");
            comboBox2.Items.Add("Casa");
            comboBox2.Items.Add("Resort");

            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            webView21.Source = new Uri("https://www.openstreetmap.org/#map=3/42.29/3.16");
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
                if (selectedItem.SubItems[5].Text == "Admin")
                {
                    comboBox5.SelectedIndex = 1;
                }
                else
                {
                    comboBox5.SelectedIndex = 0;

                }
                if (selectedItem.SubItems[6].Text == "Desativo")
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Logger logger = new Logger();
            string id = textBox7.Text;
            string nome = textBox1.Text;
            string email = textBox2.Text;
            string telefone = textBox3.Text;
            string documento = textBox4.Text;

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(telefone) || string.IsNullOrEmpty(documento))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ativo = true;
            bool adm = false;
            if (checkBox2.Checked)
            {
                ativo = false;
            }

            if (comboBox5.SelectedIndex == 1)
            {
                adm = true;
            }
            else
            {
                adm = false;
            }


            if (id != "")
            {
                int pessoaId = int.Parse(id);
                Pessoa pessoaExistente = Models.PessoaTable.GetById(pessoaId);

                if (pessoaExistente != null)
                {
                    pessoaExistente.Nome = nome;
                    pessoaExistente.Email = email;
                    pessoaExistente.Telefone = telefone;
                    pessoaExistente.DocumentoIdentidade = documento;
                    pessoaExistente.Adm = adm;
                    pessoaExistente.Ativo = ativo;
                    PessoaTable.Atualizar(pessoaExistente);
                    MessageBox.Show("Dados atualizados com sucesso.");
                    logger.LogInfo("Pessoa Atualizada Id:" + id);
                }
                else
                {
                    MessageBox.Show("Pessoa não encontrada.");
                    logger.LogError("Pessoa não encontrada");
                }
            }
            else
            {
                try
                {
                    byte[] data = Encoding.ASCII.GetBytes(documento);
                    data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                    string hash = BitConverter.ToString(data).Replace("-", "").ToLower();
                    Pessoa novaPessoa = new Pessoa
                    {
                        Nome = nome,
                        Email = email,
                        Telefone = telefone,
                        DocumentoIdentidade = documento,
                        Senha = hash,
                        Adm = adm,
                    };

                    PessoaTable.Salvar(novaPessoa);
                    MessageBox.Show("Nova pessoa adicionada com sucesso.");
                    logger.LogInfo("Nova pessoa adicionada com sucesso.");
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                    logger.LogError("Erro ao adicionar: " + ex);
                }
            }
            LoadPessoas();
        }


        private void listViewAlojamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAlojamentos.SelectedItems.Count > 0)
            {
                int selectedAlojamentoId = int.Parse(listViewAlojamentos.SelectedItems[0].Text);

                Models.Alojamento alojamentoSelecionado = Models.AlojamentosTable.GetAlojamentoById(selectedAlojamentoId);

                if (alojamentoSelecionado == null)
                {
                    MessageBox.Show("Alojamento não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                textBox8.Text = alojamentoSelecionado.Nome;
                textBox14.Text = alojamentoSelecionado.Local;
                textBox12.Text = alojamentoSelecionado.Longitude;
                textBox13.Text = alojamentoSelecionado.Estrelas.ToString();
                richTextBox1.Text = alojamentoSelecionado.Desc;
                textBox6.Text = alojamentoSelecionado.Latitude;
                textBox5.Text = alojamentoSelecionado.PrecoPorNoite.ToString("F2");
                textBox9.Text = alojamentoSelecionado.CapacidadeMaxima.ToString();
                textBox10.Text = alojamentoSelecionado.Id.ToString();

                comboBox2.SelectedIndex = (int)alojamentoSelecionado.Tipo - 1;

                comboBox1.SelectedIndex = alojamentoSelecionado.Disponivel ? 0 : 1;

                checkedListBox1.Items.Clear();

                List<Models.Comodidades> comodidades = Models.ComodidadesTable.GetComodidadesFromDB();
                if (comodidades != null && comodidades.Count > 0)
                {
                    foreach (var comodidade in comodidades)
                    {
                        int index = checkedListBox1.Items.Add(comodidade.Nome);
                        foreach (var comodidadesAlojamento in alojamentoSelecionado.Comodidades)
                        {
                            if (comodidadesAlojamento == comodidade.Nome)
                            {
                                checkedListBox1.SetItemChecked(index, true);
                            }
                        }
                    }
                }

                webView21.Source = new Uri($"https://www.openstreetmap.org/?mlat={alojamentoSelecionado.Latitude}&mlon={alojamentoSelecionado.Longitude}#map=19");

                listBoxFotosAlojamento.Items.Clear();
                string pastaDestino = $@"C:\Users\tadeu\Documents\GitHub\TrabalhoPOO\uploads\{alojamentoSelecionado.Id}";

                if (Directory.Exists(pastaDestino))
                {
                    List<string> fotos = new List<string>();
                    fotos.AddRange(Directory.GetFiles(pastaDestino, "*.jpg"));
                    fotos.AddRange(Directory.GetFiles(pastaDestino, "*.jpeg"));
                    fotos.AddRange(Directory.GetFiles(pastaDestino, "*.png"));

                    if (fotos.Count > 0)
                    {
                        string foto = fotos[0];
                        listBoxFotosAlojamento.Items.Add(foto);
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma foto encontrada na pasta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            Logger logger = new Logger();
            string id = textBox10.Text;
            string nome = textBox8.Text;
            string desc = richTextBox1.Text;
            string tipoString = comboBox2.Text;
            string lat = textBox6.Text;
            string log = textBox12.Text;
            string precoPorNoite = textBox5.Text;
            string estrelas = textBox13.Text;
            string local = textBox14.Text;
            string capacidade = textBox9.Text;


            if (string.IsNullOrEmpty(nome) ||
            string.IsNullOrEmpty(desc) ||
            string.IsNullOrEmpty(tipoString) ||
            string.IsNullOrEmpty(lat) ||
            string.IsNullOrEmpty(log) ||
            string.IsNullOrEmpty(precoPorNoite) ||
            string.IsNullOrEmpty(estrelas) ||
            string.IsNullOrEmpty(local) ||
            string.IsNullOrEmpty(capacidade))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(estrelas, out int estrelasInt) || estrelasInt < 1 || estrelasInt > 5)
            {
                MessageBox.Show("O campo Estrelas deve ser um número entre 1 e 5.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(capacidade, out int capacidadeInt) || capacidadeInt < 1)
            {
                MessageBox.Show("O campo Capacidade deve ser um número superior que 1.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(lat, NumberStyles.Float, CultureInfo.InvariantCulture, out double latDouble))
            {
                MessageBox.Show("O campo Latitude deve conter um valor numerico valido.",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(log, NumberStyles.Float, CultureInfo.InvariantCulture, out double logDouble))
            {
                MessageBox.Show("O campo Longitude deve conter um valor numerico valido.",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(precoPorNoite, out decimal precoDecimal) || precoDecimal < 0)
            {
                MessageBox.Show("O campo Preço por Noite deve conter um valor numerico valido e positivo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            List<string> comodidadesSelecionadas = checkedListBox1.CheckedItems.Cast<string>().ToList();
            bool disponivel = comboBox1.Text.Equals("Sim", StringComparison.OrdinalIgnoreCase);
            bool photos = listBoxFotosAlojamento.Items.Count > 0;

            Models.Alojamento alojamento = new Models.Alojamento
            {
                Id = int.TryParse(id, out int idParsed) ? idParsed : 0,
                Nome = nome,
                Desc = desc,
                Tipo = Enum.TryParse<TipoAlojamento>(tipoString, true, out TipoAlojamento tipo) ? tipo : TipoAlojamento.Hotel,
                Latitude = lat,
                Longitude = log,
                PrecoPorNoite = double.Parse(precoPorNoite),
                CapacidadeMaxima = int.Parse(capacidade),
                Disponivel = disponivel,
                Estrelas = int.Parse(estrelas),
                Photos = photos,
                Local = local,
                Comodidades = comodidadesSelecionadas
            };

            bool sucesso;

            if (alojamento.Id > 0)
            {
                sucesso = AlojamentosTable.EditarAlojamento(alojamento);
                /*if (sucesso)
                {
                    string pastaDestino = $@"C:\Users\tadeu\Documents\GitHub\TrabalhoPOO\uploads\{alojamento.Id}";

                    try
                    {
                        if (Directory.Exists(pastaDestino))
                        {
                            Directory.Delete(pastaDestino, true);
                            System.Threading.Thread.Sleep(100); 
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Erro ao excluir fotos antigas: {ex.Message}");
                        return;
                    }
                }*/
                MessageBox.Show(sucesso ? "Alojamento atualizado com sucesso." : "Erro ao atualizar alojamento.");
                logger.LogInfo("Alojamneto Atualizado!");

            }
            else
            {
                int novoId = AlojamentosTable.AdicionarAlojamento(alojamento);
                sucesso = novoId > 0;
                alojamento.Id = novoId;
                if (sucesso && photos && listBoxFotosAlojamento.Items.Count > 0)
                {
                    string arquivoFoto = listBoxFotosAlojamento.Items[0].ToString();
                    SavePhoto(alojamento.Id, arquivoFoto);
                }
                MessageBox.Show(sucesso ? "Novo alojamento inserido com sucesso." : "Erro ao inserir alojamento.");
                logger.LogInfo("Novo Alojamneto Inserido!");
            }



            if (sucesso)
            {
                LoadAlojamentos();
            }
        }



        private void SavePhoto(int id, string arquivo)
        {
            string pastaDestino = @"C:\Users\tadeu\Documents\GitHub\TrabalhoPOO\uploads\" + id;
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
                return;
            }

            try
            {
                string caminhoDestino = Path.Combine(pastaDestino, id.ToString()+".jpg");

                File.Copy(arquivo, caminhoDestino, true);

                MessageBox.Show("Foto copiada com sucesso para:\n" + caminhoDestino);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao copiar o arquivo {arquivo}: {ex.Message}");
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            Logger logger = new Logger();
            string id = textBox11.Text;

            Pessoa pessoaSelecionada = comboBox4.SelectedItem as Pessoa;
            Alojamento alojamentoSelecionado = comboBox3.SelectedItem as Alojamento;

            int idCliente = pessoaSelecionada != null ? pessoaSelecionada.Id : 0;
            int idAlojamento = alojamentoSelecionado != null ? alojamentoSelecionado.Id : 0;
            int hospedes = 0;
            if (comboBox6.SelectedItem == null) {
                MessageBox.Show("Sem Hospedes!");
                return;
            }
            else
            {
                hospedes = (int)comboBox6.SelectedItem;
            }

            bool ativa = true;
            if (checkBox1.Checked == true)
            {
                ativa = false;
            }

            DateTime dataCheckIn = DateTime.Parse(dateTimePicker1.Text);
            DateTime dataCheckOut = DateTime.Parse(dateTimePicker2.Text);


            TimeSpan diferenca = dataCheckOut - dataCheckIn;
            int numeroDeDias = diferenca.Days;


            if (numeroDeDias <= 0) {
                MessageBox.Show("Reserva minima uma noite!");
                return;
            }

            if (!string.IsNullOrEmpty(id))
            {
                Reserva reservaExistente = Models.ReservasTable.GetReservaById(Int32.Parse(id));

                if (reservaExistente != null)
                {
                    reservaExistente.DataCheckIn = dataCheckIn;
                    reservaExistente.DataCheckOut = dataCheckOut;
                    reservaExistente.Hospedes = hospedes;
                    reservaExistente.Pessoa.Id = idCliente;
                    reservaExistente.ValorTotal = 0;
                    reservaExistente.Ativo = ativa;
                    reservaExistente.CheckIN = reservaExistente.CheckIN;
                    reservaExistente.ValorTotal = ReservasTable.CalcularValorTotal(reservaExistente);

                    Models.ReservasTable.AtualizarReservaNaDB(reservaExistente);
                    MessageBox.Show("Reserva atualizada com sucesso.");
                    logger.LogInfo("Alteração Reserva Id:" + id);
                }
                else
                {
                    MessageBox.Show("Reserva não encontrada.");
                    logger.LogError("Erro ao encontrar reserva.");
                }
            }
            else
            {
                Models.Reserva novaReserva = new Models.Reserva
                {
                    Pessoa = new Pessoa { Id = idCliente },
                    Alojamento = new Alojamento { Id = idAlojamento },
                    DataCheckIn = dataCheckIn,
                    DataCheckOut = dataCheckOut,
                    Hospedes = hospedes,
                    ValorTotal = 0,
                    CheckIN = false
                };
                novaReserva.ValorTotal = ReservasTable.CalcularValorTotal(novaReserva);

                try
                {
                    DialogResult dr = MessageBox.Show("Confirmar Reserva?", "Deseja confirmar a reserva?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        ReservasTable.AdcionarReservaNaDB(novaReserva);
                        MessageBox.Show("Reserva efetuada com sucesso.");
                        logger.LogInfo("Nova Reserva");
                    }
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                    logger.LogError("Erro ao Reservar: "+ ex);
                }

            }
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

        private void button9_Click(object sender, EventArgs e)
        {
            FormClients form1 = new FormClients();
            form1.Show();
            this.Hide();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = false;
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView2.SelectedItems[0];
                textBox11.Text = listView2.SelectedItems[0].Text;
                Models.Reserva reserva = Models.ReservasTable.GetReservaById(Int32.Parse(listView2.SelectedItems[0].Text));

                comboBox3.SelectedValue = reserva.Alojamento.Id;
                comboBox4.SelectedValue = reserva.Pessoa.Id;
                comboBox6.SelectedItem = reserva.Hospedes;

                dateTimePicker1.Value = reserva.DataCheckIn;
                dateTimePicker2.Value = reserva.DataCheckOut;
                if (reserva.Ativo == false)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }

                if (reserva.DataCheckOut < DateTime.Now)
                {
                    label37.Visible = true;
                }
                else
                {
                    label37.Visible = false;
                }

                if (reserva.CheckIN == false)
                {
                    button10.Enabled = true;
                }
                else
                {
                    button10.Enabled = false;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string id = textBox11.Text;
            if (id == "")
            {
                MessageBox.Show("Nenhuma reserva selecionada!");
            }

            Models.Reserva reserva = Models.ReservasTable.GetReservaById(Int32.Parse(id));
            if (reserva != null)
            {
                if (reserva.CheckIN)
                {
                    MessageBox.Show("Check-In já realizado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reserva.CheckIN = true;

                Models.ReservasTable.CheckInReservaNaDB(reserva);

                MessageBox.Show("Check-In realizado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button10.Enabled = false;
                LoadReservas();
            }
        }

       
    }
}
