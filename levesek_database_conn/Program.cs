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
            string sqlStatement, output;
            MySqlConnection dbConnection;

            MySqlConnectionStringBuilder strBuild = new MySqlConnectionStringBuilder();
            strBuild.Server = "localhost";

            strBuild.UserID = "root";
            strBuild.Password = "";
            strBuild.Database = "levesek";

            dbConnection = new MySqlConnection(strBuild.ToString());
            sqlStatement = "SELECT version();";

            try
            {
                dbConnection.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = dbConnection;
                command.CommandText = sqlStatement;

                output = command.ExecuteScalar().ToString();
                Console.WriteLine(output);
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
