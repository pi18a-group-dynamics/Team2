using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Team2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            
            

            

            

            /*var cmd = new NpgsqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "INSERT INTO pdata(last_name, first_name, patronymic, nationality, series, number, who_gave, when_gave, place_code, place_of_birth, date_of_birth, residence, children, photo) " +
                "VALUES('Хренова', 'Гадя', 'Петрович', 'армянка', 'ТТ', '123456', 'Москва', '12/05/1999', '123', 'Мидгард', '12/10/1984', 'Ленина 33', 'no', 'path to photo')";
            cmd.ExecuteNonQuery();*/
            //String num = cmd.ExecuteScalar().ToString();



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}