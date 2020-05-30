﻿using System;
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

//create table pdata(person_id serial NOT NULL,first_name character varying(20) NOT NULL,patronymic character varying(20) NOT NULL,series character varying(2) NOT NULL,who_gave character varying(30) NOT NULL,when_gave character varying(30),date_of_birth date NOT NULL,children character varying(100),photo character varying(100),residence character varying(30),place_of_birth character varying(30) NOT NULL,"number" character varying(6) NOT NULL,nationality character varying(20) NOT NULL,last_name character varying(20) NOT NULL,place_code character varying(10),PRIMARY KEY (person_id)); 


namespace Team2
{
    public partial class Form1 : Form
        
    {
        public static String filePath = "";
        public static String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=passport;";
        public NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        
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

        private void button2_Click(object sender, EventArgs e) // добавление данных 
        {
   
            connection.Open();
             
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
            



           // рабочий SELECT (Илья, для поиска пригодится)

           /* NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM pdata", connection);
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
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e) // это выбор картинки
        {
            
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = "c:\\Users\\tatbr\\Desktop\\";
            op.Filter = @"Файлы изображений|*.bmp;*.png;*.jpg";
            op.Multiselect = false;

            if (op.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = op.FileName;
                pictureBox1.Image = Image.FromFile(filePath);
            }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();

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


            if(number != "" && series != ""){
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM pdata WHERE number = '"+number+"' and series = '"+series+"';", connection);
                NpgsqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in dataReader)
                    {
                        textBox1.Text = dbDataRecord["last_name"].ToString();
                        textBox2.Text = dbDataRecord["first_name"].ToString();
                        textBox3.Text = dbDataRecord["patronymic"].ToString();
                        textBox4.Text = dbDataRecord["nationality"].ToString();
                        textBox7.Text = dbDataRecord["who_gave"].ToString();
                        textBox12.Text = dbDataRecord["when_gave"].ToString();
                        textBox8.Text = dbDataRecord["place_code"].ToString();
                        textBox13.Text = dbDataRecord["place_of_birth"].ToString();
                        textBox9.Text = dbDataRecord["date_of_birth"].ToString();
                        textBox10.Text = dbDataRecord["residence"].ToString();
                        textBox11.Text = dbDataRecord["children"].ToString();
                        pictureBox1.Image = Image.FromFile(dbDataRecord["photo"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Гражданина не существует");
                }
            }
            else
            {
                String whereCommand = "";

                if (textBox2.Text != "")
                {
                    if(whereCommand != "")
                    {
                        whereCommand = whereCommand + " and ";
                    }
                    whereCommand = whereCommand + "first_name = '" + first_name + "'";
                }
                if (textBox1.Text != "")
                {
                    if (whereCommand != "")
                    {
                        whereCommand = whereCommand + " and ";
                    }
                    whereCommand = whereCommand + "last_name = '" + last_name + "'";
                }
                if (textBox3.Text != "")
                {
                    if (whereCommand != "")
                    {
                        whereCommand = whereCommand + " and ";
                    }
                    whereCommand = whereCommand + "patronymic = '" + patronymic + "'";
                }
                if (textBox4.Text != "")
                {
                    if (whereCommand != "")
                    {
                        whereCommand = whereCommand + " and ";
                    }
                    whereCommand = whereCommand + "nationality = '" + nationality + "'";
                }
                if (textBox5.Text != "")
                {
                    if (whereCommand != "")
                    {
                        whereCommand = whereCommand + " and ";
                    }
                    whereCommand = whereCommand + "series = '" + series + "'";
                }
                if (textBox6.Text != "")
                {
                    if (whereCommand != "")
                    {
                        whereCommand = whereCommand + " and ";
                    }
                    whereCommand = whereCommand + "number = '" + number + "'";
                }
                if (textBox7.Text != "")
                {
                    if (whereCommand != "")
                    {
                        whereCommand = whereCommand + " and ";
                    }
                    whereCommand = whereCommand + "who_gave = '" + who_gave + "'";
                }
                if (textBox12.Text != "")
                {
                    if (whereCommand != "")
                    {
                        whereCommand = whereCommand + " and ";
                    }
                    whereCommand = whereCommand + "when_gave = '" + when_gave + "'";
                }
                if (textBox8.Text != "")
                {
                    if (whereCommand != "")
                    {
                        whereCommand = whereCommand + " and ";
                    }
                    whereCommand = whereCommand + "place_code = '" + place_code + "'";
                }
                if (textBox13.Text != "")
                {
                    if (whereCommand != "")
                    {
                        whereCommand = whereCommand + " and ";
                    }
                    whereCommand = whereCommand + "place_of_birth = '" + place_of_birth + "'";
                }
                if (textBox9.Text != "")
                {
                    if (whereCommand != "")
                    {
                        whereCommand = whereCommand + " and ";
                    }
                    whereCommand = whereCommand + "date_of_birth = '" + date_of_birth + "'";
                }
                if (textBox10.Text != "")
                {
                    if (whereCommand != "")
                    {
                        whereCommand = whereCommand + " and ";
                    }
                    whereCommand = whereCommand + "residence = '" + residence + "'";
                }
                if (textBox11.Text != "")
                {
                    if (whereCommand != "")
                    {
                        whereCommand = whereCommand + " and ";
                    }
                    whereCommand = whereCommand + "children = '" + children + "'";
                }
                if (filePath != "")
                {
                    if (whereCommand != "")
                    {
                        whereCommand = whereCommand + " and ";
                    }
                    whereCommand = whereCommand + "photo = '" + filePath + "'";
                }
                if (whereCommand != "")
                {
                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM pdata WHERE " + whereCommand +";" , connection);
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
                        MessageBox.Show("Соотвествия не найдены");
                    }
                }

            }

            connection.Close();

            /*
            // вообще тут будет поиск, но              
            
            //так будет работать удаление:

             connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("DELETE FROM pdata WHERE person_id = 5 and last_name = 'Гончаров'", connection);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            connection.Close();
            */
        }
    }
}
