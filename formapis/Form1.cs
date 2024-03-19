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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace formapis
{
    public partial class Form1 : Form
    {
        static string endPointUrl = "https://retoolapi.dev/KqpqJ9/data";

        static List<Adat> adatok = new List<Adat>();
        HttpClient client = new HttpClient();

        private async void restapiAdatok()
         {
            listBox1.Items.Clear();
            var request = new HttpRequestMessage(HttpMethod.Get, endPointUrl);
            var response = await client.SendAsync(request);

            try
            {
                response.EnsureSuccessStatusCode();
                string jsonstring = await response.Content.ReadAsStringAsync();
                adatok = Adat.FromJson(jsonstring).ToList();
                listBox1.Items.AddRange(adatok.ToArray());


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
            
            
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            // kiolvasás
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Nincs megadva név");
                textBox2.Focus();
                return;
            }
            long fizetes;
            if (!long.TryParse(textBox3.Text, out fizetes))
            {
                MessageBox.Show("Nem megfelelő értéket adott meg fizetésként!");
                textBox3.Focus();
                return;
            }
            // json-t készítünk
            Adat adat = new Adat();
            adat.Name = textBox2.Text;
            adat.Salary = fizetes;
            string jsondolgozo = JsonConvert.SerializeObject(adat);

            // json-string
            var data = new StringContent(jsondolgozo, Encoding.UTF8, "application/json"); // elkészíti a fejlécet

            // post request
            var response = client.PostAsync(endPointUrl, data).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Sikeres hozzáadás!");
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Sikertelen hozzáadás!");
            }
            restapiAdatok();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs Kiválasztott elem!");
                return;
            }
            Adat adat = (Adat)listBox1.SelectedItem;
            string deleteUrl = $"{endPointUrl}/{adat.Id}";

            
            var response = client.DeleteAsync(deleteUrl);

            try
            {
                response.IsCompleted();
                MessageBox.Show("Sikeres törlés!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

                restapiAdatok();


            }
            catch (HttpRequestException)
            {

                MessageBox.Show("Sikertelen törlés!");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }
            Adat adat = (Adat)listBox1.SelectedItem;
            textBox3.Text = adat.Salary.ToString();
            textBox2.Text = adat.Name;
            textBox1.Text = adat.Id.ToString();
        }
    }
}
