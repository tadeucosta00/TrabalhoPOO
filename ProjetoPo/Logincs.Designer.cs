namespace ProjetoPo
{
    partial class Logincs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logincs));
            txtEmailLogin = new TextBox();
            txtPassLogin = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtEmailLogin
            // 
            txtEmailLogin.Font = new Font("Segoe UI", 12F);
            txtEmailLogin.Location = new Point(57, 105);
            txtEmailLogin.Name = "txtEmailLogin";
            txtEmailLogin.Size = new Size(348, 34);
            txtEmailLogin.TabIndex = 0;
            // 
            // txtPassLogin
            // 
            txtPassLogin.Font = new Font("Segoe UI", 12F);
            txtPassLogin.Location = new Point(57, 196);
            txtPassLogin.Name = "txtPassLogin";
            txtPassLogin.Size = new Size(348, 34);
            txtPassLogin.TabIndex = 1;
            txtPassLogin.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(55, 74);
            label1.Name = "label1";
            label1.Size = new Size(69, 28);
            label1.TabIndex = 2;
            label1.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(57, 165);
            label2.Name = "label2";
            label2.Size = new Size(106, 28);
            label2.TabIndex = 3;
            label2.Text = "Password:";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(8, 60, 148);
            button1.Font = new Font("Segoe UI", 15F);
            button1.ForeColor = SystemColors.Window;
            button1.Location = new Point(154, 264);
            button1.Name = "button1";
            button1.Size = new Size(157, 60);
            button1.TabIndex = 4;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(8, 60, 148);
            button2.Font = new Font("Segoe UI", 11F);
            button2.ForeColor = SystemColors.Window;
            button2.Location = new Point(170, 332);
            button2.Name = "button2";
            button2.Size = new Size(124, 43);
            button2.TabIndex = 6;
            button2.Text = "Criar Conta";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(8, 60, 148);
            panel2.Controls.Add(pictureBox2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1671, 168);
            panel2.TabIndex = 7;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(183, 47);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(264, 85);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.Location = new Point(57, 21);
            label3.Name = "label3";
            label3.Size = new Size(348, 35);
            label3.TabIndex = 8;
            label3.Text = "Faça login ou crie uma conta";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtEmailLogin);
            panel1.Controls.Add(txtPassLogin);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(754, 302);
            panel1.Name = "panel1";
            panel1.Size = new Size(463, 470);
            panel1.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.Controls.Add(label4);
            panel3.Controls.Add(pictureBox1);
            panel3.Location = new Point(57, 59);
            panel3.Name = "panel3";
            panel3.Size = new Size(348, 267);
            panel3.TabIndex = 10;
            panel3.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label4.Location = new Point(105, 205);
            label4.Name = "label4";
            label4.Size = new Size(149, 35);
            label4.TabIndex = 1;
            label4.Text = "A analizar...";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(86, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(178, 172);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(8, 60, 148);
            button3.Font = new Font("Segoe UI", 11F);
            button3.ForeColor = SystemColors.Window;
            button3.Location = new Point(170, 381);
            button3.Name = "button3";
            button3.Size = new Size(124, 43);
            button3.TabIndex = 9;
            button3.Text = "FaceID";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Logincs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1671, 809);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "Logincs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtEmailLogin;
        private TextBox txtPassLogin;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Label label3;
        private Panel panel1;
        private Button button3;
        private Panel panel3;
        private Label label4;
        private PictureBox pictureBox1;
    }
}