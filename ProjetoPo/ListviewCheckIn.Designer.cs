namespace ProjetoPo
{
    partial class ListviewCheckIn
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            label5 = new Label();
            button1 = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label6 = new Label();
            label7 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(770, 137);
            label5.Name = "label5";
            label5.Size = new Size(0, 25);
            label5.TabIndex = 13;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(8, 60, 148);
            button1.FlatAppearance.BorderColor = Color.FromArgb(8, 60, 148);
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe UI", 15F);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(1132, 224);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(134, 57);
            button1.TabIndex = 12;
            button1.Text = "Check-In";
            button1.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 17F);
            label4.Location = new Point(1132, 137);
            label4.Name = "label4";
            label4.Size = new Size(65, 40);
            label4.TabIndex = 11;
            label4.Text = "50€";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(378, 124);
            label3.Name = "label3";
            label3.Size = new Size(540, 87);
            label3.TabIndex = 10;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(378, 65);
            label2.Name = "label2";
            label2.Size = new Size(71, 30);
            label2.TabIndex = 9;
            label2.Text = "label2";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlLight;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(214, 269);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F);
            label1.Location = new Point(260, 53);
            label1.Name = "label1";
            label1.Size = new Size(136, 57);
            label1.TabIndex = 7;
            label1.Text = "label1";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label6.Location = new Point(1132, 85);
            label6.Name = "label6";
            label6.Size = new Size(108, 46);
            label6.TabIndex = 14;
            label6.Text = "Total:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F);
            label7.Location = new Point(378, 186);
            label7.Name = "label7";
            label7.Size = new Size(63, 25);
            label7.TabIndex = 15;
            label7.Text = "label7";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(8, 60, 148);
            button2.FlatAppearance.BorderColor = Color.FromArgb(8, 60, 148);
            button2.FlatAppearance.BorderSize = 0;
            button2.Font = new Font("Segoe UI", 15F);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(976, 224);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(134, 57);
            button2.TabIndex = 16;
            button2.Text = "Fatura";
            button2.UseVisualStyleBackColor = false;
            // 
            // ListviewCheckIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(button2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "ListviewCheckIn";
            Size = new Size(1366, 300);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Button button1;
        private Label label4;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label6;
        private Label label7;
        private Button button2;
    }
}
