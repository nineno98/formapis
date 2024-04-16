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
        public Form1()
        {
            InitializeComponent();
            
            
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

        private void szenhidrat_TextChanged(object sender, EventArgs e)
        {

        }

        private void hamu_TextChanged(object sender, EventArgs e)
        {

        }

        private void rost_TextChanged(object sender, EventArgs e)
        {

        }

        private void bevitel_Click(object sender, EventArgs e)
        {
            levesconn = new LevesekConnect();

            try
            {
                megneveves_ = megnevezes.Text;
                kaloria_ = Convert.ToInt32(kaloria.Text);
                feherje_ = Convert.ToDouble(kaloria.Text);
                zsir_ = Convert.ToDouble(zsir.Text);
                szenhidrat_ = Convert.ToDouble(szenhidrat.Text);
                hamu_ = Convert.ToDouble(hamu.Text);
                rost_ = Convert.ToDouble(hamu.Text);
            }
            catch (Exception e)
            {

                MessageBox.Show(e);
            }

            levesconn.InsertLeves();
        }
    }
}
