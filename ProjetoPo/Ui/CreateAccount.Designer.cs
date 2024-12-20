namespace ProjetoPo
{
    partial class CreateAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccount));
            button2 = new Button();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            txtPassCreate = new TextBox();
            txtEmailCreate = new TextBox();
            label3 = new Label();
            txtNameCreate = new TextBox();
            label4 = new Label();
            txtPhoneCreate = new TextBox();
            label5 = new Label();
            txtIdCreate = new TextBox();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            label6 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(8, 60, 148);
            button2.Font = new Font("Segoe UI", 15F);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(924, 646);
            button2.Name = "button2";
            button2.Size = new Size(172, 49);
            button2.TabIndex = 6;
            button2.Text = "Criar Conta";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(8, 60, 148);
            button1.Font = new Font("Segoe UI", 9F);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(945, 701);
            button1.Name = "button1";
            button1.Size = new Size(118, 37);
            button1.TabIndex = 7;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(688, 441);
            label2.Name = "label2";
            label2.Size = new Size(106, 28);
            label2.TabIndex = 10;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(1027, 338);
            label1.Name = "label1";
            label1.Size = new Size(69, 28);
            label1.TabIndex = 9;
            label1.Text = "Email:";
            // 
            // txtPassCreate
            // 
            txtPassCreate.Font = new Font("Segoe UI", 12F);
            txtPassCreate.Location = new Point(688, 472);
            txtPassCreate.Name = "txtPassCreate";
            txtPassCreate.Size = new Size(266, 34);
            txtPassCreate.TabIndex = 3;
            txtPassCreate.UseSystemPasswordChar = true;
            // 
            // txtEmailCreate
            // 
            txtEmailCreate.Font = new Font("Segoe UI", 12F);
            txtEmailCreate.Location = new Point(1027, 369);
            txtEmailCreate.Name = "txtEmailCreate";
            txtEmailCreate.Size = new Size(266, 34);
            txtEmailCreate.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(688, 338);
            label3.Name = "label3";
            label3.Size = new Size(74, 28);
            label3.TabIndex = 15;
            label3.Text = "Nome:";
            // 
            // txtNameCreate
            // 
            txtNameCreate.Font = new Font("Segoe UI", 12F);
            txtNameCreate.Location = new Point(688, 369);
            txtNameCreate.Name = "txtNameCreate";
            txtNameCreate.Size = new Size(265, 34);
            txtNameCreate.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(1027, 441);
            label4.Name = "label4";
            label4.Size = new Size(113, 28);
            label4.TabIndex = 17;
            label4.Text = "Telemovel:";
            // 
            // txtPhoneCreate
            // 
            txtPhoneCreate.Font = new Font("Segoe UI", 12F);
            txtPhoneCreate.Location = new Point(1027, 472);
            txtPhoneCreate.Name = "txtPhoneCreate";
            txtPhoneCreate.Size = new Size(266, 34);
            txtPhoneCreate.TabIndex = 4;
            txtPhoneCreate.KeyPress += txtPhoneCreate_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(688, 536);
            label5.Name = "label5";
            label5.Size = new Size(151, 28);
            label5.TabIndex = 19;
            label5.Text = "Documento Id:";
            // 
            // txtIdCreate
            // 
            txtIdCreate.Font = new Font("Segoe UI", 12F);
            txtIdCreate.Location = new Point(688, 567);
            txtIdCreate.Name = "txtIdCreate";
            txtIdCreate.Size = new Size(265, 34);
            txtIdCreate.TabIndex = 5;
            txtIdCreate.KeyPress += txtIdCreate_KeyPress;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(8, 60, 148);
            panel2.Controls.Add(pictureBox2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1559, 168);
            panel2.TabIndex = 20;
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label6.Location = new Point(881, 249);
            label6.Name = "label6";
            label6.Size = new Size(162, 37);
            label6.TabIndex = 21;
            label6.Text = "Criar Conta";
            // 
            // CreateAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1559, 853);
            Controls.Add(label6);
            Controls.Add(panel2);
            Controls.Add(label5);
            Controls.Add(txtIdCreate);
            Controls.Add(label4);
            Controls.Add(txtPhoneCreate);
            Controls.Add(label3);
            Controls.Add(txtNameCreate);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassCreate);
            Controls.Add(txtEmailCreate);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateAccount";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Criar Conta";
            WindowState = FormWindowState.Maximized;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private Label label2;
        private Label label1;
        private TextBox txtPassCreate;
        private TextBox txtEmailCreate;
        private Label label3;
        private TextBox txtNameCreate;
        private Label label4;
        private TextBox txtPhoneCreate;
        private Label label5;
        private TextBox txtIdCreate;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Label label6;
    }
}