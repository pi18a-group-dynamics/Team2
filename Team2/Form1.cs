using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;



namespace Team2
{
    public partial class Form1 : Form
        
    {
        public static String filePath = "";
        public Form1()
        {
            InitializeComponent();
            
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=Passport;";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Соединение с БД открыто");
            MessageBox.Show("Соединение с БД открыто");

            String last_name = textBox1.Text;
            String first_name = textBox2.Text;
            String patronymic = textBox3.Text;
            String nationality = textBox4.Text;
            String series = textBox5.Text;
            String number = textBox6.Text;
            String who_gave = textBox7.Text;
            String when_gave = textBox12.Text;
            String place_code = textBox8.Text;
            String place_of_birth = textBox13.Text;
            String date_of_birth = textBox9.Text;
            String residence = textBox10.Text;
            String children = textBox11.Text;

             

            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;

            MessageBox.Show(filePath);

            cmd.CommandText = $"INSERT INTO pdata(last_name, first_name, patronymic, nationality, series, number, who_gave, when_gave, place_code, place_of_birth, date_of_birth, residence, children, photo) " +
                $"VALUES('{last_name}', '{first_name}', '{patronymic}', '{nationality}', '{series}', '{number}', '{who_gave}', '{when_gave}', '{place_code}', '{place_of_birth}', '{date_of_birth}', '{residence}', '{children}', '{filePath}')";
            cmd.ExecuteNonQuery();
            




           /*

                        NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM pdata", connection);
                        NpgsqlDataReader dataReader = command.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            Console.WriteLine("Таблица: example");
                            Console.WriteLine("id value");
                            foreach (DbDataRecord dbDataRecord in dataReader)
                                MessageBox.Show(dbDataRecord["person_id"] + "   " + dbDataRecord["last_name"] + "   " + dbDataRecord["first_name"] + "   " + dbDataRecord["patronymic"] + "   " + dbDataRecord["nationality"] + "   "
                                    + dbDataRecord["series"] + "   " + dbDataRecord["number"] + "   " + dbDataRecord["who_gave"] + "   " + dbDataRecord["when_gave"] + "   " +
                                    dbDataRecord["place_code"] + "   " + dbDataRecord["place_of_birth"] + "   " + dbDataRecord["date_of_birth"] + "   " + dbDataRecord["residence"] +
                                    "   " + dbDataRecord["children"] + "   " + dbDataRecord["photo"]);
                        }
                        else
                        {
                            MessageBox.Show("Запрос не вернул строк");
                        }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = "c:\\Users\\tatbr\\Desktop\\";
            op.Filter = @"Файлы изображений|*.bmp;*.png;*.jpg";
            op.Multiselect = false;
            //op.FilterIndex = 2;
            //op.RestoreDirectory = true;

            if (op.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = op.FileName;
                pictureBox1.Image = Image.FromFile(filePath);
            }
            }
    }
}