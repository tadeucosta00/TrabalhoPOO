using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoPo
{
    public partial class FormViewImage : Form
    {

        public FormViewImage(string imagem)
        {
            InitializeComponent();
            pictureBox1.Image = System.Drawing.Image.FromFile(imagem);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
