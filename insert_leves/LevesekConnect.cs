using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows.Forms;

namespace insert_leves
{
    class LevesekConnect
    {
        List<Leves> levesek = new List<Leves>();
        Leves leves;
        string sqlStatement;
        MySqlConnection dbConnection;
        MySqlDataReader reader;
        public LevesekConnect()
        {
            
            MySqlConnectionStringBuilder strBuild = new MySqlConnectionStringBuilder();
            strBuild.Server = "localhost";
            strBuild.UserID = "root";
            strBuild.Password = "";
            strBuild.Database = "levesek";

            dbConnection = new MySqlConnection(strBuild.ToString());
            
        }
        public void SelectLeves()
        {
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


                    levesek.Add(leves);
                }
                
                dbConnection.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Hiba a kapcsolatban.");
            }
        }

        public List<Leves> GetLevesek()
        {
            return levesek;
        }

        public void InsertLeves(Leves leves)
        {
            sqlStatement = $"INSERT INTO `levesek`(`megnevezes`, `kaloria`, `feherje`, `zsir`, `szenhidrat`, `hamu`, `rost`) VALUES "
                +$"('{leves.Megnevezes_}','{leves.Kaloria}','{leves.Feherje}','{leves.Zsir}','{leves.Szenhidrat}','{leves.Hamu}','{leves.Rost}');";

            try
            {
                dbConnection.Open();
                levesek.Clear();
                MySqlCommand command = new MySqlCommand();
                command.Connection = dbConnection;
                command.CommandText = sqlStatement;

                command.ExecuteNonQuery();
                MessageBox.Show("Leves sikeresen hozzáadva.");

                dbConnection.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Hiba a kapcsolatban.");
            }
        }

        public void DeleteLeves(Leves leves)
        {
            sqlStatement = $"DELETE FROM `levesek` " +
                $"WHERE `megnevezes` = '{leves.Megnevezes_}' " +
                $"and `kaloria` = '{leves.Kaloria}' " +
                $"and `feherje` = '{leves.Feherje}' " +
                $"and `zsir` = '{leves.Zsir}' " +
                $"and `szenhidrat` = '{leves.Szenhidrat}' " +
                $"and `hamu` = '{leves.Hamu}' " +
                $"and `rost` = '{leves.Rost}';";

            try
            {
                dbConnection.Open();
                levesek.Clear();
                MySqlCommand command = new MySqlCommand();
                command.Connection= dbConnection;
                command.CommandText = sqlStatement;

                command.ExecuteNonQuery();
                MessageBox.Show("Sikeresen törölve.");

                dbConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
