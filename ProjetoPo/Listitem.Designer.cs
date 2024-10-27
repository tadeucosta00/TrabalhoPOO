namespace ProjetoPo
{
    partial class Listitem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F);
            label1.Location = new Point(275, 32);
            label1.Name = "label1";
            label1.Size = new Size(109, 46);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlLight;
            pictureBox1.Location = new Point(27, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(187, 219);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(378, 41);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(244, 94);
            label3.Name = "label3";
            label3.Size = new Size(741, 111);
            label3.TabIndex = 3;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20F);
            label4.Location = new Point(1049, 41);
            label4.Name = "label4";
            label4.Size = new Size(62, 37);
            label4.TabIndex = 4;
            label4.Text = "50€";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(8, 60, 148);
            button1.FlatAppearance.BorderColor = Color.FromArgb(8, 60, 148);
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe UI", 15F);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(1049, 94);
            button1.Name = "button1";
            button1.Size = new Size(117, 43);
            button1.TabIndex = 5;
            button1.Text = "Ver";
            button1.UseVisualStyleBackColor = false;
            // 
            // Listitem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "Listitem";
            Size = new Size(1195, 225);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
    }
}
