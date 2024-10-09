using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace DeteccionBordes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string imagePath = ofd.FileName;
                Image<Bgr, byte> imagenOriginal = new Image<Bgr, byte>(imagePath);

                // Convertir a escala de grises
                Image<Gray, byte> imagenGris = imagenOriginal.Convert<Gray, byte>();

                // Aplicar el filtro de Sobel para detectar bordes
                Image<Gray, float> sobel = imagenGris.Sobel(1, 1, 3);

                // Mostrar la imagen original y la imagen con bordes detectados
                pictureBoxOriginal.Image = imagenOriginal.ToBitmap();
                pictureBoxBordes.Image = sobel.ToBitmap();
            }
        }
    }
}
