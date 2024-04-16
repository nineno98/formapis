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
            
            LevesekConnect connLevesek = new LevesekConnect();
            connLevesek.Connect();

            List<Leves> levesek = connLevesek.GetLevesek();

            foreach (Leves item in levesek)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("*** Feladatok ***");

            // 1. feladat
            Console.WriteLine("Levesek száma: "+levesek.Count());

            //2.feladat
            
            
            foreach (Leves item in levesek)
            {
                if (item.Kaloria == levesek.Select(x => x.Kaloria).Max())
                {
                    Console.WriteLine("Max kalória: " +item);
                }
            }
            //3. feladata
            foreach (Leves item in levesek)
            {
                if (!String.IsNullOrEmpty(item.Megnevezes_) && !item.Megnevezes_.Contains("leves"))
                {
                    Console.WriteLine("Nem tartalmaz 'leves' stringet: "+item);
                }
            }

            

            Console.ReadKey();
        }
    }
}
