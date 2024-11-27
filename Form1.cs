﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BitcoinCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currencyselector.SelectedItem == null)
            { MessageBox.Show("Vali valuuta!", "Sisestusviga", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return; };
            if (string.IsNullOrWhiteSpace(bitcoinamountinput.Text))
            {
                MessageBox.Show("Sisesta Bitcoinide arv!", "Sisestusviga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            };

            if (currencyselector.SelectedItem.ToString() == "EUR")
            {
                resultlabel.Visible = true;
                tulemuslabel.Visible = true;
                Bitcoinrates newbitcoinrate = GetRates();
                float result = float.Parse(bitcoinamountinput.Text) * (float)newbitcoinrate.Bpi.EUR.rate_float;
                resultlabel.Text = $"{result} {newbitcoinrate.Bpi.EUR.code}";
            }

            if (currencyselector.SelectedItem.ToString() == "USD")
            {
                resultlabel.Visible = true;
                tulemuslabel.Visible = true;
                Bitcoinrates newbitcoinrate = GetRates();
                float result = float.Parse(bitcoinamountinput.Text) * (float)newbitcoinrate.Bpi.USD.rate_float;
                resultlabel.Text = $"{result} {newbitcoinrate.Bpi.USD.code}";
            }

            if (currencyselector.SelectedItem.ToString() == "GBP")
            {
                resultlabel.Visible = true;
                tulemuslabel.Visible = true;
                Bitcoinrates newbitcoinrate = GetRates();
                float result = float.Parse(bitcoinamountinput.Text) * (float)newbitcoinrate.Bpi.GBP.rate_float;
                resultlabel.Text = $"{result} {newbitcoinrate.Bpi.GBP.code}";
            }

            if (currencyselector.SelectedItem.ToString() == "EEK")
            {
                resultlabel.Visible = true;
                tulemuslabel.Visible = true;
                Bitcoinrates newbitcoinrate = GetRates();
                float result = float.Parse(bitcoinamountinput.Text) * (float)(newbitcoinrate.Bpi.EUR.rate_float * 15.6466);
                resultlabel.Text = $"{result} EEK";
            }

        }

        public static Bitcoinrates GetRates()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            Bitcoinrates bitcoin;
            using (var responseReader = new StreamReader(webStream))
            {
                var data = responseReader.ReadToEnd();
                bitcoin = JsonConvert.DeserializeObject<Bitcoinrates>(data);
            }
            return bitcoin;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
