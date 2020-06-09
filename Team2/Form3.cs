using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Team2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            XmlReader xmlReader = XmlReader.Create("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\FailedAccess.xml");
            var result_ = new List<string>();
            int id = 0;
            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Try"))
                {
                    if (xmlReader.HasAttributes)
                    {
                        string temp1 = "   " + id + ". " + xmlReader.GetAttribute("try") + ": ";
                        result_.Add(temp1);
                    }
                    id++;
                }
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Time"))
                {
                    if (xmlReader.HasAttributes)
                    {
                        string temp2 = "     " + xmlReader.GetAttribute("Time") + ";";
                        result_.Add(temp2);
                    }
                }

            }
            int lid = 0;
            foreach (var item in result_)
            {
                textBox1.Text += item;
                if (lid % 2 != 0)
                    textBox1.Text += Environment.NewLine;
                lid++;
            }
        }
        public void global_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
