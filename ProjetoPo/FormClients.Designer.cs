namespace ProjetoPo
{
    partial class FormClients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClients));
            panel2 = new Panel();
            label6 = new Label();
            label5 = new Label();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            panel3 = new Panel();
            comboBox1 = new ComboBox();
            label15 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            label14 = new Label();
            textBox3 = new TextBox();
            label13 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            button1 = new Button();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            textBox1 = new TextBox();
            label11 = new Label();
            textBox2 = new TextBox();
            checkedListBox2 = new CheckedListBox();
            panel4 = new Panel();
            checkedListBox1 = new CheckedListBox();
            label12 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(8, 60, 148);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(pictureBox2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1696, 150);
            panel2.TabIndex = 1;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 12F);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Image = (Image)resources.GetObject("label6.Image");
            label6.ImageAlign = ContentAlignment.MiddleLeft;
            label6.Location = new Point(301, 115);
            label6.Name = "label6";
            label6.Size = new Size(90, 21);
            label6.TabIndex = 2;
            label6.Text = "Estadias";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 12F);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Image = (Image)resources.GetObject("label5.Image");
            label5.ImageAlign = ContentAlignment.MiddleLeft;
            label5.Location = new Point(160, 114);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.No;
            label5.Size = new Size(118, 21);
            label5.TabIndex = 1;
            label5.Text = "Alojamentos";
            label5.TextAlign = ContentAlignment.TopRight;
            label5.Click += label5_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(160, 35);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(231, 64);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Location = new Point(367, 225);
            panel1.Name = "panel1";
            panel1.Size = new Size(1244, 625);
            panel1.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.AutoScrollMargin = new Size(0, 200);
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(dateTimePicker2);
            panel3.Controls.Add(dateTimePicker1);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(flowLayoutPanel1);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(webView21);
            panel3.Controls.Add(pictureBox1);
            panel3.Location = new Point(367, 225);
            panel3.Name = "panel3";
            panel3.Size = new Size(1244, 625);
            panel3.TabIndex = 4;
            panel3.Tag = "";
            panel3.Visible = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(775, 303);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 43;
            comboBox1.Text = "Pessoas";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label15.Location = new Point(525, 306);
            label15.Name = "label15";
            label15.Size = new Size(15, 20);
            label15.TabIndex = 42;
            label15.Text = "-";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(546, 303);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 41;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Location = new Point(319, 303);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 40;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label14.Location = new Point(319, 280);
            label14.Name = "label14";
            label14.Size = new Size(53, 20);
            label14.TabIndex = 39;
            label14.Text = "Datas:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(37, 44);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 38;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label13.Location = new Point(319, 393);
            label13.Name = "label13";
            label13.Size = new Size(108, 20);
            label13.TabIndex = 37;
            label13.Text = "Comodidades:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Location = new Point(319, 416);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(630, 34);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(904, 70);
            label7.Name = "label7";
            label7.Size = new Size(52, 21);
            label7.TabIndex = 6;
            label7.Text = "label7";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(483, 95);
            label4.Name = "label4";
            label4.Size = new Size(540, 152);
            label4.TabIndex = 5;
            label4.Text = "label4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(483, 65);
            label3.Name = "label3";
            label3.Size = new Size(52, 21);
            label3.TabIndex = 4;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 25F);
            label2.Location = new Point(483, 10);
            label2.Name = "label2";
            label2.Size = new Size(109, 46);
            label2.TabIndex = 3;
            label2.Text = "Name";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(8, 60, 148);
            button1.FlatAppearance.BorderColor = Color.FromArgb(8, 60, 148);
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe UI", 12F);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(904, 18);
            button1.Name = "button1";
            button1.Size = new Size(119, 49);
            button1.TabIndex = 2;
            button1.Text = "Reserve agora";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(319, 461);
            webView21.Name = "webView21";
            webView21.Size = new Size(630, 242);
            webView21.TabIndex = 1;
            webView21.ZoomFactor = 1D;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(197, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(267, 230);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F);
            label1.Location = new Point(367, 176);
            label1.Name = "label1";
            label1.Size = new Size(214, 46);
            label1.TabIndex = 3;
            label1.Text = "Alojamentos:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(13, 267);
            label8.Name = "label8";
            label8.Size = new Size(81, 15);
            label8.TabIndex = 5;
            label8.Text = "Comodidades";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label9.Location = new Point(13, 17);
            label9.Name = "label9";
            label9.Size = new Size(105, 28);
            label9.TabIndex = 7;
            label9.Text = "Filtar por:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.Location = new Point(13, 448);
            label10.Name = "label10";
            label10.Size = new Size(164, 15);
            label10.TabIndex = 8;
            label10.Text = "O seu orçamento (por noite)";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(13, 475);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 9;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(13, 514);
            label11.Name = "label11";
            label11.Size = new Size(25, 15);
            label11.TabIndex = 10;
            label11.Text = "ate";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(13, 541);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 11;
            // 
            // checkedListBox2
            // 
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Items.AddRange(new object[] { "Piscina", "Ginasio", "Estacionamento", "Wi-Fi gratuito", "Lavanderia", "Spa" });
            checkedListBox2.Location = new Point(13, 285);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new Size(155, 130);
            checkedListBox2.TabIndex = 34;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(checkedListBox1);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(checkedListBox2);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(textBox2);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(textBox1);
            panel4.Location = new Point(160, 225);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 625);
            panel4.TabIndex = 35;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Hotel", "Hostel", "Apartamento", "Casa", "Resort" });
            checkedListBox1.Location = new Point(13, 98);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(155, 130);
            checkedListBox1.TabIndex = 36;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.Location = new Point(13, 80);
            label12.Name = "label12";
            label12.Size = new Size(119, 15);
            label12.TabIndex = 35;
            label12.Text = "Tipo de propriedade";
            // 
            // FormClients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1696, 862);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormClients";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormClients";
            WindowState = FormWindowState.Maximized;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel2;
        private Panel panel1;
        private Label label1;
        private Panel panel3;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button button1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label6;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBox1;
        private Label label11;
        private TextBox textBox2;
        private CheckedListBox checkedListBox2;
        private Panel panel4;
        private CheckedListBox checkedListBox1;
        private Label label12;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label13;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker1;
        private Label label14;
        private ComboBox comboBox1;
        private Label label15;
        private DateTimePicker dateTimePicker2;
    }
}