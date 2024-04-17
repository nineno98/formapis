using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using insert_leves;

namespace insert_leves
{
    public partial class Form1 : Form
    {
        Leves leves;
        LevesekConnect levesconn;
        string megneveves_;
        int kaloria_;
        double feherje_, zsir_, szenhidrat_, hamu_, rost_;
        List<Leves> levesekList = new List<Leves>();
        public Form1()
        {
            InitializeComponent();
            levesconn = new LevesekConnect();
            Update();

        }

        private void megnevezes_TextChanged(object sender, EventArgs e)
        {

        }

        private void kaloria_TextChanged(object sender, EventArgs e)
        {

        }

        private void feherje_TextChanged(object sender, EventArgs e)
        {

        }

        private void zsir_TextChanged(object sender, EventArgs e)
        {

        }

        private void levesek_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Leves selectedLeves = (Leves)levesek_listbox.SelectedItem;

        }

        private void szenhidrat_TextChanged(object sender, EventArgs e)
        {

        }

        private void deleteLevesButton_Click(object sender, EventArgs e)
        {
            Leves levesForDeleting = (Leves)levesek_listbox.SelectedItem;

            levesconn.DeleteLeves(levesForDeleting);
            Update();
        }

        private void hamu_TextChanged(object sender, EventArgs e)
        {

        }

        private void rost_TextChanged(object sender, EventArgs e)
        {

        }

        private void bevitel_Click(object sender, EventArgs e)
        {
            

            try
            {
                megneveves_ = megnevezes.Text;
                megnevezes.Text = "";
                kaloria_ = Convert.ToInt32(kaloria.Text);
                kaloria.Text = "";
                feherje_ = Convert.ToDouble(feherje.Text);
                feherje.Text = "";
                zsir_ = Convert.ToDouble(zsir.Text);
                zsir.Text = "";
                szenhidrat_ = Convert.ToDouble(szenhidrat.Text);
                szenhidrat.Text = "";
                hamu_ = Convert.ToDouble(hamu.Text);
                hamu.Text = "";
                rost_ = Convert.ToDouble(rost.Text);
                rost.Text = "";
                leves = new Leves(megneveves_, kaloria_, feherje_, zsir_, szenhidrat_, hamu_, rost_);
                levesconn.InsertLeves(leves);
                Update();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.ToString());
            }

            
        }

        private void Update()
        {
            levesconn.SelectLeves();
            
            levesekList = levesconn.GetLevesek();
            levesek_listbox.Items.Clear();
            levesek_listbox.Items.AddRange(levesekList.ToArray());
        }
    }
}
