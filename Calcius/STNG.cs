using Calcius.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calcius
{
    public partial class FormBorders : Form
    {
        public FormBorders()
        {
            InitializeComponent();
            BCDSST();
            InterfaceElements();
        }

        public void InterfaceElements()
        {
            result.BackgroundImageLayout = ImageLayout.Stretch;
            result.BackColor = Color.Transparent;
            result.FlatAppearance.BorderSize = 1;
            result.FlatStyle = FlatStyle.Flat;

            butO.BackgroundImageLayout = ImageLayout.Stretch;
            butO.BackColor = Color.Transparent;
            butO.FlatAppearance.BorderSize = 1;
            butO.FlatStyle = FlatStyle.Flat;

            point.BackgroundImageLayout = ImageLayout.Stretch;
            point.BackColor = Color.Transparent;
            point.FlatAppearance.BorderSize = 1;
            point.FlatStyle = FlatStyle.Flat;

            but000.BackgroundImageLayout = ImageLayout.Stretch;
            but000.BackColor = Color.Transparent;
            but000.FlatAppearance.BorderSize = 1;
            but000.FlatStyle = FlatStyle.Flat;

            but0.BackgroundImageLayout = ImageLayout.Stretch;
            but0.BackColor = Color.Transparent;
            but0.FlatAppearance.BorderSize = 1;
            but0.FlatStyle = FlatStyle.Flat;

            Cleaner.BackgroundImageLayout = ImageLayout.Stretch;
            Cleaner.BackColor = Color.Transparent;
            Cleaner.FlatAppearance.BorderSize = 1;
            Cleaner.FlatStyle = FlatStyle.Flat;
        }

        private void DevS_Click(object sender, EventArgs e)
        {
            Developers();
        }
        private void CloseST_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CNGNG()
        {
            BCDSST();
        }

        public void BCDSST()
        {
            Settings.Default["BCKGRND"] = CNDS.Text;
            Settings.Default.Save();

            string bck = Settings.Default["BCKGRND"].ToString();

            if (bck == "1")
            {
                SLPC.BackgroundImage = Properties.Resources.patt1 as Bitmap;
            }
            else if (bck == "2")
            {
                SLPC.BackgroundImage = Properties.Resources.patt2 as Bitmap;
            }
            else if (bck == "3")
            {
                SLPC.BackgroundImage = Properties.Resources.patt3 as Bitmap;
            }
            else if (bck == "4")
            {
                SLPC.BackgroundImage = Properties.Resources.patt4 as Bitmap;
            }
            else if (bck == "5")
            {
                SLPC.BackgroundImage = Properties.Resources.patt5 as Bitmap;
            }
            else if (bck == "Vanila")
            {
                SLPC.BackgroundImage = null;
            }

        }

        public void Developers()
        {
            DevInfo.SizeMode = PictureBoxSizeMode.StretchImage;
            
            if (DevS.Text == "allguarder")
            {
                DevInfo.Image = Properties.Resources.allg_logo as Bitmap;
            }
            else if (DevS.Text == "test")
            {
                DevInfo.Image = Properties.Resources.test_logo as Bitmap;
            }
        }

        private void CNDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNGNG();
        }

    }
}
