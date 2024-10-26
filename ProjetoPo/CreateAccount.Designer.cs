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
            pictureBox1 = new PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 15F);
            button2.Location = new Point(185, 441);
            button2.Name = "button2";
            button2.Size = new Size(172, 49);
            button2.TabIndex = 6;
            button2.Text = "Criar Conta";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(230, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(72, 68);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F);
            button1.Location = new Point(206, 496);
            button1.Name = "button1";
            button1.Size = new Size(118, 37);
            button1.TabIndex = 7;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(118, 300);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 10;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(150, 252);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 9;
            label1.Text = "Email:";
            // 
            // txtPassCreate
            // 
            txtPassCreate.Location = new Point(207, 297);
            txtPassCreate.Name = "txtPassCreate";
            txtPassCreate.Size = new Size(188, 27);
            txtPassCreate.TabIndex = 3;
            txtPassCreate.UseSystemPasswordChar = true;
            // 
            // txtEmailCreate
            // 
            txtEmailCreate.Location = new Point(206, 249);
            txtEmailCreate.Name = "txtEmailCreate";
            txtEmailCreate.Size = new Size(188, 27);
            txtEmailCreate.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(150, 203);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 15;
            label3.Text = "Nome:";
            // 
            // txtNameCreate
            // 
            txtNameCreate.Location = new Point(206, 200);
            txtNameCreate.Name = "txtNameCreate";
            txtNameCreate.Size = new Size(188, 27);
            txtNameCreate.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(118, 349);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 17;
            label4.Text = "Telemovel:";
            // 
            // txtPhoneCreate
            // 
            txtPhoneCreate.Location = new Point(207, 346);
            txtPhoneCreate.Name = "txtPhoneCreate";
            txtPhoneCreate.Size = new Size(188, 27);
            txtPhoneCreate.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(96, 388);
            label5.Name = "label5";
            label5.Size = new Size(107, 20);
            label5.TabIndex = 19;
            label5.Text = "Documento Id:";
            // 
            // txtIdCreate
            // 
            txtIdCreate.Location = new Point(208, 385);
            txtIdCreate.Name = "txtIdCreate";
            txtIdCreate.Size = new Size(188, 27);
            txtIdCreate.TabIndex = 5;
            // 
            // CreateAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 617);
            Controls.Add(label5);
            Controls.Add(txtIdCreate);
            Controls.Add(label4);
            Controls.Add(txtPhoneCreate);
            Controls.Add(label3);
            Controls.Add(txtNameCreate);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassCreate);
            Controls.Add(txtEmailCreate);
            Name = "CreateAccount";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateAccount";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private PictureBox pictureBox1;
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
    }
}