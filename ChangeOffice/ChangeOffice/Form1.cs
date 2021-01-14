using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ChangeOffice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string today = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlFile = new XmlDocument();
            xmlFile.Load(today);

            string dolarBuy = xmlFile.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lbl_buy_dolar.Text = dolarBuy;

            string dolarSell = xmlFile.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lbl_sell_dolar.Text = dolarSell;


            string euroBuy = xmlFile.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lbl_buy_euro.Text = euroBuy;

            string euroSell = xmlFile.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
           lbl_sell_euro.Text = euroSell;


        }

        private void btn_buy_dollar_Click(object sender, EventArgs e)
        {
            txt_exchange_rate.Text = lbl_buy_dolar.Text;
        }

        private void btn_sell_dollar_Click(object sender, EventArgs e)
        {
            txt_exchange_rate.Text = lbl_sell_dolar.Text;
        }

        private void btn_buy_euro_Click(object sender, EventArgs e)
        {
            txt_exchange_rate.Text = lbl_buy_euro.Text;
        }

        private void btn_sell_euro_Click(object sender, EventArgs e)
        {
            txt_exchange_rate.Text = lbl_sell_euro.Text;
        }

        private void btn_buy_Click(object sender, EventArgs e)
        {
            double changeRate, quantity, amount;
            changeRate = Convert.ToDouble(txt_exchange_rate.Text);
            quantity = Convert.ToDouble(txt_quantity.Text);
            amount = quantity * changeRate;
            txt_amount.Text = amount.ToString();
        }

        private void btn_buy_all_Click(object sender, EventArgs e)
        {
            double changeRate = Convert.ToDouble(txt_exchange_rate.Text);
            double quantity = Convert.ToDouble(txt_quantity.Text);

            double amount= (quantity / changeRate);
            txt_amount.Text = amount.ToString();

            double remaining = quantity % changeRate;
            txt_remaining.Text = remaining.ToString();

            
        }
    }
}
