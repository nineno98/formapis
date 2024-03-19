using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ConsoleApp1;


namespace ConsoleApp1
{
    class Program
    {
        static string endPointUrl = "https://retoolapi.dev/KqpqJ9/data";

        static List<Adat> adatok = new List<Adat>();

        static void Main(string[] args)
        {
            restapiAdatok().Wait();
            foreach (Adat adat in adatok)
            {
                Console.WriteLine($"{adat.Id}. {adat.Name}, {adat.Salary}");
            }

            // 1.feladat

            Console.WriteLine(adatok.Select(x => x.Name));
            Console.WriteLine("Program vége");
            Console.ReadKey();
        }

        

        static async Task restapiAdatok()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, endPointUrl);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string jsonstring = await response.Content.ReadAsStringAsync();
            adatok = Adat.FromJson(jsonstring).ToList();


        }
    }
}
