using PictureManipulator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureManipulatorFormsApp
{
    public partial class PictureManipulatorForm : Form
    {
        public string PictureAdress { get; set; }
        public string ConvertedPictureAdress { get; set; }
        public PictureManipulatorForm()
        {
            InitializeComponent();
            btnConvert.Visible = false;
            btnSave.Visible = false;
        }

        private void BtnImportPicture_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PictureAdress = openFileDialog.FileName;
                Picture picture = new Picture(PictureAdress);
                pbSourcePicture.Image = picture.Bitmap;
                if (picture.Bitmap != null)
                {
                    btnConvert.Visible = true;
                }
                else
                {
                    MessageBox.Show("Image is too large");
                }
            }
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            if (rbGrayscale.Checked)
            {
                Picture picture = new Picture(PictureAdress);
                picture.ConvertPictureToGrayscale();
                pbConvertedPicture.Image = picture.Bitmap;
                ConvertedPictureAdress = picture.PictureAdressCopy;

            }

            else if (rbNegative.Checked)
            {
                Picture picture = new Picture(PictureAdress);
                picture.ConvertPictureToNegative();
                pbConvertedPicture.Image = picture.Bitmap;
                ConvertedPictureAdress = picture.PictureAdressCopy;


            }

            else if (rbBlurr.Checked)
            {
                Picture picture = new Picture(PictureAdress);
                picture.ConvertPictureToBlurr();
                pbConvertedPicture.Image = picture.Bitmap;
                ConvertedPictureAdress = picture.PictureAdressCopy;
            }
            btnSave.Visible = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            pbConvertedPicture.Image.Save(ConvertedPictureAdress);
        }
    }
}
