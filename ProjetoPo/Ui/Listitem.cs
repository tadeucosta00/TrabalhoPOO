using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPo
{
    public partial class Listitem : UserControl
    {
        public Listitem()
        {
            InitializeComponent();
        }

        #region Properties
        private string _name;
        private string _desc;
        private string _checkin;
        private string _stars;
        private string _local;
        private string _price;
        private Image _icon;
        private string _button;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Listitem_Load(object sender, EventArgs e)
        {
            label2.Location = new Point(label1.Right + 10, label1.Location.Y);
        }

        public string Titulo
        {
            get { return _name; }
            set { _name = value; label1.Text = value; }
        }

        public string Descricao
        {
            get { return _desc; }
            set { _desc = value; label3.Text = value; }
        }

        public string Local
        {
            get { return _local; }
            set { _local = value; label6.Text = value; }
        }

        public string Estrelas
        {
            get { return _stars; }
            set { _stars = value; label2.Text = value; }
        }

        public string ChekcIn
        {
            get { return _checkin; }
            set { _checkin = value; label5.Text = value; }
        }

        public string Preco
        {
            get { return _price; }
            set { _price = value; label4.Text = value; }
        }
        [Category("Custom Props")]

        public Image Imagem
        {
            get { return _icon; }
            set { _icon = value; pictureBox1.Image = value; }
        }
        public string Button
        {
            get { return _button; }
            set { _button = value; button1.Text = value; }
        }

        #endregion


    }
}