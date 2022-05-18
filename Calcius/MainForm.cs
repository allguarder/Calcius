using Calcius.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Calcius
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            Background();
            BtnIn();
            InterfaceElements();
        }

        

        public void BtnIn()
        {
            but0.Click += Keypad_Click;
            but1.Click += Keypad_Click;
            but2.Click += Keypad_Click;
            but3.Click += Keypad_Click;
            but4.Click += Keypad_Click;
            but5.Click += Keypad_Click;
            but6.Click += Keypad_Click;
            but7.Click += Keypad_Click;
            but8.Click += Keypad_Click;
            but9.Click += Keypad_Click;
            but000.Click += Keypad_Click;

            butI1I.Click += Keypad_Click;
            butI2I.Click += Keypad_Click;
            butminus.Click += Keypad_Click;
            butplus.Click += Keypad_Click;
            butslesh.Click += Keypad_Click;
            butO.Click += Keypad_Click;
            point.Click += Keypad_Click;
        }

        public void Keypad_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "but0":
                    display.Text += but0.Text;
                    break;

                case "but1":
                    display.Text += but1.Text;
                    break;

                case "but2":
                    display.Text += but2.Text;
                    break;

                case "but3":
                    display.Text += but3.Text;
                    break;

                case "but4":
                    display.Text += but4.Text;
                    break;

                case "but5":
                    display.Text += but5.Text;
                    break;

                case "but6":
                    display.Text += but6.Text;
                    break;

                case "but7":
                    display.Text += but7.Text;
                    break;

                case "but8":
                    display.Text += but8.Text;
                    break;

                case "but9":
                    display.Text += but9.Text;
                    break;

                case "but000":
                    display.Text += but000.Text;
                    break;

                case "butI1I":
                    display.Text += butI1I.Text;
                    break;

                case "butI2I":
                    display.Text += butI2I.Text;
                    break;

                case "butminus":
                    display.Text += butminus.Text;
                    break;

                case "butplus":
                    display.Text += butplus.Text;
                    break;

                case "butslesh":
                    display.Text += butslesh.Text;
                    break;

                case "butO":
                    display.Text += "*";
                    break;

                case "point":
                    display.Text += ".";
                    break;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tickdriver.Enabled = true;
        }

        public void Background()
        {
            string bck = Settings.Default["BCKGRND"].ToString();

            if (bck == "1")
            {
                this.BackgroundImage = Properties.Resources.patt1 as Bitmap;
            }
            else if (bck == "2")
            {
                this.BackgroundImage = Properties.Resources.patt2 as Bitmap;
            }
            else if (bck == "3")
            {
                this.BackgroundImage = Properties.Resources.patt3 as Bitmap;
            }
            else if (bck == "4")
            {
                this.BackgroundImage = Properties.Resources.patt4 as Bitmap;
            }
            else if (bck == "5")
            {
                this.BackgroundImage = Properties.Resources.patt5 as Bitmap;
            }
            else if (bck == "Vanila")
            {
                this.BackgroundImage = null;
            }
        }



        public void Reloading()
        {
            Background();
        }

        private void result_Click(object sender, EventArgs e)
        {
            Calc();
        }

        private void Calc()
        {
            if (!string.IsNullOrEmpty(",") && !string.IsNullOrEmpty("."))

                if (!string.IsNullOrEmpty(display.Text))
                {
                    display.Text = Regex.Replace(display.Text, ",", ".");
                }

            try
            {
                string a;
                a = display.Text;
                DataTable dt = new DataTable();
                var v = dt.Compute(a, a);
                display.Clear();
                display.Text += v;
            }
            catch
            {
                error();
            }
        }

        public void error()
        {
            display.Clear();
            display.Text = "ERROR!";
        }

        void result_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                result_Click(result, null);
            }
        }

        private void Cleaner_Click(object sender, EventArgs e)
        {
            display.Clear();
        }

        private void display_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && (e.KeyChar <= 39 || e.KeyChar >= 46) && number != 47 && number != 61) //калькулятор
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)13)
            {
                Calc();
            }
        }

        private void tickdriver_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(",") && !string.IsNullOrEmpty("."))

                if (!string.IsNullOrEmpty(display.Text))
                {
                    display.Text = Regex.Replace(display.Text, ",", ".");
                }



            if (!string.IsNullOrEmpty("∞") && !string.IsNullOrEmpty("∞"))
                if (!string.IsNullOrEmpty(display.Text))
                {
                    display.Text = Regex.Replace(display.Text, "∞", "ZERROR!");
                }
        }

        private void STNGS_Click(object sender, EventArgs e)
        {
            Form stn = new FormBorders();
            stn.ShowDialog();

            Reloading();
        }

        public void InterfaceElements()
        {
            STNGS.BackgroundImageLayout = ImageLayout.Stretch;
            STNGS.BackColor = Color.Transparent;
            STNGS.FlatAppearance.BorderSize = 0;
            STNGS.FlatStyle = FlatStyle.Flat;

            result.BackgroundImageLayout = ImageLayout.Stretch;
            result.BackColor = Color.Transparent;
            result.FlatAppearance.BorderSize = 1;
            result.FlatStyle = FlatStyle.Flat;

            butI2I.BackgroundImageLayout = ImageLayout.Stretch;
            butI2I.BackColor = Color.Transparent;
            butI2I.FlatAppearance.BorderSize = 1;
            butI2I.FlatStyle = FlatStyle.Flat;

            butI1I.BackgroundImageLayout = ImageLayout.Stretch;
            butI1I.BackColor = Color.Transparent;
            butI1I.FlatAppearance.BorderSize = 1;
            butI1I.FlatStyle = FlatStyle.Flat;

            butminus.BackgroundImageLayout = ImageLayout.Stretch;
            butminus.BackColor = Color.Transparent;
            butminus.FlatAppearance.BorderSize = 1;
            butminus.FlatStyle = FlatStyle.Flat;

            butplus.BackgroundImageLayout = ImageLayout.Stretch;
            butplus.BackColor = Color.Transparent;
            butplus.FlatAppearance.BorderSize = 1;
            butplus.FlatStyle = FlatStyle.Flat;

            butslesh.BackgroundImageLayout = ImageLayout.Stretch;
            butslesh.BackColor = Color.Transparent;
            butslesh.FlatAppearance.BorderSize = 1;
            butslesh.FlatStyle = FlatStyle.Flat;

            butO.BackgroundImageLayout = ImageLayout.Stretch;
            butO.BackColor = Color.Transparent;
            butO.FlatAppearance.BorderSize = 1;
            butO.FlatStyle = FlatStyle.Flat;

            point.BackgroundImageLayout = ImageLayout.Stretch;
            point.BackColor = Color.Transparent;
            point.FlatAppearance.BorderSize = 1;
            point.FlatStyle = FlatStyle.Flat;

            but9.BackgroundImageLayout = ImageLayout.Stretch;
            but9.BackColor = Color.Transparent;
            but9.FlatAppearance.BorderSize = 1;
            but9.FlatStyle = FlatStyle.Flat;

            Cleaner.BackgroundImageLayout = ImageLayout.Stretch;
            Cleaner.BackColor = Color.Transparent;
            Cleaner.FlatAppearance.BorderSize = 1;
            Cleaner.FlatStyle = FlatStyle.Flat;

            but8.BackgroundImageLayout = ImageLayout.Stretch;
            but8.BackColor = Color.Transparent;
            but8.FlatAppearance.BorderSize = 1;
            but8.FlatStyle = FlatStyle.Flat;

            but7.BackgroundImageLayout = ImageLayout.Stretch;
            but7.BackColor = Color.Transparent;
            but7.FlatAppearance.BorderSize = 1;
            but7.FlatStyle = FlatStyle.Flat;

            but6.BackgroundImageLayout = ImageLayout.Stretch;
            but6.BackColor = Color.Transparent;
            but6.FlatAppearance.BorderSize = 1;
            but6.FlatStyle = FlatStyle.Flat;

            but5.BackgroundImageLayout = ImageLayout.Stretch;
            but5.BackColor = Color.Transparent;
            but5.FlatAppearance.BorderSize = 1;
            but5.FlatStyle = FlatStyle.Flat;

            but4.BackgroundImageLayout = ImageLayout.Stretch;
            but4.BackColor = Color.Transparent;
            but4.FlatAppearance.BorderSize = 1;
            but4.FlatStyle = FlatStyle.Flat;

            but3.BackgroundImageLayout = ImageLayout.Stretch;
            but3.BackColor = Color.Transparent;
            but3.FlatAppearance.BorderSize = 1;
            but3.FlatStyle = FlatStyle.Flat;

            but2.BackgroundImageLayout = ImageLayout.Stretch;
            but2.BackColor = Color.Transparent;
            but2.FlatAppearance.BorderSize = 1;
            but2.FlatStyle = FlatStyle.Flat;

            but1.BackgroundImageLayout = ImageLayout.Stretch;
            but1.BackColor = Color.Transparent;
            but1.FlatAppearance.BorderSize = 1;
            but1.FlatStyle = FlatStyle.Flat;

            but0.BackgroundImageLayout = ImageLayout.Stretch;
            but0.BackColor = Color.Transparent;
            but0.FlatAppearance.BorderSize = 1;
            but0.FlatStyle = FlatStyle.Flat;

            but000.BackgroundImageLayout = ImageLayout.Stretch;
            but000.BackColor = Color.Transparent;
            but000.FlatAppearance.BorderSize = 1;
            but000.FlatStyle = FlatStyle.Flat;
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (display.Text == string.Empty) 
            {
            //I'm air, go away human!
            }
            else
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    DialogResult res = MessageBox.Show("Exit Calcius?", "Unsaved data detected!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else if (res == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }

            }
            return;
        }
    }
}
