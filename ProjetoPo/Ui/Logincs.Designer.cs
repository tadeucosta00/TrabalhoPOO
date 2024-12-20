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
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtEmailLogin
            // 
            txtEmailLogin.Font = new Font("Segoe UI", 12F);
            txtEmailLogin.Location = new Point(57, 121);
            txtEmailLogin.Name = "txtEmailLogin";
            txtEmailLogin.Size = new Size(348, 34);
            txtEmailLogin.TabIndex = 0;
            // 
            // txtPassLogin
            // 
            txtPassLogin.Font = new Font("Segoe UI", 12F);
            txtPassLogin.Location = new Point(57, 212);
            txtPassLogin.Name = "txtPassLogin";
            txtPassLogin.Size = new Size(348, 34);
            txtPassLogin.TabIndex = 1;
            txtPassLogin.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(55, 90);
            label1.Name = "label1";
            label1.Size = new Size(69, 28);
            label1.TabIndex = 2;
            label1.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(57, 181);
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
            button1.Location = new Point(154, 280);
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
            button2.Location = new Point(170, 348);
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
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label3.Location = new Point(55, 21);
            label3.Name = "label3";
            label3.Size = new Size(382, 37);
            label3.TabIndex = 8;
            label3.Text = "Faça login ou crie uma conta";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            // Logincs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1671, 809);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Logincs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            Load += Logincs_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
    }
}