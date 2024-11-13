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
    public partial class ListviewCheckIn : UserControl
    {
        public ListviewCheckIn()
        {
            InitializeComponent();
        }

        #region Properties
        private string _name;
        private string _desc;
        private string _checkin;
        private string _stars;
        private string _hospedes;
        private string _price;
        private Image _icon;
        private string _button;
        private string _buttonFatura;
        private Color _checkinColor;

       

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
        public string Hospedes
        {
            get { return _hospedes; }
            set { _hospedes = value; label7.Text = value; }
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

        public string ButtonFatura
        {
            get { return _buttonFatura; }
            set { _buttonFatura = value; button2.Text = value; }
        }


        public Color CheckinColor
        {
            get { return _checkinColor; }
            set
            {
                _checkinColor = value;
                label5.ForeColor = value;
            }
        }

        #endregion
    }
}
