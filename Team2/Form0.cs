using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2
{
    public partial class Form0 : Form
    {
        public static bool admin = false;
        public Form0()
        {
            InitializeComponent();
            Splash sf = new Splash();
            sf.ShowDialog();
        }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                label3.Visible = true;
                textBox2.Visible = true;
                admin = true;
            }
            else
            {
                label3.Visible = false;
                textBox2.Visible = false;
                admin = false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (admin == true)
            {
                string path = Application.StartupPath;
                FileInfo file = new FileInfo(path + "/Text.txt");
                if (file.Exists)
                {
                    StreamReader sr = new StreamReader(path + "/Text.txt");
                    if (textBox2.Text == sr.ReadLine())
                    {
                        sr.Close();
                        Form1 f2 = new Form1(admin);
                        f2.Show();
                        this.Hide();
                    }
                    else
                    {
                        sr.Close();
                        MessageBox.Show("Неверный пароль");
                    }
                }
                else
                {
                    file.Create();
                    MessageBox.Show("Укажите пароль в документе");
                }

            }
            else
            {
                Form1 f2 = new Form1(false);
                f2.Show();
                this.Hide();
            }
        }
    }
}
