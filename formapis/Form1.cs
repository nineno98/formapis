using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;


namespace formapis
{
    public partial class Form1 : Form
    {
        static string endPointUrl = "https://retoolapi.dev/KqpqJ9/data";

        static List<Adat> adatok = new List<Adat>();

       
         async Task restapiAdatok()
         {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, endPointUrl);
            var response = await client.SendAsync(request);

            try
            {
                response.EnsureSuccessStatusCode();
                string jsonstring = await response.Content.ReadAsStringAsync();
                adatok = Adat.FromJson(jsonstring).ToList();

            }
            catch (HttpRequestException)
            {

                throw;
            }

            

            


         }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            restapiAdatok();
            listBox1.Items.AddRange(adatok.ToArray());
            
        }

        
    }
}
