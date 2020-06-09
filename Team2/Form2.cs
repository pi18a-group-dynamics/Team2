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
using System.Xml.Linq;


namespace Team2
{
    public partial class Form2 : Form
    {
        //private int N = 200;
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //XmlTextReader xmlReader = new XmlTextReader("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\Access.xml");
            //while (xmlReader.Read())
            //{
            //    switch (xmlReader.NodeType)
            //    {
            //        case XmlNodeType.Element:
            //            textBox1.Text += "   " + xmlReader.Name + "   \n" ;
            //            break;
            //        case XmlNodeType.EndElement:
            //            textBox1.Text += "   \n";
            //            break;
            //    }
            //}
            XmlReader xmlReader = XmlReader.Create("C:\\Users\\User\\Desktop\\Team2-master-last\\Team2\\Access.xml");
            var result = new List<string>();
            int id = 0;
            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "log_in"))
                {
                    if (xmlReader.HasAttributes)
                    {
                        string temp1 = "   " + id + ". " + xmlReader.GetAttribute("pas") + ": ";
                        result.Add(temp1);
                    }    
                    id++;
                }
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Time"))
                {
                    if (xmlReader.HasAttributes)
                    {
                        string temp2 = "     " + xmlReader.GetAttribute("Time") + ";";
                        result.Add(temp2) ;
                    }
                }
                
            }
            int lid = 0;
            foreach (var item in result)
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
