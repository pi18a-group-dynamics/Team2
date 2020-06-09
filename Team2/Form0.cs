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
using System.Xml;

namespace Team2
{
    
    public partial class Form0 : Form
    {
        AS access = new AS();
        public static bool admin = false;
        public static bool access_control = false;
        public static bool user = false;
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
                label3.Text = "Администратор";
                label3.Visible = true;
                checkBox4.Visible = false;
                checkBox2.Visible = false;
                textBox2.Visible = true;
                checkBox3.Visible = false;
                admin = true;
            }
            else
            {
                label3.Visible = false;
                textBox2.Visible = false;
                checkBox2.Visible = true;
                checkBox4.Visible = true;
                checkBox3.Visible = true;
                admin = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.OutputEncoding = Encoding.Unicode;
            if (admin == true)
            {

                if (textBox2.Text == "fredy777")
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\Access.xml");
                    XmlElement xRoot = xDoc.DocumentElement;
                    XmlElement newFA = xDoc.CreateElement("log_in");
                    newFA.SetAttribute("pas", textBox2.Text + " - admin flag");
                    XmlElement newPM = xDoc.CreateElement("Time");
                    newPM.SetAttribute("Time", DateTime.Now.ToString());
                    newFA.AppendChild(newPM);
                    xRoot.AppendChild(newFA);
                    xDoc.Save("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\Access.xml");
                    Form1 f2 = new Form1(admin);
                    f2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\FailedAccess.xml");
                    XmlElement xRoot = xDoc.DocumentElement;
                    XmlElement newFA = xDoc.CreateElement("Try");
                    newFA.SetAttribute("try", textBox2.Text + " - admin flag");
                    XmlElement newPM = xDoc.CreateElement("Time");
                    newPM.SetAttribute("Time", DateTime.Now.ToString());
                    newFA.AppendChild(newPM);
                    xRoot.AppendChild(newFA);
                    xDoc.Save("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\FailedAccess.xml");
                }
            }
            if(user == true)
            {
                if (textBox2.Text == access.u1 || textBox2.Text == access.u2 || textBox2.Text == access.u3)
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\Access.xml");
                    XmlElement xRoot = xDoc.DocumentElement;
                    XmlElement newFA = xDoc.CreateElement("log_in");
                    newFA.SetAttribute("pas", textBox2.Text + " - user flag");
                    XmlElement newPM = xDoc.CreateElement("Time");
                    newPM.SetAttribute("Time", DateTime.Now.ToString());
                    newFA.AppendChild(newPM);
                    xRoot.AppendChild(newFA);
                    xDoc.Save("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\Access.xml");
                    Form1 f2 = new Form1(admin);
                    f2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\FailedAccess.xml");
                    XmlElement xRoot = xDoc.DocumentElement;
                    XmlElement newFA = xDoc.CreateElement("Try");
                    newFA.SetAttribute("try", textBox2.Text + " - user flag");
                    XmlElement newPM = xDoc.CreateElement("Time");
                    newPM.SetAttribute("Time", DateTime.Now.ToString());
                    newFA.AppendChild(newPM);
                    xRoot.AppendChild(newFA);
                    xDoc.Save("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\FailedAccess.xml");
                }
            }
            if(access_control == true)
            {
                
                    if (textBox2.Text == "access1" && checkBox2.CheckState == CheckState.Checked)
                    {
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.Load("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\Access.xml");
                        XmlElement xRoot = xDoc.DocumentElement;
                        XmlElement newFA = xDoc.CreateElement("log_in");
                        newFA.SetAttribute("pas", textBox2.Text + " - read mode flag");
                        XmlElement newPM = xDoc.CreateElement("Time");
                        newPM.SetAttribute("Time", DateTime.Now.ToString());
                        newFA.AppendChild(newPM);
                        xRoot.AppendChild(newFA);
                        xDoc.Save("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\Access.xml");
                        Form2 fom2 = new Form2();
                        fom2.Show();
                        this.Hide();
                    }
                    else
                    {
                        if (textBox2.Text == "access2" && checkBox3.CheckState == CheckState.Checked)
                        {
                            XmlDocument xDoc = new XmlDocument();
                            xDoc.Load("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\Access.xml");
                            XmlElement xRoot = xDoc.DocumentElement;
                            XmlElement newFA = xDoc.CreateElement("log_in");
                            newFA.SetAttribute("pas", textBox2.Text + " - read mode flag");
                            XmlElement newPM = xDoc.CreateElement("Time");
                            newPM.SetAttribute("Time", DateTime.Now.ToString());
                            newFA.AppendChild(newPM);
                            xRoot.AppendChild(newFA);
                            xDoc.Save("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\Access.xml");
                            Form3 fom3 = new Form3();
                            fom3.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль");
                            XmlDocument xDoc = new XmlDocument();
                            xDoc.Load("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\FailedAccess.xml");
                            XmlElement xRoot = xDoc.DocumentElement;
                            XmlElement newFA = xDoc.CreateElement("Try");
                            newFA.SetAttribute("try", textBox2.Text + " - read mode flag");
                            XmlElement newPM = xDoc.CreateElement("Time");
                            newPM.SetAttribute("Time", DateTime.Now.ToString());
                            newFA.AppendChild(newPM);
                            xRoot.AppendChild(newFA);
                            xDoc.Save("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\FailedAccess.xml");
                    }
                    }
                    
                
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void CheckBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Checked)
            {
                
                label3.Text = "Пароль КД";
                label3.Visible = true;
                checkBox1.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                textBox2.Visible = true;
                access_control = true;
            }
            else
            {
                label3.Visible = false;
                textBox2.Visible = false;
                checkBox3.Visible = true;
                checkBox1.Visible = true;
                checkBox4.Visible = true;
                access_control = false;
            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.CheckState == CheckState.Checked)
            {

                label3.Text = "Пароль КД";
                label3.Visible = true;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox4.Visible = false;
                textBox2.Visible = true;
                access_control = true;
            }
            else
            {
                label3.Visible = false;
                textBox2.Visible = false;
                checkBox2.Visible = true;
                checkBox1.Visible = true;
                checkBox4.Visible = true;
                access_control = false;
            }
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.CheckState == CheckState.Checked)
            {
                label3.Text = "Пользователь";
                label3.Visible = true;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                textBox2.Visible = true;
                checkBox3.Visible = false;
                user = true;
            }
            else
            {
                label3.Visible = false;
                textBox2.Visible = false;
                checkBox2.Visible = true;
                checkBox1.Visible = true;
                checkBox3.Visible = true;
                user = false;
            }
        }

    }
}
