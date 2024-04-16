using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;


namespace levesek_database_conn
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Leves> levesek = new List<Leves>();
            Leves leves;
            string sqlStatement;
            MySqlConnection dbConnection;
            MySqlDataReader reader;
            MySqlConnectionStringBuilder strBuild = new MySqlConnectionStringBuilder();
            strBuild.Server = "localhost";
            strBuild.UserID = "root";
            strBuild.Password = "";
            strBuild.Database = "levesek";

            dbConnection = new MySqlConnection(strBuild.ToString());
            sqlStatement = "SELECT megnevezes, kaloria, feherje, zsir, szenhidrat, hamu, rost FROM `levesek`;";

            try
            {
                dbConnection.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = dbConnection;
                command.CommandText = sqlStatement;

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    leves = new Leves(reader.GetString(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetDouble(6));
                    Console.WriteLine(reader.GetString(0) + " " + reader.GetInt32(1) + " " + reader.GetDouble(2)
                        +" "+reader.GetDouble(3)+ " "+reader.GetDouble(4)+" "
                        +reader.GetDouble(5)+" "+reader.GetDouble(6));

                    levesek.Add(leves);
                }


                Console.WriteLine("**************");

                foreach (Leves i in levesek)
                {
                    Console.WriteLine(i);
                }
                /*
                output = command.ExecuteScalar().ToString();
                Console.WriteLine(output);*/

                Console.ReadKey();

                dbConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }




        }
    }
}
