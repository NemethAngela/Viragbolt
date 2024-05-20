using AutosKonzolApp;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace AutosGUI
{
    public partial class Form1 : Form
    {
        List<Auto> autok = new List<Auto>(); //lista l�trehoz�sa

        public Form1()
        {
            InitializeComponent();
            FillAutokLista();
        }

        private void FillAutokLista() //lista felt�lt�se
        {
            autok = Auto.CsvtBeolvas(@"..\..\..\autok.csv");
            listBoxAutok.Items.Clear();

            foreach (var auto in autok)
            {
                listBoxAutok.Items.Add(auto);
            }

            listBoxAutok.ValueMember = "Sorszam";
            listBoxAutok.DisplayMember = "DisplayText"; //itt azok lesznek, amiket kilist�zunk
        }

        private void buttonBezar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBoxAutok_SelectedIndexChanged(object sender, EventArgs e) //kiv�lasztott aut�k a Gy�rt�si�v text-boxba
        {
            var selectedAuto = (Auto)listBoxAutok.SelectedItem;
            textBoxGyartasiEv.Text = selectedAuto.GyartasiEv.ToString();
        }

        private void listBoxAutok_MouseEnter(object sender, EventArgs e) //egeret ha kiv�lasztunk a listboxban
        {
            listBoxAutok.BackColor = Color.Red;
        }

        private void listBoxAutok_MouseLeave(object sender, EventArgs e) //legyen �jra feh�r a listbox
        {
            listBoxAutok.BackColor = Color.White;
        }

        private void buttonBetolt_Click(object sender, EventArgs e)
        {
            var selectedAuto = (Auto)listBoxAutok.SelectedItem;

            if (selectedAuto == null) return;

            textBox2.Text = selectedAuto.AtlagosEladasiAr.ToString();
        }
    }
}