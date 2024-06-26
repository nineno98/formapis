﻿using System;
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
        int kaloria_, id_;
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
            // MessageBox.Show(selectedLeves.Id_.ToString());
            id_ = selectedLeves.Id_;
            megnevezes.Text = selectedLeves.Megnevezes_;
            kaloria.Text = selectedLeves.Kaloria.ToString();
            feherje.Text = selectedLeves.Feherje.ToString();
            zsir.Text = selectedLeves.Zsir.ToString();
            szenhidrat.Text = selectedLeves.Szenhidrat.ToString();
            hamu.Text = selectedLeves.Hamu.ToString();
            rost.Text = selectedLeves.Rost.ToString();

            DeselectButton.Enabled = true;
            bevitel.Enabled = false;
            deleteLevesButton.Enabled = true;
            updateButton.Enabled = true;

        }

        private void szenhidrat_TextChanged(object sender, EventArgs e)
        {

        }

        private void deleteLevesButton_Click(object sender, EventArgs e)
        {
            Leves levesForDeleting = (Leves)levesek_listbox.SelectedItem;

            levesconn.DeleteLeves(levesForDeleting);
            Update();
            bevitel.Enabled = true;
            updateButton.Enabled = false;
            megnevezes.Text = "";
            kaloria.Text = "";
            feherje.Text = "";
            zsir.Text = "";
            szenhidrat.Text = "";
            hamu.Text = "";
            rost.Text = "";
        }

        private void updateButton_Click(object sender, EventArgs e)
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
            leves = new Leves(id_, megneveves_, kaloria_, feherje_, zsir_, szenhidrat_, hamu_, rost_);
            levesconn.UpdateLevesek(leves);
            Update();

        }

        private void DeselectButton_Click(object sender, EventArgs e)
        {
            bevitel.Enabled = true;
            updateButton.Enabled = false;
            megnevezes.Text = "";
            kaloria.Text = "";
            feherje.Text = "";
            zsir.Text = "";
            szenhidrat.Text = "";
            hamu.Text = "";
            rost.Text = "";
            
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

            if (megnevezes.Text !="" && kaloria.Text != "" 
                && feherje.Text != "" && zsir.Text != "" && szenhidrat.Text != "" 
                && hamu.Text != "" && rost.Text != "")
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
            else
            {
                MessageBox.Show("Nem lehet mező üresen!");
            }
            

            
        }

        private void Update()
        {
            deleteLevesButton.Enabled = false;
            updateButton.Enabled = false;
            DeselectButton.Enabled = false;
            levesek_listbox.Items.Clear();
            levesekList.Clear();
            levesconn.SelectLeves();
            
            levesekList = levesconn.GetLevesek();
            
            levesek_listbox.Items.AddRange(levesekList.ToArray());
        }
    }
}
