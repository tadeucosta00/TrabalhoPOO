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
            pictureBox1 = new PictureBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtEmailLogin
            // 
            txtEmailLogin.Location = new Point(132, 167);
            txtEmailLogin.Name = "txtEmailLogin";
            txtEmailLogin.Size = new Size(188, 27);
            txtEmailLogin.TabIndex = 0;
            // 
            // txtPassLogin
            // 
            txtPassLogin.Location = new Point(132, 232);
            txtPassLogin.Name = "txtPassLogin";
            txtPassLogin.Size = new Size(188, 27);
            txtPassLogin.TabIndex = 1;
            txtPassLogin.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 170);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 2;
            label1.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 235);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 3;
            label2.Text = "Password:";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(132, 294);
            button1.Name = "button1";
            button1.Size = new Size(129, 45);
            button1.TabIndex = 4;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(156, 38);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(72, 68);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(151, 348);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 6;
            button2.Text = "Criar Conta";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Logincs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 418);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassLogin);
            Controls.Add(txtEmailLogin);
            Name = "Logincs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmailLogin;
        private TextBox txtPassLogin;
        private Label label1;
        private Label label2;
        private Button button1;
        private PictureBox pictureBox1;
        private Button button2;
    }
}